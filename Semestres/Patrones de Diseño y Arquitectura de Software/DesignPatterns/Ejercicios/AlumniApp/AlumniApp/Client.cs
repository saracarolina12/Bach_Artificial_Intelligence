using System;

namespace AlumniApp
{
	public class Client
	{
		public void Operation()
		{
			Target adapter = new Adapter(); // wrap the adaptee with an adapter
			adapter.Request(); // use the adapter to make a request
		}
	}
}
