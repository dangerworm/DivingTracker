using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace DivingTracker.ServiceLayer.Helpers
{
    public class WebHelper
    {
        public static HtmlDocument GetHtmlDocument(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            var stream = response.GetResponseStream();
            if (stream == null)
            {
                return null;
            }

            var html = new StreamReader(stream).ReadToEnd();

            var document = new HtmlDocument();
            document.LoadHtml(html);

            return document;
        }
    }
}
