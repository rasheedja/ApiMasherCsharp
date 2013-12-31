using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;




    public class DoHttp
    {
        public object DoGet(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);
            request.Method = "GET";
            String json = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                json = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var serializer = new JavaScriptSerializer();
            //var jsonObject = serializer.DeserializeObject(json) as Dictionary<string, object>;
            var dict = serializer.Deserialize<Dictionary<string, dynamic>>(json);
            Dal Dal = new Dal();
            Dal GuardianPost = new Dal();

            foreach (IDictionary list in dict.Values)
            {
                foreach (dynamic items in list)
                {
                    var key = items.Key;
                    var value = items.Value;
                    string mykey = items.Key;
                    string category = string.Empty;
                    string img = string.Empty;
                    switch (mykey)
                    {
                        case "results":
                            {
                                ArrayList ParentList = value;
                                foreach (dynamic childlist in ParentList)
                                {
                                    foreach (dynamic childlistitems in childlist)
                                    {
                                        string listItemKey = childlistitems.Key;
                                        var fieldsKey = childlistitems.Key;
                                        string sectionname = string.Empty;
                                        string Tags = string.Empty;
                                        string headline = string.Empty;
                                        string body = string.Empty;
                                       
                                        string trailText = string.Empty;
                                        string shortUrl = string.Empty;
                                        string byline = string.Empty;
                                     
                                        switch (listItemKey)
                                        {
                                                 

                                            case "sectionName":
                                                {
                                                   category = childlistitems.Value;
                                                
                                                }
                                                break;
                                            case "fields":
                                                {
                                                    dynamic fieldvalues;
                                                    fieldvalues = childlistitems.Value;
                                                    foreach (dynamic Html in fieldvalues)
                                                    {
                                                         Tags = Html.Key;
                                                     

                                                        switch (Tags)
                                                        {
                                                            case "headline":
                                                                {
                                                                     headline = Html.Value;
                                                                };
                                                                break;
                                                            case "body":
                                                                {
                                                                    body = Html.Value;
                                                                   
                                                                };
                                                                break;
                                                            case "thumbnail":
                                                                {
                                                                   img = Html.Value;
                                                                };
                                                                break;
                                                            case "trailText":
                                                                {
                                                                   trailText = Html.Value;
                                                                };
                                                                break;
                                                            case "shortUrl":
                                                                {
                                                                    shortUrl = Html.Value;
                                                                };
                                                                break;
                                                            case "byline":
                                                                {
                                                                    byline = Html.Value;
                                                                };
                                                                break;

                                                              
                                                                         //Category, HeadLine, Body, Img, ByeLine, ShortUrl, TrailText, InsDateTime)
                                                                    //(@Category,@Headline,@StoryData,@Img,@ByeLine,@ShortUrl,@TrailText,)
                                                        };

                                                 


                                                    };
                                                    string exclude = "<!-- Redistribution rights for this field are unavailable -->";
                                                    if (body != exclude)
                                                    {
                                                        Dal.ExecSp7P("[AddGuardianStories]", "@Category", category, "@Headline", headline, "@StoryData", body, "@Img", img, "@ByeLine", byline, "@ShortUrl", shortUrl, "@TrailText", trailText);

                                                    };
                                                };
                                                break;
                                        };
                                    };
                                };
                            };
                            break;
                    };
                };
            };

            return "";
        }
    };





