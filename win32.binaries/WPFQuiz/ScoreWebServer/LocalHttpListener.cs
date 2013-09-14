/*
A trivia game framework for Microsoft Windows

Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Ollie Whitehouse, ollie dot whitehouse at nccgroup dot com

https://github.com/nccgroup/44Con2013Game

Released under AGPL see LICENSE for more information
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace ScoreWebServer
{

    public class Result
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Time { get; set; }
    }

    public class MyOrderingClass : IComparer<Result>
    {
        public int Compare(Result x, Result y)
        {
            int compareData = x.Level.CompareTo(y.Level);
            if (compareData == 0)
            {
                // This is a hack
                if (x.Time.CompareTo(y.Time) > 0) return -1;
                else if (x.Time.CompareTo(y.Time) == 0) return 0;
                else return 1;
            }
            return compareData;
        }
    }


    class LocalHttpListener
    {
        public const string UriAddress = "http://*:8888/";
        HttpListener _httpListener;
        private List<Result> Results = new List<Result>();

        public LocalHttpListener()
        {
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(LocalHttpListener.UriAddress);
        }

        public void Start()
        {
            _httpListener.Start();

            while (_httpListener.IsListening)
                ProcessRequest();
        }

        public void Stop()
        {
            _httpListener.Stop();
        }

        void ProcessRequest()
        {
            var result = _httpListener.BeginGetContext(ListenerCallback, _httpListener);
            result.AsyncWaitHandle.WaitOne();
        }


        string GenerateResults()
        {
            StringBuilder strOut = new StringBuilder();
            Results.Clear();

            /*
            strOut.Append("<HTML>");
            strOut.Append("<HEAD>");
            strOut.Append("<TITLE>");
            strOut.Append("NCC Group 44Con Challenge");
            strOut.Append("</TITLE>");
            strOut.Append("<meta http-equiv=\"refresh\" content=\"5\">");
            strOut.Append("</HEAD>");
            strOut.Append("<BODY>");
            */

            foreach(string strFile in Directory.EnumerateFiles("C:\\NCCPlayers\\","*.xml")){
                string xmlText = File.ReadAllText(strFile);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlText);
                Result resThis = null;

                try
                {
                    XmlNode xmlName = xmlDoc.GetElementsByTagName("PlayerName")[0];
                    XmlNode xmlL = xmlDoc.GetElementsByTagName("Level")[0];
                    XmlNode xmlS = xmlDoc.GetElementsByTagName("Seconds")[0];
                    resThis = new Result();
                    resThis.Name = xmlName.InnerText;
                    resThis.Level = Convert.ToInt32(xmlL.InnerText);
                    resThis.Time = Convert.ToInt32(xmlS.InnerText);
                }
                catch
                {
                    resThis = new Result();
                    resThis.Name = "Unknown";
                    resThis.Level = 0;
                    resThis.Time = 0;
                }

                

                Results.Add(resThis);                
            }

            // http://stackoverflow.com/questions/3309188/c-net-how-to-sort-a-list-t-by-a-property-in-the-object
            IComparer<Result> myCompare = new MyOrderingClass();
            Results.Sort(myCompare);
            Results.Reverse();
                       
           /*
            strOut.Append("<CENTER>");

            strOut.Append("<style type=\"text/css\">");
            strOut.Append("body { font-family: \"Segoe UI\", Arial, Helvetica, sans-serif; font-size:40px; }");
            strOut.Append("td { font-family: \"Segoe UI\", Arial, Helvetica, sans-serif; font-size:40px; }");
            strOut.Append("</style>");
            strOut.Append("<TABLE BORDER=\"0\" CELLSPACING=\"5\" CELLPADDING=\"10\">");
            
            strOut.Append("<TR>");
                strOut.Append("<TD>Name</TD>");
                strOut.Append("<TD>Level Achieved</TD>");
                strOut.Append("<TD>Total Seconds</TD>");
            strOut.Append("</TR>");
            */
             
            //int intCount = 0;
            foreach (Result thisRes in Results)
            {
                strOut.Append(thisRes.Name + "," + thisRes.Level + "," + thisRes.Time + Environment.NewLine);

                /*
                if (intCount == 10) break;
                intCount++;
                strOut.Append("<TR>");
                    strOut.Append("<TD> " + thisRes.Name + "</TD>");
                    strOut.Append("<TD> " + thisRes.Level + "</TD>");
                    strOut.Append("<TD> " + thisRes.Time + "</TD>");
                strOut.Append("</TR>");
                 */
            }

            /*
            strOut.Append("</TABLE>");
            strOut.Append("</CENTER>");
            strOut.Append("</BODY>");
            strOut.Append("</HTML>");
            */

            return strOut.ToString();
        }

        void ListenerCallback(IAsyncResult result)
        {
            var context = _httpListener.EndGetContext(result);
            var info = Read(context.Request);

            if(context.Request.Url.AbsolutePath.Equals("/NCC.png")){
                CreateResponse(context.Response, "Image");
            } else {
                Console.WriteLine(GenerateResults());
                CreateResponse(context.Response, GenerateResults());
            }

            Console.WriteLine("Server received: {0}{1}", Environment.NewLine, info.ToString());

            
        }

        public static WebRequestInfo Read(HttpListenerRequest request)
        {
            var info = new WebRequestInfo();
            info.HttpMethod = request.HttpMethod;
            info.Url = request.Url;

            if (request.HasEntityBody)
            {
                Encoding encoding = request.ContentEncoding;
                using (var bodyStream = request.InputStream)
                using (var streamReader = new StreamReader(bodyStream, encoding))
                {
                    if (request.ContentType != null)
                        info.ContentType = request.ContentType;

                    info.ContentLength = request.ContentLength64;
                    info.Body = streamReader.ReadToEnd();
                }
            }

            return info;
        }

        public static WebResponseInfo Read(HttpWebResponse response)
        {
            var info = new WebResponseInfo();
            info.StatusCode = response.StatusCode;
            info.StatusDescription = response.StatusDescription;
            info.ContentEncoding = response.ContentEncoding;
            info.ContentLength = response.ContentLength;
            info.ContentType = response.ContentType;

            using (var bodyStream = response.GetResponseStream())
            using (var streamReader = new StreamReader(bodyStream, Encoding.UTF8))
            {
                info.Body = streamReader.ReadToEnd();
            }

            return info;
        }

        private static void CreateResponse(HttpListenerResponse response, string body)
        {
            response.StatusCode = (int)HttpStatusCode.OK;
            response.StatusDescription = HttpStatusCode.OK.ToString();
            byte[] buffer = Encoding.UTF8.GetBytes(body);
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        }
    }

    public class WebRequestInfo
    {
        public string Body { get; set; }
        public long ContentLength { get; set; }
        public string ContentType { get; set; }
        public string HttpMethod { get; set; }
        public Uri Url { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("HttpMethod {0}", HttpMethod));
            sb.AppendLine(string.Format("Url {0}", Url));
            sb.AppendLine(string.Format("ContentType {0}", ContentType));
            sb.AppendLine(string.Format("ContentLength {0}", ContentLength));
            sb.AppendLine(string.Format("Body {0}", Body));
            return sb.ToString();
        }
    }

    public class WebResponseInfo
    {
        public string Body { get; set; }
        public string ContentEncoding { get; set; }
        public long ContentLength { get; set; }
        public string ContentType { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("StatusCode {0} StatusDescripton {1}", StatusCode, StatusDescription));
            sb.AppendLine(string.Format("ContentType {0} ContentEncoding {1} ContentLength {2}", ContentType, ContentEncoding, ContentLength));
            sb.AppendLine(string.Format("Body {0}", Body));
            return sb.ToString();
        }
    }
}
