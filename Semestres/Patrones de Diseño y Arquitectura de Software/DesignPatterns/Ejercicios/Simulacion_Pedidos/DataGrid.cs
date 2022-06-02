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
			//Form3._Form3.update("change text");
			Console.WriteLine("1 Datagrid -> {0}", newLine);
		}
		
		public void addToDataGrid(Form3 formObject)
		{
			Start.textArrayDG.Add(new KeyValuePair<string, string>(newLine, DateTime.Now.ToShortTimeString()));
		}
	}
}
