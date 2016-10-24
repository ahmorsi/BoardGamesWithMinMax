using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BoardGameProject
{
	interface TennoReversi
	{
          void UpdateReversi(List<Point> pnt);
          void IntializeReversi();
          void switchPlayer();
          void StopTimers();
	}

     
}
