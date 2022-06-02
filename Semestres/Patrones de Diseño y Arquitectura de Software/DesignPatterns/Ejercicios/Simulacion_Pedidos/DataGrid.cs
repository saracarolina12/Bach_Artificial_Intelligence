using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_Pedidos
{
	class DataGrid : Strategy
	{
		public string newLine { get; set; }
		public override void AlgorithmInterface()
		{
			Console.WriteLine("Writing in datagrid -> {0}", newLine);
		}
	}
}
