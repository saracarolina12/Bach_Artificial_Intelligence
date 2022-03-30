using System;

namespace BuilderPattern
{
	class Computer_Director
	{
		
		public void Construct(Computer_Builder computer_builder)
		{
			computer_builder.IncludeCentralUnit();
			computer_builder.IncludeComponent(); 
		}
	}
}
