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
	// The adapter makes the QR library compatible
	class Adapter : Target
	{
		private Adaptee _adaptee = new Adaptee();

		public override Root[] Read(string ruta)
		{
			// possibly do some other work ...
			return Adaptee.ReadQR(ruta);
		}
		public override Bitmap Write(Root[] JSONdata)
		{
			// possibly do some other work ...
			return Adaptee.WriteQR(JSONdata);
		}
	}
}
