using System;

namespace BuilderPattern
{
	class IO_CPU : IO_Builder
	{
		// the product being constructed
		private IO _io = new IO();


		public override void setInfo(){
			_io.name="CPU";
			_io.FabName="Intel"; //nombre de fabricante
			_io.model="i5"; //modelo
			_io.subprice=5175f; //precio de venta
		}

		public override void setConector(){
			// just for inputs
		}
		public override void setPort(){
			_io.validPorts[0] = 7;
		}
		public override void setAsToner(){
			//just for printers
		}

		public override void setAsCart(){
			//just for printers
		}
		public override void setAsInput(){
			_io.isInput = false;
		}

		public override void setAsOutput(){
			_io.isOutput = false;
		}

		public override IO IO_GetResult(){
			return _io;
		}

	}
}
