using System;

namespace FactoryMethodPattern
{
	/// <summary>
	/// The concrete factory class for creating product A.
	/// </summary>
	class ConcreteCreatorA : Creator
	{
		/// <summary>
		/// Create a new product A. "COMPUTER"
		/// </summary>
		/// <returns>The newly created product A.</returns>
		public override Product FactoryMethod()
		{
			return new ConcreteCreator();
		}
	}
}
