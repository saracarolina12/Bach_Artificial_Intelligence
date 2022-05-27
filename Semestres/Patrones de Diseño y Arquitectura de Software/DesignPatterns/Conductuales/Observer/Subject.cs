using System;

namespace Observer
{
	public delegate void NotifyEvent<T>(T subject, NotifyEventArgs args);
	public class Subject
	{
		public event NotifyEvent<Subject> ONnotif;
		private decimal _exchangeType;
		public void ChangeState(decimal exchangeType)
		
		{
			Console.WriteLine("Changing subject state to {0}", exchangeType);

			if (exchangeType != _exchangeType)
			{
				_exchangeType = exchangeType;
				ONnotif(this, new NotifyEventArgs(_exchangeType));
			}
		}
	}
}
