using System;

namespace BuilderPattern
{
	class Computer_Basic : Computer_Builder
	{
		// the product being constructed
		private Computer _computer = new Computer();
		public override void BuildCentralUnit()
		{
			Console. WriteLine("Basic Central Unit builded");
			_computer.Add("Basic CentralUnit");
		}

		public override void BuildComponent()
		{
			Console. WriteLine("Basic Component builded");
			_computer.Add("Basic Component");
		}

		public override Computer Computer_GetResult()
		{
			Console.WriteLine("Basic computer result: {0}",_computer);
			return _computer;
		}
	}
}
