using System;
using System.Collections.Generic;

namespace BuilderPattern
{
	class Computer
	{
		// generic collection holding the list of parts
		private List<string> _parts = new List<string>();

		/// <summary>
		/// Add a new part to the product.
		/// </summary>
		/// <param name="part">The part to add to the product.</param>
		public void Add(string part)
		{
			_parts.Add(part);
		}
	}
}
