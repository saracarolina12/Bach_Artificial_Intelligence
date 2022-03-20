using System;

namespace BuilderPattern
{
	class IO_screen : IO_Builder
	{
		// the product being constructed
		private IO _io = new IO();


		public override void setInfo(){
			_io.name="screen";
			_io.FabName="Acer"; //nombre de fabricante
			_io.model="KG241Q"; //modelo
			_io.subprice=4510f; //precio de venta
		}

		public override void setConector(){
			_io.conector = "wire"; //tipo de conector
		}
		public override void setPort(){
			_io.validPorts[0] = 4;
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
			_io.isOutput = true;
		}

		public override IO IO_GetResult(){
			return _io;
		}

	}
}
