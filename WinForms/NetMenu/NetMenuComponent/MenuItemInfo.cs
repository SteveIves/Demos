using System;
using System.Collections.Generic;
using System.Text;

namespace SynPSG.Examples.NetMenu
{

    public enum MenuItemType
    {
        Program=1,
        Subroutine=2
    }
    
    class MenuItemInfo
    {
        //Constructor to set defaults
        
        public MenuItemInfo()
        {
            ItemType = MenuItemType.Program;
            ColapseApplicationExplorer = false;
        }

        //Public properties to store menu item attributes

        public string GroupName { get; set; }

        public MenuItemType ItemType { get; set; }

        public string Description { get; set; }

        public string ActivationCommand { get; set; }

        public bool ColapseApplicationExplorer { get; set; }

    }
}
