//*****************************************************************************
//
//      Class:          MainWindow
//      Namespace:      Kerr.IconBrowser
//      Date created:   22 November 2001
//      Copyright:      © Kenny Kerr 2001 (mailto:kennykerr@hotmail.com)
//
//*****************************************************************************

using System;
using System.Diagnostics;
using System.Drawing;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

using Kerr.Resources;

namespace Kerr.IconBrowser
{
	/// <summary>
	/// The MainWindow class provides the user-interface for the Icon Browser 
	/// application. It was generated using the Forms Designer so keep that in
	/// mind when modifying this class.
	/// </summary>
	public class MainWindow : System.Windows.Forms.Form
	{
        private System.Windows.Forms.ImageList m_imageList;
        private System.Windows.Forms.SaveFileDialog m_saveFileDialog;
        private System.Windows.Forms.OpenFileDialog m_openFileDialog;
        private System.Windows.Forms.Button m_browse;
        private System.Windows.Forms.TextBox m_filename;
        private System.Windows.Forms.Button m_ok;
        private System.Windows.Forms.Button m_export;
        private System.Windows.Forms.ListView m_list;
        private System.Windows.Forms.Panel m_toolBarPanel;
        private System.Windows.Forms.Panel m_listPanel;
        private System.Windows.Forms.ContextMenu m_contextMenu;
        private System.Windows.Forms.MenuItem m_exportMenuItem;
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
		public MainWindow()
		{
			InitializeComponent();

            Assembly assembly = Assembly.GetExecutingAssembly();
            
            IntPtr hIcon = WindowsAPI.ExtractIcon(IntPtr.Zero,
                                                  assembly.Location,
                                                  0);

            if (IntPtr.Zero != hIcon)
            {
                Icon = Icon.FromHandle(hIcon);
            }
		}

        /// <summary>
        /// Releases the unmanaged resources used by the MainWindow and 
        /// optionally releases the managed resources.
        /// </summary>
		protected override void Dispose( bool bDisposing )
		{
			if (bDisposing)
			{
				if (null != components) 
				{
					components.Dispose();
				}
			}

			base.Dispose(bDisposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.m_filename = new System.Windows.Forms.TextBox();
            this.m_browse = new System.Windows.Forms.Button();
            this.m_ok = new System.Windows.Forms.Button();
            this.m_list = new System.Windows.Forms.ListView();
            this.m_contextMenu = new System.Windows.Forms.ContextMenu();
            this.m_exportMenuItem = new System.Windows.Forms.MenuItem();
            this.m_imageList = new System.Windows.Forms.ImageList(this.components);
            this.m_toolBarPanel = new System.Windows.Forms.Panel();
            this.m_export = new System.Windows.Forms.Button();
            this.m_listPanel = new System.Windows.Forms.Panel();
            this.m_openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.m_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.m_toolBarPanel.SuspendLayout();
            this.m_listPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_filename
            // 
            this.m_filename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_filename.Location = new System.Drawing.Point(88, 10);
            this.m_filename.Name = "m_filename";
            this.m_filename.Size = new System.Drawing.Size(224, 21);
            this.m_filename.TabIndex = 1;
            this.m_filename.TextChanged += new System.EventHandler(this.FileNameChangedEventHandler);
            // 
            // m_browse
            // 
            this.m_browse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_browse.Location = new System.Drawing.Point(8, 8);
            this.m_browse.Name = "m_browse";
            this.m_browse.Size = new System.Drawing.Size(72, 24);
            this.m_browse.TabIndex = 0;
            this.m_browse.Text = "&Browse...";
            this.m_browse.Click += new System.EventHandler(this.BrowseEventHandler);
            // 
            // m_ok
            // 
            this.m_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ok.Enabled = false;
            this.m_ok.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_ok.Location = new System.Drawing.Point(320, 8);
            this.m_ok.Name = "m_ok";
            this.m_ok.Size = new System.Drawing.Size(32, 24);
            this.m_ok.TabIndex = 2;
            this.m_ok.Text = "&Go";
            this.m_ok.Click += new System.EventHandler(this.OkEventHandler);
            // 
            // m_list
            // 
            this.m_list.ContextMenu = this.m_contextMenu;
            this.m_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_list.HideSelection = false;
            this.m_list.LargeImageList = this.m_imageList;
            this.m_list.Location = new System.Drawing.Point(0, 0);
            this.m_list.MultiSelect = false;
            this.m_list.Name = "m_list";
            this.m_list.Size = new System.Drawing.Size(464, 366);
            this.m_list.TabIndex = 0;
            this.m_list.UseCompatibleStateImageBehavior = false;
            this.m_list.SelectedIndexChanged += new System.EventHandler(this.SelectionChangedEventHandler);
            // 
            // m_contextMenu
            // 
            this.m_contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_exportMenuItem});
            this.m_contextMenu.Popup += new System.EventHandler(this.ContextMenuPopupEventHandler);
            // 
            // m_exportMenuItem
            // 
            this.m_exportMenuItem.Index = 0;
            this.m_exportMenuItem.Text = "&Export Icon";
            this.m_exportMenuItem.Click += new System.EventHandler(this.ExportEventHandler);
            // 
            // m_imageList
            // 
            this.m_imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.m_imageList.ImageSize = new System.Drawing.Size(32, 32);
            this.m_imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // m_toolBarPanel
            // 
            this.m_toolBarPanel.Controls.Add(this.m_export);
            this.m_toolBarPanel.Controls.Add(this.m_filename);
            this.m_toolBarPanel.Controls.Add(this.m_browse);
            this.m_toolBarPanel.Controls.Add(this.m_ok);
            this.m_toolBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_toolBarPanel.Location = new System.Drawing.Point(0, 0);
            this.m_toolBarPanel.Name = "m_toolBarPanel";
            this.m_toolBarPanel.Size = new System.Drawing.Size(464, 40);
            this.m_toolBarPanel.TabIndex = 0;
            // 
            // m_export
            // 
            this.m_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_export.Enabled = false;
            this.m_export.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_export.Location = new System.Drawing.Point(368, 8);
            this.m_export.Name = "m_export";
            this.m_export.Size = new System.Drawing.Size(88, 24);
            this.m_export.TabIndex = 3;
            this.m_export.Text = "&Export Icon...";
            this.m_export.Click += new System.EventHandler(this.ExportEventHandler);
            // 
            // m_listPanel
            // 
            this.m_listPanel.Controls.Add(this.m_list);
            this.m_listPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_listPanel.Location = new System.Drawing.Point(0, 40);
            this.m_listPanel.Name = "m_listPanel";
            this.m_listPanel.Size = new System.Drawing.Size(464, 366);
            this.m_listPanel.TabIndex = 5;
            // 
            // m_openFileDialog
            // 
            this.m_openFileDialog.Filter = "Icon Resource Files (*.exe;*.dll)|*.exe;*.dll|All Files (*.*)|*.*";
            this.m_openFileDialog.Title = "Choose a File";
            // 
            // m_saveFileDialog
            // 
            this.m_saveFileDialog.DefaultExt = "ico";
            this.m_saveFileDialog.Filter = "Icon Files (*.ico)|*.ico|All Files (*.*)|*.*";
            this.m_saveFileDialog.Title = "Save Icon As";
            // 
            // MainWindow
            // 
            this.AcceptButton = this.m_ok;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(464, 406);
            this.Controls.Add(this.m_listPanel);
            this.Controls.Add(this.m_toolBarPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Icon Browser 1.0 by Kenny Kerr";
            this.m_toolBarPanel.ResumeLayout(false);
            this.m_toolBarPanel.PerformLayout();
            this.m_listPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainWindow());
		}

        /// <summary>
        /// Displays the Open File dialog box, allowing the user to choose a 
        /// resource file to search for icons.
        /// </summary>
        private void BrowseEventHandler(object sender, System.EventArgs e)
        {
            if (DialogResult.OK == m_openFileDialog.ShowDialog())
            {
                m_filename.Text = m_openFileDialog.FileName;
                m_filename.Focus();
            }
        }

        /// <summary>
        /// Enables the OK button if the edit control contains some text, 
        /// hopefully a file name...
        /// </summary>
        private void FileNameChangedEventHandler(object sender, System.EventArgs e)
        {
            m_ok.Enabled = (0 < m_filename.TextLength);
        }

        /// <summary>
        /// Searches the user-supplied file for icon resources and adds any 
        /// that are found to the list.
        /// </summary>
        private void OkEventHandler(object sender, System.EventArgs args)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    // Load the selected library and populate the list view 
                    // with any icons that are found.

                    using (Library library = new Library(m_filename.Text,
                                                         WindowsAPI.LOAD_LIBRARY_AS_DATAFILE))
                    {
                        m_list.Clear();
                        m_imageList.Images.Clear();

                        library.EnumResourceNames(WindowsAPI.RT_GROUP_ICON,
                                                  new WindowsAPI.EnumResNameProc(AddIconToList),
                                                  IntPtr.Zero);
                    }

                    // If icons were found the select the first icon, 
                    // otherwise notify the user that we couldn't find any.

                    if (0 < m_list.Items.Count)
                    {
                        m_list.Focus();
                        m_list.Items[0].Selected = true;
                    }
                    else
                    {
                        MessageBox.Show(this, 
                                        "The specified file does not contain any icons.", 
                                        "Icon Browser", 
                                        MessageBoxButtons.OK, 
                                        MessageBoxIcon.Information);
                    }
                }
                catch (Win32Exception e)
                {
                    // If the message contains an insert marker, its probably 
                    // looking for the file name. So we resolve it and then rethrow
                    // the exception. Although this isn't 100% foolproof its better
                    // than letting the user see "%1" in the most common case.

                    string strMessage = e.Message.Replace("%1", m_filename.Text);

                    throw new Exception(strMessage, e);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, 
                                "Failed to extract any icons from the specified file.\n\n" + e.Message, 
                                "Icon Browser", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            UpdateExportButton();
        }

        /// <summary>
        /// Enables the Export button if the user has select an icon.
        /// </summary>
        private void SelectionChangedEventHandler(object sender, System.EventArgs e)
        {
            UpdateExportButton();
        }

        /// <summary>
        /// Displays the Save As dialog box, allowing the user to indicate 
        /// where to save the .ICO file. Then it writes the icon to the chosen
        /// file.
        /// </summary>
        private void ExportEventHandler(object sender, System.EventArgs e)
        {
            Debug.Assert(1 == m_list.SelectedItems.Count);

            IconItem item = (IconItem) m_list.SelectedItems[0];
            m_saveFileDialog.FileName = item.Text + ".ico";

            if (DialogResult.OK == m_saveFileDialog.ShowDialog(this))
            {
                item.IconResource.Save(m_saveFileDialog.FileName);
            }
        }

        /// <summary>
        /// Shows the context menu if the user clicked on an icon.
        /// </summary>
        private void ContextMenuPopupEventHandler(object sender, System.EventArgs e)
        {
            m_exportMenuItem.Visible = (1 == m_list.SelectedItems.Count);
        }

        /// <summary>
        /// This is the callback that gets called for any icon resources that 
        /// are found. Create an IconResource object to represent it and an 
        /// item to the list.
        /// </summary>
        private bool AddIconToList(IntPtr hModule,
                                   IntPtr pType,
                                   IntPtr pName,
                                   IntPtr param)
        {
            try
            {
                Library library = new Library(hModule, false);
                IconResource iconResource = new IconResource(library, pName);
                
                m_imageList.Images.Add(library.LoadIcon(pName));

                int iImageIndex = m_imageList.Images.Count - 1;
                m_list.Items.Add(new IconItem(iconResource, iImageIndex));
            }
            catch (Win32Exception e)
            {
                // We simply suppress any failure in loading an icon resource.
                // In this way Icon Browser will still be able to display other
                // icons that may have loaded successfully.

                Debug.WriteLine("Failed to load an icon: " + e.Message + " (" + e.NativeErrorCode + ")");
            }

            return true;
        }

        /// <summary>
        /// Enables the Export button if the user has select an icon.
        /// </summary>
        private void UpdateExportButton()
        {
            m_export.Enabled = (1 == m_list.SelectedItems.Count);
        }
	}

    /// <summary>
    /// ListViewItem-derived class to represent an IconResource.
    /// </summary>
    internal class IconItem : ListViewItem
    {
        public IconItem(IconResource iconResource,
                        int iImageIndex)
        {
            m_iconResource = iconResource;
            ImageIndex = iImageIndex;

            Text = iconResource.Text;
        }

        public IconResource IconResource
        {
            get
            {
                return m_iconResource;
            }
        }

        private IconResource m_iconResource;
    }

}
