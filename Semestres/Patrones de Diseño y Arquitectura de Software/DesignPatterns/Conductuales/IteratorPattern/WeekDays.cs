using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorPattern
{
	abstract class WeekDays: AggregateClass
	{
		public string Name { get; set; }
		public abstract GetEnumarator(){
			throw new NotImplementedException();
		}
	}
}