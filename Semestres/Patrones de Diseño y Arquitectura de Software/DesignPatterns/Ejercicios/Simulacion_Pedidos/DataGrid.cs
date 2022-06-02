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
			Console.WriteLine("Writing in datagrid -> {0}", newLine);
		}
		public void addToDataGrid(Form3 formObject)
		{
			formObject.textBox1.Text = "-" + newLine + " " + DateTime.Now.ToShortTimeString();
		}
	}
}
