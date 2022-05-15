using System;
using System.Collections.Generic;

namespace IteratorPattern
{
	abstract class AggregateClass: IEnumerable
	{
        public abstract IEnumerable GetEnumerator();
		
	}
}