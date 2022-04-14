using System;

namespace Calculator
{
	public abstract class Command
	{
		protected Receiver receiver;
		public Command(Receiver receiver)
		{
			this.receiver = receiver;
		}
		public abstract void Execute(int a, int b, char op, float res);
	}
}