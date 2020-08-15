using System;
using System.Collections.Generic;
using System.Linq;


namespace FootballTeamGenerator
{
    public class Program
    {

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string teamName = string.Empty;
            string playerName = string.Empty;

            while (input.ToLower() != "end")
            {
                var info = input.Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

                try
                {
                    switch (info[0].ToLower())
                    {
                        case "team":
                            teamName = info[1];
                            Team team = new Team(teamName);

                            GenerateTeam.AddTeam(team);

                            break;
                        case "add":
                            teamName = info[1];
                            playerName = info[2];
                            var skills = info.Skip(3).ToArray();

                            Player player = new Player(playerName, skills);
                            var currentTeam = GenerateTeam.CheckForCurrentTeam(teamName);
                            currentTeam.AddPlayer(player);

                            break;
                        case "remove":
                            teamName = info[1];
                            playerName = info[2];

                            currentTeam = GenerateTeam.CheckForCurrentTeam(teamName);
                            currentTeam.RemovePlayer(teamName, playerName);

                            break;
                        case "rating":
                            teamName = info[1];
                            currentTeam = GenerateTeam.CheckForCurrentTeam(teamName);
                            Console.WriteLine($"{currentTeam.Name} - {Math.Round(GenerateTeam.CalculateTeamRating(teamName))}");
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }


                input = Console.ReadLine();
            }

        }
    }
}
