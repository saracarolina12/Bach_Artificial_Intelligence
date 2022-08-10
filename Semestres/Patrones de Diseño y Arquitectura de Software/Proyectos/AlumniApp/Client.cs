using System;

namespace AlumniApp
{
	public class Client //administra queries (id, etc)
	{
		private Root data;
		public void getData() 
		{
			Target adapter = new Adapter(); // wrap the adaptee with an adapter
			data = adapter.Request("..\\..\\Data.json"); // use the adapter to make a request
		}
	}
}
