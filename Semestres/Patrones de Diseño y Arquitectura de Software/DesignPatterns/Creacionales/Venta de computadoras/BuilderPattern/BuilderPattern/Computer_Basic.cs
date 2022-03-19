using System;

namespace BuilderPattern
{
	class Computer_Basic : Computer_Builder
	{
		// the product being constructed
		private Computer _computer = new Computer();

		/// <summary>
		/// Build part A.
		/// </summary>
		public override void BuildCentralUnit()
		{
			Console. WriteLine("Basic Central Unit builded");
			_computer.Add("PartA1");
		}

		/// <summary>
		/// Build part B.
		/// </summary>
		public override void BuildComponent()
		{
			Console. WriteLine("Basic Component builded");
			_computer.Add("PartB1");
		}

		/// <summary>
		/// Gets the finished product.
		/// </summary>
		/// <returns>The finished product.</returns>
		public override Computer Computer_GetResult()
		{
			Console. WriteLine("Basic computer result: {0}",_computer);
			return _computer;
		}
	}
}
