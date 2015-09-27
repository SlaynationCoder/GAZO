using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace Gazo
{
    class FTPAPI
    {
        string user;
        string pass;
        public FTPAPI()
        {
            user = "gazoserver";
            pass = "r&$a4A2$";
        }
        WebClient wc = new WebClient();
        public void Up(byte[] f, string URL)
        {
            wc.Credentials = new NetworkCredential(user, pass);
            wc.UploadData(URL, f);
        }

        }
}
