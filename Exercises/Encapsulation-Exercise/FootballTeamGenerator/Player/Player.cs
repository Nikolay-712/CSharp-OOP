using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Player : GeneratePlayer
    {
        private string name;
        private double skillRating;



        public Player(string name, string[] skills)
        {
            this.Name = name;
            PlayerSkills(skills);
            this.SkillRating = CalculateAveragePlayerSkill();

        }

        public double SkillRating
        {
            get { return this.skillRating; }
            private set { this.skillRating = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set { ValidPlayerName(value); this.name = value; }
           
        }

    }
}
