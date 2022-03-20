using System;

namespace BuilderPattern
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IO_Director io_director = new IO_Director();

			// Console.WriteLine("****** keyboard ******");	 //I
			// IO_Builder keyboard = new IO_keyboard();
			// io_director.Construct(keyboard);
			// IO x1 = keyboard.IO_GetResult();

			// Console.WriteLine("\n");

			// Console.WriteLine("****** mouse ******");		//I
			// IO_Builder mouse = new IO_mouse();
			// io_director.Construct(mouse);
			// IO x2 = mouse.IO_GetResult();

			// Console.WriteLine("\n");

			//Console.WriteLine("****** graphicsTablet ******");	//I
			IO_Builder graphicsTablet = new IO_graphicTablet();
			io_director.Construct(graphicsTablet);
			IO x3 = graphicsTablet.IO_GetResult();
			x3.PrintInfo();

			// Console.WriteLine("\n");

			// Console.WriteLine("****** screen ******");		//O
			// IO_Builder screen = new IO_screen();
			// io_director.Construct(screen);
			// IO x4 = screen.IO_GetResult();

			// Console.WriteLine("\n");

			// Console.WriteLine("****** printer ******");		//O
			// IO_Builder printer = new IO_printer();
			// io_director.Construct(printer);
			// IO x5 = printer.IO_GetResult();

			// Console.WriteLine("\n");

			// Console.WriteLine("****** touchScreen ******");		//IO
			// IO_Builder touchScreen = new IO_touchScreen();
			// io_director.Construct(touchScreen);
			// IO x6 = touchScreen.IO_GetResult();
			
			// Console.WriteLine("\n");

			// Console.WriteLine("****** centralunit ******");	//NONE
			// IO_Builder centralunit = new IO_centralunit();
			// io_director.Construct(centralunit);
			// IO x7 = centralunit.IO_GetResult();
		}
	}
}
