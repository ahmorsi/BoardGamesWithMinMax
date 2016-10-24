using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BoardGameProject
{
	class KingUnit : ChessUnit
	{
		private bool Moved;

		public KingUnit(char newUnitCode, bool owner)
			: base(newUnitCode, owner)
		{
			Moved = false;
			Directions.Add(new Point(-1, -1));
			Directions.Add(new Point(-1, 1));
			Directions.Add(new Point(-1, 0));
			Directions.Add(new Point(1, -1));
			Directions.Add(new Point(1, 1));
			Directions.Add(new Point(1, 0));
			Directions.Add(new Point(0, -1));
			Directions.Add(new Point(0, 1));
			Directions.Add(new Point(0, 2));
			Directions.Add(new Point(0, -2));
		}

		public override void IntializeAvailableMoves(int Row, int Column)
		{
			List<Point> Current = new List<Point>();

			for (int CurrentDirection = 0; CurrentDirection < Directions.Count; CurrentDirection++)
			{
				Current.Add(new Point(Row + Directions[CurrentDirection].X , Column + Directions[CurrentDirection].Y));
				AvailableMoves.Add(Current);
				Current = new List<Point>();
			}
		}

		public override void ChangeAvailableMoves(int Row, int Column)
		{
			if (!Moved)
			{
				Moved = true;
				Directions.RemoveAt(8);
				Directions.RemoveAt(8);
				AvailableMoves.RemoveAt(8);
				AvailableMoves.RemoveAt(8);
			}

			for (int CurrentDirection = 0; CurrentDirection < Directions.Count; CurrentDirection++)
			{
				AvailableMoves[CurrentDirection][0] = new Point(Row + Directions[CurrentDirection].X, Column + Directions[CurrentDirection].Y);
			}
		}
	}
}
