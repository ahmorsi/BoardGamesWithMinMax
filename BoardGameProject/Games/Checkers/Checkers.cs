using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BoardGameProject
{
	class Checkers : BoardGame
	{
		private Point Selected;
		private List<Point> Hover;
		private TennoCheckers ViewController;

		private List<Point> BlackList;
		private List<Point> WhiteList;
        private List<KeyValuePair<Point, Point>> enemyAttack;

		public Checkers(Player newFirstPlayer, Player newSecondPlayer, TennoCheckers newViewController)
			: base(newFirstPlayer, newSecondPlayer)
		{
			BlackList = new List<Point>();
			WhiteList = new List<Point>();
            enemyAttack = new List<KeyValuePair<Point, Point>>();
			
            ViewController = newViewController;
			setGameState(new Board(8, 8));

			Selected = new Point(-1 , -1);

			for (int i = 0; i < 8; i++)
			{
				if (i % 2 == 0)
				{
					getGameState().setUnit(1, i, new CheckersUnit('B', false));
					BlackList.Add(new Point(1, i));
					getGameState().setUnit(5, i, new CheckersUnit('W', true));
					WhiteList.Add(new Point(5, i));
					getGameState().setUnit(7, i, new CheckersUnit('W', true));
					WhiteList.Add(new Point(7, i));
				}
				else
				{
					getGameState().setUnit(0, i, new CheckersUnit('B', false));
					BlackList.Add(new Point(0, i));
					getGameState().setUnit(2, i, new CheckersUnit('B', false));
					BlackList.Add(new Point(2, i));
					getGameState().setUnit(6, i, new CheckersUnit('W', true));
					WhiteList.Add(new Point(6, i));
				}
			}

			SetValidMoves(WhiteList);

			ViewController.IntializeCheckers();
		}

        public override void reSet()
        {
            setGameEnd(false);
            BlackList.Clear();
            WhiteList.Clear();
            enemyAttack.Clear();

            setGameState(new Board(8, 8));

            Selected = new Point(-1, -1);

            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    getGameState().setUnit(1, i, new CheckersUnit('B', false));
                    BlackList.Add(new Point(1, i));
                    getGameState().setUnit(5, i, new CheckersUnit('W', true));
                    WhiteList.Add(new Point(5, i));
                    getGameState().setUnit(7, i, new CheckersUnit('W', true));
                    WhiteList.Add(new Point(7, i));
                }
                else
                {
                    getGameState().setUnit(0, i, new CheckersUnit('B', false));
                    BlackList.Add(new Point(0, i));
                    getGameState().setUnit(2, i, new CheckersUnit('B', false));
                    BlackList.Add(new Point(2, i));
                    getGameState().setUnit(6, i, new CheckersUnit('W', true));
                    WhiteList.Add(new Point(6, i));
                }
            }

            SetValidMoves(WhiteList);
            if (!getFirstPlayer().IsMyTurn())
                SwitchPlayer();
            ViewController.IntializeCheckers();
        }

		public Checkers(Checkers newGame)
			: base(newGame)
		{
			BlackList = new List<Point>();
			WhiteList = new List<Point>();

			ViewController = newGame.getViewController();
			setGameState(newGame.getGameState());

			for (int i = 0; i < 8; i++)
			{

				// Re build
				//if (i % 2 == 0)
				//{
				//    getGameState().setUnit(1, i, new CheckersUnit('B', false, false));
				//    BlackList.Add(new Point(1, i));
				//    getGameState().setUnit(5, i, new CheckersUnit('W', true, false));
				//    WhiteList.Add(new Point(5, i));
				//    getGameState().setUnit(7, i, new CheckersUnit('W', true, false));
				//    WhiteList.Add(new Point(7, i));
				//}
				//else
				//{
				//    getGameState().setUnit(0, i, new CheckersUnit('B', false, false));
				//    BlackList.Add(new Point(0, i));
				//    getGameState().setUnit(2, i, new CheckersUnit('B', false, false));
				//    BlackList.Add(new Point(2, i));
				//    getGameState().setUnit(6, i, new CheckersUnit('W', true, false));
				//    WhiteList.Add(new Point(6, i));
				//}
			}
		}

		public TennoCheckers getViewController()
		{
			return ViewController;
		}

		public bool inRange(int X, int Y)
		{
			return (X >= 0 && Y >= 0 && X < 8 && Y < 8);
		}

		private void SelectCurrent(int Row, int Column)
		{
			Selected.X = Row;
			Selected.Y = Column;
			Hover = ((CheckersUnit)getGameState().getUnit(Row , Column)).get_Avaliable_Moves();
			ViewController.ShadowSelectedChecker(Selected, ((CheckersUnit)getGameState().getUnit(Row, Column)).IsKing());
			ViewController.HoverValidMoves(Hover);
		}

		private void UnSelectCurrent()
		{
			ViewController.UnShadowSelectedChecker(Selected, ((CheckersUnit)getGameState().getUnit(Selected.X, Selected.Y)).IsKing());
			ViewController.UnHoverValidMoves(Hover);
			Selected = new Point(-1 , -1);
		}

		private void Move(int Row , int Column)
		{
			Point Current = new Point(Selected.X , Selected.Y);
			Point Direction = new Point(Row - Current.X , Column - Current.Y);
			if (Direction.X == -2 || Direction.X == 2)
			{
				Direction.X /= 2;
				Direction.Y /= 2;

				if (getFirstPlayer().IsMyTurn())
				{
					BlackList.Remove(new Point(Current.X + Direction.X, Current.Y + Direction.Y));
					WhiteList.Remove(Current);
					WhiteList.Add(new Point(Row, Column));
				}
				else
				{
					WhiteList.Remove(new Point(Current.X + Direction.X, Current.Y + Direction.Y));
					BlackList.Remove(Current);
					BlackList.Add(new Point(Row, Column));
				}

				UnSelectCurrent();

				CheckersUnit Temp = (CheckersUnit)getGameState().getUnit(Current.X, Current.Y);
				getGameState().setUnit(Current.X + Direction.X, Current.Y + Direction.Y, null);
				getGameState().setUnit(Current.X, Current.Y, null);
				getGameState().setUnit(Row, Column, Temp);

				CheckPromotion(new Point(Row , Column));

				ViewController.MoveChecker(Current, new Point(Row, Column), ((CheckersUnit)getGameState().getUnit(Row, Column)).IsKing());
				ViewController.DeleteChecker(new Point(Current.X + Direction.X, Current.Y + Direction.Y));
			}
			else
			{
				if (getFirstPlayer().IsMyTurn())
				{
					WhiteList.Remove(Current);
					WhiteList.Add(new Point(Row, Column));
				}
				else
				{
					BlackList.Remove(Current);
					BlackList.Add(new Point(Row, Column));
				}

				UnSelectCurrent();

				CheckersUnit Temp = (CheckersUnit)getGameState().getUnit(Current.X, Current.Y);
				getGameState().setUnit(Current.X, Current.Y, null);
				getGameState().setUnit(Row, Column, Temp);

				CheckPromotion(new Point(Row, Column));

				ViewController.MoveChecker(Current, new Point(Row, Column), ((CheckersUnit)getGameState().getUnit(Row, Column)).IsKing());
			}
		}

		private void UpdateEnemyAttak(int Row , int Column)
		{
			enemyAttack.Clear();
			((CheckersUnit)getGameState().getUnit(Row , Column)).clearAvaliableMove();

			List<Point> Direction = ((CheckersUnit)getGameState().getUnit(Row , Column)).getDirections();
			int newRow , newColumn;
			char UnitCode = getGameState().getUnit(Row , Column).getUnitCode();

			for(int CurrentDirection = 0;CurrentDirection < Direction.Count;CurrentDirection++)
			{
				newRow = Row + Direction[CurrentDirection].X ;
				newColumn = Column + Direction[CurrentDirection].Y;

				if(inRange(newRow , newColumn))
				{
					if(getGameState().getUnit(newRow , newColumn) != null && getGameState().getUnit(newRow , newColumn).getUnitCode() != UnitCode)
					{
						newRow += Direction[CurrentDirection].X ;
						newColumn += Direction[CurrentDirection].Y;

						if(inRange(newRow , newColumn))
						{
							if(getGameState().getUnit(newRow , newColumn) == null)
							{
								((CheckersUnit)getGameState().getUnit(Row , Column)).addAvaliableMove(newRow , newColumn);
								enemyAttack.Add(new KeyValuePair<Point , Point>(new Point(Row , Column) , new Point(newRow , newColumn)));
							}
						}
					}
				}
			}
		}

		private void SetValidMoves(List<Point> CurrentCheckersList)
		{
			Point Current;
			enemyAttack.Clear();

			for(int CurrentChecker = 0;CurrentChecker < CurrentCheckersList.Count;CurrentChecker++)
			{
				Current = CurrentCheckersList[CurrentChecker];
				((CheckersUnit)getGameState().getUnit(Current.X , Current.Y)).clearAvaliableMove();
				SetValidMovesForUnit(Current);
			}
		}

		private void SetValidMovesForUnit(Point Current)
		{
			List<Point> Direction = ((CheckersUnit)getGameState().getUnit(Current.X , Current.Y)).getDirections();
			int newRow , newColumn;
			char UnitCode;

			if(getFirstPlayer().IsMyTurn())
				UnitCode = 'W';
			else
				UnitCode = 'B';

			for(int CurrentDirection = 0;CurrentDirection < Direction.Count;CurrentDirection++)
			{
				newRow = Current.X + Direction[CurrentDirection].X;
				newColumn = Current.Y + Direction[CurrentDirection].Y;

				if(inRange(newRow , newColumn))
				{
					if(getGameState().getUnit(newRow , newColumn) == null)
					{
						((CheckersUnit)getGameState().getUnit(Current.X , Current.Y)).addAvaliableMove(newRow , newColumn);
					}
					else if(getGameState().getUnit(newRow , newColumn).getUnitCode() != UnitCode)
					{
						newRow += Direction[CurrentDirection].X;
						newColumn += Direction[CurrentDirection].Y;

						if(inRange(newRow , newColumn))
						{
							if(getGameState().getUnit(newRow , newColumn) == null)
							{
								((CheckersUnit)getGameState().getUnit(Current.X , Current.Y)).addAvaliableMove(newRow , newColumn);
								enemyAttack.Add(new KeyValuePair<Point , Point>(Current , new Point(newRow , newColumn)));
							}
						}
					}
				}
			}
		}

		private bool IsValid(int Row , int Column)
		{
			Point CurrentKey , CurrentValue;

			for(int CurrentEnemyAttack = 0;CurrentEnemyAttack < enemyAttack.Count;CurrentEnemyAttack++)
			{
				CurrentKey = enemyAttack[CurrentEnemyAttack].Key;
				CurrentValue = enemyAttack[CurrentEnemyAttack].Value;
				
				if(CurrentKey.X == Selected.X && CurrentKey.Y == Selected.Y && CurrentValue.X == Row && CurrentValue.Y == Column)
					return true;
			}

			return false; 
		}

		private void CheckPromotion(Point Moved)
		{
			if (getFirstPlayer().IsMyTurn() && Moved.X == 0)
				((CheckersUnit)getGameState().getUnit(Moved.X, Moved.Y)).Promote();
			else if (getSecondPlayer().IsMyTurn() && Moved.X == 7)
				((CheckersUnit)getGameState().getUnit(Moved.X, Moved.Y)).Promote();
		}

		private void CheckGameEnd(List<Point> CurrentList)
		{
			Point Current;

			for (int CurrentChecker = 0; CurrentChecker < CurrentList.Count; CurrentChecker++)
			{
				Current = CurrentList[CurrentChecker];

				if (((CheckersUnit)getGameState().getUnit(Current.X, Current.Y)).get_Avaliable_Moves().Count > 0)
				{
					return;
				}
			}

			setGameEnd(true);
		}

		private Player IsWin()
		{
			Point Current;
			Player Winner = null;
			int SmallWhite = 0, SmallBlack = 0, KingWhite = 0, KingBlack = 0;

			for (int CurrentWhite = 0; CurrentWhite < WhiteList.Count; CurrentWhite++)
			{
				Current = WhiteList[CurrentWhite];

				if (((CheckersUnit)getGameState().getUnit(Current.X, Current.Y)).IsKing())
				{
					KingWhite++;
				}
				else
				{
					SmallWhite++;
				}
			}

			for (int CurrentBlack = 0; CurrentBlack < BlackList.Count; CurrentBlack++)
			{
				Current = BlackList[CurrentBlack];

				if (((CheckersUnit)getGameState().getUnit(Current.X, Current.Y)).IsKing())
				{
					KingBlack++;
				}
				else
				{
					SmallBlack++;
				}
			}

			if ((KingWhite * 10) + SmallWhite > (KingBlack * 10) + SmallBlack)
				Winner = getFirstPlayer();
			else if ((KingWhite * 10) + SmallWhite < (KingBlack * 10) + SmallBlack)
				Winner = getSecondPlayer();

			return Winner;
		}

		public override void PlayAt(int Row, int Column)
		{
			if (IsGameEnd())
				return;

			if(Selected.X == -1 && Selected.Y == -1)
			{
				if(getGameState().getUnit(Row , Column) != null)
				{
					char UnitCode;

					if(getFirstPlayer().IsMyTurn())
					{
						UnitCode = 'W';
					}
					else
					{
						UnitCode = 'B';
					}

					if(getGameState().getUnit(Row , Column).getUnitCode() == UnitCode)
					{
						SelectCurrent(Row , Column);
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
				if(getGameState().getUnit(Row , Column) != null)
				{
					char UnitCode;

					if(getFirstPlayer().IsMyTurn())
					{
						UnitCode = 'W';
					}
					else
					{
						UnitCode = 'B';
					}

					if(getGameState().getUnit(Row , Column).getUnitCode() == UnitCode)
					{
						UnSelectCurrent();
						SelectCurrent(Row , Column);
					}
					else
					{
						UnSelectCurrent();
					}
				}
				else
				{
					if(((CheckersUnit)getGameState().getUnit(Selected.X , Selected.Y)).isMove(new Point(Row , Column)))
					{
						if (enemyAttack.Count != 0)
						{
							if (IsValid(Row, Column))
							{
								Move(Row, Column);
								UpdateEnemyAttak(Row, Column);

								if (enemyAttack.Count > 0)
								{
									SelectCurrent(Row, Column);
								}
								else
								{
									SwitchPlayer();
									ViewController.switchPlayer();

									if (getFirstPlayer().IsMyTurn())
									{
										SetValidMoves(WhiteList);
										CheckGameEnd(WhiteList);
									}
									else
									{
										SetValidMoves(BlackList);
										CheckGameEnd(BlackList);
									}

									if (IsGameEnd())
									{
										Player Winner = IsWin();

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
							}
							else
							{
								MessageBox.Show("You Have Enemy Attak");
								UnSelectCurrent();
							}
						}
						else
						{
							Move(Row, Column);
							SwitchPlayer();
							ViewController.switchPlayer();

							if (getFirstPlayer().IsMyTurn())
							{
								SetValidMoves(WhiteList);
								CheckGameEnd(WhiteList);
							}
							else
							{
								SetValidMoves(BlackList);
								CheckGameEnd(BlackList);
							}

							if (IsGameEnd())
							{
								Player Winner = IsWin();

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
					}
					else
					{
						UnSelectCurrent();
					}
				}
			}
		}
	}
}

