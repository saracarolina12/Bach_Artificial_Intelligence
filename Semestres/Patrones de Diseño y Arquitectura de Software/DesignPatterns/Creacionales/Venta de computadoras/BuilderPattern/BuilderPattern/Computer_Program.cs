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
			// create director and builders
			Computer_Director computer_director = new Computer_Director();

			Computer_Builder Computer_b1 = new Computer_ConcreteBuilder1();
			Computer_Builder Computer_b2 = new Computer_ConcreteBuilder2();

			// create product using builder 1
			computer_director.Construct(Computer_b1);
			Product p1 = Computer_b1.Computer_GetResult();

			// create product using builder 1
			computer_director.Construct(Computer_b2);
			Product p2 = Computer_b2.Computer_GetResult();
		}
	}
}
