using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BoardGameProject
{
	class Connect4 : BoardGame
	{
		private Unit R, B;
		private TennoC4 ViewController;

		public Connect4(Player newFirstPlayer, Player newSecondPlayer, TennoC4 newViewController)
			: base(newFirstPlayer, newSecondPlayer)
		{
			ViewController = newViewController;
			R = new Connect4unit('R', true);
			B = new Connect4unit('B', false);
			setGameState(new Board(6, 7));
            ViewController.IntializeConnect4();
		}

		public Connect4(Connect4 newGame)
			: base(newGame)
		{
			ViewController = newGame.getViewController();
			R = new Connect4unit('R', true);
			B = new Connect4unit('B', false);
			setGameState(new Board(6, 7));
		}

		public override void reSet()
		{
            setGameEnd(false);
			R = new Connect4unit('R', true);
			B = new Connect4unit('B', false);
			setGameState(new Board(6, 7));
            if (!getFirstPlayer().IsMyTurn())
                SwitchPlayer();
            ViewController.IntializeConnect4();
		}
		public Unit getR()
		{
			return R;
		}

		public Unit getB()
		{
			return B;
		}

		public TennoC4 getViewController()
		{
			return ViewController;
		}

		private bool Is_in_Range(int Row, int Column)
		{
			if (Row < 6 && Column < 7 && Row >= 0 && Column >= 0)
				return true;
			return false;
		}

		public override void PlayAt(int Row, int Column)
		{
			Row = is_avaliable(Column).X;

			if (!Is_in_Range(Row, Column) || getGameState().getUnit(Row, Column) != null || IsGameEnd())
				return;

			Unit CurrentUnit;
			Player Winer;

			if (getFirstPlayer().IsMyTurn())
				CurrentUnit = new Connect4unit(R);
			else
				CurrentUnit = new Connect4unit(B);

			getGameState().setUnit(Row, Column, CurrentUnit);
			ViewController.updateConnect4(new Point(Row , Column));

			Winer = isWin(Row, Column);
			if (Winer != null)
			{
                ViewController.StopTimers();
				MessageBox.Show("Player " + Winer.getName() + " Win");
				setGameEnd(true);
			}
			else if (isTie())
			{
                ViewController.StopTimers();
				MessageBox.Show("Tie");
				setGameEnd(true);
			}
			else
			{
				SwitchPlayer();
				ViewController.switchPlayer();
			}
		}

		private int CheckIfFour(int Row, int Column, int newRow, int newColumn, Unit Past)
		{
			if (!Is_in_Range(Row, Column) || getGameState().getUnit(Row, Column) == null || getGameState().getUnit(Row, Column).getUnitCode() != Past.getUnitCode())
				return 0;

			return CheckIfFour(Row + newRow, Column + newColumn, newRow, newColumn, Past) + 1;
		}

		public Player isWin(int Row, int Column)
		{
			if (!Is_in_Range(Row, Column))
				return null;

			Player Winer = null;
			Unit CurrentUnit = getGameState().getUnit(Row, Column);
			int Counter;

			//Down
			Counter = CheckIfFour(Row, Column, 1, 0, CurrentUnit);
			if (Counter >= 4)
			{
				if (CurrentUnit.getIsFirstPlayer())
				{
					Winer = getFirstPlayer();
				}
				else
				{
					Winer = getSecondPlayer();
				}
			}

			//Right Left
			Counter = CheckIfFour(Row, Column, 0, 1, CurrentUnit) + CheckIfFour(Row, Column, 0, -1, CurrentUnit) - 1;
			if (Counter >= 4)
			{
				if (CurrentUnit.getIsFirstPlayer())
				{
					Winer = getFirstPlayer();
				}
				else
				{
					Winer = getSecondPlayer();
				}
			}

			//To Left Top And Right Down
			Counter = CheckIfFour(Row, Column, 1, 1, CurrentUnit) + CheckIfFour(Row, Column, -1, -1, CurrentUnit) - 1;
			if (Counter >= 4)
			{
				if (CurrentUnit.getIsFirstPlayer())
				{
					Winer = getFirstPlayer();
				}
				else
				{
					Winer = getSecondPlayer();
				}
			}

			//To Right Top And Left Down
			Counter = CheckIfFour(Row, Column, 1, -1, CurrentUnit) + CheckIfFour(Row, Column, -1, 1, CurrentUnit) - 1;
			if (Counter >= 4)
			{
				if (CurrentUnit.getIsFirstPlayer())
				{
					Winer = getFirstPlayer();
				}
				else
				{
					Winer = getSecondPlayer();
				}
			}

			return Winer;
		}

		public bool isTie()
		{
			for (int i = 0; i < getGameState().getRows(); i++)
			{
				for (int j = 0; j < getGameState().getColoums(); j++)
				{
					if (getGameState().getUnit(i, j) == null)
						return false;
				}
			}

			return true;
		}

		public Point is_avaliable(int Coloumn)
		{
			for (int i = 5; i >= 0; i--)
			{
				if (getGameState().getUnit(i, Coloumn) == null)
					return new Point(i, Coloumn);
			}
			return new Point(-1, -1);
		}

		public Point get_avaliable(int Coloumn)
		{
			int temp_i = 0;
			for (int i = 0; i < 6; i++)
			{
				if (getGameState().getUnit(i, Coloumn) != null)
				{
					temp_i = i;
					break;
				}
			}
			return new Point(temp_i - 1, Coloumn);
		}
	}
}
