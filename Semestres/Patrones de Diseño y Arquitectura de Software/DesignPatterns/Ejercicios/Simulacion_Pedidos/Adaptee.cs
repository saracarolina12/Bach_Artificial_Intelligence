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
        public Root[] ReadQR(string ruta) //Decode
		{
            Console.WriteLine("readQR");
            FileInfo fileInfo = new FileInfo("..\\..\\Stores-data\\QRs\\Tienda_1.png");
            Console.WriteLine(fileInfo.Length);
            byte[] JSONdata = new byte[fileInfo.Length];
            using (FileStream fs = fileInfo.OpenRead())
            {
                fs.Read(JSONdata, 0, JSONdata.Length);
            }
            //fileInfo.Delete();
            Image myimage;
            using (MemoryStream memstr = new MemoryStream(JSONdata))
            {
                myimage = Image.FromStream(memstr);
            }
            //QR_container.BackgroundImage = myimage;
            MessagingToolkit.QRCode.Codec.QRCodeDecoder decoder = new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
            string json = decoder.Decode(new QRCodeBitmapImage(myimage as Bitmap));
            data = JsonConvert.DeserializeObject<Root[]>(json);
            return data;

        }

        public Bitmap WriteQR() //Encode
        {
            Console.WriteLine("WriteQR");
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode("holamundou", out qrCode);

            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            Bitmap imageTemporal = new Bitmap(ms);
            mywrite = imageTemporal;
            return mywrite;
        }

     
    }
}
