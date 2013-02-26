using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Liquid;
using System.Windows.Interop;
using System.Runtime.InteropServices.Automation;

namespace LocalFileBrowser
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            if (App.Current.HasElevatedPermissions)
            {
                oob.Visibility = Visibility.Visible;
                fileTree.Visibility = Visibility.Visible;
                fileTree.BuildRoot();
            }
            else
            {
                inBrowser.Visibility = Visibility.Visible;
            }
        }

        #region Private Methods

        private void PopulateFileSelector()
        {
            PopulateFileSelector(fileTree.Selected.ID);
        }

        private void PopulateFileSelector(string path)
        {
            try
            {
                var folders = Directory.EnumerateDirectories(path);
                var files = Directory.EnumerateFiles(path);
                FileInfo file;

                items.Clear();

                foreach (string s in folders)
                {
                    AddToSelector(s + "\\", 0);
                }

                foreach (string s in files)
                {
                    file = new FileInfo(s);

                    AddToSelector(s, file.Length);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void AddToSelector(string fileName, long size)
        {
            FileItem item = new FileItem();
            string title = GetTitle(fileName);

            item.LiquidTag = fileName;
            item.MouseRightButtonDown += new MouseButtonEventHandler(item_MouseRightButtonDown);
            item.EditingFinished += new ItemViewerEventHandler(item_EditingFinished);

            if (fileName.EndsWith("\\"))
            {
                item.Icon = "images/large/folder.png";
            }
            else
            {
                item.Icon = "images/large/" + GetIcon(fileName);
                item.OtherText = (Math.Round((double)size / 1024, 2)).ToString() + "KB";
            }

            UpdateTitle(item, title);
            items.Add(item);
        }

        private void UpdateTitle(FileItem item, string title)
        {
            TextBlock titleTemplate = new TextBlock();

            titleTemplate.FontFamily = item.FontFamily;
            titleTemplate.FontSize = item.FontSize;
            titleTemplate.Text = title;

            if (titleTemplate.ActualWidth > 105)
            {
                titleTemplate.Text = string.Empty;
                // We need to trim the text
                foreach (char c in title)
                {
                    titleTemplate.Text += c;
                    if (titleTemplate.ActualWidth > 105)
                    {
                        titleTemplate.Text += "..";
                        break;
                    }
                }
            }

            ToolTipService.SetToolTip(item, title);
            item.Text = titleTemplate.Text;
        }

        private string GetTitle(string filename)
        {
            string[] split = filename.TrimEnd('\\').Split('\\');
            string title = filename;

            if (split.Length > 0)
            {
                title = split[split.Length - 1];
            }

            return title;
        }

        private string GetIcon(string filename)
        {
            string[] split = filename.Split('.');
            string extension = string.Empty;

            if (split.Length > 0)
            {
                extension = split[split.Length - 1].ToLower();
            }

            if (extension != "pdf" && extension != "xls" && extension != "doc" && extension != "gif" && extension != "mp3" &&
                extension != "ascx" && extension != "asmx" && extension != "aspx" && extension != "avi" && extension != "config" &&
                extension != "cs" && extension != "css" && extension != "htm" && extension != "html" && extension != "jpg" &&
                extension != "js" && extension != "mp4" && extension != "png" && extension != "txt" && extension != "xaml" &&
                extension != "xml" && extension != "zip" && extension != "xlsx" && extension != "docx")
            {
                extension = "unknown";
            }

            return extension + ".png";
        }

        private int GetChildCount(DirectoryInfo directory)
        {
            int count = 0;

            try
            {
                var folders = directory.EnumerateDirectories();
                var files = directory.EnumerateFiles();

                foreach (DirectoryInfo s in folders)
                {
                    count++;
                }

                foreach (FileInfo s in files)
                {
                    count++;
                }
            }
            catch (Exception ex)
            {
                count = 0;
            }

            return count;
        }

        private void OpenDocument(string documentPath)
        {
            FileInfo fileInfo = new FileInfo(documentPath);

            switch (fileInfo.Extension.Trim('.').ToLower())
            {
                case "doc":
                case "docx":
                case "txt":
                case "ini":
                case "cs":
                case "vb":
                    OpenInWord(fileInfo);
                    break;
                case "xls":
                case "xlsx":
                    OpenInExcel(fileInfo);
                    break;
                case "gif":
                case "jpg":
                case "png":
                    break;
            }

            //filePreview.Visibility = Visibility.Visible;
            //filePreview.Navigate(new Uri(documentPath, UriKind.Absolute));
        }

        private void OpenInWord(FileInfo fileInfo)
        {
            dynamic word = AutomationFactory.CreateObject("Word.Application");
            dynamic doc = word.Documents.Open(fileInfo.FullName);
            word.Visible = true;
            doc.Activate();
        }

        private void OpenInExcel(FileInfo fileInfo)
        {
            dynamic excel = AutomationFactory.CreateObject("Excel.Application");
            dynamic doc = excel.Workbooks.Open(fileInfo.FullName);
            excel.Visible = true;
            doc.Activate();
        }

        private bool Delete(string filename)
        {
            bool success = true;

            try
            {
                File.Delete(filename);
            }
            catch (Exception ex)
            {
                messageBox.ShowAsModal("There was an error deleting the file.", "Error");
                success = false;
            }

            PopulateFileSelector();

            return success;
        }

        #endregion

        #region Event Handlers

        private void fileTree_Populate(object sender, TreeEventArgs e)
        {
            Node node = (Node)sender;

            if (sender is Tree)
            {	// We are populating the root nodes collection
                fileTree.Nodes.Add(new Node(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\", "My Documents", true, "images/mydocs.png", "images/mydocs.png", true));
                fileTree.Nodes[0].Expand();
                fileTree.SetSelected(fileTree.Nodes[0]);
            }
            else
            {	// Otherwise we are populating a node
                PopulateNode(node, e);
            }
        }

        private void PopulateNode(Node node, TreeEventArgs e)
        {
            try
            {
                var folders = Directory.EnumerateDirectories(node.ID);
                var files = Directory.EnumerateFiles(node.ID);
                DirectoryInfo dir;

                foreach (string s in folders)
                {
                    dir = new DirectoryInfo(s);
                    node.Nodes.Add(new Node(s + "\\", dir.Name, (GetChildCount(dir) > 0), "images/folder.png", "images/folder.png", true));
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
            }
        }

        private void fileTree_NodeClick(object sender, TreeEventArgs e)
        {
            if (e.ID.EndsWith("\\"))
            {   // Clicked a folder
                PopulateFileSelector(e.ID);
            }
            else
            {   // Clicked a file
            }
        }

        private void items_DoubleClick(object sender, ItemViewerEventArgs e)
        {
            Node n;
            string selectedFile = items.Selected.LiquidTag.ToString();

            if (fileTree.Selected != null)
            {
                if (selectedFile.EndsWith("\\"))
                {
                    // Double clicked a folder
                    if (!fileTree.Selected.IsExpanded)
                    {
                        fileTree.Selected.Expand();
                    }

                    n = fileTree.Get(selectedFile);
                    fileTree.SetSelected(n);
                }
                else
                {
                    // Double clicked a file
                    OpenDocument(selectedFile);
                }
            }
        }

        private void items_Drop(object sender, DragEventArgs e)
        {
            FileInfo[] files = (FileInfo[])e.Data.GetData(DataFormats.FileDrop);
            string target;
            byte[] buffer;

            try
            {
                foreach (FileInfo file in files)
                {
                    target = fileTree.Selected.ID + file.Name;
                    Stream fileStream = file.OpenRead();

                    using (BinaryReader reader = new BinaryReader(fileStream))
                    {
                        buffer = new byte[reader.BaseStream.Length];
                        reader.Read(buffer, 0, (int)reader.BaseStream.Length);

                        FileStream targetStream = File.Create(target);
                        using (BinaryWriter writer = new BinaryWriter(targetStream))
                        {
                            writer.Write(buffer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowAsModal("One or more files could not be copied due to security restrictions.", "Error");
            }

            PopulateFileSelector();
        }

        private void item_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);

            if (sender is FileItem)
            {
                items.Selected = (FileItem)sender;
            }

            contextMenu.Margin = new Thickness(p.X, p.Y, 0, 0);
            contextMenu.Show();
            contextMenu.Focus();

            e.Handled = true;
        }

        private void item_EditingFinished(object sender, ItemViewerEventArgs e)
        {
            if (e.NewTitle != e.Title)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(items.Selected.LiquidTag.ToString());
                    File.Move(fileInfo.FullName, fileInfo.Directory.FullName + "\\" + e.NewTitle);

                    items.Selected.LiquidTag = fileInfo.Directory.FullName + "\\" + e.NewTitle;
                    UpdateTitle((FileItem)items.Selected, e.NewTitle);
                }
                catch (Exception ex)
                {
                    messageBox.ShowAsModal("There was an error renaming the file.", "Error");
                }
                finally
                {
                    e.Cancel = true;
                }
            }
        }

        private void Menu_ItemSelected(object sender, MenuEventArgs e)
        {
            MenuItem item = (MenuItem)e.Parameter;

            if (e.Tag == null)
            {
                return;
            }

            switch (e.Tag.ToString())
            {
                case "open":
                    if (items.Selected != null)
                    {
                        OpenDocument(items.Selected.LiquidTag.ToString());
                    }
                    break;
                case "rename":
                    if (items.Selected != null)
                    {
                        ((FileItem)items.Selected).Text = ToolTipService.GetToolTip(items.Selected).ToString();
                        items.Selected.IsEditable = true;
                    }
                    break;
                case "delete":
                    if (items.Selected != null)
                    {
                        Delete(items.Selected.LiquidTag.ToString());
                    }
                    break;
            }

            contextMenu.Hide();
        }

        private void installOutOfBrowser_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.InstallState == InstallState.NotInstalled)
            {
                App.Current.Install();
            }
        }

        #endregion
    }
}
