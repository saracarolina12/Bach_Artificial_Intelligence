using System;
using System.Collections.Generic;

namespace BuilderPattern
{
	class Computer
	{
		// generic collection holding the list of parts
		private List<IO> _parts = new List<IO>();
		
		public void Add(IO part)
		{
			_parts.Add(part);
		}

		public void PrintComputer(){
			Console.WriteLine("\t ~ Computer ~");
			float totalPrice = 0f;
			foreach(IO i in _parts){
				i.PrintInfo();
				totalPrice += i.subprice;
			}
			Console.WriteLine("Total price: ${0}",totalPrice);
		}
	}
}
