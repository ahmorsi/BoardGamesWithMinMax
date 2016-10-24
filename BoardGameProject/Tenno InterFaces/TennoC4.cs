using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BoardGameProject
{
	interface TennoC4
	{
        void IntializeConnect4();
		void updateConnect4(Point pnt);
        void switchPlayer();
        void StopTimers();
	}
}
