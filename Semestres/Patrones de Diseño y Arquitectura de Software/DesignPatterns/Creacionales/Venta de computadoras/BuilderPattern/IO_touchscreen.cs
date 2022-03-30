using System;

namespace BuilderPattern
{
	class IO_touchscreen: IO_Builder
	{
		// the product being constructed
		private IO _io = new IO();


		public override void setInfo(){
			_io.name="Touch Screen";
			_io.FabName="LG"; //nombre de fabricante
			_io.model="17MB15T"; //modelo
			_io.subprice=5616F; //precio de venta
		}

		public override void setConector(){
			//just inputs
		}
		public override void setPort(){
			_io.validPorts[0] = 6;
		}
		public override void setAsToner(){
			//just for printers
		}

		public override void setAsLaser(){
			//just for printers
		}

		public override void setAsIny(){
			//just for printers
		}
		public override void setAsCart(){
			_io.isCart = false;
		}

		public override void setAsInput(){
			_io.isInput = true;
		}

		public override void setAsOutput(){
			_io.isOutput = true;
		}

		public override IO IO_GetResult(){
			return _io;
		}

	}
}
