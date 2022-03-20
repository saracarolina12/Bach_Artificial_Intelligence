using System;
using System.Collections.Generic;

namespace BuilderPattern
{
	class IO
	{
		// generic collection holding the list of parts
		private List<string> _parts = new List<string>();
		public bool isInput;
		public bool isOutput;
		public string name="";
		public string FabName="";
		public string model="";
		public float subprice;
		public string conector="";
		public int[] validPorts = new int[5];
		public bool isToner;
		public bool isCart;
		public bool isIny;
		public bool isLaser;

		public void Add(string part)
		{
			_parts.Add(part);
		}

		public void PrintInfo(){
			Console.WriteLine("\t  -{0}",name);
			Console.WriteLine("\t      *{0}",FabName);
			Console.WriteLine("\t      *{0}",model);
			Console.WriteLine("\t      *${0}",subprice);
			//input / output
			if(isInput == true && isOutput == false) Console.WriteLine("\t      *IO Type: Input");
			else if(isOutput && !isInput) Console.WriteLine("\t      *IO Type: Output");
			else if(isInput && isOutput) Console.WriteLine("\t      *IO Type: Input and Output");
			else Console.WriteLine("\t      *IO Type: CPU");

			//toner / cart
			if(isToner && !isCart) Console.WriteLine("\t      *Printer type: Toner");
			else if(isCart && !isToner) Console.WriteLine("\t      *Printer type: Cart");
			else if(isCart && isToner) Console.WriteLine("\t      *Printer type: Toner and Cart");
			else Console.WriteLine("");
		}
	}
}
