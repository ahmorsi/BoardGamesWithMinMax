using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BoardGameProject
{
	class KnightUnit : ChessUnit
	{
		public KnightUnit(char newUnitCode, bool owner)
			: base(newUnitCode, owner)
		{
			Directions.Add(new Point(-1, -2));
			Directions.Add(new Point(-1, 2));
			Directions.Add(new Point(-2, -1));
			Directions.Add(new Point(-2, 1));
			Directions.Add(new Point(1, -2));
			Directions.Add(new Point(1, 2));
			Directions.Add(new Point(2, -1));
			Directions.Add(new Point(2, 1));
		}

		public override void IntializeAvailableMoves(int Row, int Column)
		{
			List<Point> Current = new List<Point>();
			int newRow , newColumn;

			for (int CurrentDirection = 0; CurrentDirection < Directions.Count; CurrentDirection++)
			{
				newRow = Row + Directions[CurrentDirection].X;
				newColumn = Column + Directions[CurrentDirection].Y;
				Current.Add(new Point(newRow, newColumn));
				AvailableMoves.Add(Current);
				Current = new List<Point>();
			}
		}

		public override void ChangeAvailableMoves(int Row, int Column)
		{
			int newRow, newColumn;

			for (int CurrentDirection = 0; CurrentDirection < Directions.Count; CurrentDirection++)
			{
				newRow = Row + Directions[CurrentDirection].X;
				newColumn = Column + Directions[CurrentDirection].Y;
				AvailableMoves[CurrentDirection][0] = new Point(newRow, newColumn);
			}
		}
	}
}
