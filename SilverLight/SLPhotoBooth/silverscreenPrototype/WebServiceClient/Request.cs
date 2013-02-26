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
using System.Windows.Browser;
using System.IO;
using System.Net.Browser;

namespace Archetype.Web
{
    public class Request
    {
        public static HttpWebRequest Open(Uri uri, Action<HttpWebRequest> created, Action<HttpWebRequest, Stream> opened, Action<HttpWebRequest, HttpWebResponse> closed)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequestCreator.ClientHttp.Create(uri);
            if (created != null)
            {
                created(request);
            }
            request.BeginGetRequestStream(delegate(IAsyncResult asyncResult)
            {
                using (Stream postWriter = request.EndGetRequestStream(asyncResult))
                {
                    opened(request, postWriter);
                    postWriter.Close();
                }

                request.BeginGetResponse(delegate(IAsyncResult asyncEndResult)
                {
                    try
                    {
                        HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncEndResult);
                        if (closed != null)
                        {
                            closed(request, response);
                        }
                    }
                    catch (WebException exception)
                    {
                        if (exception.Response != null)
                        {
                            HttpWebResponse response = (HttpWebResponse)exception.Response;
                            if (closed != null)
                            {
                                closed(request, response);
                            }
                        }
                    }
                }, request);
            }, request);

            return request;
        }

        static public Uri GetAbsoluteUri(string webpath)
        {
            if (webpath == null || !HtmlPage.IsEnabled)
                return null;

            if (webpath.IndexOf("http://", StringComparison.CurrentCultureIgnoreCase) == -1 && webpath.IndexOf("https://", StringComparison.CurrentCultureIgnoreCase) == -1)
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
                if (webpath.Length > 0 && webpath[0] == '/')
                    webpath = path + webpath;
                else
                    webpath = path + "/" + webpath;
            }
            return new Uri(webpath, UriKind.Absolute);
        }
    }
}

