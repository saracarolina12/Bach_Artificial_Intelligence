using System;
using System.Configuration;

namespace Alumnos_DesignPatterns
{

	class MainClass
	{
		public static void Main (string[] args)
		{
			var mensaje = ConfigurationManager.AppSettings["export"];
			Console.WriteLine(mensaje);

			ApplicationConfiguration.Initialize();
			Application.Run(new Login());

			// get the singleton instance
			Singleton instance = Singleton.Instance();
            instance = Singleton.GetInstance();
		}
	}
}
