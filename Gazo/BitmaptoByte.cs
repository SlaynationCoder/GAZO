using System;
using System.Drawing;

namespace Gazo
{
    class BitmaptoPNGByte
    {
        public static byte[] Convert(Bitmap bmp)
        {
            System.IO.MemoryStream mms1 =new System.IO.MemoryStream();

            bmp.Save(mms1,System.Drawing.Imaging.ImageFormat.Png);
            
            Byte[] dats = mms1.GetBuffer();
            mms1.Close();

            return dats;
        }
    }
}
