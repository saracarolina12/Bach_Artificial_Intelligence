using System;

namespace AlumniApp
{
	// The Adapter makes the Adaptee's interface compatible with the Target's
	// interface. (XML->JSON)
	class Adapter : Target
	{
		private Adaptee _adaptee = new Adaptee();

		public override void Request()
		{
			// possibly do some other work ...
			// call the adaptee
			_adaptee.SpecificRequest();
			// possibly do some other work ...
		}
	}	

}