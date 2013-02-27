Public Class ClientForm

    'For ShowWindow
    Private Const SW_HIDE As Integer = 0        'Hides the window and activates another window.
    Private Const SW_SHOWNORMAL As Integer = 1  'Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
    Private Const SW_SHOW As Integer = 5        'Activates the window and displays it in its current size and position.
    Private Const SW_SHOWNA As Integer = 8      'Displays the window in its current state. The active window remains active.

    'For SetWindowPos
    Private Const SWP_DRAWFRAME As Integer = &H20      'Draws a frame (defined in the window's class description) around the window. This value is not supported in Windows CE 1.0 and 1.01. 
    Private Const SWP_FRAMECHANGED As Integer = &H20   'Causes the operating system to recalculate the size and position of the windows client area, even if the window size is not being changed. If this flag is not specified, the client area is recalculated only when the size or position of the window changes. 
    Private Const SWP_HIDEWINDOW As Integer = &H80     'Hides the window. 
    Private Const SWP_NOACTIVATE As Integer = &H10     'Does not activate the window. If this flag is not set, the window is activated and moved to the top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter parameter). 
    Private Const SWP_NOCOPYBITS As Integer = &H100    'Discards the entire contents of the client area. If this flag is not specified, the valid contents of the client area are saved and copied back into the client area after the window is sized or repositioned. This value is not supported in Windows CE 2.10 and later. 
    Private Const SWP_NOMOVE As Integer = &H2          'Retains the current position (ignores the X and Y parameters). 
    Private Const SWP_NOOWNERZORDER As Integer = &H200 'Does not change the owner window's position in the z-order. 
    Private Const SWP_NOREPOSITION As Integer = &H200  'Same as the SWP_NOOWNERZORDER flag. 
    Private Const SWP_NOSIZE As Integer = &H1          'Retains the current size (ignores the cx and cy parameters). 
    Private Const SWP_NOZORDER As Integer = &H4        'Retains the current z-order (ignores the hWndInsertAfter parameter). 
    Private Const SWP_SHOWWINDOW As Integer = &H40     'Displays the window. 

    Private Const GWL_STYLE As Long = -16
    Private Const WS_CAPTION As Long = &HC00000
    Private Const WS_THICKFRAME As Long = &H40000
    Private Const WS_DLGFRAME As Long = &H400000
    Private Const WS_BORDER As Long = &H800000

    Private Const HWND_TOP As Integer = 0           'Places the window at the top of the z-order. 
    Private Const HWND_BOTTOM As Integer = 1        'Places the window at the bottom of the z-order. If the hWnd parameter identifies a topmost window, the window loses its topmost status and is placed at the bottom of all other windows. 
    Private Const HWND_TOPMOST As Integer = -1      'Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated. This value is not supported in Windows CE 1.0 and 1.01. 
    Private Const HWND_NOTOPMOST As Integer = -2    'Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no effect if the window is already a non-topmost window. This value is not supported in Windows CE 1.0 and 1.01.  

    Declare Function ShowWindow Lib "user32" (ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
    Declare Function SetParent Lib "user32" (ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As System.IntPtr
    Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As IntPtr) As Integer
    Declare Function SetWindowPos Lib "user32" (ByVal hwnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal HWnd As Integer, ByVal nIndex As Integer) As Integer
    Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal HWnd As Integer, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer

    Private WithEvents ChildProcess As Process
    Private ChildProcessEnded As Boolean

    Public Sub New(ByVal AppName As String, ByVal AppTag As String, ByVal Parent As Form)

        'Initialize the base class
        InitializeComponent()

        CheckForIllegalCrossThreadCalls = False

        Me.MdiParent = Parent
        'Me.WindowState = FormWindowState.Maximized

        'Create a new process
        ChildProcess = New System.Diagnostics.Process
        With ChildProcess

            If InStr(AppTag, ".dbr") Then
                .StartInfo.FileName = "dbr.exe"
                .StartInfo.Arguments = AppTag
            Else
                .StartInfo.FileName = AppTag
            End If
            .StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            .EnableRaisingEvents = True
            .Start()


            'System.Threading.Thread.Sleep(200)

            .WaitForInputIdle()

            RemoveWindowFrame(CLng(.MainWindowHandle))

            'Show the child processes application window in normal "mode"
            ShowWindow(.MainWindowHandle, 1)

            'Slave the child applicastion onto this MDI window
            SetParent(.MainWindowHandle, Me.Handle)

            'Resize the app window to the MDI container
            SizeClientToMdiContainer()

            Me.Text = AppName

        End With

        Me.Height = Me.Height

    End Sub

    Private Sub ClientForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Not IsNothing(ChildProcess) Then
            SizeClientToMdiContainer()
        End If
    End Sub

    Private Sub SizeClientToMdiContainer()
        'The MDI form was resized, resize the child process window
        Dim Rect As Rectangle = Me.ClientRectangle
        SetWindowPos(ChildProcess.MainWindowHandle, Me.Handle, 0, 0, Rect.Width, Rect.Height, SWP_FRAMECHANGED Or SWP_NOZORDER)
        'SetWindowPos(ChildProcess.MainWindowHandle, HWND_TOPMOST, 0, 0, Rect.Width, Rect.Height, SWP_FRAMECHANGED)
    End Sub

    Private Sub ClientForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not ChildProcessEnded Then
            ChildProcess.CloseMainWindow()
            While Not ChildProcess.HasExited
                ChildProcess.WaitForExit(100)
            End While
        End If
    End Sub

    Private Sub ChildProcessExited(ByVal Sender As Object, ByVal e As System.EventArgs) Handles ChildProcess.Exited
        ChildProcessEnded = True
        Me.Close()
    End Sub

    Private Sub RemoveWindowFrame(ByVal HWnd As Long)

        SetWindowLong(HWnd, GWL_STYLE, GetWindowLong(HWnd, GWL_STYLE) And Not (WS_CAPTION Or WS_THICKFRAME Or WS_DLGFRAME Or WS_BORDER))
        'SetWindowPos(HWnd, 0, 0, 0, 0, 0, SWP_FRAMECHANGED Or SWP_NOMOVE Or SWP_NOZORDER Or SWP_NOSIZE)
        SetWindowPos(HWnd, 0, 0, 0, 0, 0, SWP_FRAMECHANGED)

    End Sub

    Private Sub ClientForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class