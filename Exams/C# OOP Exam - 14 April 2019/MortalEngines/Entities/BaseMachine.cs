
namespace MortalEngines.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MortalEngines.Entities.Contracts;
    

    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private IList<string> targets;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get { return this.pilot; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Pilot cannot be null.");
                }
                this.pilot = value;
            }
        }
        public double HealthPoints { get; set; }


        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get { return this.targets; } }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            this.targets.Add(target.Name);

            double pointsToSubstract = Math.Abs(this.AttackPoints - target.DefensePoints);

            target.HealthPoints = target.HealthPoints - pointsToSubstract;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;

                
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            var targets = "None";

            if (this.Targets.Count > 0)
            {
                targets = string.Join(",", this.Targets);
            }

            builder.AppendLine($"- {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Health: {this.HealthPoints:F2}")
                .AppendLine($" *Attack: {this.AttackPoints:F2}")
                .AppendLine($" *Defense: {this.DefensePoints:F2}").AppendLine($" *Targets: {targets}");


            return builder.ToString().TrimEnd();
        }
    }
}
