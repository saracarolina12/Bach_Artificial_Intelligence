using System;

namespace BuilderPattern
{
	/// The concrete builder class for product type 2.
	class Computer_Medium : Computer_Builder
	{
		// the product being constructed
		private Computer _computer = new Computer();
		// nombre del fabricante, el modelo y el precio de venta
		public override void IncludeCentralUnit()
		{

			//_computer.Add(null);
		}

		public override void IncludeComponent()
		{
			//_computer.Add(null);
		}

		public override Computer Computer_GetResult()
		{
			return _computer;
		}
	}
}

