using System;

namespace FactoryMethodPattern
{
	/// <summary>
	/// The concrete factory class for creating product B.
	/// </summary>
	class ConcreteCreatorB : Creator
	{
		/// <summary>
		/// Create a new product B.
		/// </summary>
		/// <returns>The newly created product B.</returns>
		public override Product FactoryMethod()
		{
			return new ConcreteProductB();
		}
	}
}
