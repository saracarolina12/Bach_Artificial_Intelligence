using System;

namespace BuilderPattern
{
	class IO_Director
	{
		
		public void Construct(IO IO_builder)
		{
			IO_builder.BuildCentralUnit();
			IO_builder.BuildComponent(); //Input/output
		}
	}
}
