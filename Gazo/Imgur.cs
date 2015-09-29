using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Gazo
{
    class Imgur
    {

        public string ClientID { get; private set; }

        public Imgur(string clientID)
        {
            ClientID = clientID;
        }

        public string Upload(Bitmap img)
        {

            var content = BitmaptoPNGByte.Convert(img);

            string resp;

            using (var w = new WebClient())
            {
                var values = new NameValueCollection();

                values.Add("image", Convert.ToBase64String(content));

                w.Headers.Add("Authorization", "Client-ID " + ClientID);
                byte[] response = w.UploadValues("https://api.imgur.com/3/upload", values);
                resp = Encoding.UTF8.GetString(response);
            }

            var model = new JavaScriptSerializer().Deserialize<dynamic>(resp);
            var imagelink = model["data"]["link"];

            return imagelink;
        }

    }
}
