using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace GazoUpdate
{
    class GitHubApi
    {

        string lastinfo;

        public GitHubApi()
        {
            lastinfo = HTTPGET("https://api.github.com/repos/SlaynationCoder/GAZO/releases/latest");
        }

        public string getLastestVer()
        {
            var model = new JavaScriptSerializer().Deserialize<dynamic>(lastinfo);
            string ret = model["name"];

            return ret;
        }

        public string getLastestURL()
        {
            dynamic  model = new JavaScriptSerializer().Deserialize<dynamic>(lastinfo);

            string ret = model["assets"][0]["browser_download_url"];

            return ret;
        }



        public string HTTPGET(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            req.UserAgent = "GAZO";

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            Stream s = res.GetResponseStream();
            StreamReader sr = new StreamReader(s);
            return sr.ReadToEnd();
        }
    }
}
