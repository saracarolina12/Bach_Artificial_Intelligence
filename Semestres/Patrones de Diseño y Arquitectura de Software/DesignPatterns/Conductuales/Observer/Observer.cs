using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Observer
{
    class Observer
    {
		private string _stores;

		private decimal exchangeType;
		Label label;

		//public Observer(string name, Label _label)
		public Observer(string name, Label _label)
		{
			_stores = name;
			//this.label = _label;
			//this.label.
		}

		public void Update(Subject sender, NotifyEventArgs args)
		{
			exchangeType = args.ExchangeType;
			//this.label.BackColor = Color.Red;
			Console.WriteLine("{0} syncing state to {1}", _stores, exchangeType);
		}
	}
}
