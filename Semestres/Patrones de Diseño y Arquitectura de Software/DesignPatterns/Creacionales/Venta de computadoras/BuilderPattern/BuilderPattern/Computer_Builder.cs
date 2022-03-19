using System;

namespace BuilderPattern
{
	abstract class Computer_Builder
	{
		public abstract void BuildCentralUnit();		
		public abstract void BuildComponent(); //Input & Output
		public abstract Computer Computer_GetResult(); //returns finished product
	}
}
