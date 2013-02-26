using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections.ObjectModel;
using System.IO;
using System.Drawing;

namespace RibbonPage
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod(Description = "GetDirectoryInfo")]
        public DirectoryInfo GetDirectoryInfo(string path)
        {
            string directoryPath = this.Context.ApplicationInstance.Server.MapPath(@"~\Files\" + path);
            System.IO.DirectoryInfo objDirectoryInfo = new System.IO.DirectoryInfo(directoryPath);

            List<FileInfo> files = new List<FileInfo>();
            List<DirectoryInfo> directories = new List<DirectoryInfo>();
            DirectoryInfo currentDirectory = new DirectoryInfo(path, directories, files);
            foreach (var fi in objDirectoryInfo.GetFiles().OrderBy(x => x.Name))
            {
                FileInfo file = new FileInfo(fi.Name, new DirectoryInfo(currentDirectory.FullName), fi.Length);
                Icon icon = Icon.ExtractAssociatedIcon(fi.FullName);
                files.Add(file);
            }

            foreach (System.IO.DirectoryInfo di in objDirectoryInfo.GetDirectories().OrderBy(x => x.Name))
            {
                DirectoryInfo directory = new DirectoryInfo(di.Name, new DirectoryInfo(currentDirectory.FullName));
                directories.Add(directory);
            }

            return currentDirectory;
        }

    }
}
