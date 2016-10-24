using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BoardGameProject
{
    abstract class ChessUnit : Unit
    {
        protected List<Point> Directions;
		protected List<List<Point>> AvailableMoves;

		public ChessUnit(char newUnitCode, bool owner)
			: base(newUnitCode, owner)
		{
			Directions = new List<Point>();
			AvailableMoves = new List<List<Point>>();
		}

        public List<Point> getDirections()
        {
            return Directions;
        }

		public List<List<Point>> getAvailableMoves()
		{
			return AvailableMoves;
		}

		public bool IsAvailableMove(int Row , int Column)
		{
			Point CurrentAvailableMoves;

			for (int CurrentDirection = 0; CurrentDirection < AvailableMoves.Count; CurrentDirection++)
			{
				for (int CurrentTile = 0; CurrentTile < AvailableMoves[CurrentDirection].Count; CurrentTile++)
				{
					CurrentAvailableMoves = AvailableMoves[CurrentDirection][CurrentTile];

					if (CurrentAvailableMoves.X == Row && CurrentAvailableMoves.Y == Column)
						return true;
				}
			}

			return false;
		}

		public abstract void IntializeAvailableMoves(int Row, int Column);
		public abstract void ChangeAvailableMoves(int Row, int Column);
    }
}
