using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Windows.Browser;
using System.Text;

namespace Archetype.External
{
    public class Request
    {
        static public Uri GetAbsoluteUri(string pPath)
        {
            // if (pPath == null || !HtmlPage.IsEnabled)
            //   return null;

            if (pPath.IndexOf("http://", StringComparison.CurrentCultureIgnoreCase) == -1 && pPath.IndexOf("https://", StringComparison.CurrentCultureIgnoreCase) == -1)
            {
                string path = HtmlPage.Document.DocumentUri.AbsoluteUri;
                int anchor = path.LastIndexOf('#');
                if (anchor != -1)
                    path = path.Substring(0, anchor);
                int i = path.LastIndexOf('/');
                if (i != -1)
                {
                    path = path.Substring(0, i);
                }
                if (pPath.Length > 0 && pPath[0] == '/')
                    pPath = path + pPath;
                else
                    pPath = path + "/" + pPath;
            }
            return new Uri(pPath, UriKind.Absolute);
        }
    }
}