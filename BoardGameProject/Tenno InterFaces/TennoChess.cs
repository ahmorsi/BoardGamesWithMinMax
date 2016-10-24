using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace BoardGameProject
{
	interface TennoChess
	{
		void switchPlayer();
		void IntializeChess();
		void ChessShadowSelected(Point pnt, char c);
		void ChessUnshadowSelected(Point pnt, char c);
		void ChessHover(List<KeyValuePair<Point,char>> pntList);
		void ChessUnhover(List<KeyValuePair<Point, char>> pntList);
		void ChessMove(Point pntFrom, Point pntTo, char c);
		void ChessRemove(Point pnt);
        void StopTimers();

	}
}
