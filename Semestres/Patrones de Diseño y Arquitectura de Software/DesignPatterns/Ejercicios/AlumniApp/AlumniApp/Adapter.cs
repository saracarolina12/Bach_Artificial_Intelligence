using System;

namespace AlumniApp
{

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