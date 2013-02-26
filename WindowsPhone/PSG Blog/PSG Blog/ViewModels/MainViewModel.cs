using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Net;
using System.Xml;
using System.ServiceModel.Syndication;


namespace PSG_Blog
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        ObservableCollection<ItemViewModel> _items;
        public ObservableCollection<ItemViewModel> Items
        {
            get
            {
                if (_items == null)
                {
                    string url = "http://www.steveives.com/feed/";
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
                    request.BeginGetResponse(responseHandler, request);
                }
                return _items;
            }
            private set
            {
                if (_items != value)
                {
                    _items = value;
                    NotifyPropertyChanged("Items");
                }
            }
        }

        private void responseHandler(IAsyncResult asyncResult)
        {
            HttpWebRequest request = (HttpWebRequest)asyncResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                XmlReader reader = XmlReader.Create(response.GetResponseStream());
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                ObservableCollection<ItemViewModel> newItems = new ObservableCollection<ItemViewModel>();

                foreach (SyndicationItem post in feed.Items)
                {
                    newItems.Add(new ItemViewModel()
                    {
                        Title = post.Title.Text,
                        PublishDate = post.PublishDate.ToLocalTime().ToString(),
                        Summary = post.Summary.Text
                    });
                }

                Items = newItems;
            }
        }

    }
}