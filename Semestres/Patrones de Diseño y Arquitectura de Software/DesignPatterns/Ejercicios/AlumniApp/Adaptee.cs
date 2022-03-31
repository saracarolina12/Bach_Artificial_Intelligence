using System;

namespace AlumniApp
{
	// The Adaptee contains some useful behavior, but its interface is
	// incompatible with the existing client code. The Adaptee needs some
	// adaptation before the client code can use it. (XML)
	class Adaptee
	{
		/// A specific request that needs an adapter.
		public void SpecificRequest()
		{
			//throw new NotImplementedException("SpecificRequest is not implemented.");
			Console.WriteLine("-----> Adapted");
		}
	}

}