using System;
using System.Collections.Generic;

namespace Calculator
{
	public class Client
	{
		
		public void Run ()
		{
			float res=0;
            int a=0, b=0;
            char op;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            op = char.Parse(Console.ReadLine());

			Receiver receiver = new Receiver(); //quien recibe los números y hacer los cálculos
			Command command = new ConcreteCommand(receiver);
			Invoker invoker = new Invoker();
			invoker.Invoke(command,a, b, op,res);
		}
	}
}