using System;

namespace BuilderPattern
{
	class Computer_Basic : Computer_Builder
	{
		// the product being constructed
		private Computer _computer = new Computer();
		public override void IncludeCentralUnit()
		{
			
			//_computer.Add(null);
		}

		public override void IncludeComponent()
		{
			

			IO_Builder graphicsTablet = new IO_graphicTablet();
			io_director.Construct(graphicsTablet);
			IO x3 = graphicsTablet.IO_GetResult();
			_computer.Add(x3);
		}

		public override Computer Computer_GetResult()
		{
			
			return _computer;
		}
	}
}
