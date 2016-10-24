using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BoardGameProject
{
	class Reversi : BoardGame
	{
		private Unit B, W;
		private TennoReversi ViewController;
		private List<Point> BlackList = new List<Point>();
		private List<Point> WhiteList = new List<Point>();
		private List<KeyValuePair<Point, List<Point>>> ValidMoves = new List<KeyValuePair<Point,List<Point>>>();//3AYZEN KOL MARA LIST GADEEDA
		private List<Point> ChangedUnits = new List<Point>();
		private Point[] direc = {(new Point(0, -1)),
								(new Point(1, 0)),
								(new Point(-1, 0)),
								(new Point(0, 1)),
								(new Point(1, -1)),
								(new Point(-1, -1)),
								(new Point(1, 1)),
								(new Point(-1, 1))};

		public Reversi(Player newFirstPlayer, Player newSecondPlayer, TennoReversi newViewController)
			: base(newFirstPlayer, newSecondPlayer)
		{
			ViewController = newViewController;
			B = new Reversiunit('B', false);
			W = new Reversiunit('W', true);
			setGameState(new Board(8, 8));
			getGameState().setUnit(3, 3, new Reversiunit('W', true));
			WhiteList.Add(new Point(3, 3));
			getGameState().setUnit(4, 4, new Reversiunit('W', true));
			WhiteList.Add(new Point(4, 4));
			getGameState().setUnit(3, 4, new Reversiunit('B', false));
			BlackList.Add(new Point(3, 4));
			getGameState().setUnit(4, 3, new Reversiunit('B', false));
			BlackList.Add(new Point(4, 3));

			ViewController.IntializeReversi();
		}
		public Reversi(Reversi newGame)
			: base(newGame)
		{
			ViewController = newGame.getViewController();
			B = new Reversiunit('B', false);
			W = new Reversiunit('W', true);
			setGameState(new Board(8, 8));
			getGameState().setUnit(3, 3, new Reversiunit('W', true));
			WhiteList.Add(new Point(3, 3));
			getGameState().setUnit(4, 4, new Reversiunit('W', true));
			WhiteList.Add(new Point(4, 4));
			getGameState().setUnit(3, 4, new Reversiunit('B', false));
			BlackList.Add(new Point(3, 4));
			getGameState().setUnit(4, 3, new Reversiunit('B', false));
			BlackList.Add(new Point(4, 3));
		}

        public override void reSet()
        {
            setGameEnd(false);
            B = new Reversiunit('B', false);
            W = new Reversiunit('W', true);
            setGameState(new Board(8, 8));
            getGameState().setUnit(3, 3, new Reversiunit('W', true));
            WhiteList.Add(new Point(3, 3));
            getGameState().setUnit(4, 4, new Reversiunit('W', true));
            WhiteList.Add(new Point(4, 4));
            getGameState().setUnit(3, 4, new Reversiunit('B', false));
            BlackList.Add(new Point(3, 4));
            getGameState().setUnit(4, 3, new Reversiunit('B', false));
            BlackList.Add(new Point(4, 3));
            if (!getFirstPlayer().IsMyTurn())
                SwitchPlayer();
            ViewController.IntializeReversi();
        }
		public Unit getB()
		{
			return B;
		}

		public Unit getW()
		{
			return W;
		}

		public TennoReversi getViewController()
		{
			return ViewController;
		}

		public override void PlayAt(int Row, int Column)
		{
			if (IsGameEnd())
				return;

			ValidMoves.Clear();
			ChangedUnits.Clear();

			if (CheckValid(Row, Column))
			{
				TakeAction();
				Set_Lists(ChangedUnits);
				ViewController.UpdateReversi(ChangedUnits);

				if (getFirstPlayer().IsMyTurn())
				{
					CheckEnd(BlackList, WhiteList);
				}
				else
				{
					CheckEnd(WhiteList, BlackList);
				}

				Player Winner = isWin();

				if (Winner != null)
				{
                    ViewController.StopTimers();
					MessageBox.Show("Player " + Winner.getName() + " Win");
				}
				else if (isTie())
				{
                    ViewController.StopTimers();
					MessageBox.Show("Tie");
				}

				SwitchPlayer();
                ViewController.switchPlayer();
			}
		}

		public bool inRange(int X, int Y)//X is Row && Y is Column
		{
			if (X >= getGameState().getRows() || Y >= getGameState().getColoums() || Y < 0 || X < 0)
				return false;
			return true;
		}

		private bool CheckValid(int Row, int Column)
		{
			if (!inRange(Row, Column) || getGameState().getUnit(Row, Column) != null)
				return false;
			else
			{
				int CurrentRow;
				int CurrentColumn;
				char UnitCode;
				Point EndPoint, StartPoint = new Point(Row, Column);
				bool Valid = false;
				List<Point> EndPoints = new List<Point>();

				if (getFirstPlayer().IsMyTurn())
				{
					UnitCode = W.getUnitCode();
				}
				else
				{
					UnitCode = B.getUnitCode();
				}

				for (int CurrentDirection = 0; CurrentDirection < 8; CurrentDirection++)
				{
					CurrentRow = Row + direc[CurrentDirection].X;
					CurrentColumn = Column + direc[CurrentDirection].Y;

					if (inRange(CurrentRow, CurrentColumn))
					{
						if (getGameState().getUnit(CurrentRow, CurrentColumn) != null)
						{
							if (UnitCode != getGameState().getUnit(CurrentRow, CurrentColumn).getUnitCode())
							{
								EndPoint = FindEnd(CurrentRow, CurrentColumn, direc[CurrentDirection], UnitCode);

								if (EndPoint.X != -1 && EndPoint.Y != -1)
								{
									Valid = true;
									EndPoints.Add(EndPoint);
								}
							}
						}
					}
				}

				if(EndPoints.Count > 0)
					ValidMoves.Add(new KeyValuePair<Point, List<Point>>(StartPoint, EndPoints));

				return Valid;
			}
		}

		private Point FindEnd(int Row, int Column, Point dir, char UnitCode)
		{
			Row += dir.X;
			Column += dir.Y;

			if (inRange(Row, Column))
			{
				if (getGameState().getUnit(Row, Column) != null)
				{
					if (getGameState().getUnit(Row, Column).getUnitCode() == UnitCode)
					{
						return new Point(Row, Column);
					}
					else
					{
						return FindEnd(Row, Column, dir, UnitCode);
					}
				}
			}

			return new Point(-1, -1);
		}

		public void CheckEnd(List<Point> First , List<Point> Second)
		{
			if (BlackList.Count() + WhiteList.Count() == 64)
			{
				setGameEnd(true);
				return;
			}
			if (WhiteList.Count() == 0)
			{
				setGameEnd(true);
				return;
			}
			if (BlackList.Count() == 0)
			{
				setGameEnd(true);
				return;
			}

			ValidMoves.Clear();
			SetValidMoves(First);

			if (ValidMoves.Count == 0)
			{
				ValidMoves.Clear();
				SetValidMoves(Second);
				SwitchPlayer();
                ViewController.switchPlayer();

				if (ValidMoves.Count == 0)
				{
					setGameEnd(true);
				}
			}
		}

		public bool isTie()
		{
			if (IsGameEnd())
			{
				if (BlackList.Count() == WhiteList.Count())
					return true;
			}

			return false;
		}

		public Player isWin()
		{
			if (IsGameEnd())
			{
				if (BlackList.Count() > WhiteList.Count())
					return getSecondPlayer();
				if (WhiteList.Count() > BlackList.Count())
					return getFirstPlayer();
			}

			return null;
		}

		public void SetValidMoves(List<Point> Selected)
		{
			Point Current , StartPoint;
			int CurrentRow , CurrentColumn;
			char UnitCode;

			for (int CurrentUnit = 0; CurrentUnit < Selected.Count; CurrentUnit++)
			{
				List<Point> StartPoints = new List<Point>();
				Current = Selected[CurrentUnit];
				UnitCode = getGameState().getUnit(Current.X , Current.Y).getUnitCode();

				for (int CurrentDirection = 0; CurrentDirection < 8; CurrentDirection++)
				{
					CurrentRow = Current.X + direc[CurrentDirection].X;
					CurrentColumn = Current.Y + direc[CurrentDirection].Y;

					if (inRange(CurrentRow, CurrentColumn))
					{
						if(getGameState().getUnit(CurrentRow , CurrentColumn) != null)
						{
							if (getGameState().getUnit(CurrentRow, CurrentColumn).getUnitCode() != UnitCode)
							{
								StartPoint = FindStart(CurrentRow, CurrentColumn, direc[CurrentDirection] , UnitCode);

								if (StartPoint.X != -1 && StartPoint.Y != -1)
									StartPoints.Add(StartPoint);
							}
						}
					}
				}

				if (StartPoints.Count > 0)
					ValidMoves.Add(new KeyValuePair<Point, List<Point>>(Current , StartPoints));
			}
		}

		private Point FindStart(int Row, int Column, Point dir, char UnitCode)
		{
			Row += dir.X;
			Column += dir.Y;

			if (inRange(Row, Column))
			{
				if (getGameState().getUnit(Row, Column) == null)
				{
					return new Point(Row, Column);
				}
				else
				{
					if (getGameState().getUnit(Row, Column).getUnitCode() != UnitCode)
					{
						return FindStart(Row, Column, dir, UnitCode);
					}
				}
			}

			return new Point(-1, -1);
		}

		private void TakeAction()
		{
			KeyValuePair<Point, List<Point>> CurrentMove;
			KeyValuePair<Point, Point> Current;

			for (int CurrentValidMove = 0; CurrentValidMove < ValidMoves.Count; CurrentValidMove++)
			{
				CurrentMove = ValidMoves[CurrentValidMove];
				ChangedUnits.Add(CurrentMove.Key);
				for (int CurrentEndPoint = 0; CurrentEndPoint < CurrentMove.Value.Count; CurrentEndPoint++)
				{
					Current = new KeyValuePair<Point, Point>(CurrentMove.Key, CurrentMove.Value[CurrentEndPoint]);
					ChangeUnits(Current);
				}
			}
		}

		public void ChangeUnits(KeyValuePair<Point, Point> p)//X is Row && Y is Column
		{
			Point EndUnit = p.Value;
			Point StartUnit = p.Key;

			if (p.Key.X == p.Value.X)
			{
				if (p.Key.Y > p.Value.Y)
					p = new KeyValuePair<Point, Point>(p.Value, p.Key);

				for (int i = p.Key.Y; i <= p.Value.Y; i++)
				{
					getGameState().setUnit(p.Key.X, i, getGameState().getUnit(EndUnit.X, EndUnit.Y));
					if (!(EndUnit.X == p.Key.X && EndUnit.Y == i) && !(StartUnit.X == p.Key.X && StartUnit.Y == i))
						ChangedUnits.Add(new Point(p.Key.X, i));
				}
			}
			else if (p.Key.Y == p.Value.Y)
			{
				if (p.Key.X > p.Value.X)
					p = new KeyValuePair<Point, Point>(p.Value, p.Key);

				for (int i = p.Key.X; i <= p.Value.X; i++)
				{
					getGameState().setUnit(i, p.Value.Y, getGameState().getUnit(EndUnit.X, EndUnit.Y));
					if (!(EndUnit.X == i && EndUnit.Y == p.Value.Y) && !(StartUnit.X == i && StartUnit.Y == p.Value.Y))
						ChangedUnits.Add(new Point(i, p.Value.Y));
				}
			}
			else if (p.Key.X > p.Value.X && p.Key.Y > p.Value.Y)// swap operation
			{
				for (int i = p.Value.X, j = p.Value.Y; i <= p.Key.X && j <= p.Key.Y; i++, j++)
				{
					getGameState().setUnit(i, j, getGameState().getUnit(EndUnit.X, EndUnit.Y));
					if (!(EndUnit.X == i && EndUnit.Y == j) && !(StartUnit.X == i && StartUnit.Y == j))
						ChangedUnits.Add(new Point(i, j));
				}
			}
			else if (p.Value.X > p.Key.X && p.Value.Y > p.Key.Y)
			{
				for (int i = p.Key.X, j = p.Key.Y; i <= p.Value.X && j <= p.Value.Y; i++, j++)
				{
					getGameState().setUnit(i, j, getGameState().getUnit(EndUnit.X, EndUnit.Y));
					if (!(EndUnit.X == i && EndUnit.Y == j) && !(StartUnit.X == i && StartUnit.Y == j))
						ChangedUnits.Add(new Point(i, j));
				}
			}
			else
			{
				if (p.Key.X < p.Value.X && p.Key.Y > p.Value.Y)
					p = new KeyValuePair<Point, Point>(p.Value, p.Key);

				for (int i = p.Key.X, j = p.Key.Y; i >= 0 && j <= p.Value.Y; i--, j++)
				{
					getGameState().setUnit(i, j, getGameState().getUnit(EndUnit.X, EndUnit.Y));
					if (!(EndUnit.X == i && EndUnit.Y == j) && !(StartUnit.X == i && StartUnit.Y == j))
						ChangedUnits.Add(new Point(i, j));
				}

			}
		}

		private void Set_Lists(List<Point> Updated_Units)
		{
			if (getFirstPlayer().IsMyTurn())
			{
				for (int i = 0; i < Updated_Units.Count ; i++)
				{
					BlackList.Remove(Updated_Units.ElementAt(i));
					WhiteList.Add(Updated_Units.ElementAt(i));
				}
			}
			else
			{
				for (int i = 0; i < Updated_Units.Count; i++)
				{
					WhiteList.Remove(Updated_Units.ElementAt(i));
					BlackList.Add(Updated_Units.ElementAt(i));
				}
			}
		}
	}
}