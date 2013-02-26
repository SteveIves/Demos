using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;

namespace SilverScreen.Web
{
    public partial class UpdateTwitterPicture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            byte[] buffer = new byte[Request.InputStream.Length];
            Request.InputStream.Read(buffer,0,buffer.Length);

            string error = Account_UpdateProfileImage(Request["username"], Request["password"], buffer, ImageExtension.JPEG);
            if (error == null)
                Response.Write("1");
            else
                Response.Write("0");
        }

        // Code developed by Dennis Delimarsky (Core) in July 2009
        // This code is part of the dotTweet project (http://dottweet.codeplex.com)
        // Please, leave this comment block when using the following code.

        public enum ImageExtension
        {
            JPEG,
            GIF,
            PNG
        }

        public static string Account_UpdateProfileImage(string username, string password, byte[] image, ImageExtension extension)
        {
            try
            {
                string s = string.Empty;

                System.Net.ServicePointManager.Expect100Continue = false;

                HttpWebRequest updateRequest = (HttpWebRequest)HttpWebRequest.Create(@"http://twitter.com/account/update_profile_image.xml");
                updateRequest.PreAuthenticate = true;
                updateRequest.AllowWriteStreamBuffering = true;

                string boundary = System.Guid.NewGuid().ToString();

                updateRequest.Credentials = new NetworkCredential(username, password);
                updateRequest.ContentType = String.Format("multipart/form-data;boundary={0}", boundary);
                updateRequest.Method = "POST";

                string header = "--" + boundary;
                string footer = "--" + boundary + "--";

                StringBuilder headers = new StringBuilder();

                headers.AppendLine(header);

                switch (extension)
                {
                    case ImageExtension.PNG:
                        {
                            headers.AppendLine(String.Format("Content-Disposition:form-data); name=\"image\"); filename=\"{0}\"", "image.png"));
                            headers.AppendLine("Content-Type: image/png");
                            break;
                        }
                    case ImageExtension.GIF:
                        {
                            headers.AppendLine(String.Format("Content-Disposition:form-data); name=\"image\"); filename=\"{0}\"", "image.gif"));
                            headers.AppendLine("Content-Type: image/gif");
                            break;
                        }
                    case ImageExtension.JPEG:
                        {
                            headers.AppendLine(String.Format("Content-Disposition:form-data); name=\"image\"); filename=\"{0}\"", "image.jpg"));
                            headers.AppendLine("Content-Type: image/jpeg");
                            break;
                        }
                }

                headers.AppendLine();
                headers.AppendLine(System.Text.Encoding.GetEncoding("iso-8859-1").GetString(image));
                headers.AppendLine(footer);

                byte[] contents = Encoding.GetEncoding("iso-8859-1").GetBytes(headers.ToString());

                updateRequest.ContentLength = contents.Length;

                using (Stream requestStream = updateRequest.GetRequestStream())
                {
                    requestStream.Write(contents, 0, contents.Length);
                    requestStream.Flush();
                    requestStream.Close();


                    using (WebResponse webResponse = updateRequest.GetResponse())
                    {
                        using (StreamReader responseReader = new StreamReader(webResponse.GetResponseStream()))
                        {
                            s = responseReader.ReadToEnd();
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}