using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BoardGameProject
{
	class BishopUnit : ChessUnit
	{
		public BishopUnit(char newUnitCode, bool owner)
			: base(newUnitCode, owner)
		{
			Directions.Add(new Point(-1, -1));
			Directions.Add(new Point(-1, 1));
			Directions.Add(new Point(1, -1));
			Directions.Add(new Point(1, 1));
		}

		public override void IntializeAvailableMoves(int Row, int Column)
		{
			List<Point> Current = new List<Point>();

			for (int CurrentDirection = 0; CurrentDirection < Directions.Count; CurrentDirection++)
			{
				int newRow = Row, newColumn = Column;

				for (int CurrentPlot = 0; CurrentPlot < 7; CurrentPlot++)
				{
					newRow += Directions[CurrentDirection].X;
					newColumn += Directions[CurrentDirection].Y;
					Current.Add(new Point(newRow , newColumn));
				}

				AvailableMoves.Add(Current);
				Current = new List<Point>();
			}
		}

		public override void ChangeAvailableMoves(int Row, int Column)
		{
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
