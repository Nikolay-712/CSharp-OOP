using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class GenerateTeam 
    {

        private static List<Team> teamList = new List<Team>();
        protected static void ValidTeamName(string teamName)
        {
            if (string.IsNullOrEmpty(teamName)|| string.IsNullOrWhiteSpace(teamName))
            {
                throw new ArgumentException("A name should not be empty.");

            }
        }

        public static IReadOnlyCollection<Team> TeamList
        {
            get { return teamList; }
        }

        public static void AddTeam(Team team)
        {
            teamList.Add(team);
        }

        public static Team CheckForCurrentTeam(string teamName)
        {

            var currentTeam = teamList.Where(x => x.Name == teamName).FirstOrDefault();
            if (currentTeam == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");

            }
            return currentTeam;

        }

        protected static Player RemoveCurrentPlayer(string teamName, string playerName)
        {
            var currentPlayer = CheckForCurrentTeam(teamName).Players.Where(x => x.Name == playerName).FirstOrDefault();

            if (currentPlayer == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {teamName} team.");

            }
            return currentPlayer;
        }

        public static double CalculateTeamRating(string teamName)
        {
            var team = CheckForCurrentTeam(teamName);

            if (team.Players.Count > 0)
            {
                var rating = team.Players.Select(x => x.SkillRating).Average();

                return rating;
            }

            return 0;
        }

    }
}
