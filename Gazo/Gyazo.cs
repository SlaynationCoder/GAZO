using System;
using System.Drawing;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;

namespace Gazo
{
    class Gyazo
    {
        public string APIkey { get; private set; }


        public Gyazo(string apikey)
        {
            APIkey = apikey;
        }

        public string Upload(Bitmap img)
        {

            string resp;

            byte[] imgbytes = BitmaptoPNGByte.Convert(img);

            //送信先のURL
            string url = "https://upload.gyazo.com/api/upload";
            Encoding enc = Encoding.UTF8;
            string boundary = Environment.TickCount.ToString();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            req.Method = "POST";
            req.ContentType = "multipart/form-data; boundary=" + boundary;

            //POST
            string postData = "";
            postData = "--" + boundary + "\r\n" +
                "Content-Disposition: form-data; name=\"access_token\"\r\n\r\n" +
                APIkey + "\r\n" +
                "--" + boundary + "\r\n" +
                "Content-Disposition: form-data; name=\"imagedata\"; filename=\"" +
                    "temp.png" + "\"\r\n" +
                "Content-Type: application/octet-stream\r\n" +
                "Content-Transfer-Encoding: binary\r\n\r\n";

            //convert bytes
            byte[] startData = enc.GetBytes(postData);
            postData = "\r\n--" + boundary + "--\r\n";
            byte[] endData = enc.GetBytes(postData);

            MemoryStream ms = new MemoryStream(imgbytes);

            //POST送信するデータの長さを指定
            req.ContentLength = startData.Length + endData.Length + ms.Length;

            //データをPOST送信するためのStreamを取得
            System.IO.Stream reqStream = req.GetRequestStream();
            //送信するデータを書き込む
            reqStream.Write(startData, 0, startData.Length);
            //ファイルの内容を送信

            byte[] readData = new byte[0x1000];
            int readSize = 0;
            while (true)
            {
                readSize = ms.Read(readData, 0, readData.Length);
                if (readSize == 0)
                    break;
                reqStream.Write(readData, 0, readSize);
            }

            ms.Close();
            reqStream.Write(endData, 0, endData.Length);
            reqStream.Close();

            //サーバーからの応答を受信するためのWebResponseを取得
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            //応答データを受信するためのStreamを取得
            System.IO.Stream resStream = res.GetResponseStream();
            //受信して表示
            StreamReader sr =new StreamReader(resStream, enc);
            resp = sr.ReadToEnd();
            //閉じる
            sr.Close();



            var model = new JavaScriptSerializer().Deserialize<dynamic>(resp);
            var imagelink = model["permalink_url"];

            return imagelink;
        }
    }
}
