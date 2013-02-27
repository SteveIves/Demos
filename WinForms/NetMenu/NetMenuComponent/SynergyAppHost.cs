using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SynPSG.Examples.NetMenu
{
    internal partial class SynergyAppHost : Form
    {

        //For ShowWindow
        private const int SW_HIDE = 0;              //Hides the window and activates another window.
        private const int SW_SHOWNORMAL = 1;        //Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
        private const int SW_SHOW = 5;              //Activates the window and displays it in its current size and position.
        private const int SW_SHOWNA = 8;            //Displays the window in its current state. The active window remains active.

        //For SetWindowPos
        private const int SWP_DRAWFRAME = 0x20;      //Draws a frame (defined in the windows class description) around the window. This value is not supported in Windows CE 1.0 and 1.01. 
        private const uint SWP_FRAMECHANGED = 0x20;   //Causes the operating system to recalculate the size and position of the windows client area, even if the window size is not being changed. If this flag is not specified, the client area is recalculated only when the size or position of the window changes. 
        private const int SWP_HIDEWINDOW = 0x80;     //Hides the window. 
        private const int SWP_NOACTIVATE = 0x10;     //Does not activate the window. If this flag is not set, the window is activated and moved to the top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter parameter). 
        private const int SWP_NOCOPYBITS = 0x100;    //Discards the entire contents of the client area. If this flag is not specified, the valid contents of the client area are saved and copied back into the client area after the window is sized or repositioned. This value is not supported in Windows CE 2.10 and later. 
        private const int SWP_NOMOVE = 0x2;          //Retains the current position (ignores the X and Y parameters). 
        private const int SWP_NOOWNERZORDER = 0x200; //Does not change the owner windows position in the z-order. 
        private const int SWP_NOREPOSITION = 0x200;  //Same as the SWP_NOOWNERZORDER flag. 
        private const int SWP_NOSIZE = 0x1;          //Retains the current size (ignores the cx and cy parameters). 
        private const int SWP_NOZORDER = 0x4;        //Retains the current z-order (ignores the hWndInsertAfter parameter). 
        private const int SWP_SHOWWINDOW = 0x40;     //Displays the window. 

        private const int GWL_STYLE = -16;
        private const int WS_CAPTION = 0xC00000;
        private const int WS_THICKFRAME = 0x40000;
        private const int WS_DLGFRAME = 0x400000;
        private const int WS_BORDER = 0x800000;

        private const int HWND_TOP = 0;             //Places the window at the top of the z-order. 
        private const int HWND_BOTTOM = 1;          //Places the window at the bottom of the z-order. If the hWnd parameter identifies a topmost window, the window loses its topmost status and is placed at the bottom of all other windows. 
        private const int HWND_TOPMOST = -1;        //Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated. This value is not supported in Windows CE 1.0 and 1.01. 
        private const int HWND_NOTOPMOST = -2;      //Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no effect if the window is already a non-topmost window. This value is not supported in Windows CE 1.0 and 1.01.  

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        private System.Diagnostics.Process ChildProcess;
        private bool ChildProcessEnded=false;

        public SynergyAppHost(ref MenuItemInfo ItemInfo, Form Parent, string DbrSpec)
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            this.MdiParent = Parent;
            //this.WindowState = FormWindowState.Maximized;

            //Create a new process
            ChildProcess = new System.Diagnostics.Process();
            ChildProcess.Exited += ChildProcessExited;

            switch (ItemInfo.ItemType)
            {
                case MenuItemType.Program:
                    if (ItemInfo.ActivationCommand.ToLower().Contains(".dbr"))
                    {
                        ChildProcess.StartInfo.FileName = DbrSpec;
                        ChildProcess.StartInfo.Arguments = ItemInfo.ActivationCommand;
                    }
                    else
                        ChildProcess.StartInfo.FileName = ItemInfo.ActivationCommand;
                    break;
                case MenuItemType.Subroutine:
                    ChildProcess.StartInfo.FileName = DbrSpec;
                    ChildProcess.StartInfo.Arguments = "EXE:runsubroutine " + ItemInfo.ActivationCommand;
                    break;
            }
            
            ChildProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ChildProcess.EnableRaisingEvents = true;

            try
            {
                ChildProcess.Start();

                //System.Threading.Thread.Sleep(200);

                ChildProcess.WaitForInputIdle();
                RemoveWindowFrame(ChildProcess.MainWindowHandle);

                //Show the child processes application window in normal "mode"
                ShowWindow(ChildProcess.MainWindowHandle, 1);

                //Slave the child applicastion onto this MDI window
                SetParent(ChildProcess.MainWindowHandle, this.Handle);

                //Resize the app window to the MDI container
                SizeClientToMdiContainer();

                //Set the window title
                this.Text = ItemInfo.Description;
                this.Height = this.Height;  //??????
            }
            catch
            {
                MessageBox.Show(this, "Failed to launch " + ChildProcess.StartInfo.FileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChildProcess.Dispose();
                ChildProcess = null;
                this.Close();
            }
        }

        private void frmSynergyAppHost_Resize(object sender, EventArgs e)
        {
            if (ChildProcess != null)
            {
                SizeClientToMdiContainer();
            }
        }

        private void SizeClientToMdiContainer()
        {
            //The MDI form was resized, resize the child process window
            Rectangle Rect = this.ClientRectangle;
            SetWindowPos(ChildProcess.MainWindowHandle, this.Handle, 0, 0, Rect.Width, Rect.Height, SWP_FRAMECHANGED | SWP_NOZORDER);
        }

        private void frmSynergyAppHost_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((ChildProcess!=null)&&(!ChildProcessEnded))
            {
                ChildProcess.CloseMainWindow();
                while (!ChildProcess.HasExited)
                {
                    ChildProcess.WaitForExit(100);
                }
            }
        }

        private void ChildProcessExited(Object Sender, System.EventArgs e)
        {
            ChildProcessEnded = true;
            this.Close();
        }

        private void RemoveWindowFrame(IntPtr HWnd)
        {
            SetWindowLong(HWnd, GWL_STYLE, new IntPtr(GetWindowLong(HWnd, GWL_STYLE) ^ (WS_CAPTION | WS_THICKFRAME | WS_DLGFRAME | WS_BORDER)));
            SetWindowPos(HWnd, (IntPtr)0, 0, 0, 0, 0, SWP_FRAMECHANGED);
        }

    }
}
