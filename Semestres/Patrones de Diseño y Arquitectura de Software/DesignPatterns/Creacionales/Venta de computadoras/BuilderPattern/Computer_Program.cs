using System;

namespace BuilderPattern
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Computer_Director computer_director = new Computer_Director();

			Console.WriteLine("****** Basic Computer ******");
			Computer_Builder Computer_b1 = new Computer_Basic();
			computer_director.Construct(Computer_b1);
			Computer c1 = Computer_b1.Computer_GetResult();
			c1.PrintComputer();

			Console.WriteLine("\n");

			Console.WriteLine("****** Medium Computer ******");
			Computer_Builder Computer_b2 = new Computer_Medium();
			computer_director.Construct(Computer_b2);
			Computer c2 = Computer_b2.Computer_GetResult();
			c2.PrintComputer();
			
		}
	}
}
