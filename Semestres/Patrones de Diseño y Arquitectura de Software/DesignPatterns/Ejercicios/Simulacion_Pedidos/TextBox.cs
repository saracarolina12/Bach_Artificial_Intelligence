using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_Pedidos
{
	class TextBox : Strategy
	{
		public override void AlgorithmInterface()
		{
			Console.WriteLine("Writing in TextBox");
		}
	}
}
