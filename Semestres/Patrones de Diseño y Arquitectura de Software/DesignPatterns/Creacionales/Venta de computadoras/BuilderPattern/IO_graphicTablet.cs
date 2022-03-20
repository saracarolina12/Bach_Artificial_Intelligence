using System;

namespace BuilderPattern
{
	class IO_graphicTablet : IO_Builder
	{
		// the product being constructed
		private IO _io = new IO();


		public override void setInfo(){
			_io.name="GraphicTablet";
			_io.FabName="xp-Pen"; //nombre de fabricante
			_io.model="StarG430s"; //modelo
			_io.subprice=4714f; //precio de venta
		}

		public override void setConector(){
			_io.conector = "usb"; //tipo de conector
		}
		public override void setPort(){
			_io.validPorts[0] = 1;
		}
		public override void setTonerCart(){
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
