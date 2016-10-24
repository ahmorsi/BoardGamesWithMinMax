using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace BoardGameProject
{
    class Connect4Strategy : Strategy
    {
        bool Wining_State;

        public Connect4Strategy(int level, Board temp)
            : base(level, temp)
        {
            Weights = new int[] { 10, 100, 1000, 10000, -15, -150, -1500, -15000 };
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

        private bool Is_in_Range(int Row, int Column)
        {
            if (Row < 6 && Column < 7 && Row >= 0 && Column >= 0)
                return true;
            return false;
        }

        private int CheckIfFour(int Row, int Column, int newRow, int newColumn, char Past, char[,] B)
        {
            if (!Is_in_Range(Row, Column) || B[Row, Column] == '\0' || B[Row, Column] != Past)
                return 0;

            return CheckIfFour(Row + newRow, Column + newColumn, newRow, newColumn, Past, B) + 1;
        }

        public void isWin(int Row, int Column, char[,] B, bool MaxPlayer)
        {

            char CurrentUnit = B[Row, Column];
            int Counter;

            //Down
            Counter = CheckIfFour(Row, Column, 1, 0, CurrentUnit, B);
            if (Counter >= 4)
            {
                Wining_State = true;
            }

            //Right Left
            Counter = CheckIfFour(Row, Column, 0, 1, CurrentUnit, B) + CheckIfFour(Row, Column, 0, -1, CurrentUnit, B) - 1;
            if (Counter >= 4)
            {
                Wining_State = true;
            }

            //To Left Top And Right Down
            Counter = CheckIfFour(Row, Column, 1, 1, CurrentUnit, B) + CheckIfFour(Row, Column, -1, -1, CurrentUnit, B) - 1;
            if (Counter >= 4)
            {
                Wining_State = true;
            }

            //To Right Top And Left Down
            Counter = CheckIfFour(Row, Column, 1, -1, CurrentUnit, B) + CheckIfFour(Row, Column, -1, 1, CurrentUnit, B) - 1;
            if (Counter >= 4)
            {
                Wining_State = true;
            }

        }

        protected override List<Point> Generate_Moves(char[,] B)
        {
            List<Point> Moves = new List<Point>();
            for (int j = 0; j < SizeY; j++)
            {
                for (int i = Sizex - 1; i >= 0; i--)
                    if (B[i, j] == '\0')
                    {
                        Moves.Add(new Point(i, j));
                        break;
                    }
            }
            return Moves;
        }

        protected override void Apply_Move(Point move, char[,] B, bool MaxPlayer, ref char[,] newboard)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                    newboard[i, j] = B[i, j];
            }
            if (MaxPlayer)
                newboard[move.X, move.Y] = 'B';
            else
                newboard[move.X, move.Y] = 'R';
            isWin(move.X, move.Y, newboard, MaxPlayer);
        }

        public override KeyValuePair<int, Point> MiniMax(char[,] board, int depth, int alpha, int beta, bool Maxplayer)
        {
            if (level == depth || Wining_State)
            {
                Wining_State = false;
                return new KeyValuePair<int, Point>(EvaluationFunc(board), new Point());// new Point() 2y 7aga mlhash lzma
            }

            Point bestmove = new Point();
            int bestScore;

            if (Maxplayer)
                bestScore = int.MinValue;
            else
                bestScore = int.MaxValue;

            List<Point> Generated_Moves = Generate_Moves(board);

            if (Maxplayer)
            {
                foreach (Point node in Generated_Moves)
                {
                    char[,] newboard = new char[6, 7];

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
                    char[,] newboard = new char[6, 7];

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


        protected override int EvaluationFunc(char[,] B)
        {
            int Scores_R = 0, Scores_B = 0;

            #region  Calcualte Rows Scores

            for (int i = 0; i < Sizex; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int counterRow_R = 0, counterRow_B = 0, counterRow_null = 0;
                    for (int k = j, counter = 0; counter != 4; k++, counter++)
                    {
                        if (B[i, k] == 'R') counterRow_R++;
                        else
                            if (B[i, k] == 'B') counterRow_B++;
                            else
                                counterRow_null++;
                    }
                    if (counterRow_R == 4) Scores_R += Weights[7];
                    else if (counterRow_R == 3 && counterRow_null == 1) Scores_R += Weights[6];
                    else if (counterRow_R == 2 && counterRow_null == 2) Scores_R += Weights[5];
                    else if (counterRow_R == 1 && counterRow_null == 3) Scores_R += Weights[4];

                    if (counterRow_B == 4) Scores_B += Weights[3];
                    else if (counterRow_B == 3 && counterRow_null == 1) Scores_B += Weights[2];
                    else if (counterRow_B == 2 && counterRow_null == 2) Scores_B += Weights[1];
                    else if (counterRow_B == 1 && counterRow_null == 3) Scores_B += Weights[0];
                }
            }

            #endregion

            #region Calcualte Coloumns Scores

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int counterColoumn_R = 0, counterColoumn_B = 0, counterColoumn_null = 0;
                    for (int k = j, counter = 0; counter != 4; k++, counter++)
                    {
                        if (B[k, i] == 'R') counterColoumn_R++;
                        else
                            if (B[k, i] == 'B') counterColoumn_B++;
                            else
                                counterColoumn_null++;
                    }
                    if (counterColoumn_R == 4) Scores_R += Weights[7];
                    else if (counterColoumn_R == 3 && counterColoumn_null == 1) Scores_R += Weights[6];
                    else if (counterColoumn_R == 2 && counterColoumn_null == 2) Scores_R += Weights[5];
                    else if (counterColoumn_R == 1 && counterColoumn_null == 3) Scores_R += Weights[4];

                    if (counterColoumn_B == 4) Scores_B += Weights[3];
                    else if (counterColoumn_B == 3 && counterColoumn_null == 1) Scores_B += Weights[2];
                    else if (counterColoumn_B == 2 && counterColoumn_null == 2) Scores_B += Weights[1];
                    else if (counterColoumn_B == 1 && counterColoumn_null == 3) Scores_B += Weights[0];
                }
            }

            #endregion

            #region Calculate Diagonal Scores

            for (int i = 5; i >= 3; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    int counterDiagonal_R = 0, counterDiagonal_B = 0, counterDiagonal_null = 0;
                    for (int x = i, y = j, count = 0; count != 4; x--, y++, count++)
                    {
                        if (B[x, y] == 'R') counterDiagonal_R++;
                        else
                            if (B[x, y] == 'B') counterDiagonal_B++;
                            else
                                counterDiagonal_null++;
                    }
                    if (counterDiagonal_R == 4) Scores_R += Weights[7];
                    if (counterDiagonal_R == 3 && counterDiagonal_null == 1) Scores_R += Weights[6];
                    if (counterDiagonal_R == 2 && counterDiagonal_null == 2) Scores_R += Weights[5];
                    if (counterDiagonal_R == 1 && counterDiagonal_null == 3) Scores_R += Weights[4];

                    if (counterDiagonal_B == 4) Scores_B += Weights[3];
                    if (counterDiagonal_B == 3 && counterDiagonal_null == 1) Scores_B += Weights[2];
                    if (counterDiagonal_B == 2 && counterDiagonal_null == 2) Scores_B += Weights[1];
                    if (counterDiagonal_B == 1 && counterDiagonal_null == 3) Scores_B += Weights[0];
                }
            }

            #endregion

            #region Calculate Diagonal_2 Scores

            for (int i = 5; i >= 3; i--)
            {
                for (int j = 6; j >= 3; j--)
                {
                    int counterDiagonal_R = 0, counterDiagonal_B = 0, counterDiagonal_null = 0;
                    for (int x = i, y = j, count = 0; count != 4; x--, y--, count++)
                    {
                        if (B[x, y] == 'R') counterDiagonal_R++;
                        else
                            if (B[x, y] == 'B') counterDiagonal_B++;
                            else
                                counterDiagonal_null++;
                    }
                    if (counterDiagonal_R == 4) Scores_R += Weights[7];
                    if (counterDiagonal_R == 3 && counterDiagonal_null == 1) Scores_R += Weights[6];
                    if (counterDiagonal_R == 2 && counterDiagonal_null == 2) Scores_R += Weights[5];
                    if (counterDiagonal_R == 1 && counterDiagonal_null == 3) Scores_R += Weights[4];

                    if (counterDiagonal_B == 4) Scores_B += Weights[3];
                    if (counterDiagonal_B == 3 && counterDiagonal_null == 1) Scores_B += Weights[2];
                    if (counterDiagonal_B == 2 && counterDiagonal_null == 2) Scores_B += Weights[1];
                    if (counterDiagonal_B == 1 && counterDiagonal_null == 3) Scores_B += Weights[0];
                }
            }

            #endregion

            return Scores_B + Scores_R;
        }
    }
}
