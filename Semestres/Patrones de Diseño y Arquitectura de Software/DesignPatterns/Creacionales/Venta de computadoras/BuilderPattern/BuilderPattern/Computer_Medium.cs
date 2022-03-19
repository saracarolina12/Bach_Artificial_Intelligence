using System;

namespace BuilderPattern
{
	/// <summary>
	/// The concrete builder class for product type 2.
	/// </summary>
	class Computer_Medium : Computer_Builder
	{
		// the product being constructed
		private Computer _computer = new Computer();

		/// <summary>
		/// Build part A.
		/// </summary>
		public override void BuildCentralUnit()
		{
			Console.WriteLine("Medium Central Unit builded");
			_computer.Add("Central Unit");
		}

		/// <summary>
		/// Build part B.
		/// </summary>
		public override void BuildComponent()
		{
			Console.WriteLine("Medium Components builded");
			_computer.Add("Components");
		}

		/// <summary>
		/// Gets the finished product.
		/// </summary>
		/// <returns>The finished product.</returns>
		public override Computer Computer_GetResult()
		{
			Console.WriteLine("Medium computer result: {0}",_computer);
			return _computer;
		}
	}
}
