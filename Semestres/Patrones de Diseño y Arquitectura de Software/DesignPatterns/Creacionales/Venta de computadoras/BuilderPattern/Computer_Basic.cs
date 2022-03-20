using System;

namespace BuilderPattern
{
	class Computer_Basic : Computer_Builder
	{
		// the product being constructed
		private Computer _computer = new Computer();
		public override void IncludeCentralUnit()
		{
			IO_Builder CPU = new IO_CPU();
			io_director.Construct(CPU);
			IO x2 = CPU.IO_GetResult();
			_computer.Add(x2);
		}

		public override void IncludeComponent()
		{
			//INPUT - graphics
			IO_Builder graphicsTablet = new IO_graphicTablet();
			io_director.Construct(graphicsTablet);
			IO x1 = graphicsTablet.IO_GetResult();
			_computer.Add(x1);

			//OUTPUT
			IO_Builder screen = new IO_screen();
			io_director.Construct(screen);
			IO x2 = screen.IO_GetResult();
			_computer.Add(x2);
			
		}

		public override Computer Computer_GetResult()
		{
			
			return _computer;
		}
	}
}
