using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGameProject
{
	class Connect4unit : Unit
	{
		public Connect4unit(char newUnitCode, bool owner) : base( newUnitCode, owner) {}

		public Connect4unit(Unit oldUnit) : base(oldUnit) { }
	}
}
