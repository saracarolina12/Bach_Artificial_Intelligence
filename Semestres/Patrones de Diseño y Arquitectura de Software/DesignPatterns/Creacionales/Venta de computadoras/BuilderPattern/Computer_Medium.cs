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

			IO_Builder CPU = new IO_CPU();
			io_director.Construct(CPU);
			IO x2 = CPU.IO_GetResult();
			_computer.Add(x2);
		}

		public override void IncludeComponent()
		{
			//input 1 
			IO_Builder keyboard = new IO_keyboard();
			io_director.Construct(keyboard);
			IO x1 = keyboard.IO_GetResult();
			_computer.Add(x1);

			//input 2
			IO_Builder mouse = new IO_mouse(); 
			io_director.Construct(mouse);
			IO x2 = mouse.IO_GetResult();
			_computer.Add(x2);

			//input 3
			IO_Builder graphicsTablet = new IO_graphicTablet();
			io_director.Construct(graphicsTablet);
			IO x3 = graphicsTablet.IO_GetResult();
			_computer.Add(x3);

			//output 1
			IO_Builder touchscreen = new IO_touchscreen();
			io_director.Construct(touchscreen);
			IO x4 = touchscreen.IO_GetResult();
			_computer.Add(x4);

			//output 1
			IO_Builder printer = new IO_printer();
			io_director.Construct(printer);
			IO x5 = printer.IO_GetResult();
			_computer.Add(x5);

		}

		public override Computer Computer_GetResult()
		{
			return _computer;
		}
	}
}

