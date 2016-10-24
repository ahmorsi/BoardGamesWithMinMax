using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoardGameProject;
using System.Drawing;
namespace BoardGameProject
{
    abstract class Player
    {
        private string Name;
        private bool MyTurn;
        protected Strategy myStrategy;
        abstract public Point Apply_Strategy(Board current_board);

        public Player(string newName)
        {
            Name = newName;
        }

        public Player(Player newP)
        {
            Name = newP.Name;
            myStrategy = newP.myStrategy;
        }
        public void Set_Strategy(Strategy S)
        {
            myStrategy = S;
        }
        public void setName(string newName)
        {
            Name = newName;
        }
        public void setMyTurn(bool newMyTurn)
        {
            MyTurn = newMyTurn;
        }
        public string getName()
        {
            return Name;
        }
        public Strategy getStrategy()
        {
            return myStrategy;
        }
        public bool IsMyTurn()
        {
            return MyTurn;
        }
    }
}
