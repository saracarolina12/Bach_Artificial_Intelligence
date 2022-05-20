using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_Pedidos
{
	public class Client //administra queries (id, etc)
	{
		private Root[] data;
		public void getQR()
		{
			Target adapter = new Adapter(); // wrap the adaptee with an adapter
			data = adapter.Read("..\\..\\Stores-data\\JSONS\\Sarita.json"); // use the adapter to make a request
			bool towrite = adapter.Write();
		}
	}
}
