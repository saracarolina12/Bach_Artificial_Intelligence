using System;

namespace BuilderPattern
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IO_Director io_director = new IO_Director();


			Console.WriteLine("****** Basic IO ******");
			//Basic IO
			IO IO_b1 = new Computer_Basic();
			IO_director.Construct(IO_b1);
			IO c1 = IO_b1.IO_GetResult();
			//Console.WriteLine ("Basic IO: {0}", c1);

			Console.WriteLine("\n");

			Console.WriteLine("****** Medium IO ******");
			//Medium IO
			IO_Builder IO_b2 = new Computer_Medium();
			IO_director.Construct(IO_b2);
			IO c2 = IO_b2.IO_GetResult();
			//Console.WriteLine ("{0} ,  {1}",c2, c2.GetType().Name);
		}
	}
}
