using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverExcercise
{
    public class NotifyEventArgs : EventArgs
    {
        private float exchangeRate;

        public float ExchangeRate
        {
            get
            {
                return exchangeRate;
            }
        }

        public NotifyEventArgs(float _exchangeRate)
        {
            this.exchangeRate = _exchangeRate;
        }

    }
}
