using System;

namespace BuilderPattern
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Computer_Director computer_director = new Computer_Director();


			Console.WriteLine("****** Basic Computer ******");
			//Basic Computer
			Computer_Builder Computer_b1 = new Computer_Basic();
			computer_director.Construct(Computer_b1);
			Computer c1 = Computer_b1.Computer_GetResult();
			//Console.WriteLine ("Basic computer: {0}", c1);

			Console.WriteLine("\n");

			Console.WriteLine("****** Medium Computer ******");
			//Medium computer
			Computer_Builder Computer_b2 = new Computer_Medium();
			computer_director.Construct(Computer_b2);
			Computer c2 = Computer_b2.Computer_GetResult();
			//Console.WriteLine ("{0} ,  {1}",c2, c2.GetType().Name);
		}
	}
}
