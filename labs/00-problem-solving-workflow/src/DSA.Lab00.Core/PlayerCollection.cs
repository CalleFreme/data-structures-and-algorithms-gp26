using System;
using System.Collections.Generic;

namespace DSA.Lab00
{
    public sealed class PlayerCollection
    {
        private readonly List<Player> _players;

        public PlayerCollection(IEnumerable<Player> players)
        {
            if (players == null)
            {
                throw new ArgumentNullException(nameof(players));
            }

            _players = new List<Player>(players);
        }

        public Player? FindById(int id)
        {
            foreach (Player player in _players)
            {
                if (player.Id == id)
                {
                    return player;
                }
            }

            return null;
        }

        public Player? FindHighestScore()
        {
            if (_players.Count == 0)
            {
                return null;
            }

            Player highest = _players[0];

            for (int i = 1; i < _players.Count; i++)
            {
                if (_players[i].Score > highest.Score)
                {
                    highest = _players[i];
                }
            }

            return highest;
        }

        public bool ContainsName(string name)
        {
            foreach (Player player in _players)
            {
                if (string.Equals(player.Name, name, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }
    }
}