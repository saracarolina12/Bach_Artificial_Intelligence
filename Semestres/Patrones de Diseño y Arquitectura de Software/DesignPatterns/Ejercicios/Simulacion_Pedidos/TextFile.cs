using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Simulacion_Pedidos
{
	class TextFile : Strategy
	{
		public override void AlgorithmInterface()
		{
			Console.WriteLine("Writing in TextFile");
			File.AppendAllLines(Start.report_route, new[] {"new line: "+ DateTime.Now.ToShortTimeString() });
		}
	}
}
