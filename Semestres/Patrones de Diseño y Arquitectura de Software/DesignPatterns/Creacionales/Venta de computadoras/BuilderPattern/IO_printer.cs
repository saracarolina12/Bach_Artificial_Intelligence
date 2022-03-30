using System;

namespace BuilderPattern
{
	class IO_printer : IO_Builder
	{
		// the product being constructed
		private IO _io = new IO();


		public override void setInfo(){
			_io.name="printer";
			_io.FabName="Kyocera"; //nombre de fabricante
			_io.model="xM2040dn"; //modelo
			_io.subprice=8795f; //precio de venta
		}

		public override void setConector(){
			//just inputs
		}
		public override void setPort(){
			_io.validPorts[0] = 5;
		}
		public override void setAsToner(){
			_io.isToner = false;
		}

		public override void setAsCart(){
			_io.isCart = true;
		}

		public override void setAsLaser(){
			_io.isLaser = false;
		}

		public override void setAsIny(){
			_io.isIny = true;
		}		public override void setAsInput(){
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
