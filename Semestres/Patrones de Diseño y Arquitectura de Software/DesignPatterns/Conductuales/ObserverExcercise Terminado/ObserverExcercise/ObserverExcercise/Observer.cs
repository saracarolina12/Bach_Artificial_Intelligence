using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverExcercise
{
    public class Observer
    {
        // evento que se accionara cuando el tipo de cambio cambie y avisará
        // al formulario para que cambie el color a a etiqueta.
        public delegate void ChangedColor<T>();
        public event ChangedColor<Observer> OnChangedColor;

        private string _name;

        private float _exchangeRate;

        public Observer(string _name)
        {
            this._name = _name;
        }

        public void Update(Subject   sender, NotifyEventArgs args) 
        {
            _exchangeRate = args.ExchangeRate;
            OnChangedColor();
        }


    }
}
