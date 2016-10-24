using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BoardGameProject
{
	interface TennoXO
	{
        void IntializeXO();
        void UpdateXO(Point pnt);
        void switchPlayer();
        void StopTimers();
	}
}
