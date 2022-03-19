using System;
using System.Collections.Generic;

namespace BuilderPattern
{
	class IO
	{
		// generic collection holding the list of parts
		private List<string> _parts = new List<string>();

		public void Add(string part)
		{
			_parts.Add(part);
			/*
				Int32 length = _parts.Count;
				Console.WriteLine("size: {0}", length);
			*/
		}
	}
}
