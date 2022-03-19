using System;

namespace BuilderPattern
{
	class Computer_Director
	{
		/// <summary>
		/// Construct the product using the specified builder.
		/// </summary>
		/// <param name="builder">The builder to use to construct the product.</param>
		public void Construct(Computer_Builder computer_builder)
		{
			computer_builder.BuildCentralUnit();
			computer_builder.BuildComponent();
		}
	}
}
