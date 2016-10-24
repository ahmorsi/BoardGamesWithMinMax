using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGameProject
{
    abstract class BoardGame
    {
        private Player FirstPlayer, SecondPlayer;
        private Board GameState;
        private bool GameEnded;

        public BoardGame(Player newFirstPlayer, Player newSecondPlayer)
        {
            FirstPlayer = newFirstPlayer;
            FirstPlayer.setMyTurn(true);
            SecondPlayer = newSecondPlayer;
            SecondPlayer.setMyTurn(false);
            GameEnded = false;
        }

        public BoardGame(BoardGame newGame)
        {
            FirstPlayer = new Human(newGame.getFirstPlayer().getName());
            FirstPlayer.setMyTurn(true);
            SecondPlayer = new Human(newGame.getSecondPlayer().getName());
            SecondPlayer.setMyTurn(false);
            GameEnded = false;
        }

        public abstract void reSet();

        public BoardGame()
        {
        }

        public Player getFirstPlayer()
        {
            return FirstPlayer;
        }

        public Player getSecondPlayer()
        {
            return SecondPlayer;
        }

        public void setFirstPlayer(Player newFirstPlayer)
        {
            FirstPlayer = newFirstPlayer;
        }

        public void getSecondPlayer(Player newSecondPlayer)
        {
            SecondPlayer = newSecondPlayer;
        }

        public void SwitchPlayer()
        {
            FirstPlayer.setMyTurn(!FirstPlayer.IsMyTurn());
            SecondPlayer.setMyTurn(!SecondPlayer.IsMyTurn());
        }

        public void setGameState(Board newGameState)
        {
            GameState = newGameState;
        }

        public Board getGameState()
        {
            return GameState;
        }

        public void setGameEnd(bool EndorNot)
        {
            GameEnded = EndorNot;
        }

        public bool IsGameEnd()
        {
            return GameEnded;
        }

        abstract public void PlayAt(int Row , int Column);
    }
}
