using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoardGameProject;
using System.Drawing;

namespace BoardGameProject
{
	class Computer : Player
	{
		public Computer() : base("Computer") { }
		public override Point Apply_Strategy(Board current_board)
		{
			myStrategy.Copy_Board(current_board);
			KeyValuePair<int, Point> Best_Turn = //myStrategy.NegaMax(myStrategy.Get_Tested_Board(), 0, int.MinValue, int.MaxValue,true);
				myStrategy.MiniMax(myStrategy.Get_Tested_Board(), 0, int.MinValue, int.MaxValue, true);
			return Best_Turn.Value;
		}
	}
}
