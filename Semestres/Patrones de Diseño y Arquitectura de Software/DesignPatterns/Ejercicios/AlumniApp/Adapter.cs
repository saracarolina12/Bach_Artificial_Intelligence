using System;

namespace AlumniApp
{
	// The Adapter makes the Adaptee's interface compatible with the Target's
	// interface. (XML->JSON)
	class Adapter : Target
	{
		private Adaptee _adaptee = new Adaptee();

		public override Root Request(string ruta)
		{
			// possibly do some other work ...
			return _adaptee.ReadJSON(ruta);
		}
	}	

}