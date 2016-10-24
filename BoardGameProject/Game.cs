using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGameProject
{
    class Game
    {
		private Player MainPlayer;
		private BoardGame CurrentGame;
		private List<Player> Players = new List<Player>();

        public Player getFirstPlayer()
        {
            return MainPlayer;
        }

        public Player getSecondPlayer()
        {
            return CurrentGame.getSecondPlayer();
        }

        public void SetMainPlayer(string newName , int newID)
		{
			MainPlayer = new Human(newName);
		}

		public Player GetMainPlayer()
		{
			return MainPlayer;
		}

		public void SetCurrentGame(BoardGame newCurrentGame)
		{
			CurrentGame = newCurrentGame;
		}

		public List<Player> getPlayers()
		{
			return Players;
		}

		public Player getPlayer(int index)
		{
			return Players.ElementAt(index);
		}

		public void AddPlayer(string newName, int newID)
		{
			Players.Add(new Human(newName));
		}

		public void EditPlayer(string newName, int index)
		{
			Players.ElementAt(index).setName(newName);
		}

		public void DeletePlayer(int index)
		{
			Players.RemoveAt(index);
		}

		public void Click(int Row, int Column)
		{
			CurrentGame.PlayAt(Row, Column);
		}

        public BoardGame getCurrentGame()
        {
            return CurrentGame;
        }

        public BoardGame getCurrentgame()
        {
            return CurrentGame;
        }
    }
}
