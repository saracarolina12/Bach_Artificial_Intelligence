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
		public void Add(string part)
		{
			_parts.Add(part);
		}

		public void PrintInfo(){
			Console.WriteLine("{0}",name);
		}
	}
}
