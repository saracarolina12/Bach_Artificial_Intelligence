using System;

namespace AlumniApp
{
	class Adaptee
	{
		/// A specific request that needs an adapter.
		public void SpecificRequest()
		{
			throw new NotImplementedException("SpecificRequest is not implemented.");

			//Console.WriteLine("SpecificRequest is not implemented.");
		}
	}

}