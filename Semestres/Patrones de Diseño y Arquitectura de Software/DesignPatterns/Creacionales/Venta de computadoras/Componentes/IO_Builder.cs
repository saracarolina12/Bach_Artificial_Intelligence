using System;

namespace BuilderPattern
{
	abstract class IO_Builder
	{
		public abstract void BuildCentralUnit();		
		public abstract void BuildComponent(); //Input & Output
		public abstract IO IO_GetResult(); //returns finished product
	}
}
