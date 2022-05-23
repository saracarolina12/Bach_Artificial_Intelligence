using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_Pedidos
{
    class Singleton
    {
		private static Singleton _instance = null;

		protected Singleton()
		{
		}

		public static Singleton Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Singleton();
				}

				return _instance;
			}
		}

		public static Singleton GeneratePath()
		{
			if (_instance == null)
			{
				_instance = new Singleton();
			}
			return _instance;
		}
	}
}
