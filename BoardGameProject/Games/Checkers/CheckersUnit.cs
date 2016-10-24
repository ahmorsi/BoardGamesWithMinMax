using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BoardGameProject
{
    class  CheckersUnit : Unit
    {
        private List<Point> directions = new List<Point>();
        private List<Point> avaliableMoves;
        bool king;

        public CheckersUnit(char newType, bool owner)
            : base(newType, owner)
        {
            king = false;
			avaliableMoves = new List<Point>();

			if (owner)
			{
				directions.Add(new Point(-1, 1));
				directions.Add(new Point(-1, -1));
			}
			else
			{
				directions.Add(new Point(1, 1));
				directions.Add(new Point(1, -1));
			}
        }

        public CheckersUnit(CheckersUnit newCheckersUnit)
            : base(newCheckersUnit)
        {
            avaliableMoves = new List<Point>();

			if (getIsFirstPlayer())
			{
				directions.Add(new Point(-1, 1));
				directions.Add(new Point(-1, -1));
			}
			else
			{
				directions.Add(new Point(1, 1));
				directions.Add(new Point(1, -1));
			}

			if (king)
            {
                Promote();
            }
        }

        public void clearAvaliableMove()
        {
            avaliableMoves.Clear();
        }

        public void addAvaliableMove(int row, int column)
        {
            avaliableMoves.Add(new Point(row, column));
        }

        public List<Point> getDirections()
        {
            return directions;
        }

        public List<Point> get_Avaliable_Moves()
        {
            return avaliableMoves;
        }

        public bool hasMoves()
        {
            return (avaliableMoves.Count != 0);
        }

        public bool isMove(Point P)
        {
            return avaliableMoves.Contains(P);
        }

        public void Promote()
        {
            king = true;

			if (getIsFirstPlayer())
			{
				directions.Add(new Point(1, 1));
				directions.Add(new Point(1, -1));
			}
			else
			{
				directions.Add(new Point(-1, -1));
				directions.Add(new Point(-1, 1));
			}
        }

		public bool IsKing()
		{
			return king;
		}
    }
}
