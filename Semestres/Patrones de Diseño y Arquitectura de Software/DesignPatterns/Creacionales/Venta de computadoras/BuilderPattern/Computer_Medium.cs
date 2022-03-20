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
			//input 1 
			IO_Builder keyboard = new IO_keyboard();
			io_director.Construct(keyboard);
			IO x2 = keyboard.IO_GetResult();
			_computer.Add(x2);

			//input 2
			IO_Builder mouse = new IO_mouse(); 
			io_director.Construct(mouse);
			IO x1 = mouse.IO_GetResult();
			_computer.Add(x1);
		}

		public override Computer Computer_GetResult()
		{
			return _computer;
		}
	}
}

