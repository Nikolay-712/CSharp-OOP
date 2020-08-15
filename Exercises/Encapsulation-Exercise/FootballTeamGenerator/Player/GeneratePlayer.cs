using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class GeneratePlayer
    {
        private static Dictionary<string, int> stats = new Dictionary<string, int>();
        protected static void ValidPlayerName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A name should not be empty.");

            }
        }

        protected static void PlayerSkills(string[] skillLevel)
        {
            var skills = Enum.GetNames(typeof(PlayerSkills));
            var level = skillLevel;

            for (int i = 0; i < level.Length; i++)
            {
                if (int.Parse(level[i]) > 100 || int.Parse(level[i]) < 0)
                {
                    throw new ArgumentException($"{skills[i]} should be between 0 and 100.");

                }
                stats[skills[i]] = int.Parse(level[i]);
            }
        }

        protected static double CalculateAveragePlayerSkill()
        {
            var skilLevel = stats.Values.Average();
            return skilLevel;
        }

    }

}
