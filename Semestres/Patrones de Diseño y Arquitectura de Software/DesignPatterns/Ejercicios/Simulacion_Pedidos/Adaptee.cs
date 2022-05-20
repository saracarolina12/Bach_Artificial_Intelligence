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
            StreamReader read = new StreamReader(ruta);
            using (read)
            {
                string json = read.ReadToEnd();
                data = JsonConvert.DeserializeObject<Root[]>(json);
                return data;
            }

            //e decoder = new QRCodeDecoder();
            //String decodedString = decoder.decode(ruta);
            //return decodedString;

            //FileInfo fileInfo = new FileInfo(ruta);
            //byte[] data = new byte[fileInfo.Length];
            //using (FileStream fs = fileInfo.OpenRead())
            //{
            //   fs.Read(data, 0, data.Length);
            //}
            //fileInfo.Delete();
            //PictureBox.Image = data;
            //MessagingToolkit.QRCode.Codec.QRCodeDecoder decoder = new MessagingToolkit.QRCode.Codec.QRCodeDecoder();

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
