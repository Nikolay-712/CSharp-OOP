using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team : GenerateTeam
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public IReadOnlyCollection<Player> Players
        {
            get { return players; }
        }


        public string Name
        {
            get { return this.name; }
            private set { ValidTeamName(value); this.name = value; }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);

        }

        public void RemovePlayer(string teamName, string playerName)
        {
            var player = GenerateTeam.RemoveCurrentPlayer(teamName, playerName);
            players.Remove(player);
        }



    }
}
