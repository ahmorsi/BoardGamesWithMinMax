using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BoardGameProject
{
	interface TennoCheckers
	{
		void IntializeCheckers();
        void switchPlayer();
		void DeleteChecker(Point Killed);
		void MoveChecker(Point KillerFrom, Point KillerTo , bool King);
		void ShadowSelectedChecker(Point Selected, bool King);
		void UnShadowSelectedChecker(Point UnSelected, bool King);
		void HoverValidMoves(List<Point> Hover);
		void UnHoverValidMoves(List<Point> UnHover);
        void StopTimers();
	}
}
