using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_Pedidos
{
	class TextBox : Strategy
	{
		public string newLine { get; set; }
		public override void AlgorithmInterface()
		{
			Console.WriteLine("Writing in TextBox -> {0}", newLine);
		}
		public void addToDataGrid(Form3 formObject)
		{
			Start.textArray.Add(new KeyValuePair<string, string>("-" + newLine, " ~ " + DateTime.Now.ToShortTimeString()));
		}
	}
}
