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
using System.IO;

namespace silverscreenPrototype
{
    // Simple helper class which acts as a client for our post to twitter web service.
    public class UpdateTwitterProfileImage
    {
        static public void Upload(string username, string password, byte[] image, Action<bool> completed)
        {
            Archetype.Web.Request.Open(Archetype.Web.Request.GetAbsoluteUri("UpdateTwitterPicture.aspx?username=" + username + "&password=" + password),

                delegate(HttpWebRequest request)
                {
                    request.Method = "POST";
                },

                delegate(HttpWebRequest request, System.IO.Stream stream)
                {
                    stream.Write(image, 0, image.Length);
                },

                delegate(HttpWebRequest request, HttpWebResponse response)
                {
                    try
                    {
                        using (StreamReader responseReader = new StreamReader(response.GetResponseStream()))
                        {
                            string b = responseReader.ReadToEnd();
                            if (b == "1")
                                completed(true);
                            else
                                completed(false);

                        }
                    }
                    catch (Exception)
                    {
                        completed(false);
                    }
                });
        }
    }
}
