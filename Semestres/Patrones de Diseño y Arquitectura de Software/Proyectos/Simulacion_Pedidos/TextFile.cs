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
		public string newLine { get; set; }
		public override void AlgorithmInterface()
		{
			Console.WriteLine("2 TextFile -> {0}", newLine);
			File.AppendAllLines(Start.report_route, new[] {"*"+newLine+ " - " + DateTime.Now.ToShortTimeString() });
		}
	}
}
