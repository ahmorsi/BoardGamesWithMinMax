using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BoardGameProject
{
    class PawnUnit : ChessUnit
    {
        private bool Moved;

		public PawnUnit(char newUnitCode, bool owner)
			: base(newUnitCode, owner)
		{
			Moved = false;

			if (owner)
			{
				Directions.Add(new Point(-1, -1));
				Directions.Add(new Point(-1, 1));
				Directions.Add(new Point(-1, 0));
				Directions.Add(new Point(-2, 0));
			}
			else
			{
				Directions.Add(new Point(1, 1));
				Directions.Add(new Point(1, -1));
				Directions.Add(new Point(1, 0));
				Directions.Add(new Point(2, 0));
			}
		}

		public override void IntializeAvailableMoves(int Row, int Column)
		{
			List<Point> Current = new List<Point>();

			for (int CurrentDirection = 0; CurrentDirection < Directions.Count; CurrentDirection++)
			{
				Current.Add(new Point(Row + Directions[CurrentDirection].X, Column + Directions[CurrentDirection].Y));
				AvailableMoves.Add(Current);
				Current = new List<Point>();
			}
		}

		public override void ChangeAvailableMoves(int Row, int Column)
		{
			if (!Moved)
			{
				Moved = true;
				Directions.RemoveAt(3);
				AvailableMoves.RemoveAt(3);
			}

			for (int CurrentDirection = 0; CurrentDirection < Directions.Count; CurrentDirection++)
			{
				AvailableMoves[CurrentDirection][0] = new Point(Row + Directions[CurrentDirection].X, Column + Directions[CurrentDirection].Y);
			}
		}
	}
}
