using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorPattern
{
	public abstract class IteratorClass1: IEnumerator
	{
		public abstract object Current { get; }
		public abstract MoveNext();

		public abstract Reset();
	}
}