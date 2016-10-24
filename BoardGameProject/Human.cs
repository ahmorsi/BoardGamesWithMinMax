using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGameProject
{
	class Human : Player
	{
		public Human(string name) : base(name)
		{
			myStrategy = null;	
		}

		public override System.Drawing.Point Apply_Strategy(Board current_board)
		{
			throw new NotImplementedException();
		}
	}
}
