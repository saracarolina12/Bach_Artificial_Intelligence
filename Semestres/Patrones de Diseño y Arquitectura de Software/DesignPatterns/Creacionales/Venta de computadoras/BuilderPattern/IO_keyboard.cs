using System;

namespace BuilderPattern
{
	class IO_keyboard : IO_Builder
	{
		// the product being constructed
		private IO _io = new IO();


		public override void setInfo(){
			_io.name="keyboard";
			_io.FabName="LogiTech"; //nombre de fabricante
			_io.model="MK200"; //modelo
			_io.subprice=480f; //precio de venta
		}

		public override void setAsLaser(){
			//just for printers
		}

		public override void setAsIny(){
			//just for printers
		}
		public override void setConector(){
			_io.conector = "bluetooth"; //tipo de conector
		}
		public override void setPort(){
			_io.validPorts[0] = 2;
		}
		public override void setAsToner(){
			//just for printers
		}

		public override void setAsCart(){
			//just for printers
		}

		public override void setAsInput(){
			_io.isInput = true;
		}

		public override void setAsOutput(){
			_io.isOutput = false;
		}

		public override IO IO_GetResult(){
			return _io;
		}

	}
}
