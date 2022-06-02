using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion_Pedidos
{
	class Context
	{
		private Strategy _strategy;

		public Context(Strategy strategy)
		{
			_strategy = strategy;
		}

		public void ContextInterface()
		{
			_strategy.AlgorithmInterface();
		}
	}
}
