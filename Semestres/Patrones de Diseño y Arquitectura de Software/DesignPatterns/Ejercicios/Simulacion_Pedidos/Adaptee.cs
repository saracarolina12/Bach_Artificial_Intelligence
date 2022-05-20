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
using System.IO;
using Newtonsoft.Json;


namespace Simulacion_Pedidos
{ 
	//QR Library update
	class Adaptee
	{
		/// A specific request that needs an adapter.
		public static Root[] data;
        public static bool mywrite;
        public Root[] ReadQR(string ruta) //sólo lee JSONS
		{
            Console.WriteLine("readQR");
            StreamReader read = new StreamReader(ruta);
			using (read)
			{
                string json = read.ReadToEnd();
                data = JsonConvert.DeserializeObject<Root[]>(json);
                return data;
			}

		}

        public bool WriteQR(Bitmap imagen)
        {
            Console.WriteLine("WriteQR");
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode("ddfsh", out qrCode);

            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            Bitmap imageTemporal = new Bitmap(ms);
            imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));


            imagen.Save("QR-code", ImageFormat.Png);

            QR_container.BackgroundImage = imagen;
            //Save image as png
            Image image = (Image)QR_container.BackgroundImage.Clone();
            string path = @"C:\Users\scago\Downloads\QRs\store-QR.png";
            image.Save(path);

            mywrite = true;
            return mywrite;
        }

     
    }
}
