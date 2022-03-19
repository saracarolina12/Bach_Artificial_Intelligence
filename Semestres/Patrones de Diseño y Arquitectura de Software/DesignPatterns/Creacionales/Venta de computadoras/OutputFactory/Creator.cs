using System;

namespace FactoryMethodPattern
{
	/// <summary>
	/// The abstract factory class.
	/// </summary>
	abstract class Creator
	{
		/// <summary>
		/// Create a new product.
		/// </summary>
		/// <returns>The newly created product.</returns>
		public abstract Product FactoryMethod();
	}
}
