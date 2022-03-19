using System;

namespace BuilderPattern
{
	class MainClass
	{
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main (string[] args)
		{
			// create director
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
			//Console.WriteLine ("Basic computer: {0}", c2);
		}
	}
}
