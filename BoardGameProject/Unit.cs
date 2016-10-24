using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGameProject
{
    abstract class Unit
    {
        private char UnitCode;
        private bool FirstPlayer;

        public Unit(char newUnitCode, bool owner)
        {
            UnitCode = newUnitCode;
            FirstPlayer = owner;
        }

        public Unit(Unit newUnit)
        {
            UnitCode = newUnit.getUnitCode();
            FirstPlayer = newUnit.getIsFirstPlayer();
        }

        public Unit()
        {
        }

        public char getUnitCode()
        {
            return UnitCode;
        }

        public bool getIsFirstPlayer()
        {
            return FirstPlayer;
        }

        public void setUnitCode(char newType)
        {
            UnitCode = newType;
        }

        public void setFirstPlayerAsOwner()
        {
            FirstPlayer = true;
        }

        public void setSecondPlayerAsOwner()
        {
            FirstPlayer = false;
        }
    }
}
