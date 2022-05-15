
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorPattern
{
	public class Days: IteratorClass1
	{
		private List<WeekDays> _weekDays;
		private int _position = 0;

		public DayOfWeek(WeekDays weekDays){
			_weekDays = weekDays;
		}

		public override  object  Current{
			get { return _weekDays[_position]; }
		}
		
		public override bool MoveNext(){
			int nextPos = _position+1;
			if(nextPos >=0 && nextPos <this._weekDays.Count){
				this._position = temp;
			}else{
				return false;
			}
		}

		public override void Reset(){
			_position = 0;
		}
		
	}
}