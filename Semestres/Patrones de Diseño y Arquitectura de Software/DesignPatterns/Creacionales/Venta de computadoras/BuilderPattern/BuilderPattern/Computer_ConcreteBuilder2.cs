using System;

namespace BuilderPattern
{
	/// <summary>
	/// The concrete builder class for product type 2.
	/// </summary>
	class Computer_ConcreteBuilder2 : Computer_Builder
	{
		// the product being constructed
		private Product _product = new Product();

		/// <summary>
		/// Build part A.
		/// </summary>
		public override void CentralUnit()
		{
			Console. WriteLine("Central Unit added");
			_product.Add("Central Unit");
		}

		/// <summary>
		/// Build part B.
		/// </summary>
		public override void Component()
		{
			Console. WriteLine("Component added");
			_product.Add("Components");
		}

		/// <summary>
		/// Gets the finished product.
		/// </summary>
		/// <returns>The finished product.</returns>
		public override Product Computer_GetResult()
		{
			Console. WriteLine("Result: ",_product);
			return _product;
		}
	}
}
