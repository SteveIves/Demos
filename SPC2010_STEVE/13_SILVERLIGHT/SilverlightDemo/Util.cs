using System;
using System.Net;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightDemo.SPC2010Server;

namespace SilverlightDemo
{
    internal static class Util
    {
        //public static string webServiceUri;
        public static string wcfServiceUri;

        static Util()
        {
            string xapFileUri = Application.Current.Host.Source.AbsoluteUri;
            string rootUri = xapFileUri.Remove(xapFileUri.IndexOf("/ClientBin/SilverlightDemo.xap"));
            //webServiceUri = String.Format("{0}/{1}", rootUri, "SPC2010WebService.asmx");
            wcfServiceUri = String.Format("{0}/{1}", rootUri, "SPC2010WcfService.svc");
        }

        //public static SPC2010WebServiceSoapClient GetClient()
        //{
        //    return new SPC2010WebServiceSoapClient(
        //        getBinding(),
        //        new System.ServiceModel.EndpointAddress(new Uri(webServiceUri)));
        //}

        public static SPC2010WcfServiceClient GetClient()
        {
            return new SPC2010WcfServiceClient(
                getBinding(),
                new System.ServiceModel.EndpointAddress(new Uri(wcfServiceUri)));
        }

        private static BasicHttpBinding getBinding()
        {
            BasicHttpBinding httpBinding = new BasicHttpBinding();
            httpBinding.MaxReceivedMessageSize = 2147483647;
            return httpBinding;
        }
    }
}
