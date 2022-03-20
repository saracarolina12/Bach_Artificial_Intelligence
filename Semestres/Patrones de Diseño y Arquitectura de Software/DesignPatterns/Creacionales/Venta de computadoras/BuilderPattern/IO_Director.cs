using System;

namespace BuilderPattern
{
	class IO_Director
	{
		
		public void Construct(IO_Builder io_builder)
		{
			io_builder.setInfo();
			io_builder.setConector();
			io_builder.setPort();
			io_builder.setAsInput();
			io_builder.setAsOutput();
			io_builder.setAsToner();
			io_builder.setAsCart();
		}
	}
}
