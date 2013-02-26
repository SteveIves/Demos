using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    static class Util
    {

        public static string GetGridViewState(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            //Save the default grid layout
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            view.SaveLayoutToStream(ms);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            System.IO.StreamReader sr = new System.IO.StreamReader(ms);
            string s = sr.ReadToEnd();
            sr.Close();
            return s;
        }

        public static void SetGridViewState(DevExpress.XtraGrid.Views.Grid.GridView view, string state)
        {
            if (state.Length > 0)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                System.IO.StreamWriter sw = new System.IO.StreamWriter(ms);
                sw.Write(state);
                sw.Flush();
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                view.RestoreLayoutFromStream(ms);
                sw.Close();
            }

        }
    }
}
