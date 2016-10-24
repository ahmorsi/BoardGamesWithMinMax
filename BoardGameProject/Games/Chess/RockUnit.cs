using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BoardGameProject
{
	class RockUnit : ChessUnit
	{
		private bool Moved;

		public RockUnit(char newUnitCode, bool owner)
			: base(newUnitCode, owner)
		{
			Moved = false;

			Directions.Add(new Point(-1, 0));
			Directions.Add(new Point(1, 0));
			Directions.Add(new Point(0, -1));
			Directions.Add(new Point(0, 1));
			Directions.Add(new Point(0, -2));
			Directions.Add(new Point(0, 3));
		}

		public override void IntializeAvailableMoves(int Row, int Column)
		{
			if (Column == 7)
				Directions.RemoveAt(5);
			else
				Directions.RemoveAt(4);

			List<Point> Current = new List<Point>();

			for (int CurrentDirection = 0; CurrentDirection < Directions.Count - 1; CurrentDirection++)
			{
				int newRow = Row , newColumn = Column;

				for (int CurrentPlot = 1; CurrentPlot < 8; CurrentPlot++)
				{
					newRow += Directions[CurrentDirection].X;
					newColumn += Directions[CurrentDirection].Y;
					Current.Add(new Point(newRow, newColumn));
				}

				AvailableMoves.Add(Current);
				Current = new List<Point>();
			}

			Current.Add(new Point(Row + Directions[Directions.Count - 1].X, Column + Directions[Directions.Count - 1].Y));
			AvailableMoves.Add(Current);
		}

		public override void ChangeAvailableMoves(int Row, int Column)
		{
			if (!Moved)
			{
				Moved = true;
				Directions.RemoveAt(4);
				AvailableMoves.RemoveAt(AvailableMoves.Count - 1);
			}

			for (int CurrentDirection = 0; CurrentDirection < Directions.Count; CurrentDirection++)
			{
				int newRow = Row, newColumn = Column;

				for (int CurrentPlot = 0; CurrentPlot < AvailableMoves[CurrentDirection].Count; CurrentPlot++)
				{
					newRow += Directions[CurrentDirection].X;
					newColumn += Directions[CurrentDirection].Y;
					AvailableMoves[CurrentDirection][CurrentPlot] = new Point(newRow, newColumn);
				}
			}
		}
	}
}
