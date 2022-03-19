using System;

namespace BuilderPattern
{
	abstract class Computer_Builder
	{
		public abstract void CentralUnit();		
		public abstract void Component(); //Input & Output
		public abstract Product Computer_GetResult(); //returns finished product
	}
}
