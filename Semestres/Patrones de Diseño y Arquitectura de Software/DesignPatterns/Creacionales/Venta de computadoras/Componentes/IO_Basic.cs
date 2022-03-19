using System;

namespace BuilderPattern
{
	class IO_Basic : IO_Builder
	{
		// the product being constructed
		private IO _IO = new IO();

		public override void BuildCentralUnit()
		{
			Console. WriteLine("Basic Central Unit builded");
			_IO.Add("Basic CentralUnit");
		}

		public override void BuildComponent()
		{
			Console. WriteLine("Basic Component builded");
			_IO.Add("Basic Component");
		}

		public override IO IO_GetResult()
		{
			Console.WriteLine("Basic IO result: {0}",_IO);
			return _IO;
		}
	}
}
