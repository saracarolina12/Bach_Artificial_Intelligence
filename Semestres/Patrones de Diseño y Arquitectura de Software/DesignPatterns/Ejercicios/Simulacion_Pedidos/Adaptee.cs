using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;


namespace Simulacion_Pedidos
{ 
	//QR Library update
	class Adaptee
	{
		/// A specific request that needs an adapter.
		public static Root[] data;
        public static Bitmap mywrite;
        public static Bitmap qr = null;
        //public static Root[] JSONdata;
        public static Root[] ReadQR(string ruta) //Decode
		{
            if(ruta != "init")
            {
                FileInfo fileInfo = new FileInfo(ruta);
                byte[] JSONdata = new byte[fileInfo.Length];
                using (FileStream fs = fileInfo.OpenRead())
                {
                    fs.Read(JSONdata, 0, JSONdata.Length);
                    fs.Close();
                    fs.Dispose();
                }
                //fileInfo.Delete();
                Image myimage;
                using (MemoryStream memstr = new MemoryStream(JSONdata))
                {
                    myimage = Image.FromStream(memstr);
                    memstr.Dispose();
                }
                //QR_container.BackgroundImage = myimage;
                QRCodeDecoder decoder = new QRCodeDecoder();
                string json = decoder.Decode(new QRCodeBitmapImage(myimage as Bitmap));
                data = JsonConvert.DeserializeObject<Root[]>(json);
                //File.Delete(Start.global_route);
                return data;
            }
            return null;
        }

        public static Bitmap WriteQR(Root[] JSONdata) //Encode
        {

            Root[] root = JSONdata;
            string jsontoQR = JsonConvert.SerializeObject(root);

            //QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            //QrCode qrCode = new QrCode();
            //qrEncoder.TryEncode(jsontoQR, out qrCode);
            //Bitmap imageTemporal;
            //GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            //    imageTemporal = new Bitmap(ms);
            //    ms.Close();
            //}
            //mywrite = imageTemporal;
            //return mywrite;
            var encoder = new QRCodeEncoder();
            encoder.QRCodeScale = 6;
            qr = encoder.Encode(jsontoQR);
            return qr;

        }

        public static void SavePNG(string path)
        {
            if (qr != null) 
            {
                Image img = (Image)qr;
                bool result = File.Exists(path);
                if (result == true)
                {
                    File.Delete(path);
                }
                Console.WriteLine("QR saved");
                Start.selectStrategy();
                img.Save(path);
                img.Dispose();
            }
        }

    }
}
