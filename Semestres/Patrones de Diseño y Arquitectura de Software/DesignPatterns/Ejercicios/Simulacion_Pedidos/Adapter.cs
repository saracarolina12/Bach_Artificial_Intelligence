using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_Pedidos
{
	// The adapter makes the QR library compatible
	class Adapter : Target
	{
		private Adaptee _adaptee = new Adaptee();

		public override Root[] Read(string ruta)
		{
			// possibly do some other work ...
			return _adaptee.ReadQR(ruta);
		}
		public override bool Write()
		{
			// possibly do some other work ...
			return _adaptee.WriteQR();
		}
	}
}
