using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Gazo
{
    class GazoAPI
    {

        public GazoAPI()
        {

        }

        public string Upload(Bitmap img)
        {
            string tp = Path.GetTempPath() + "temp.png";

            img.Save(tp, ImageFormat.Png);

            //送信先のURL
            string url = "http://gazo1.cf/api/upload.php";

            System.Net.WebClient wc = new System.Net.WebClient();
            //データを送信し、また受信する
            //byte[] resData = wc.UploadData(url, imgbytes);
            byte[] resData = wc.UploadFile(url, tp);
            //受信したデータを表示する
            string resText = System.Text.Encoding.UTF8.GetString(resData);
            Console.WriteLine(resText);

            File.Delete(tp);

            return resText;
        }
    }
}
