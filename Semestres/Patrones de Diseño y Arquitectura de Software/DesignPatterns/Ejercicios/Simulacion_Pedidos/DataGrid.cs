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
			Console.WriteLine("1 Datagrid -> {0}", newLine);
		}
		
		public void addToDataGrid()
		{
			Start.textArrayDG.Add(new KeyValuePair<string, string>(newLine, DateTime.Now.ToShortTimeString()));
		}
	}
}
