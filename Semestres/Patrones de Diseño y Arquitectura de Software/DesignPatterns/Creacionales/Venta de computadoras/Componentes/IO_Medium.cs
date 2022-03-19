using System;

namespace BuilderPattern
{
	/// The concrete builder class for product type 2.
	class IO_Input : IO_Builder
	{
		// the product being constructed
		private IO _IO = new IO();
		// nombre del fabricante, el modelo y el precio de venta
		public override void BuildCentralUnit()
		{
			Console.WriteLine("-> medium Central Unit builded");

			_IO.Add("IO Central Unit");
		}

		public override void BuildComponent()
		{
			Console.WriteLine("-> medium Components builded");
			_IO.Add("IO Components");
		}

		public override IO IO_GetResult()
		{
			Console.WriteLine("--- medium IO result: {0}",_IO,"---");
			return _IO;
		}
	}
}

