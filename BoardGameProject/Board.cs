using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGameProject
{
    class Board
    {
		private int Rows, Coloums;
		private Unit[,] BoardStatus;

		public Board(int newRows, int newColoums)
		{
			Rows = newRows;
			Coloums = newColoums;
			BoardStatus = new Unit[newRows, newColoums];
		}

		public void setUnit(int Row, int Coloum, Unit newUnit)
		{
			BoardStatus[Row, Coloum] = newUnit;
		}

		public Unit getUnit(int Row, int Coloum)
		{
			return BoardStatus[Row, Coloum];
		}

		public void Reset()
		{
			for (int CurrentRow = 0; CurrentRow < Rows; CurrentRow++)
				for (int CurrentColoum = 0; CurrentColoum < Coloums; CurrentColoum++)
					BoardStatus[CurrentRow, CurrentColoum] = null;
		}

		public int getRows()
		{
			return Rows;
		}

		public int getColoums()
		{
			return Coloums;
		}
    }
}
