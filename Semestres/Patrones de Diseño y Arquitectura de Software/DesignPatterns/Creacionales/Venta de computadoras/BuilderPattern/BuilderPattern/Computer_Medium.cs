using System;

namespace BuilderPattern
{
	/// The concrete builder class for product type 2.
	class Computer_Medium : Computer_Builder
	{
		// the product being constructed
		private Computer _computer = new Computer();
		// nombre del fabricante, el modelo y el precio de venta
		public override void BuildCentralUnit()
		{
			Console.WriteLine("-> Medium Central Unit builded");

			_computer.Add("Medium Central Unit");
		}

		public override void BuildComponent()
		{
			Console.WriteLine("-> Medium Components builded");
			_computer.Add("Medium Components");
		}

		public override Computer Computer_GetResult()
		{
			Console.WriteLine("--- Medium computer result: {0}",_computer,"---");
			return _computer;
		}
	}
}

