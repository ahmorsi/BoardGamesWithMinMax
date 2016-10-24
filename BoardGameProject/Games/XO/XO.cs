using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BoardGameProject
{
    class XOBoardGame : BoardGame
    {
		private Unit X, O;
		private TennoXO ViewController;

		public XOBoardGame(Player newFirstPlayer, Player newSecondPlayer, TennoXO newViewController)
			: base(newFirstPlayer, newSecondPlayer) 
		{
			ViewController = newViewController;
			X = new XOunit('X', true);
			O = new XOunit('O', false);
			setGameState(new Board(3, 3));
            ViewController.IntializeXO();
		}

		public XOBoardGame(XOBoardGame newGame) : base(newGame)
		{
			ViewController = newGame.getViewController();
			X = new XOunit('X', true);
			O = new XOunit('O', false);
			setGameState(new Board(3, 3));
		}

        public override void reSet()
        {
            setGameEnd(false);
            X = new XOunit('X', true);
            O = new XOunit('O', false);
            setGameState(new Board(3, 3));
            if (!getFirstPlayer().IsMyTurn())
                SwitchPlayer();
            ViewController.IntializeXO();
        }

		public Unit getX()
		{
			return X;
		}

		public Unit getO()
		{
			return O;
		}

		public TennoXO getViewController()
		{
			return ViewController;
		}

		public bool endOfGame()
		{
			for (int i = 0; i < getGameState().getRows(); i++)
				for (int j = 0; j < getGameState().getColoums(); j++)
					if (getGameState().getUnit(i, j) == null)
						return false;
			return true;
		}

		public override void PlayAt(int Row, int Column)
		{
			if (IsGameEnd() || getGameState().getUnit(Row, Column) != null)
				return;

			Player Winner = null;

            if (getFirstPlayer().IsMyTurn())
				getGameState().setUnit(Row, Column, getX());
			else
				getGameState().setUnit(Row, Column, getO());

            ViewController.UpdateXO(new Point(Row, Column));

            Winner = isWin();

			if (Winner != null)
			{
                ViewController.StopTimers();
                MessageBox.Show("Player " + Winner.getName() + " Win");
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

		public Player isWin()
		{
			Unit Winer = null;

			for (int CurrentRow = 0;CurrentRow < getGameState().getRows(); CurrentRow++)
			{
				if (getGameState().getUnit(CurrentRow, 0) != null &&
					getGameState().getUnit(CurrentRow, 1) != null &&
					getGameState().getUnit(CurrentRow, 2) != null)
				{
					if (getGameState().getUnit(CurrentRow, 0).getUnitCode() == getGameState().getUnit(CurrentRow, 1).getUnitCode() &&
						getGameState().getUnit(CurrentRow, 1).getUnitCode() == getGameState().getUnit(CurrentRow, 2).getUnitCode())
						Winer = getGameState().getUnit(CurrentRow, 0);
				}
			}

			for (int CurrentColumn = 0; CurrentColumn < getGameState().getColoums(); CurrentColumn++)
			{
				if (getGameState().getUnit(0, CurrentColumn) != null &&
					getGameState().getUnit(1, CurrentColumn) != null &&
					getGameState().getUnit(2, CurrentColumn) != null)
				{
					if (getGameState().getUnit(0, CurrentColumn).getUnitCode() == getGameState().getUnit(1, CurrentColumn).getUnitCode() &&
						getGameState().getUnit(1, CurrentColumn).getUnitCode() == getGameState().getUnit(2, CurrentColumn).getUnitCode())
						Winer = getGameState().getUnit(0, CurrentColumn);
				}
			}

			if (getGameState().getUnit(0, 0) != null && getGameState().getUnit(1, 1) != null && getGameState().getUnit(2, 2) != null)
			{
				if (getGameState().getUnit(0, 0).getUnitCode() == getGameState().getUnit(1, 1).getUnitCode() &&
					getGameState().getUnit(1, 1).getUnitCode() == getGameState().getUnit(2, 2).getUnitCode())
					Winer = getGameState().getUnit(0, 0);
			}

			if (getGameState().getUnit(2, 0) != null && getGameState().getUnit(1, 1) != null && getGameState().getUnit(0, 2) != null)
			{
				if (getGameState().getUnit(2, 0).getUnitCode() == getGameState().getUnit(1, 1).getUnitCode() &&
					getGameState().getUnit(1, 1).getUnitCode() == getGameState().getUnit(0, 2).getUnitCode())
					Winer =  getGameState().getUnit(0, 2);
			}

			if(Winer != null)
			{
				if (Winer.getIsFirstPlayer() == true)
					return getFirstPlayer();
				else
					return getSecondPlayer();
			}

			return null;
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
    }
}
