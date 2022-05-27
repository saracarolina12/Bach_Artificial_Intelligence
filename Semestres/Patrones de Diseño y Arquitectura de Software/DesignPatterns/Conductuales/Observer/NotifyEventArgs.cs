using System;

namespace Observer
{
	public class NotifyEventArgs : EventArgs
	{
		private decimal _exchangeType;
		public decimal ExchangeType { get { return _exchangeType; } }

        public NotifyEventArgs(decimal exchangeType)
        {
            _exchangeType = exchangeType;
        }
    }
}

