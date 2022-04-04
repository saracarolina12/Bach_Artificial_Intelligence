using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;

namespace AlumniApp
{
	// The Adaptee contains some useful behavior, but its interface is
	// incompatible with the existing client code. The Adaptee needs some
	// adaptation before the client code can use it. (XML)
	class Adaptee
	{
		/// A specific request that needs an adapter.
		public Root ReadJSON(string ruta) //sólo lee JSONS
		{
			
			//throw new NotImplementedException("SpecificRequest is not implemented.");
			//StreamReader read = new StreamReader("..\\..\\Data.json");
			StreamReader read = new StreamReader(ruta);
			using (read)
			{
				string json = read.ReadToEnd();
				Root data = JsonConvert.DeserializeObject<Root>(json);
				return data;
			}
			
		}
	}

}