using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Observer
    {
		private string _stores;

		private decimal exchangeType;

		public Observer(string name)
		{
			_stores = name;
		}

		public void Update(Subject sender, NotifyEventArgs args)
		{
			exchangeType = args.ExchangeType;
			Console.WriteLine("{0} syncing state to {1}", _stores, exchangeType);
		}
	}
}
