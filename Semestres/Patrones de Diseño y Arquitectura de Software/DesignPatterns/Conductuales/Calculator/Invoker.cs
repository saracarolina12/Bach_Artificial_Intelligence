using System;

namespace Calculator
{
	public class Invoker
	{
		public void Invoke(Command command, int a, int b, char op, float res)
		{
			Console.WriteLine ("Invoker.Invoke(command) called");
			command.Execute(a,b,op,res);
		}
	}
}