using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTabbedMdi;
using Infragistics.Win.UltraWinDock;

namespace SynPSG.Examples.NetMenu
{
    public partial class MainMenu : Form
    {
        private string appTitle;
        private string menuXmlFile;
        private string dbrSpec;

        public MainMenu(string AppTitle, string MenuXmlFile, string DbrSpec)
        {
            InitializeComponent();
            appTitle = AppTitle;
            menuXmlFile = MenuXmlFile;
            dbrSpec = DbrSpec;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Width = 1024;
            this.Height = 737;
            this.Text = appTitle;

            XmlDocument xmlDoc;
            XmlNodeList menuGroups;

            xmlDoc = new XmlDocument();
            xmlDoc.Load(menuXmlFile);

            /*
             * First lets see if we have any program items which are not embedded within
             * a submenu.  If we do then we'll create a special "Main Programs" menu group
             * to contain them.
             */

            //TODO: Adding "top-level" programs (those not in any submenu)
            //NOT WORKING RIGHT NOW, NOT SURE WHY!!!
            //XmlNodeList topLevelPrograms = xmlDoc.SelectNodes("/HBSmenu/program");
            //if (topLevelPrograms.Count>0)
            //{
            //    XmlElement menuGroup = xmlDoc.CreateElement("submenu");
            //    menuGroup.SetAttribute("name", "Main Programs");
            //    foreach (XmlNode x in topLevelPrograms)
            //        menuGroup.AppendChild(x);
            //    addMenuGroup(menuGroup);
            //}

            /*
             * Next we'll process each of the "submenu" elements which are directly below
             * the root element.  For each of these we will create a folder in the application
             * explorer, and a sub menu in the "Applications" menu column.
             */

            menuGroups = xmlDoc.SelectNodes("/HBSmenu/submenu");

            foreach (XmlElement menuGroup in menuGroups)
            {
                //Create the group
                addMenuGroup(menuGroup);

                /*
                 * Now we'll process any "program" elements which are found below the current
                 * subment element.
                 */
                
                XmlNodeList menuItems = menuGroup.SelectNodes("program");

                //Iterate through the groups items
                foreach (XmlElement menuItem in menuItems)
                {
                    switch (menuItem.GetAttribute("executeType"))
                    {
                        case "0":   //Nothing
                            break;
                        case "1":   //Submenu
                            break;
                        case "2":   //xcall
                            addSynergySubroutineItem(menuGroup, menuItem);
                            break;
                        case "3":   //Program
                        case "4":   //Program
                            addSynergyProgramItem(menuGroup, menuItem);
                            break;
                        case "5":   //xcall
                            addSynergySubroutineItem(menuGroup, menuItem);
                            break;
                    }

                }
            }

        }

        private void addMenuGroup(XmlElement menuGroup)
        {
            string groupKey = menuGroup.GetAttribute("name");
            string groupDescription = menuGroup.GetAttribute("name");

            try
            {
                //Add the new group to the application explorer
                applicationExplorer.Groups.Add(groupKey, groupDescription);

                //Add the new group to the applications menu
                PopupMenuTool newMenu = new PopupMenuTool(groupKey);
                newMenu.SharedProps.Caption = groupDescription;
                newMenu.SharedProps.Category = "Main Menu";
                toolbarsManager.Tools.Add(newMenu);
                PopupMenuTool appMenu = (PopupMenuTool)toolbarsManager.Tools["MnuApplications"];
                appMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] { newMenu });
            }
            catch
            {
                MessageBox.Show("Menu group '" + groupKey + "' already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void addSynergyProgramItem(XmlElement menuGroup, XmlElement menuItem)
        {

            //Clean up the program name specified in the XML file
            string programName = menuItem.GetAttribute("executeDbr");
            if (programName.Contains(":") && !programName.Trim().ToLower().EndsWith(".dbr"))
                programName = programName.Trim() + ".dbr";

            //Create a MenuItemInfo object for the new menu item
            MenuItemInfo newItem = new MenuItemInfo();
            newItem.GroupName = menuGroup.GetAttribute("name");
            newItem.ItemType = MenuItemType.Program;
            newItem.Description = menuItem.GetAttribute("name");
            newItem.ActivationCommand = programName;
            newItem.ColapseApplicationExplorer = menuItem.GetAttribute("appstate").Equals("wide");

            //Create a unique key for the new item in the menu and application explorer
            UltraExplorerBarGroup group = (UltraExplorerBarGroup)applicationExplorer.Groups[newItem.GroupName];
            string uniqueKey = group.Key.Replace(" ","") + (group.Items.Count + 1);

            //Add the new item to the Application explorer
            UltraExplorerBarItem newAppExplorerItem = group.Items.Add(uniqueKey, newItem.Description);
            newAppExplorerItem.Tag = newItem;

            //Create a new ButtonTool to add to the applications menu heirarchy
            ButtonTool newButtonTool = new ButtonTool(uniqueKey);
            newButtonTool.SharedProps.Caption = newItem.Description;
            newButtonTool.SharedProps.Category = "Main Menu";
            newButtonTool.Tag = newItem;
            //TODO: Fix item activation from pull-down menus
            /*
             * Right now the program items in the pull-down menus are not working.
             * The reason seems to be that even though I am adding the MenuItemInfo
             * object as the button tools "tag", at run time the tag is not propagating
             * through, so the logic takes no action.  Not currently sure why this is!!!
             */

            //Add the new button tool to the toolbar manager
            toolbarsManager.Tools.Add(newButtonTool);

            //And also add it to the appropriate application sub-menu
            PopupMenuTool parentMenu = (PopupMenuTool)toolbarsManager.Tools[newItem.GroupName];
            parentMenu.Tools.Add(newButtonTool);
        }

        private void addSynergySubroutineItem(XmlElement menuGroup, XmlElement menuItem)
        {

            //Create a MenuItemInfo object for the new menu item
            MenuItemInfo newItem = new MenuItemInfo();
            newItem.GroupName = menuGroup.GetAttribute("name");
            newItem.ItemType = MenuItemType.Subroutine;
            newItem.Description = menuItem.GetAttribute("name");
            newItem.ActivationCommand = menuItem.GetAttribute("executeMethod");
            newItem.ColapseApplicationExplorer = false;

            //Create a unique key for the new item in the menu and application explorer
            UltraExplorerBarGroup group = (UltraExplorerBarGroup)applicationExplorer.Groups[newItem.GroupName];
            string uniqueKey = group.Key.Replace(" ", "") + (group.Items.Count + 1);

            //Add the new item to the Application explorer
            UltraExplorerBarItem newAppExplorerItem = group.Items.Add(uniqueKey, newItem.Description);
            newAppExplorerItem.Tag = newItem;
            //newAppExplorerItem.Settings.Enabled = Infragistics.Win.DefaultableBoolean.False;

            //Create a new ButtonTool to add to the applications menu heirarchy
            ButtonTool newButtonTool = new ButtonTool(uniqueKey);
            newButtonTool.SharedProps.Caption = newItem.Description;
            newButtonTool.SharedProps.Category = "Main Menu";
            newButtonTool.Tag = newItem;
            newButtonTool.SharedProps.Enabled = false;

            //Add the new button tool to the toolbar manager
            toolbarsManager.Tools.Add(newButtonTool);

            //And also add it to the appropriate application sub-menu
            PopupMenuTool parentMenu = (PopupMenuTool)toolbarsManager.Tools[newItem.GroupName];
            parentMenu.Tools.Add(newButtonTool);
        }

        private void toolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {

            //If the tool has a tag then it's a program to be started
            if (e.Tool.Tag != null)
            {
                if (e.Tool.Tag.GetType().ToString().Contains("MenuItemInfo"))
                {
                    MenuItemInfo itemInfo = (MenuItemInfo)e.Tool.Tag;
                    activateSynergyApplication(ref itemInfo);
                }
                else
                    MessageBox.Show("Don't know how to start this item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                switch (e.Tool.Key)
                {
                    case "MnuFileExit":
                        this.Close();
                        break;

                    case "MnuViewStatusBar":
                        statusBar.Visible = !statusBar.Visible;
                        break;

                    case "MnuViewApplicationExplorer":
                        if (((StateButtonTool)e.Tool).Checked)
                        {
                            dockManager.ControlPanes["ApplicationExplorer"].Pin();
                            dockManager.ControlPanes["ApplicationExplorer"].Show();
                        }
                        else
                            dockManager.ControlPanes["ApplicationExplorer"].Close();
                        break;

                    case "MnuExplorerBarStyle":
                        applicationExplorer.Style = UltraExplorerBarStyle.ExplorerBar;
                        break;
                    case "MnuListBarStyle":
                        applicationExplorer.Style = UltraExplorerBarStyle.Listbar;
                        break;
                    case "MnuToolboxStyle":
                        applicationExplorer.Style = UltraExplorerBarStyle.Toolbox;
                        break;
                    case "MnuOutlookStyle":
                        applicationExplorer.Style = UltraExplorerBarStyle.OutlookNavigationPane;
                        break;

                    case "MnuViewTabs":
                        tabbedMdiManager.Enabled = ((StateButtonTool)e.Tool).Checked;
                        break;
                    default:
                        MessageBox.Show("Unknown item " + e.Tool.Key, "Unknown Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }

        }

        private void explorerBar_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            if ((e.Item.Tag != null) && (e.Item.Tag.GetType().ToString().Contains("MenuItemInfo")))
            {
                MenuItemInfo itemInfo = (MenuItemInfo)e.Item.Tag;
                activateSynergyApplication(ref itemInfo);
            }
            else
                MessageBox.Show("Don't know how to start this item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void activateSynergyApplication(ref MenuItemInfo ItemInfo)
        {
            if (ItemInfo.ColapseApplicationExplorer)
            {
                dockManager.ControlPanes["ApplicationExplorer"].Close();
            }
            
            switch (ItemInfo.ItemType)
            {
                case MenuItemType.Program:
                    activateSynergyProgram(ref ItemInfo);
                    break;
                case MenuItemType.Subroutine:
                    activateSynergySubroutine(ref ItemInfo);
                    break;
            }
        }

        private void activateSynergyProgram(ref MenuItemInfo ItemInfo)
        {
            try
            {
                if (ItemInfo.ActivationCommand.Contains(":"))
                {
                    int colonPos = ItemInfo.ActivationCommand.IndexOf(":");
                    string envVar = ItemInfo.ActivationCommand.Substring(0, colonPos);
                    string dbrFile = Environment.GetEnvironmentVariable(envVar);
                    if (dbrFile == null)
                        throw new Exception("Environment variable " + envVar + " is not defined.");
                    if (!dbrFile.Trim().EndsWith("\\"))
                        dbrFile = dbrFile.Trim() + "\\";
                    dbrFile = dbrFile + ItemInfo.ActivationCommand.Remove(0, colonPos + 1);
                    if (!File.Exists(dbrFile))
                        throw new Exception("Program " + ItemInfo.ActivationCommand + " not found.");
                }
                SynergyAppHost child = new SynergyAppHost(ref ItemInfo, this, dbrSpec);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void activateSynergySubroutine(ref MenuItemInfo ItemInfo)
        {
            try
            {
                string dbrFile = Environment.GetEnvironmentVariable("EXE");
                if (dbrFile == null)
                    throw new Exception("Environment variable EXE is not defined.");
                if (!dbrFile.Trim().EndsWith("\\"))
                    dbrFile = dbrFile.Trim() + "\\";
                dbrFile = dbrFile + "runsubroutine.dbr";
                if (!File.Exists(dbrFile))
                    throw new Exception("Program EXE:runsubroutine.dbr not found.");
                SynergyAppHost child = new SynergyAppHost(ref ItemInfo, this, dbrSpec);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dockManager_PaneHidden(object sender, Infragistics.Win.UltraWinDock.PaneHiddenEventArgs e)
        {
            if (e.Pane.Key.Equals("ApplicationExplorer"))
            {
                StateButtonTool tool = (StateButtonTool)toolbarsManager.Tools["MnuViewApplicationExplorer"];
                tool.Checked = false;
            }
        }

        private void dockManager_PaneDisplayed(object sender, Infragistics.Win.UltraWinDock.PaneDisplayedEventArgs e)
        {
            if (e.Pane.Key.Equals("ApplicationExplorer"))
            {
                StateButtonTool tool = (StateButtonTool)toolbarsManager.Tools["MnuViewApplicationExplorer"];
                tool.Checked = true;
            }
        }

        private void tabbedMdiManager_TabClosed(object sender, Infragistics.Win.UltraWinTabbedMdi.MdiTabEventArgs e)
        {

            if (tabbedMdiManager.TabGroups.Count == 0)
            {
                DockableControlPane applicationExplorer = dockManager.ControlPanes["ApplicationExplorer"];
                applicationExplorer.Pin();
                applicationExplorer.Show();
            }

        }

    }
}
