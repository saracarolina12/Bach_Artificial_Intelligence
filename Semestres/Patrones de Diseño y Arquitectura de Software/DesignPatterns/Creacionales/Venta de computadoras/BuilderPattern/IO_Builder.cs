using System;

namespace BuilderPattern
{
	abstract class IO_Builder
	{
		public abstract void setAsOutput();
		public abstract void setAsInput();
		public abstract void setInfo();
		public abstract void setConector();
		public abstract void setPort();
		public abstract void setTonerCart();
		public abstract IO IO_GetResult(); //returns finished product
	}
}
