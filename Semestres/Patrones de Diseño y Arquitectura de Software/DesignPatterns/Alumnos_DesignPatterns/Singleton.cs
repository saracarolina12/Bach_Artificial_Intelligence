using System;

namespace Alumnos_DesignPatterns
{
	class Singleton
	{
		private static Singleton _instance = null;
		private static object _handle = null;

		protected Singleton(){}

		public static Singleton Instance(){
			if(_instance == null) _instance = new Singleton ();
			return _instance;
		}

        public static Singleton GetInstance(){
			return new Singleton();
		}
	}

	
}
