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
	public abstract class Target
	{
		public abstract Root[] Read(string ruta);
		public abstract Bitmap Write(Root[] JSONdata);
	}
}
