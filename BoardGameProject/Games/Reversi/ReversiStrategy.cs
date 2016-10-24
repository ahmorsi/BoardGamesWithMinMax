using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace BoardGameProject
{
	class ReversiStrategy : Strategy
	{
		bool Wining_State;
		private Point[] direc = {(new Point(0, -1)),
								(new Point(1, 0)),
								(new Point(-1, 0)),
								(new Point(0, 1)),
								(new Point(1, -1)),
								(new Point(-1, -1)),
								(new Point(1, 1)),
								(new Point(-1, 1))};

		public ReversiStrategy(int level, Board temp)
			: base(level, temp)
		{
			Weights = new int[] { 10, 100, 1000, 10000, -10, -100, -1500, -15000 };
		}

		protected override int EvaluationFunc(char[,] B)
		{
			return 0;
		}

		private void Count(ref List<Point> BlackList,ref List<Point> WhiteList , char[,] B)
		{
			for(int i = 0;i < 8;i++)
				for (int j = 0; j < 8; j++)
				{
					if (B[i, j] == 'W')
						WhiteList.Add(new Point(i, j));
					else if(B[i, j] == 'B')
						BlackList.Add(new Point(i, j));
				}
		}

		public override void Copy_Board(Board temp)
		{
			Tested_Board = new char[temp.getRows(), temp.getColoums()];
			for (int i = 0; i < temp.getRows(); i++)
			{
				for (int j = 0; j < temp.getColoums(); j++)
				{
					if (temp.getUnit(i, j) == null)
						Tested_Board[i, j] = '\0';
					else
						Tested_Board[i, j] = temp.getUnit(i, j).getUnitCode();
				}
			}
		}
		public bool inRange(int X, int Y)//X is Row && Y is Column
		{
			if (X >= 8 || Y >= 8 || Y < 0 || X < 0)
				return false;
			return true;
		}

		public override KeyValuePair<int, Point> MiniMax(char[,] board, int depth, int alpha, int beta, bool Maxplayer)
		{
			List<Point> WhiteList = new List<Point>();
			List<Point> BlackList = new List<Point>();
			Count(ref WhiteList, ref BlackList, board);
			if (level == depth || Wining_State)
			{
				Wining_State = false;
				return new KeyValuePair<int, Point>(BlackList.Count - WhiteList.Count, new Point());// new Point() 2y 7aga mlhash lzma
			}
			Point bestmove = new Point();
			int bestScore;
			if (Maxplayer)
				bestScore = int.MinValue;
			else
				bestScore = int.MaxValue;

			List<KeyValuePair<Point, List<Point>>> Moves = new List<KeyValuePair<Point,List<Point>>>();
			
			List<Point> Generated_Moves = Generate_Moves(board , Maxplayer ? BlackList : WhiteList , ref Moves);
			if (Maxplayer)
			{
				foreach (Point node in Generated_Moves)
				{
					char[,] newboard = new char[8, 8];
					Apply_Move(node, board, Maxplayer, ref newboard); // deep Copy for board Array
					KeyValuePair<int, Point> new_Level = MiniMax(newboard, depth + 1, alpha, beta, !Maxplayer);
					if (new_Level.Key > bestScore)
					{
						bestmove = node;
						bestScore = new_Level.Key;
					}
					//if (beta <= alpha)
					//    break;
				}
				//return new KeyValuePair<int, Point>(alpha, bestmove);
			}
			else
			{
				foreach (Point node in Generated_Moves)
				{
					char[,] newboard = new char[8, 8];
					Apply_Move(node, board, Maxplayer, ref newboard); // deep Copy for board Array
					KeyValuePair<int, Point> new_Level = MiniMax(newboard, depth + 1, alpha, beta, !Maxplayer);
					if (new_Level.Key < bestScore)
					{
						bestmove = node;
						bestScore = new_Level.Key;
					}
					//if (beta <= alpha)
					//    break;
				}
				//return new KeyValuePair<int, Point>(alpha, bestmove);
			}
			return new KeyValuePair<int, Point>(bestScore, bestmove);
		}
		protected override void Apply_Move(Point move, char[,] B, bool MaxPlayer, ref char[,] newboard)
		{
			
		}

		protected void Apply_Move(Point move, char[,] B, bool MaxPlayer, ref char[,] newboard, List<KeyValuePair<Point, List<Point>>> Moves)
		{
			TakeAction(Moves, B);
		}

		protected override List<Point> Generate_Moves(char[,] B) // Generate Avaliable Moves
		{
			List<Point> ValidMoves = new List<Point>();

			return ValidMoves;
		}

		protected List<Point> Generate_Moves(char[,] B, List<Point> Selected,ref List<KeyValuePair<Point, List<Point>>> Moves) // Generate Avaliable Moves
		{
			List<Point> ValidMoves = new List<Point>();

			Point Current, StartPoint;
			int CurrentRow, CurrentColumn;
			char UnitCode;

			for (int CurrentUnit = 0; CurrentUnit < Selected.Count; CurrentUnit++)
			{
				List<Point> StartPoints = new List<Point>();
				Current = Selected[CurrentUnit];
				UnitCode = B[Current.X, Current.Y];

				for (int CurrentDirection = 0; CurrentDirection < 8; CurrentDirection++)
				{
					CurrentRow = Current.X + direc[CurrentDirection].X;
					CurrentColumn = Current.Y + direc[CurrentDirection].Y;

					if (inRange(CurrentRow, CurrentColumn))
					{
						if (B[CurrentRow, CurrentColumn] != null)
						{
							if (B[CurrentRow, CurrentColumn] != UnitCode)
							{
								StartPoint = FindStart(CurrentRow, CurrentColumn, direc[CurrentDirection], UnitCode, B);

								if (StartPoint.X != -1 && StartPoint.Y != -1)
								{
									ValidMoves.Add(StartPoint);
									StartPoints.Add(StartPoint);
								}
							}
						}
					}
				}

				if (StartPoints.Count > 0)
					Moves.Add(new KeyValuePair<Point, List<Point>>(Current, StartPoints));
			}

			return ValidMoves;
		}
		private Point FindStart(int Row, int Column, Point dir, char UnitCode, char[,] B)
		{
			Row += dir.X;
			Column += dir.Y;

			if (inRange(Row, Column))
			{
				if (B[Row, Column] == null)
				{
					return new Point(Row, Column);
				}
				else
				{
					if (B[Row, Column] != UnitCode)
					{
						return FindStart(Row, Column, dir, UnitCode, B);
					}
				}
			}

			return new Point(-1, -1);
		}

		private void TakeAction(List<KeyValuePair<Point, List<Point>>> ValidMoves, char[,] B)
		{
			KeyValuePair<Point, List<Point>> CurrentMove;
			KeyValuePair<Point, Point> Current;

			for (int CurrentValidMove = 0; CurrentValidMove < ValidMoves.Count; CurrentValidMove++)
			{
				CurrentMove = ValidMoves[CurrentValidMove];
				for (int CurrentEndPoint = 0; CurrentEndPoint < CurrentMove.Value.Count; CurrentEndPoint++)
				{
					Current = new KeyValuePair<Point, Point>(CurrentMove.Key, CurrentMove.Value[CurrentEndPoint]);
					ChangeUnits(Current, B);
				}
			}
		}

		public void ChangeUnits(KeyValuePair<Point, Point> p, char[,] B)//X is Row && Y is Column
		{
			Point EndUnit = p.Value;
			Point StartUnit = p.Key;

			if (p.Key.X == p.Value.X)
			{
				if (p.Key.Y > p.Value.Y)
					p = new KeyValuePair<Point, Point>(p.Value, p.Key);

				for (int i = p.Key.Y; i <= p.Value.Y; i++)
				{
					B[p.Key.X, i] = B[EndUnit.X, EndUnit.Y];
				}
			}
			else if (p.Key.Y == p.Value.Y)
			{
				if (p.Key.X > p.Value.X)
					p = new KeyValuePair<Point, Point>(p.Value, p.Key);

				for (int i = p.Key.X; i <= p.Value.X; i++)
				{
					B[i, p.Value.Y] = B[EndUnit.X, EndUnit.Y];
				}
			}
			else if (p.Key.X > p.Value.X && p.Key.Y > p.Value.Y)// swap operation
			{
				for (int i = p.Value.X, j = p.Value.Y; i <= p.Key.X && j <= p.Key.Y; i++, j++)
				{
					B[i, j] = B[EndUnit.X, EndUnit.Y];
				}
			}
			else if (p.Value.X > p.Key.X && p.Value.Y > p.Key.Y)
			{
				for (int i = p.Key.X, j = p.Key.Y; i <= p.Value.X && j <= p.Value.Y; i++, j++)
				{
					B[i, j] = B[EndUnit.X, EndUnit.Y];
				}
			}
			else
			{
				if (p.Key.X < p.Value.X && p.Key.Y > p.Value.Y)
					p = new KeyValuePair<Point, Point>(p.Value, p.Key);

				for (int i = p.Key.X, j = p.Key.Y; i >= 0 && j <= p.Value.Y; i--, j++)
				{
					B[i, j] = B[EndUnit.X, EndUnit.Y];
				}

			}
		}
	}
}
