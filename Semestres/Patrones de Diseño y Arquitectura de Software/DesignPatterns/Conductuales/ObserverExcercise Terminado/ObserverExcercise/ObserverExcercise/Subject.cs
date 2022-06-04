using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverExcercise
{

    public delegate void NotifyEvent<T>(T subject, NotifyEventArgs args);
    public class Subject
    {
        public event NotifyEvent<Subject> OnNotify;

        private float _exchangeRate;
        public void ExchangeRateChanged(float exchangeRate)
        {
            if (exchangeRate != _exchangeRate)
            {
                _exchangeRate = exchangeRate;
                if (OnNotify!=null)
                    OnNotify(this, new NotifyEventArgs(_exchangeRate));
            }
        }


    }
}
