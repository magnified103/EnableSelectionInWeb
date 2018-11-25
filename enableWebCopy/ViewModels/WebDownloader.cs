using System.IO;
using System.Net;
using System.Linq;

namespace enableWebCopy
{
    public class WebDownloader
    {
        private string URL;
        public WebDownloader(string url)
        {
            URL = url;
        }
        public WebDownloader()
        {
            URL = string.Empty;
        }
        public void SetURL(string url)
        {
            URL = url;
        }
        public string GetName()
        {
            return URL.Split('/').ToList().Last();
        }
        public bool IsURLEmpty()
        {
            return (URL.Length == 0) ? true : false;
        }
        public string getWebPageSource()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(URL);
            WebResponse webResponse = webRequest.GetResponse();
            Stream webStream = webResponse.GetResponseStream();
            StreamReader tempReader = new StreamReader(webStream);

            string webContent = tempReader.ReadToEnd();

            tempReader.Close();
            webStream.Close();
            webResponse.Close();

            return webContent;
        }
    }
}