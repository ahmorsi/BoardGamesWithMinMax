using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace BoardGameProject
{
    class XOStrategy : Strategy
    {
        int wining_Score;

        public XOStrategy(int level, Board temp)
            : base(level, temp)
        {
            Weights = new int[] { 10, 100, 1000, -15, -150, -1500 };
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
        public bool IS_GameOver(char[,] B)
        {
            wining_Score = 0;
            char winner = 'z';
            for (int CurrentRow = 0; CurrentRow < Sizex; CurrentRow++)
            {
                if (B[CurrentRow, 0] != '\0' &&
                    B[CurrentRow, 1] != '\0' &&
                    B[CurrentRow, 2] != '\0')
                {
                    if (B[CurrentRow, 0] == B[CurrentRow, 1] &&
                        B[CurrentRow, 1] == B[CurrentRow, 2])
                        winner = B[CurrentRow, 0];
                    if (winner == 'O')
                    {
                        wining_Score = Weights[2];
                        return true;
                    }
                    else
                        if (winner == 'X')
                        {
                            wining_Score = Weights[5];
                            return true;
                        }

                }
            }

            for (int CurrentColumn = 0; CurrentColumn < SizeY; CurrentColumn++)
            {
                if (B[0, CurrentColumn] != '\0' &&
                    B[1, CurrentColumn] != '\0' &&
                    B[2, CurrentColumn] != '\0')
                {
                    if (B[0, CurrentColumn] == B[1, CurrentColumn] &&
                        B[1, CurrentColumn] == B[2, CurrentColumn])
                        winner = B[0, CurrentColumn];
                    if (winner == 'O')
                    {
                        wining_Score = Weights[2];
                        return true;
                    }
                    else
                        if (winner == 'X')
                        {
                            wining_Score = Weights[5];
                            return true;
                        }
                }
            }

            if (B[0, 0] != '\0' && B[1, 1] != '\0' && B[2, 2] != '\0')
            {
                if (B[0, 0] == B[1, 1] &&
                    B[1, 1] == B[2, 2])
                    winner = B[0, 0];
                if (winner == 'O')
                {
                    wining_Score = Weights[2];
                    return true;
                }
                else
                    if (winner == 'X')
                    {
                        wining_Score = Weights[5];
                        return true;
                    }

            }

            if (B[2, 0] != '\0' && B[1, 1] != '\0' && B[0, 2] != '\0')
            {
                if (B[2, 0] == B[1, 1] &&
                    B[1, 1] == B[0, 2])
                    winner = B[2, 0];
                if (winner == 'O')
                {
                    wining_Score = Weights[2];
                    return true;
                }
                else
                    if (winner == 'X')
                    {
                        wining_Score = Weights[5];
                        return true;
                    }

            }
            return FullBoard(B);
        }
        public override KeyValuePair<int, Point> MiniMax(char[,] board, int depth, int alpha, int beta, bool Maxplayer)
        {
            if (level == depth || IS_GameOver(board))
                return new KeyValuePair<int, Point>(EvaluationFunc(board), new Point());// new Point() 2y 7aga mlhash lzma
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
                    char[,] newboard = new char[3, 3];
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
                    char[,] newboard = new char[3, 3];
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

        //public override KeyValuePair<int, Point> NegaMax(char[,] board, int depth, int alpha, int beta, bool MaxPlayer)
        //{
        //    if (level == depth || IS_GameOver(board))
        //        return new KeyValuePair<int, Point>(EvaluationFunc(board), new Point());
        //    Point bestmove = new Point();
        //    int bestscore = int.MinValue;
        //    List<Point> Moves = Generate_Moves(board);
        //    foreach (Point node in Moves)
        //    {
        //        char[,] newboard = new char[Sizex, SizeY];
        //        Apply_Move(node, board, MaxPlayer, ref newboard);// make deep Copy of 
        //        KeyValuePair<int, Point> Current_Play = NegaMax(newboard, depth + 1, -beta, -Math.Max(bestscore, alpha), !MaxPlayer);
        //        int Current_Score = -1 * Current_Play.Key;
        //        if (Current_Score > bestscore)
        //        {
        //            bestscore = Current_Score;
        //            bestmove = node;
        //        }
        //        if (bestscore >= beta)
        //            return new KeyValuePair<int, Point>(bestscore, bestmove);
        //    }
        //    return new KeyValuePair<int, Point>(bestscore, bestmove);
        //}

        protected override void Apply_Move(Point move, char[,] B, bool MaxPlayer, ref char[,] newboard)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    newboard[i, j] = B[i, j];
            }
            if (!MaxPlayer)
                newboard[move.X, move.Y] = 'X';
            else
                newboard[move.X, move.Y] = 'O';
        }

        protected override List<Point> Generate_Moves(char[,] B)
        {
            List<Point> Moves = new List<Point>();
            for (int i = 0; i < Sizex; i++)
            {
                for (int j = 0; j < SizeY; j++)
                    if (B[i, j] == '\0')
                        Moves.Add(new Point(i, j));
            }
            return Moves;
        }

        protected override int EvaluationFunc(char[,] B)
        {
            //if (wining_Score == Weights[2] || wining_Score == Weights[5])
            //return (wining_Score);
            ////int PathsX = Calculate_Paths(B, 'X'), PathsO = Calculate_Paths(B, 'O');
            //    return PathsO - PathsX;


            int Scores_X = 0, Scores_O = 0;

            for (int i = 0; i < Sizex; i++) // Rows
            {
                int counterX_Row = 0, counterO_Row = 0, counterNull_Row = 0;
                int counterX_Coloumn = 0, counterO_Coloumn = 0, counterNull_Coloumn = 0;

                for (int j = 0; j < SizeY; j++)
                {
                    if (B[i, j] == 'X')
                        counterX_Row++;
                    else if (B[i, j] == 'O')
                        counterO_Row++;
                    else
                        counterNull_Row++;

                    if (B[j, i] == 'X')
                        counterX_Coloumn++;
                    else if (B[j, i] == 'O')
                        counterO_Coloumn++;
                    else
                        counterNull_Coloumn++;
                }

                //Calculate Scores for each Row
                if (counterX_Row == 2 && counterNull_Row == 1)
                    Scores_X += Weights[4];
                else if (counterO_Row == 2 && counterNull_Row == 1)
                    Scores_O += Weights[1];
                else if (counterX_Row == 1 && counterNull_Row == 2)
                    Scores_X += Weights[3];
                else if (counterO_Row == 1 && counterNull_Row == 2)
                    Scores_O += Weights[0];
                else if (counterX_Row == 3)
                    Scores_X += Weights[5];
                else if (counterO_Row == 3)
                    Scores_O += Weights[2];

                //Calculate Scores for each Coloumn
                if (counterX_Coloumn == 2 && counterNull_Coloumn == 1)
                    Scores_X += Weights[4];
                else if (counterO_Coloumn == 2 && counterNull_Coloumn == 1)
                    Scores_O += Weights[1];
                else if (counterX_Coloumn == 1 && counterNull_Coloumn == 2)
                    Scores_X += Weights[3];
                else if (counterO_Coloumn == 1 && counterNull_Coloumn == 2)
                    Scores_O += Weights[0];
                else if (counterX_Coloumn == 3)
                    Scores_X += Weights[5];
                else if (counterO_Coloumn == 3)
                    Scores_O += Weights[2];
            }

            int counterX_Diagonal = 0, counterO_Diagonal = 0, counterNull_Diagonal = 0;

            //Calculate First Diagonal
            for (int i = 0, j = 0; i < 3 && j < 3; i++, j++)
            {
                if (B[i, j] == 'X') counterX_Diagonal++;
                else
                    if (B[i, j] == 'O') counterO_Diagonal++;
                    else
                        counterNull_Diagonal++;
            }

            if (counterX_Diagonal == 2 && counterNull_Diagonal == 1)
                Scores_X += Weights[4];
            else if (counterO_Diagonal == 2 && counterNull_Diagonal == 1)
                Scores_O += Weights[1];
            else if (counterX_Diagonal == 1 && counterNull_Diagonal == 2)
                Scores_X += Weights[3];
            else if (counterO_Diagonal == 1 && counterNull_Diagonal == 2)
                Scores_O += Weights[0];
            else if (counterX_Diagonal == 3)
                Scores_X += Weights[5];
            else if (counterO_Diagonal == 3)
                Scores_O += Weights[2];


            counterX_Diagonal = 0; counterO_Diagonal = 0; counterNull_Diagonal = 0;

            //Calculate The second Diagonal
            for (int i = 2, j = 0; i >= 0 && j < 3; i--, j++)
            {
                if (B[i, j] == 'X')
                    counterX_Diagonal++;
                else if (B[i, j] == 'O')
                    counterO_Diagonal++;
                else
                    counterNull_Diagonal++;
            }

            if (counterX_Diagonal == 2 && counterNull_Diagonal == 1)
                Scores_X += Weights[4];
            else if (counterO_Diagonal == 2 && counterNull_Diagonal == 1)
                Scores_O += Weights[1];
            else if (counterX_Diagonal == 1 && counterNull_Diagonal == 2)
                Scores_X += Weights[3];
            else if (counterO_Diagonal == 1 && counterNull_Diagonal == 2)
                Scores_O += Weights[0];
            else if (counterX_Diagonal == 3)
                Scores_X += Weights[5];
            else if (counterO_Diagonal == 3)
                Scores_O += Weights[2];

            return Scores_O + Scores_X;
        }

        private int Calculate_Paths(char[,] Bx, char C)
        {
            int paths = 0;
            for (int i = 0; i < 3; i++)
            {
                if ((Bx[i, 0] == '\0' || Bx[i, 0] == C) &&
                    (Bx[i, 1] == '\0' || Bx[i, 1] == C) &&
                    (Bx[i, 2] == '\0' || Bx[i, 2] == C))
                {
                    paths++;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if ((Bx[0, i] == '\0' || Bx[0, i] == C) &&
                    (Bx[1, i] == '\0' || Bx[1, i] == C) &&
                    (Bx[2, i] == '\0' || Bx[2, i] == C))
                {
                    paths++;
                }
            }
            if ((Bx[0, 0] == '\0' || Bx[0, 0] == C) &&
                    (Bx[1, 1] == '\0' || Bx[1, 1] == C) &&
                    (Bx[2, 2] == '\0' || Bx[2, 2] == C))
            {
                paths++;
            }
            if ((Bx[2, 0] == '\0' || Bx[2, 0] == C) &&
                    (Bx[1, 1] == '\0' || Bx[1, 1] == C) &&
                    (Bx[0, 2] == '\0' || Bx[0, 2] == C))
            {
                paths++;
            }

            return paths;
        }
    }
}
