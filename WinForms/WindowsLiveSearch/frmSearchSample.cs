//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED
//TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//
//Copyright (C) 2007  Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using System.Net;
using WindowsLiveSearch.LiveSearch;

namespace WindowsLiveSearch
{
    public partial class frmSearchSample : Form
    {
        public frmSearchSample()
        {
            InitializeComponent();
        }

        public void executeQuery(bool nearMe)
        {
            try
            {
                // Create a new MSNSearchService object. MSNSearchService is the top-level
                // proxy class for accessing the service. MSNSearchService has one synchronous method:
                // Search, which takes a single SearchRequest object as an argument.
                // Asynchronous search methods, such as BeginSearch and EndSearch, may also be
                // available, depending on the SOAP toolkit used to generate the proxies.
                MSNSearchService s = new MSNSearchService();

                // Create a new SearchRequest object that represents the search request. Each SearchRequest can
                // contain multiple SourceRequest objects; however, each SearchRequest can contain
                // only one SourceRequest of each type. (More on this later.)
                SearchRequest searchRequest = new SearchRequest();

                // For the sample application, we will use seven SourceRequest objects: SourceType.Web,
                // which returns Web results or Web-Local results if a Location object is present;
                // SourceType.Spelling, which returns spelling suggestions; SourceType.PhoneBook,
                // which returns White Pages and Yellow Pages entries and geographic information for
                // select markets when a Location object is present; SourceType.News, which returns
                // news stories; SourceType.QueryLocation, which returns the keyword and place name,
                // for a query such as "pizza new york" or "pizza 98052," as "pizza" in the Title field and
                // the location name requested, such as a postal code ("98052") or a place name ("New York, NY");
                // SourceType.InlineAnswers, which returns Encarta, Finance, Weather, and ShowTimes
                // for commercial partners who have subscribed to these services; and SourceType.Image,
                // which returns information about images returned by the query, including the URI to 
                // the full-size image, the URI to the generated thumbnail, the height and width of the 
                // full-size image, the height and width of the thumbnail, the file size of the full-size
                // image, and the file size of the thumbnail.

                int arraySize = 7;

                // Each SourceRequest can be configured to return one or more common result fields:
                // Title, Description, Url, DisplayUrl, CacheUrl, Source, SearchTags, Phone, Address, Location;
                // The fields return vary by SourceType. Extended data fields can also be returned for specific
                // SourceTypes; see the online documentation for details.

                // Fields can be combined using the bitwise OR operator (|); 
                // All returns all available fields in the enumeration.
                // Note that some SourceRequest objects cannot return all of the fields
                // described. For example, a SourceRequest of type Spelling returns one spelling
                // suggestion in the Title field, so the returned data is the same when the
                // ResultFields property is set to ResultFieldMask.All or ResultFieldMask.Title.
                SourceRequest[] sr = new SourceRequest[arraySize];

                // The first SourceRequest is a Web source request. This can be a request for Web or
                // Web-Local results, depending on whether the Location object is set. When the user clicks
                // "Near Me," the sample application applies the Location information to the search and
                // returns Web-Local results (results that consider Location as a relevance factor) and
                // PhoneBook results.
                sr[0] = new SourceRequest();
                sr[0].Source = SourceType.Web;

                // For this SourceRequest, we can return all fields...
                sr[0].ResultFields = ResultFieldMask.All | ResultFieldMask.SearchTagsArray;

                // or just specific fields, such as SearchTags.

                // sr[0].ResultFields = ResultFieldMask.SearchTags;

                // To return a subset of all fields, combine the result fields using the bitwise
                // OR operator (|). The following example returns the Title and URL fields only:

                // sr[0].ResultFields = ResultFieldMask.Title | ResultFieldMask.Url;

                // Check for the number of results to return per page. If this value is not set,
                // the service returns the default number of results, which is ten per page.
                if (txtNumResults.Text != String.Empty)
                    sr[0].Count = Int32.Parse(txtNumResults.Text);

                // Check for an offset value. The default offset is zero, meaning that results are
                // returned from the Live Search Engine with the highest-ranking result displayed first.
                // The Offset property is most commonly used in conjunction with the Count
                // property, above, for paging through long lists of results.
                if (txtOffset.Text != String.Empty)
                    sr[0].Offset = Int32.Parse(txtOffset.Text);

                // If the user chooses to specify a SearchTagFilter or filters, the SearchTags returned will contain
                // only those specified. The sample application limits the number of filters to five (5). Example:
                // Query: MSDN, SearchTagFilter: search.title;search.mscategory
                if (txtWebSearchTagFilters.Text != String.Empty)
                {
                    string strUserSuppliedSearchTags = txtWebSearchTagFilters.Text;
                    string[] strFiltersWeb = new string[5];
                    strFiltersWeb = strUserSuppliedSearchTags.Split(';');
                    sr[0].SearchTagFilters = strFiltersWeb;
                }

                // Determine the user's choice of FileType. The default setting is any file
                // type. To restrict the FileType, set the SourceRequest.FileType to a specific string
                // value, as in the following setting for the Microsoft .DOC type.

                // sr[0].FileType = "DOC";

                // In this sample, all valid Web FileType values are listed in a combo box. To apply the user-
                // selected extension, the application gets the substring from the listed value and applies it
                // to the request.
                string strRawFileTypeString = cbxWebFileType.SelectedItem.ToString();
                if (strRawFileTypeString != "No File Type Preference")
                {
                    string[] strFileTypeProcessingArray = new string[2];
                    strFileTypeProcessingArray = strRawFileTypeString.Split('(');
                    string strFileType = strFileTypeProcessingArray[1].Substring(1, 4);
                    strFileType = strFileType.Trim();
                    sr[0].FileType = strFileType;
                }

                // The second SourceRequest is a spelling source request. Spelling returns only one
                // result per call, in the Title field.
                sr[1] = new SourceRequest();
                sr[1].Source = SourceType.Spelling;
                sr[1].ResultFields = ResultFieldMask.Title;
                // Set the Count to 1 and the Offset to 0 for SourceType.Spelling; Spelling returns
                // only one result per request (Count = 1) at offset zero (Offset = 0).
                sr[1].Count = 1;
                sr[1].Offset = 0;

                // The third SourceRequest is a PhoneBook source request. PhoneBook results include
                // a title, description, URL, phone number, address object, and location object.
                sr[2] = new SourceRequest();
                sr[2].Source = SourceType.PhoneBook;
                if (optRelevanceSort.Checked)
                    sr[2].SortBy = SortByType.Relevance;
                else if (optDistanceSort.Checked)
                    sr[2].SortBy = SortByType.Distance;
                else
                    sr[2].SortBy = SortByType.Default;

                // In this sample, we will return the Title, Description, and Url fields, as well as
                // the PhoneBook-specific return fields Phone, Address, and Location.
                sr[2].ResultFields = ResultFieldMask.Address | ResultFieldMask.Description | ResultFieldMask.Location | ResultFieldMask.Phone | ResultFieldMask.Title | ResultFieldMask.Url;
                if (txtNumResults.Text != String.Empty)
                    sr[2].Count = Int32.Parse(txtNumResults.Text);
                if (txtOffset.Text != String.Empty)
                    sr[2].Offset = Int32.Parse(txtOffset.Text);
                // PhoneBook results can be restricted by listing types to return all results, White Pages (Residential)
                // listings only, or Yellow Pages (Commercial) listings only. The following FileType values are
                // supported for the PhoneBook SourceType.
                if (optFileTypeWP_Only.Checked)
                    sr[2].FileType = "WP";
                if (optFileTypeYP_Only.Checked)
                    sr[2].FileType = "YP";

                // The fourth SourceRequest is a News source request. News results include
                // a title, description, URL, news source, and a date/time object.
                sr[3] = new SourceRequest();
                sr[3].Source = SourceType.News;

                // If the user chooses to specify a SearchTagFilter or filters, the SearchTags returned will contain
                // only those specified. The sample application limits the number of filters to five (5).
                // Example: Query: MSNBC, SearchTagFilter: search.source
                if (txtNewsSearchTagFilters.Text != String.Empty)
                {
                    string strUserSuppliedSearchTags = txtNewsSearchTagFilters.Text;
                    string[] strFiltersNews = new string[5];
                    strFiltersNews = strUserSuppliedSearchTags.Split(';');
                    sr[3].SearchTagFilters = strFiltersNews;
                }

                // In this sample, we will return the Title, Description, and Url fields, as well as
                // the extended news return fields Source and DateTime.
                sr[3].ResultFields = ResultFieldMask.All | ResultFieldMask.DateTime | ResultFieldMask.SearchTagsArray;
                if (txtNumResults.Text != String.Empty)
                    sr[3].Count = Int32.Parse(txtNumResults.Text);
                if (txtOffset.Text != String.Empty)
                    sr[3].Offset = Int32.Parse(txtOffset.Text);

                // The fifth SourceRequest is a QueryLocation request. The response includes the keyword for the query,
                // such as "pizza" and the location name requested, such as a postal code ("98052") or a place name
                // ("New York, NY"). The keyword is returned in the QueryLocation.Title field and the place name or
                // postal code is returned in the QueryLocation.Description field.
                sr[4] = new SourceRequest();
                sr[4].Source = SourceType.QueryLocation;
                sr[4].ResultFields = ResultFieldMask.All;

                // The sixth SourceRequest is an InlineAnswers request. Inline Answers are returned only to those
                // commercial partners who have subscribed to the service(s). Possible types include: Encarta,
                // Finance, Weather, and movie ShowTimes. InlineAnswers extended fields include the Summary field,
                // which displays a compact version of the answer, suitable for mobile devices such as smart phones,
                // and a ResultType field, which returns the name of the InlineAnswer type that responded to the
                // query.
                sr[5] = new SourceRequest();
                sr[5].Source = SourceType.InlineAnswers;
                sr[5].ResultFields = ResultFieldMask.All | ResultFieldMask.ResultType | ResultFieldMask.Summary;

                // The seventh SourceRequest is an Image request. Image results can include the URL and Display URL
                // for the HTML page that contains the image, the image name (in the Title field), the image file size,
                // the image height and width, the thumbnail file size, the thumbnail height and width, and URIs for
                // the full image and thumbnail.
                sr[6] = new SourceRequest();
                sr[6].Source = SourceType.Image;
                sr[6].ResultFields = ResultFieldMask.All | ResultFieldMask.Image;
                if (txtNumResults.Text != String.Empty)
                    sr[6].Count = Int32.Parse(txtNumResults.Text);
                if (txtOffset.Text != String.Empty)
                    sr[6].Offset = Int32.Parse(txtOffset.Text);

                // The Query field of the SearchRequest object is the text of the query submitted to the
                // Live Search Engine. The query can contain any valid query text supported by the 
                // Live Search Engine, including advanced query syntax. 
                searchRequest.Query = txtQuery.Text;

                // The Requests field of the SearchRequest object is the array of SourceRequest objects
                // for this search.
                searchRequest.Requests = sr;

                // Check the user selection for SafeSearchOptions.
                // The default setting is Moderate.
                if (optSafeSearchOff.Checked)
                    searchRequest.SafeSearch = SafeSearchOptions.Off;
                else if (optSafeSearchStrict.Checked)
                    searchRequest.SafeSearch = SafeSearchOptions.Strict;
                else
                    searchRequest.SafeSearch = SafeSearchOptions.Moderate;

                // Enter the Application ID, in double quotation marks, supplied by the 
                // Developer Provisioning System, as the value of the AppID on the SearchRequest.
                searchRequest.AppID = "APP_ID_GOES_HERE";

                // Determine whether the user chose to enable query word marking, disable spell correction
                // for search operators, and disable host collapsing.
                int searchFlagsValue = 0;

                if (chkQueryWordMarking.Checked)
                    searchFlagsValue += 1;
                if (chkDisableSpellCorrectForSpecialWords.Checked)
                    searchFlagsValue += 2;
                if (chkDisableHostCollapsing.Checked)
                    searchFlagsValue += 4;

                switch (searchFlagsValue)
                {
                    case 0:
                        searchRequest.Flags = SearchFlags.None;
                        break;
                    case 1:
                        searchRequest.Flags = SearchFlags.MarkQueryWords;
                        break;
                    case 2:
                        searchRequest.Flags = SearchFlags.DisableSpellCorrectForSpecialWords;
                        break;
                    case 3:
                        searchRequest.Flags = SearchFlags.MarkQueryWords | SearchFlags.DisableSpellCorrectForSpecialWords;
                        break;
                    case 4:
                        searchRequest.Flags = SearchFlags.DisableHostCollapsing;
                        break;
                    case 5:
                        searchRequest.Flags = SearchFlags.MarkQueryWords | SearchFlags.DisableHostCollapsing;
                        break;
                    case 6:
                        searchRequest.Flags = SearchFlags.DisableSpellCorrectForSpecialWords | SearchFlags.DisableHostCollapsing;
                        break;
                    case 7:
                        searchRequest.Flags = SearchFlags.MarkQueryWords | SearchFlags.DisableSpellCorrectForSpecialWords | SearchFlags.DisableHostCollapsing;
                        break;
                    default:
                        searchRequest.Flags = SearchFlags.None;
                        break;
                }

                // Determine the user's CultureInfo selection.
                // The following code gets the CultureInfo value from the combo box.
                // The combo box collection contains all values recognized by the Live Search Engine.
                // You can also set the CultureInfo to a specific value in the code, as shown in the
                // following example:
                // searchRequest.CultureInfo = "fr-CA";
                searchRequest.CultureInfo = cbxCultureInfo.SelectedItem.ToString();

                // To return PhoneBook results in addition to Web results, the user must set the Location.
                // The following code sets the Latitude and Longitude fields of the Location
                // object, and the Radius of the search.

                // If invalid Location data is specified, the Live Search Engine will attempt to
                // return search results based on the information provided. Note that zero results
                // may return if the Location data does not map to a valid geographic location.
                // The value of Radius also affects the search results; a small value for Radius may
                // return fewer results than expected.

                // The sample application user interface does not validate user input.
                if (nearMe)
                {
                    double latitude = Double.Parse(txtLatitude.Text);
                    double longitude = Double.Parse(txtLongitude.Text);
                    double radius = Double.Parse(txtRadius.Text);
                    searchRequest.Location = new Location();
                    searchRequest.Location.Latitude = latitude;
                    searchRequest.Location.Longitude = longitude;
                    searchRequest.Location.Radius = radius;
                }

                // Once the SearchRequest has been configured, and all of the SourceRequest
                // objects have been configured and added to the SearchRequest, the
                // application can process the request.

                // Create a SearchResponse object for the SourceResponse objects returned by the query.
                SearchResponse searchResponse;

                // Execute the search request and return the search response by
                // setting the SearchResponse to MSNSearchService.Search(SearchRequest).
                searchResponse = s.Search(searchRequest);

                // Check the SearchResponse to determine whether it contains a spelling suggestion.
                // The spelling suggestion is returned in the Title field of the Spelling SourceResponse.
                // If the SearchResponse does not contain a Spelling SourceResponse, there is no
                // spelling suggestion and the application passes the SearchResponse to the printResults method.
                // If a Spelling SourceResponse is returned, the application displays a MessageBox that asks
                // the user to choose whether to ignore the spelling suggestion, or accept the spelling
                // suggestion and re-execute the query with the updated query string.
                // To test for the presence of the Spelling SourceResponse, check the Total field for
                // the SearchResponse.Response for the Spelling SourceType.
                if (searchResponse.Responses[1].Total != 0)
                    handleSpellingSuggestion(searchResponse, nearMe);
                else
                    printResults(searchResponse);
            }

            // Catch SOAP exceptions.
            catch (SoapException fault)
            {
                MessageBox.Show(fault.Detail.InnerText.ToString());
            }

            // Catch Web exceptions.
            catch (WebException webx)
            {
                MessageBox.Show(webx.ToString());
            }
        }

        public void handleSpellingSuggestion(SearchResponse searchResponse, bool nearMe)
        {
            // Get the spelling suggestion from the Spelling SourceResponse.
            String strSpellingSuggestion = searchResponse.Responses[1].Results[0].Title;
            // Remove tokens from the spelling suggestion.
            char[] trimChars = new char[2];
            trimChars[0] = '\xe000';
            trimChars[1] = '\xe001';
            strSpellingSuggestion = strSpellingSuggestion.Trim(trimChars);
            strSpellingSuggestion = strSpellingSuggestion.Replace(trimChars[0], ' ');
            strSpellingSuggestion = strSpellingSuggestion.Replace(trimChars[1], ' ');

            // Display a MessageBox, and ask the user if he or she wants to accept the suggested spelling.
            // If the user chooses Yes, replace the text in the query text box (txtQuery)
            // with the spelling suggestion, and execute a new query with the changed query string.
            // If the user chooses No, close the MessageBox and pass the SearchResponse, which includes the
            // Spelling SourceResponse, to the printResults method.
            if (MessageBox.Show("Were you looking for " + strSpellingSuggestion + "?", "Spelling Suggestion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                txtQuery.Text = strSpellingSuggestion;
                if (nearMe)
                    executeQuery(true);
                else
                    executeQuery(false);
            }
            else
                printResults(searchResponse);
        }

        public void printResults(SearchResponse searchResponse)
        {
            // Create a new StringBuilder to accumulate the text to be displayed in the WebBrowser
            // control when the search is complete and all results are returned.
            StringBuilder sb = new StringBuilder(8192);

            // Set up the HTML tags for the output returned from the search.
            sb.Append("<HTML><BODY>");

            // Using foreach, loop through all the SourceResponses in the SearchResponse.
            foreach (SourceResponse sourceResponse in searchResponse.Responses)
            {
                // The requested result fields for each SourceRequest are returned in the 
                // Results field of the respective SourceResponse.
                Result[] sourceResults = sourceResponse.Results;

                // For each SourceResponse, determine whether the total number of results returned
                // is greater than zero. If so, print a simple heading for that SourceResponse
                // type. Note that Total is an *estimate* of the total number of returned results,
                // with the exception of Spelling results, which return zero results or one result.
                if (sourceResponse.Total > 0)
                {
                    // List the source type.
                    sb.Append("<H3><B>" + sourceResponse.Source.ToString() + " - Total Results: ");
                    // Show the estimated total of results.
                    sb.Append(sourceResponse.Total.ToString() + "</B></H3><HR>");
                }
                // Using foreach, loop through the results returned in each SourceResponse.
                foreach (Result sourceResult in sourceResults)
                {
                    // Do not print any labels for results that are not returned (NULL) or
                    // contain no text (String.Empty).
                    if ((sourceResult.Title != null) && (sourceResult.Title != String.Empty))
                        sb.Append("<B>Title: </B>" + sourceResult.Title + "<BR>");
                    if ((sourceResult.Description != null) && (sourceResult.Description != String.Empty))
                        sb.Append("<B>Description: </B>" + sourceResult.Description + "<BR>");
                    if ((sourceResult.DisplayUrl != null) && (sourceResult.DisplayUrl != String.Empty))
                        sb.Append("<B>DisplayUrl: </B><A HREF=\"" + sourceResult.DisplayUrl + "\">" + sourceResult.DisplayUrl + "</A><BR>");
                    if ((sourceResult.Url != null) && (sourceResult.Url != String.Empty))
                        sb.Append("<B>Url: </B><A HREF=\"" + sourceResult.Url + "\">" + sourceResult.Url + "</A><BR>");
                    if ((sourceResult.SearchTags != null) && (sourceResult.SearchTags != String.Empty))
                        sb.Append("<B>SearchTags: </B>" + sourceResult.SearchTags + "<BR>");
                    if (sourceResult.SearchTagsArray != null)
                    {
                        sb.Append("<B>SearchTagsArray (Length " + sourceResult.SearchTagsArray.Length.ToString() + ")</B><BR><BR>");
                        int counter = 0;
                        foreach (SearchTag nameValuePair in sourceResult.SearchTagsArray)
                        {
                            sb.Append("<B>SearchTagsArray[" + counter.ToString() + "] Name: </B>" + nameValuePair.Name + "<BR>");
                            sb.Append("<B>SearchTagsArray[" + counter.ToString() + "] Value: </B>" + nameValuePair.Value + "<BR>");
                            counter++;
                        }
                    }
                    if ((sourceResult.CacheUrl != null) && (sourceResult.CacheUrl != String.Empty))
                        sb.Append("<B>CacheUrl: </B><A HREF=\"" + sourceResult.CacheUrl + "\">" + sourceResult.CacheUrl + "</A><BR>");
                    if ((sourceResult.Source != null) && (sourceResult.Source != String.Empty))
                        sb.Append("<B>Source: </B>" + sourceResult.Source + "<BR>");
                    if ((sourceResult.Summary != null) && (sourceResult.Summary != String.Empty))
                        sb.Append("<B>Summary: </B>" + sourceResult.Summary + "<BR>");
                    if ((sourceResult.ResultType != null) && (sourceResult.ResultType != String.Empty))
                        sb.Append("<B>ResultType: </B>" + sourceResult.ResultType + "<BR>");

                    if (sourceResult.DateTime != null)
                    {
                        int year = sourceResult.DateTime.Year;
                        int month = sourceResult.DateTime.Month;
                        int day = sourceResult.DateTime.Day;
                        int hour = sourceResult.DateTime.Hour;
                        int minute = sourceResult.DateTime.Minute;
                        int second = sourceResult.DateTime.Second;

                        System.DateTime newsDateTime = new System.DateTime(year, month, day, hour, minute, second);
                        // Print the raw data for the DateTime returned.
                        sb.Append("<B>NewsDateTime (Raw Data): </B>" + newsDateTime.ToString() + "<BR>");
                        // Print the age of the news story, as on the Live Search Web site.
                        System.TimeSpan newsAge = new System.TimeSpan();
                        newsAge = System.DateTime.Now.ToUniversalTime() - newsDateTime;

                        if ((newsAge.Days == 0) && (newsAge.Hours == 0))
                            sb.Append("<B>NewsDateTime (Age of Story): " + newsAge.Minutes.ToString() + " minutes ago</B><BR>");
                        if ((newsAge.Days == 0) && (newsAge.Hours == 1))
                            sb.Append("<B>NewsDateTime (Age of Story): " + newsAge.Hours.ToString() + " hour ago</B><BR>");
                        else if ((newsAge.Days == 0) && (newsAge.Hours > 1))
                            sb.Append("<B>NewsDateTime (Age of Story): " + newsAge.Hours.ToString() + " hours ago</B><BR>");
                        else if (newsAge.Days >= 1)
                            sb.Append("<B>NewsDateTime (Age of Story): " + newsDateTime.ToShortDateString() + "</B><BR>");
                    }
                    sb.Append("<BR>");

                    // Process PhoneBook results.
                    // If the search was a "Near Me" search, the Location settings are considered as a relevance factor in the 
                    // Web search, and PhoneBook results may also be returned for appropriate queries.
                    // If the SourceType returned is a PhoneBook SourceType, print a label for the Phone field, each field
                    // in the Address Object, and each field in the returned Location object.
                    // Since Address.FormattedAddress is always blank and Location.Radius always returns 5,
                    // these fields are skipped in the sample.
                    // The SecondaryCity and PostalCode fields are not returned for addresses in the United States;
                    // the SecondaryCity field is used for addresses in the United Kingdom.
                    if (sourceResponse.Source == SourceType.PhoneBook)
                    {
                        if ((sourceResult.Phone != null) && (sourceResult.Phone != String.Empty))
                            sb.Append("<B>Phone: </B>" + sourceResult.Phone + "<BR>");
                        if (sourceResult.Address != null)
                        {
                            if ((sourceResult.Address.AddressLine != null) && (sourceResult.Address.AddressLine != String.Empty))
                                sb.Append("<B>AddressLine: </B>" + sourceResult.Address.AddressLine + "<BR>");
                            if ((sourceResult.Address.CountryRegion != null) && (sourceResult.Address.CountryRegion != String.Empty))
                                sb.Append("<B>CountryRegion: </B>" + sourceResult.Address.CountryRegion + "<BR>");
                            if ((sourceResult.Address.PostalCode != null) && (sourceResult.Address.PostalCode != String.Empty))
                                sb.Append("<B>PostalCode: </B>" + sourceResult.Address.PostalCode + "<BR>");
                            if ((sourceResult.Address.PrimaryCity != null) && (sourceResult.Address.PrimaryCity != String.Empty))
                                sb.Append("<B>PrimaryCity: </B>" + sourceResult.Address.PrimaryCity + "<BR>");
                            if ((sourceResult.Address.SecondaryCity != null) && (sourceResult.Address.SecondaryCity != String.Empty))
                                sb.Append("<B>SecondaryCity: </B>" + sourceResult.Address.SecondaryCity + "<BR>");
                            if ((sourceResult.Address.Subdivision != null) && (sourceResult.Address.Subdivision != String.Empty))
                                sb.Append("<B>Subdivision: </B>" + sourceResult.Address.Subdivision + "<BR>");
                        }
                        if (sourceResult.Location != null)
                        {
                            sb.Append("<B>Latitude: </B>" + sourceResult.Location.Latitude.ToString() + "<BR>");
                            sb.Append("<B>Longitude: </B>" + sourceResult.Location.Longitude.ToString() + "<BR>");

                            // Calculate the "Great Circle" distance between the Location specified in the SearchRequest
                            // and the longitude and latitude of each Location returned by the query in miles and kilometers.
                            // 
                            // Note: The distance is calculated based on the values entered in the Latitude and Longitude
                            // text boxes, which are in the user interface in the Location Information section of the Settings tab.
                            // For queries of the form "keyword, place name" or "keyword, ZIP code," this code will not compute
                            // the distance from the center of the city, as returned in the QueryLocation.Location object.
                            double earthRadius = 3963.0;
                            double earthRadiusKM = 6392.0;
                            double latitudeIn = Double.Parse(txtLatitude.Text);
                            double longitudeIn = Double.Parse(txtLongitude.Text);
                            double latitudeOut = sourceResult.Location.Latitude;
                            double longitudeOut = sourceResult.Location.Longitude;
                            double radianConversion = (Math.PI / 180.0);

                            double operandOne;
                            double operandTwo;
                            double acosOfSum;
                            double finalValue;
                            double finalValueKM;

                            operandOne = Math.Cos(radianConversion * (90.0 - latitudeIn)) * Math.Cos(radianConversion * (90.0 - latitudeOut));
                            operandTwo = Math.Sin(radianConversion * (90.0 - latitudeIn)) * Math.Sin(radianConversion * (90.0 - latitudeOut)) * Math.Cos(radianConversion * (longitudeIn - longitudeOut));
                            acosOfSum = Math.Acos(operandOne + operandTwo);
                            finalValue = earthRadius * acosOfSum;
                            finalValueKM = earthRadiusKM * acosOfSum;

                            sb.Append("<B>Distance (Miles): </B>" + finalValue.ToString("F") + "<BR>");
                            sb.Append("<B>Distance (Kilometers): </B>" + finalValueKM.ToString("F") + "<BR><HR>");
                        }
                    }

                    // If the query was of the form "keyword(s) Place_Name" or "keyword(s) ZIP_Code,"
                    // and SourceType.QueryLocation was requested, print a string showing the
                    // QueryLocation result, as on the Live Search Web site. QueryLocation can be used in conjunction
                    // with PhoneBook results for select markets, as listed in the online documentation.
                    // Examples of this type of location-based keyword query are:
                    // "pizza new york," "pizza ottawa," and "pizza 98052."
                    if (sourceResponse.Source == SourceType.QueryLocation)
                    {
                        if (sourceResult.Location != null)
                        {
                            sb.Append("<B>Sample Return String for QueryLocation:</B><BR>");
                            sb.Append("Top local listings for " + "<B>" + sourceResult.Title + "</B>" + " near ");
                            sb.Append("<B>" + sourceResult.Description + "</B>");
                            sb.Append(" (" + sourceResult.Location.Longitude.ToString() + ", " + sourceResult.Location.Latitude.ToString() + ")<BR>");
                        }
                    }
                    if (sourceResult.Image != null)
                    {
                        if (sourceResult.Image.ThumbnailFileSizeSpecified)
                            sb.Append("<B>Thumbnail File Size: </B>" + sourceResult.Image.ThumbnailFileSize.ToString() + "<BR>");
                        if (sourceResult.Image.ThumbnailHeightSpecified && sourceResult.Image.ThumbnailWidthSpecified)
                            sb.Append("<B>Thumbnail Height: </B>" + sourceResult.Image.ThumbnailHeight.ToString() +
                                "<B>, Thumbnail Width: </B>" + sourceResult.Image.ThumbnailWidth.ToString() + "<BR>");
                        sb.Append("<B>Thumbnail:</B><BR><IMG SRC=\"" + sourceResult.Image.ThumbnailURL + "\"></A><BR>");
                        if (sourceResult.Image.ImageFileSizeSpecified)
                            sb.Append("<B>Image File Size: </B>" + sourceResult.Image.ImageFileSize.ToString() + "<BR>");
                        if (sourceResult.Image.ImageHeightSpecified && sourceResult.Image.ImageWidthSpecified)
                            sb.Append("<B>Image Height: </B>" + sourceResult.Image.ImageHeight.ToString() +
                                "<B>, Image Width: </B>" + sourceResult.Image.ImageWidth.ToString() + "<BR>");
                        sb.Append("<B>Full Size Image URL: </B><A HREF=\"" + sourceResult.Image.ImageURL + "\">" + sourceResult.Image.ImageURL + "</A><BR><HR>");
                    }
                }
                // Close the BODY and HTML tags.
                sb.Append("</BODY></HTML>");

                // Handle the user request for query word marking. Query words are marked with
                // the Unicode characters 0xE000 and 0xE001 (begin and end, respectively).
                // Create String objects for each Unicode character.
                if (chkQueryWordMarking.Checked)
                {
                    string MarkBegin = "\xe000";
                    string MarkEnd = "\xe001";
                    // Replace the marking characters with boldface tags in the text.
                    sb.Replace(MarkBegin, "<B>");
                    sb.Replace(MarkEnd, "</B>");
                }
            }
            // Set the text of the WebBrowser control to the HTML contained in the StringBuilder.
            webBrowser1.DocumentText = sb.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Call Method executeQuery with "false" to indicate that the search is not for PhoneBook results,
            // and that Location should not be included as a factor in relevance.
            executeQuery(false);
        }

        private void btnNearMe_Click(object sender, EventArgs e)
        {
            // Call Method executeQuery with "true" to indicate that the search is for PhoneBook results,
            // and that Location should be included as a factor in relevance.
            executeQuery(true);
        }
    }
}