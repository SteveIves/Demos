using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.ServiceModel;
using Simple.Amazon.ECS;

namespace Barcode.Site
{
    public partial class FindProducts : System.Web.UI.Page
    {
        private const string accessKeyId = "YOUR_ACCESS_KEY_HERE";
        private const string secretKey = "PUT_SECRET_KEY_HERE";

        protected void Page_Load(object sender, EventArgs e)
        {
            string isbn = Request["ISBN"];
            // create a WCF Amazon ECS client
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            //binding.MaxReceivedMessageSize	= int.MaxValue;
            Simple.Amazon.ECS.AWSECommerceServicePortTypeClient client = new Simple.Amazon.ECS.AWSECommerceServicePortTypeClient(
                binding,
                new EndpointAddress("https://webservices.amazon.com/onca/soap?Service=AWSECommerceService"));

            // add authentication to the ECS client
            client.ChannelFactory.Endpoint.Behaviors.Add(new Simple.AmazonSigningEndpointBehavior(accessKeyId, secretKey));

            // prepare an ItemSearch request
            ItemSearchRequest request = new ItemSearchRequest();
            request.SearchIndex = "Books";

            request.Power = "ISBN: " + isbn;
            request.ResponseGroup = new string[] { "Large" };

            ItemSearch itemSearch = new ItemSearch();
            itemSearch.Request = new ItemSearchRequest[] { request };
            itemSearch.AWSAccessKeyId = accessKeyId;

            // issue the ItemSearch request
            ItemSearchResponse response = client.ItemSearch(itemSearch);

            XElement responseElement = new XElement("Response");
            XElement booksElement = new XElement("Books");
            responseElement.Add(booksElement);
            if (response != null && response.Items.Length > 0 && response.Items[0].Item != null)
            {

                foreach (var item in response.Items[0].Item)
                {
                    {
                        XElement bookElement = new XElement("Book", new XAttribute("Title", item.ItemAttributes.Title), new XAttribute("Image", "http://images.amazon.com/images/P/"+item.ASIN+".01.LZZZZZZZ.jpg"));
                        booksElement.Add(bookElement);
                        if (item.ItemAttributes.Author != null && item.ItemAttributes.Author.Length > 0)
                        {
                            XElement authorsElement = new XElement("Authors");
                            for (int i = 0; i < item.ItemAttributes.Author.Length; i++)
                            {
                                authorsElement.Add(new XElement("Author", item.ItemAttributes.Author[i]));
                            }
                            bookElement.Add(authorsElement);
                        }
                    }
                }
            }
            Response.ContentType = "text/xml";
            Response.Write(responseElement.ToString());
        }
    }
}