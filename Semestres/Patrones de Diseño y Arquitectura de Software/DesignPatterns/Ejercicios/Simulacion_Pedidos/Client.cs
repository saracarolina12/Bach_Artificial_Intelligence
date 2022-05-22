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
	public class Client //administra queries (id, etc)
	{
		private Root[] data;
		private Root[] JSONdata;
		public void getQR()
		{
			Target adapter = new Adapter(); // wrap the adaptee with an adapter
			//data = adapter.Read("..\\..\\Stores-data\\JSONS\\Sarita.json"); // use the adapter to make a request  -- JSON --
			data = adapter.Read("..\\..\\Stores-data\\QRs\\Tienda_2.png");
			Bitmap towrite = adapter.Write(JSONdata);
		}
	}
}
