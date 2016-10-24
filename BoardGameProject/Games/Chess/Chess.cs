using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BoardGameProject
{
	class Chess : BoardGame
	{
		private Point Selected;
		private List<KeyValuePair<Point, char>> Hover;
		private TennoChess ViewController;
		private List<Point> BlackList;
		private List<Point> WhiteList;
		private Point WhiteKing;
		private Point BlackKing;

		public Chess(Player newFirstPlayer, Player newSecondPlayer, TennoChess newViewController)
			: base(newFirstPlayer, newSecondPlayer)
		{
			Selected = new Point(-1, -1);
			BlackList = new List<Point>();
			WhiteList = new List<Point>();
			Hover = new List<KeyValuePair<Point, char>>();
			ViewController = newViewController;
			setGameState(new Board(8, 8));

			ChessUnit Temp;

			//White
			Temp = new KingUnit('K', true);
			Temp.IntializeAvailableMoves(7, 4);
			getGameState().setUnit(7, 4, Temp);
			WhiteList.Add(new Point(7, 4));
			WhiteKing = new Point(7, 4);

			Temp = new QueenUnit('Q', true);
			Temp.IntializeAvailableMoves(7, 3);
			getGameState().setUnit(7, 3, Temp);
			WhiteList.Add(new Point(7, 3));

			Temp = new BishopUnit('B', true);
			Temp.IntializeAvailableMoves(7, 2);
			getGameState().setUnit(7, 2, Temp);
			WhiteList.Add(new Point(7, 2));
			Temp = new BishopUnit('B', true);
			Temp.IntializeAvailableMoves(7, 5);
			getGameState().setUnit(7, 5, Temp);
			WhiteList.Add(new Point(7, 5));

			Temp = new KnightUnit('N', true);
			Temp.IntializeAvailableMoves(7, 1);
			getGameState().setUnit(7, 1, Temp);
			WhiteList.Add(new Point(7, 1));
			Temp = new KnightUnit('N', true);
			Temp.IntializeAvailableMoves(7, 6);
			getGameState().setUnit(7, 6, Temp);
			WhiteList.Add(new Point(7, 6));

			Temp = new RockUnit('R', true);
			Temp.IntializeAvailableMoves(7, 0);
			getGameState().setUnit(7, 0, Temp);
			WhiteList.Add(new Point(7, 0));
			Temp = new RockUnit('R', true);
			Temp.IntializeAvailableMoves(7, 7);
			getGameState().setUnit(7, 7, Temp);
			WhiteList.Add(new Point(7, 7));

			for (int CurrentPawn = 0; CurrentPawn < 8; CurrentPawn++)
			{
				Temp = new PawnUnit('P', true);
				Temp.IntializeAvailableMoves(6, CurrentPawn);
				getGameState().setUnit(6, CurrentPawn, Temp);
				WhiteList.Add(new Point(6, CurrentPawn));
			}

			//Black
			Temp = new KingUnit('k', false);
			Temp.IntializeAvailableMoves(0, 4);
			getGameState().setUnit(0, 4, Temp);
			BlackList.Add(new Point(0, 4));
			BlackKing = new Point(0, 4);

			Temp = new QueenUnit('q', false);
			Temp.IntializeAvailableMoves(0, 3);
			getGameState().setUnit(0, 3, Temp);
			BlackList.Add(new Point(0, 3));

			Temp = new BishopUnit('b', false);
			Temp.IntializeAvailableMoves(0, 2);
			getGameState().setUnit(0, 2, Temp);
			BlackList.Add(new Point(0, 2));
			Temp = new BishopUnit('b', false);
			Temp.IntializeAvailableMoves(0, 5);
			getGameState().setUnit(0, 5, Temp);
			BlackList.Add(new Point(0, 5));

			Temp = new KnightUnit('n', false);
			Temp.IntializeAvailableMoves(0, 1);
			getGameState().setUnit(0, 1, Temp);
			BlackList.Add(new Point(0, 1));
			Temp = new KnightUnit('n', false);
			Temp.IntializeAvailableMoves(0, 6);
			getGameState().setUnit(0, 6, Temp);
			BlackList.Add(new Point(0, 6));

			Temp = new RockUnit('r', false);
			Temp.IntializeAvailableMoves(0, 0);
			getGameState().setUnit(0, 0, Temp);
			BlackList.Add(new Point(0, 0));
			Temp = new RockUnit('r', false);
			Temp.IntializeAvailableMoves(0, 7);
			getGameState().setUnit(0, 7, Temp);
			BlackList.Add(new Point(0, 7));

			for (int CurrentPawn = 0; CurrentPawn < 8; CurrentPawn++)
			{
				Temp = new PawnUnit('p', false);
				Temp.IntializeAvailableMoves(1, CurrentPawn);
				getGameState().setUnit(1, CurrentPawn, Temp);
				BlackList.Add(new Point(1, CurrentPawn));
			}

            if (!getFirstPlayer().IsMyTurn())
                SwitchPlayer();

			ViewController.IntializeChess();
		}

        public override void reSet()
        {
            if (!getFirstPlayer().IsMyTurn())
                SwitchPlayer();
            setGameEnd(false);
            Selected = new Point(-1, -1);
            BlackList.Clear();
            WhiteList.Clear();
            Hover.Clear();
            setGameState(new Board(8, 8));

            ChessUnit Temp;

            //White
            Temp = new KingUnit('K', true);
            Temp.IntializeAvailableMoves(7, 4);
            getGameState().setUnit(7, 4, Temp);
            WhiteList.Add(new Point(7, 4));
            WhiteKing = new Point(7, 4);

            Temp = new QueenUnit('Q', true);
            Temp.IntializeAvailableMoves(7, 3);
            getGameState().setUnit(7, 3, Temp);
            WhiteList.Add(new Point(7, 3));

            Temp = new BishopUnit('B', true);
            Temp.IntializeAvailableMoves(7, 2);
            getGameState().setUnit(7, 2, Temp);
            WhiteList.Add(new Point(7, 2));
            Temp = new BishopUnit('B', true);
            Temp.IntializeAvailableMoves(7, 5);
            getGameState().setUnit(7, 5, Temp);
            WhiteList.Add(new Point(7, 5));

            Temp = new KnightUnit('N', true);
            Temp.IntializeAvailableMoves(7, 1);
            getGameState().setUnit(7, 1, Temp);
            WhiteList.Add(new Point(7, 1));
            Temp = new KnightUnit('N', true);
            Temp.IntializeAvailableMoves(7, 6);
            getGameState().setUnit(7, 6, Temp);
            WhiteList.Add(new Point(7, 6));

            Temp = new RockUnit('R', true);
            Temp.IntializeAvailableMoves(7, 0);
            getGameState().setUnit(7, 0, Temp);
            WhiteList.Add(new Point(7, 0));
            Temp = new RockUnit('R', true);
            Temp.IntializeAvailableMoves(7, 7);
            getGameState().setUnit(7, 7, Temp);
            WhiteList.Add(new Point(7, 7));

            for (int CurrentPawn = 0; CurrentPawn < 8; CurrentPawn++)
            {
                Temp = new PawnUnit('P', true);
                Temp.IntializeAvailableMoves(6, CurrentPawn);
                getGameState().setUnit(6, CurrentPawn, Temp);
                WhiteList.Add(new Point(6, CurrentPawn));
            }

            //Black
            Temp = new KingUnit('k', false);
            Temp.IntializeAvailableMoves(0, 4);
            getGameState().setUnit(0, 4, Temp);
            BlackList.Add(new Point(0, 4));
            BlackKing = new Point(0, 4);

            Temp = new QueenUnit('q', false);
            Temp.IntializeAvailableMoves(0, 3);
            getGameState().setUnit(0, 3, Temp);
            BlackList.Add(new Point(0, 3));

            Temp = new BishopUnit('b', false);
            Temp.IntializeAvailableMoves(0, 2);
            getGameState().setUnit(0, 2, Temp);
            BlackList.Add(new Point(0, 2));
            Temp = new BishopUnit('b', false);
            Temp.IntializeAvailableMoves(0, 5);
            getGameState().setUnit(0, 5, Temp);
            BlackList.Add(new Point(0, 5));

            Temp = new KnightUnit('n', false);
            Temp.IntializeAvailableMoves(0, 1);
            getGameState().setUnit(0, 1, Temp);
            BlackList.Add(new Point(0, 1));
            Temp = new KnightUnit('n', false);
            Temp.IntializeAvailableMoves(0, 6);
            getGameState().setUnit(0, 6, Temp);
            BlackList.Add(new Point(0, 6));

            Temp = new RockUnit('r', false);
            Temp.IntializeAvailableMoves(0, 0);
            getGameState().setUnit(0, 0, Temp);
            BlackList.Add(new Point(0, 0));
            Temp = new RockUnit('r', false);
            Temp.IntializeAvailableMoves(0, 7);
            getGameState().setUnit(0, 7, Temp);
            BlackList.Add(new Point(0, 7));

            for (int CurrentPawn = 0; CurrentPawn < 8; CurrentPawn++)
            {
                Temp = new PawnUnit('p', false);
                Temp.IntializeAvailableMoves(1, CurrentPawn);
                getGameState().setUnit(1, CurrentPawn, Temp);
                BlackList.Add(new Point(1, CurrentPawn));
            }

            ViewController.IntializeChess();
        }

		private bool InRange(int Row, int Column)
		{
			return (Row >= 0 && Column >= 0 && Row < 8 && Column < 8);
		}

		private void Select(int Row, int Column)
		{
			setValidMove();
			ViewController.ChessShadowSelected(new Point(Row, Column), getGameState().getUnit(Row, Column).getUnitCode());
			ViewController.ChessHover(Hover);
		}

		private void UnSelect()
		{
			ViewController.ChessUnshadowSelected(new Point(Selected.X, Selected.Y), getGameState().getUnit(Selected.X, Selected.Y).getUnitCode());
			ViewController.ChessUnhover(Hover);
			Selected = new Point(-1, -1);
		}

		private void UpdateKingPosition(int Row, int Column)
		{
			if (getFirstPlayer().IsMyTurn())
				WhiteKing = new Point(Row, Column);
			else
				BlackKing = new Point(Row, Column);
		}

		private void Move(int Row, int Column)
		{
			Point Current = new Point(Selected.X, Selected.Y);

			Point TempKing;
			List<Point> CurrentList;

			if (getFirstPlayer().IsMyTurn())
			{
				TempKing = new Point(WhiteKing.X, WhiteKing.Y);
				CurrentList = WhiteList;
			}
			else
			{
				TempKing = new Point(BlackKing.X, BlackKing.Y);
				CurrentList = BlackList;
			}

			if ((Selected.X == WhiteKing.X && Selected.Y == WhiteKing.Y) || (Selected.X == BlackKing.X && Selected.Y == BlackKing.Y))
				UpdateKingPosition(Row, Column);

			UnSelect();
			ViewController.ChessMove(Current, new Point(Row, Column), getGameState().getUnit(Current.X, Current.Y).getUnitCode());

			if (getGameState().getUnit(Row, Column) != null)
			{
				if (getFirstPlayer().IsMyTurn())
					BlackList.Remove(new Point(Row, Column));
				else
					WhiteList.Remove(new Point(Row, Column));
			}

			ChessUnit Temp = (ChessUnit)getGameState().getUnit(Current.X, Current.Y);
			Temp.ChangeAvailableMoves(Row, Column);

			getGameState().setUnit(Current.X, Current.Y, null);
			getGameState().setUnit(Row, Column, Temp);

			if (getFirstPlayer().IsMyTurn())
			{
				WhiteList.Remove(new Point(Current.X, Current.Y));
				WhiteList.Add(new Point(Row, Column));
			}
			else
			{
				BlackList.Remove(new Point(Current.X, Current.Y));
				BlackList.Add(new Point(Row, Column));
			}

			if (TempKing.X == Current.X && TempKing.Y == Current.Y)
			{
				if (getFirstPlayer().IsMyTurn())
				{
					if (TempKing.X != 7)
						return;
				}
				else
				{
					if (TempKing.X != 0)
						return;
				}

				if (Row == Current.X && Column == 6)
				{
					ChessUnit Rock = (ChessUnit)getGameState().getUnit(Current.X, 7);
					getGameState().setUnit(Current.X, 7, null);
					getGameState().setUnit(Current.X, 5, Rock);
					CurrentList.Remove(new Point(Current.X, 7));
					CurrentList.Add(new Point(Current.X, 5));
					ViewController.ChessMove(new Point(Current.X, 7), new Point(Current.X, 5), getGameState().getUnit(Current.X, 5).getUnitCode());
					((ChessUnit)getGameState().getUnit(Current.X, 5)).ChangeAvailableMoves(Current.X, 5);
				}
				else if (Row == Current.X && Column == 2)
				{
					ChessUnit Rock = (ChessUnit)getGameState().getUnit(Current.X, 0);
					getGameState().setUnit(Current.X, 0, null);
					getGameState().setUnit(Current.X, 3, Rock);
					CurrentList.Remove(new Point(Current.X, 0));
					CurrentList.Add(new Point(Current.X, 3));
					ViewController.ChessMove(new Point(Current.X, 0), new Point(Current.X, 3), getGameState().getUnit(Current.X, 3).getUnitCode());
					((ChessUnit)getGameState().getUnit(Current.X, 3)).ChangeAvailableMoves(Current.X, 3);
				}
			}
		}

		private void setPawnValidMove()
		{
			List<List<Point>> Temp = ((ChessUnit)getGameState().getUnit(Selected.X, Selected.Y)).getAvailableMoves();
			int newRow, newColumn;
			Hover.Clear();

			newRow = Temp[2][0].X;
			newColumn = Temp[2][0].Y;

			if (InRange(newRow, newColumn) && getGameState().getUnit(newRow, newColumn) == null)
			{
				if (WhatIf(newRow, newColumn))
				{
					Hover.Add(new KeyValuePair<Point, char>(new Point(newRow, newColumn), '\0'));
				}

				if (Temp.Count == 4)
				{
					newRow = Temp[3][0].X;
					newColumn = Temp[3][0].Y;

					if (getGameState().getUnit(newRow, newColumn) == null)
					{
						if (WhatIf(newRow, newColumn))
						{
							Hover.Add(new KeyValuePair<Point, char>(new Point(newRow, newColumn), '\0'));
						}
					}
				}
			}

			newRow = Temp[0][0].X;
			newColumn = Temp[0][0].Y;

			if (InRange(newRow, newColumn) && getGameState().getUnit(newRow, newColumn) != null)
			{
				if (getGameState().getUnit(newRow, newColumn).getIsFirstPlayer() != getGameState().getUnit(Selected.X, Selected.Y).getIsFirstPlayer())
					Hover.Add(new KeyValuePair<Point, char>(new Point(newRow, newColumn), getGameState().getUnit(newRow, newColumn).getUnitCode()));
			}

			newRow = Temp[1][0].X;
			newColumn = Temp[1][0].Y;

			if (InRange(newRow, newColumn) && getGameState().getUnit(newRow, newColumn) != null)
			{
				if (getGameState().getUnit(newRow, newColumn).getIsFirstPlayer() != getGameState().getUnit(Selected.X, Selected.Y).getIsFirstPlayer())
					Hover.Add(new KeyValuePair<Point, char>(new Point(newRow, newColumn), getGameState().getUnit(newRow, newColumn).getUnitCode()));
			}
		}

		private void setKnightValidMove()
		{
			List<List<Point>> Temp = ((ChessUnit)getGameState().getUnit(Selected.X, Selected.Y)).getAvailableMoves();
			int newRow, newColumn;
			Hover.Clear();

			for (int CurrentDirection = 0; CurrentDirection < Temp.Count; CurrentDirection++)
			{
				for (int CurrentTile = 0; CurrentTile < Temp[CurrentDirection].Count; CurrentTile++)
				{
					newRow = Temp[CurrentDirection][CurrentTile].X;
					newColumn = Temp[CurrentDirection][CurrentTile].Y;

					if (InRange(newRow, newColumn))
					{
						if (getGameState().getUnit(newRow, newColumn) != null)
						{
							bool Owner = getGameState().getUnit(newRow, newColumn).getIsFirstPlayer();

							if (getGameState().getUnit(Selected.X, Selected.Y).getIsFirstPlayer() != Owner)
							{
								if (WhatIf(newRow, newColumn))
								{
									Hover.Add(new KeyValuePair<Point, char>(new Point(newRow, newColumn), getGameState().getUnit(newRow, newColumn).getUnitCode()));
								}
							}
						}
						else
						{
							if (WhatIf(newRow, newColumn))
							{
								Hover.Add(new KeyValuePair<Point, char>(new Point(newRow, newColumn), '\0'));
							}
						}
					}
				}
			}
		}

		private void setKingValidMove()
		{
			List<List<Point>> Temp = ((ChessUnit)getGameState().getUnit(Selected.X, Selected.Y)).getAvailableMoves();
			int newRow, newColumn;
			Hover.Clear();

			for (int CurrentDirection = 0; CurrentDirection < 8; CurrentDirection++)
			{
				newRow = Temp[CurrentDirection][0].X;
				newColumn = Temp[CurrentDirection][0].Y;

				if (InRange(newRow, newColumn))
				{
					if (getGameState().getUnit(newRow, newColumn) == null)
					{
						if (WhatIf(newRow, newColumn))
						{
							Hover.Add(new KeyValuePair<Point, char>(new Point(newRow, newColumn), '\0'));
						}
					}
					else
					{
						if (getGameState().getUnit(newRow, newColumn).getIsFirstPlayer() != getGameState().getUnit(Selected.X, Selected.Y).getIsFirstPlayer())
						{
							if (WhatIf(newRow, newColumn))
							{
								Hover.Add(new KeyValuePair<Point, char>(new Point(newRow, newColumn), getGameState().getUnit(newRow, newColumn).getUnitCode()));
							}
						}
					}
				}
			}

			if (Temp.Count > 8)
			{
				if (getGameState().getUnit(Selected.X, 7) != null)
				{
					if (getFirstPlayer().IsMyTurn())
					{
						if (getGameState().getUnit(Selected.X, 7).getUnitCode() == 'R')
						{
							if (((ChessUnit)getGameState().getUnit(Selected.X, 7)).getAvailableMoves().Count > 4)
							{
								if (getGameState().getUnit(Selected.X, 5) == null && getGameState().getUnit(Selected.X, 6) == null)
								{
									if (WhatIf(Selected.X, 6))
									{
										Hover.Add(new KeyValuePair<Point, char>(new Point(Selected.X, 6), '\0'));
									}
								}
							}
						}
					}
					else
					{
						if (getGameState().getUnit(Selected.X, 7).getUnitCode() == 'r')
						{
							if (((ChessUnit)getGameState().getUnit(Selected.X, 7)).getAvailableMoves().Count > 4)
							{
								if (getGameState().getUnit(Selected.X, 5) == null && getGameState().getUnit(Selected.X, 6) == null)
								{
									if (WhatIf(Selected.X, 6))
									{
										Hover.Add(new KeyValuePair<Point, char>(new Point(Selected.X, 6), '\0'));
									}
								}
							}
						}
					}
				}

				if (getGameState().getUnit(Selected.X, 0) != null)
				{
					if (getFirstPlayer().IsMyTurn())
					{
						if (getGameState().getUnit(Selected.X, 0).getUnitCode() == 'R')
						{
							if (((ChessUnit)getGameState().getUnit(Selected.X, 0)).getAvailableMoves().Count > 4)
							{
								if (getGameState().getUnit(Selected.X, 1) == null && getGameState().getUnit(Selected.X, 2) == null && getGameState().getUnit(Selected.X, 3) == null)
								{
									if (WhatIf(Selected.X, 2))
									{
										Hover.Add(new KeyValuePair<Point, char>(new Point(Selected.X, 2), '\0'));
									}
								}
							}
						}
					}
					else
					{
						if (getGameState().getUnit(Selected.X, 0).getUnitCode() == 'r')
						{
							if (((ChessUnit)getGameState().getUnit(Selected.X, 0)).getAvailableMoves().Count > 4)
							{
								if (getGameState().getUnit(Selected.X, 1) == null && getGameState().getUnit(Selected.X, 2) == null && getGameState().getUnit(Selected.X, 3) == null)
								{
									if (WhatIf(Selected.X, 2))
									{
										Hover.Add(new KeyValuePair<Point, char>(new Point(Selected.X, 2), '\0'));
									}
								}
							}
						}
					}
				}
			}
		}

		private void setRockValidMove()
		{
			List<List<Point>> Temp = ((ChessUnit)getGameState().getUnit(Selected.X, Selected.Y)).getAvailableMoves();
			int newRow, newColumn;
			Hover.Clear();

			for (int CurrentDirection = 0; CurrentDirection < 4; CurrentDirection++)
			{
				for (int CurrentTile = 0; CurrentTile < Temp[CurrentDirection].Count; CurrentTile++)
				{
					newRow = Temp[CurrentDirection][CurrentTile].X;
					newColumn = Temp[CurrentDirection][CurrentTile].Y;

					if (InRange(newRow, newColumn))
					{
						if (getGameState().getUnit(newRow, newColumn) != null)
						{
							if (getGameState().getUnit(newRow, newColumn).getIsFirstPlayer() != getGameState().getUnit(Selected.X, Selected.Y).getIsFirstPlayer())
							{
								if (WhatIf(newRow, newColumn))
								{
									Hover.Add(new KeyValuePair<Point, char>(new Point(newRow, newColumn), getGameState().getUnit(newRow, newColumn).getUnitCode()));
								}
							}

							break;
						}
						else
						{
							if (WhatIf(newRow, newColumn))
							{
								Hover.Add(new KeyValuePair<Point, char>(new Point(newRow, newColumn), '\0'));
							}
						}
					}
					else
					{
						break;
					}
				}
			}
		}

		private void setGeneralValidMove()
		{
			List<List<Point>> Temp = ((ChessUnit)getGameState().getUnit(Selected.X, Selected.Y)).getAvailableMoves();
			int newRow, newColumn;
			Hover.Clear();

			for (int CurrentDirection = 0; CurrentDirection < Temp.Count; CurrentDirection++)
			{
				for (int CurrentTile = 0; CurrentTile < Temp[CurrentDirection].Count; CurrentTile++)
				{
					newRow = Temp[CurrentDirection][CurrentTile].X;
					newColumn = Temp[CurrentDirection][CurrentTile].Y;

					if (InRange(newRow, newColumn))
					{
						if (getGameState().getUnit(newRow, newColumn) != null)
						{
							if (getGameState().getUnit(newRow, newColumn).getIsFirstPlayer() != getGameState().getUnit(Selected.X, Selected.Y).getIsFirstPlayer())
							{
								if (WhatIf(newRow, newColumn))
								{
									Hover.Add(new KeyValuePair<Point, char>(new Point(newRow, newColumn), getGameState().getUnit(newRow, newColumn).getUnitCode()));
								}
							}

							break;
						}
						else
						{
							if (WhatIf(newRow, newColumn))
							{
								Hover.Add(new KeyValuePair<Point, char>(new Point(newRow, newColumn), '\0'));
							}
						}
					}
					else
					{
						break;
					}
				}
			}
		}

		private void setValidMove()
		{
			char UnitCode = ((ChessUnit)getGameState().getUnit(Selected.X, Selected.Y)).getUnitCode();

			if (UnitCode == 'P' || UnitCode == 'p')
			{
				setPawnValidMove();
			}
			else if (UnitCode == 'N' || UnitCode == 'n')
			{
				setKnightValidMove();
			}
			else if (UnitCode == 'K' || UnitCode == 'k')
			{
				setKingValidMove();
			}
			else if (UnitCode == 'R' || UnitCode == 'r')
			{
				setRockValidMove();
			}
			else
			{
				setGeneralValidMove();
			}
		}

		private bool IsValidMove(int Row, int Column)
		{
			for (int CurrentValidMove = 0; CurrentValidMove < Hover.Count; CurrentValidMove++)
			{
				if (Hover[CurrentValidMove].Key.X == Row && Hover[CurrentValidMove].Key.Y == Column)
					return true;
			}

			return false;
		}

		private bool WhatIf(int Row, int Column)//true if Valid
		{
			ChessUnit Moved = (ChessUnit)getGameState().getUnit(Selected.X, Selected.Y);
			ChessUnit Killed = (ChessUnit)getGameState().getUnit(Row, Column);
			Point TempKing = new Point(-1, -1);
			bool Valid = true;

			if (getFirstPlayer().IsMyTurn())
				TempKing = new Point(WhiteKing.X , WhiteKing.Y);
			else
				TempKing = new Point(BlackKing.X , BlackKing.Y);

			if ((Selected.X == WhiteKing.X && Selected.Y == WhiteKing.Y) || (Selected.X == BlackKing.X && Selected.Y == BlackKing.Y))
				UpdateKingPosition(Row, Column);

			getGameState().setUnit(Row , Column , Moved);
			getGameState().setUnit(Selected.X, Selected.Y, null);

			if (getFirstPlayer().IsMyTurn())
			{
				if (Checked(WhiteKing.X , WhiteKing.Y))
				{
					Valid = false;
				}
			}
			else
			{
				if(Checked(BlackKing.X , BlackKing.Y))
				{
					Valid = false;
				}
			}

			getGameState().setUnit(Selected.X, Selected.Y, Moved);
			getGameState().setUnit(Row, Column, Killed);

			if (!(TempKing.X == -1 && TempKing.Y == -1))
				UpdateKingPosition(TempKing.X, TempKing.Y);

			return Valid;
		}

		private bool KingCheckedByKnight(int Row, int Column)
		{
			List<Point> Directions = new List<Point>();
			Directions.Add(new Point(-1, -2));
			Directions.Add(new Point(-1, 2));
			Directions.Add(new Point(-2, -1));
			Directions.Add(new Point(-2, 1));
			Directions.Add(new Point(1, -2));
			Directions.Add(new Point(1, 2));
			Directions.Add(new Point(2, -1));
			Directions.Add(new Point(2, 1));
			int newRow, newColumn;
			Point Current;

			for (int CurrentDirection = 0; CurrentDirection < Directions.Count; CurrentDirection++)
			{
				Current = Directions[CurrentDirection];
				newRow = Row + Current.X;
				newColumn = Column + Current.Y;

				if (InRange(newRow, newColumn))
				{
					if (getGameState().getUnit(newRow, newColumn) != null)
					{
						if (getGameState().getUnit(newRow, newColumn).getIsFirstPlayer() != getGameState().getUnit(Row, Column).getIsFirstPlayer())
						{
							if (((ChessUnit)getGameState().getUnit(newRow, newColumn)).IsAvailableMove(Row, Column))
							{
								return true;
							}
						}
					}
				}
			}

			return false;
		}

		private bool KingCheckedGenerally(int Row, int Column)
		{
			List<Point> Temp = ((ChessUnit)getGameState().getUnit(Row, Column)).getDirections();
			int newRow, newColumn;
			Point Current;

			for (int CurrentDirection = 0; CurrentDirection < 8; CurrentDirection++)
			{
				Current = Temp[CurrentDirection];
				newRow = Row;
				newColumn = Column;

				while (true)
				{
					newRow += Current.X;
					newColumn += Current.Y;

					if (InRange(newRow, newColumn))
					{
						if (getGameState().getUnit(newRow, newColumn) != null)
						{
							if (getGameState().getUnit(newRow, newColumn).getIsFirstPlayer() != getGameState().getUnit(Row, Column).getIsFirstPlayer())
							{
								if (((ChessUnit)getGameState().getUnit(newRow, newColumn)).IsAvailableMove(Row, Column))
								{
									return true;
								}
								else
								{
									break;
								}
							}
							else
							{
								break;
							}
						}
						else
						{
							continue;
						}
					}
					else
					{
						break;
					}
				}
			}

			return false;
		}

		private bool Checked(int Row, int Column)//Row and Column of King
		{
			if (KingCheckedByKnight(Row, Column) || KingCheckedGenerally(Row, Column))
				return true;
			return false;
		}

		private Player CheckEndOfGame(List<Point> CurrentList)
		{
			Player Winner = null;
			Point Temp = getFirstPlayer().IsMyTurn() ? WhiteKing : BlackKing;

			if (Checked(Temp.X, Temp.Y))
			{
				Selected.X = Temp.X;
				Selected.Y = Temp.Y;
				setValidMove();
				Selected.X = -1;
				Selected.Y = -1;

				if (Hover.Count == 0)
				{
					for (int CurrentUnit = 0; CurrentUnit < CurrentList.Count; CurrentUnit++)
					{
						Selected.X = CurrentList[CurrentUnit].X;
						Selected.Y = CurrentList[CurrentUnit].Y;
						setValidMove();

						if (Hover.Count > 0)
						{
							Selected.X = -1;
							Selected.Y = -1;
							return null;
						}
					}

					Winner = getFirstPlayer().IsMyTurn() ? getFirstPlayer() : getSecondPlayer();
					setGameEnd(true);

					Selected.X = -1;
					Selected.Y = -1;
				}
			}
			else
			{
				for (int CurrentUnit = 0; CurrentUnit < CurrentList.Count; CurrentUnit++)
				{
					Selected.X = CurrentList[CurrentUnit].X;
					Selected.Y = CurrentList[CurrentUnit].Y;
					setValidMove();

					if (Hover.Count > 0)
					{
						Selected.X = -1;
						Selected.Y = -1;
						return null;
					}
				}

				Winner = null;
				setGameEnd(true);

				Selected.X = -1;
				Selected.Y = -1;
			}

			return Winner;
		}

		public override void PlayAt(int Row, int Column)
		{
			if (IsGameEnd())
				return;

			if (Selected.X == -1 && Selected.Y == -1)
			{
				if (getGameState().getUnit(Row, Column) != null)
				{
					bool Owner = getGameState().getUnit(Row, Column).getIsFirstPlayer();

					if (getFirstPlayer().IsMyTurn() == Owner)
					{
						Selected.X = Row;
						Selected.Y = Column;
						Select(Row, Column);
					}
					else
					{
						return;
					}
				}
				else
				{
					return;
				}
			}
			else
			{
				if (getGameState().getUnit(Row, Column) != null)
				{
					bool Owner = getGameState().getUnit(Row, Column).getIsFirstPlayer();

					if (getGameState().getUnit(Selected.X, Selected.Y).getIsFirstPlayer() == Owner && !(Selected.X == Row && Selected.Y == Column))
					{
						UnSelect();
						Selected.X = Row;
						Selected.Y = Column;
						Select(Row, Column);
					}
					else
					{
						if (IsValidMove(Row, Column))
						{
							Move(Row, Column);
							SwitchPlayer();
							ViewController.switchPlayer();

							Player Winner;
							Winner = CheckEndOfGame(getFirstPlayer().IsMyTurn() ? WhiteList : BlackList);

							if (IsGameEnd())
							{
                                if (Winner != null)
                                {
                                    ViewController.StopTimers();
                                    MessageBox.Show("Player " + Winner.getName() + " Win");
                                }
                                else
                                {
                                    ViewController.StopTimers();
                                    MessageBox.Show("Tie");
                                }
							}
						}
						else
						{
							UnSelect();
						}
					}
				}
				else
				{
					if (IsValidMove(Row, Column))
					{
						Move(Row, Column);
						SwitchPlayer();
						ViewController.switchPlayer(); 
						
						Player Winner;
						Winner = CheckEndOfGame(getFirstPlayer().IsMyTurn() ? WhiteList : BlackList);

						if (IsGameEnd())
						{
                            if (Winner != null)
                            {
                                MessageBox.Show("Player " + Winner.getName() + " Win");
                                ViewController.StopTimers();
                            }
                            else
                            {
                                MessageBox.Show("Tie");
                                ViewController.StopTimers();
                            }
						}
					}
					else
					{
						UnSelect();
					}
				}
			}
		}
	}
}
