using System;

namespace BuilderPattern
{
	abstract class Computer_Builder
	{
		public IO_Director io_director = new IO_Director();
		public abstract void IncludeCentralUnit();		
		public abstract void IncludeComponent(); //Input & Output
		public abstract Computer Computer_GetResult(); //returns finished product
	}
}
