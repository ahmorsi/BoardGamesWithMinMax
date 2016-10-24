using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BoardGameProject
{
    abstract class Strategy
    {
        
        protected int level,Sizex,SizeY;
        protected char[,] Tested_Board;
        protected int[] Weights;
        public Strategy(int level, Board temp)
        {
            Sizex = temp.getRows();
            SizeY = temp.getColoums();
            Tested_Board = new char[Sizex, SizeY];
            this.level = level;
        }
        public char[,] Get_Tested_Board()
        {
            return Tested_Board;
        }
        //abstract public bool IS_GameOver(char[,] B);
        abstract public void Copy_Board(Board temp);
        abstract public KeyValuePair<int, Point> MiniMax(char[,] board, int depth, int alpha, int beta, bool Maxplayer);
        //abstract public KeyValuePair<int, Point> NegaMax(char[,] board, int depth, int alpha, int beta, bool MaxPlayer);
        abstract protected void Apply_Move(Point move,char[,] B,bool MaxPlayer,ref char[,] newboard);

        public bool FullBoard(char[,] B)
        {
            for (int i = 0; i < Sizex; i++)
                for (int j = 0; j < SizeY; j++)
                    if (B[i, j] == 0) // use null but now i will use it for X and O
                        return false;
            
            return true;
        }

        abstract protected int EvaluationFunc(char[,] B);
        abstract protected List<Point> Generate_Moves(char[,] B);
    }
}
