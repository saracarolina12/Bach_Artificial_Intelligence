using System;

namespace BuilderPattern
{
	class Computer_ConcreteBuilder1 : Computer_Builder
	{
		// the product being constructed
		private Product _product = new Product();

		/// <summary>
		/// Build part A.
		/// </summary>
		public override void CentralUnit()
		{
			_product.Add("PartA1");
		}

		/// <summary>
		/// Build part B.
		/// </summary>
		public override void Component()
		{
			_product.Add("PartB1");
		}

		/// <summary>
		/// Gets the finished product.
		/// </summary>
		/// <returns>The finished product.</returns>
		public override Product Computer_GetResult()
		{
			return _product;
		}
	}
}
