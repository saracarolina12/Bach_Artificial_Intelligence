using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_Pedidos
{
	class TextFile : Strategy
	{
		public override void AlgorithmInterface()
		{
			Console.WriteLine("Writing in TextFile");
		}
	}
}
