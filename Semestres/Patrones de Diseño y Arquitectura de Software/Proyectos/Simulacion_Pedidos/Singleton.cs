using System.Collections.Specialized;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Simulacion_Pedidos
{
    class Singleton
    {
		private static Singleton _instance = null;

		public static Singleton Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Singleton();
				}

				return _instance;
			}
		}

		public static Singleton GetInstance()
		{
			if (_instance == null) 
			{
				_instance = new Singleton();
			}
			return _instance;
		}

		public static string GenerateRoute()
        {
			var fileCount = (from file in Directory.EnumerateFiles("..\\..\\Stores-data\\QRs\\", "*.png", SearchOption.AllDirectories)
							 select file).Count();
			DirectoryInfo d = new DirectoryInfo("..\\..\\Stores-data\\QRs\\"); //Folder where we are going to iterate
            FileInfo[] Files = d.GetFiles("*.png"); //Getting png files

			if(Start.route_index != fileCount+1)
            {
				Start.route_index++;
				return "..\\..\\Stores-data\\QRs\\Tienda_" + (Start.route_index - 1) + ".png";
            }
			
			return "returnF1";
        }

		
	}
}
