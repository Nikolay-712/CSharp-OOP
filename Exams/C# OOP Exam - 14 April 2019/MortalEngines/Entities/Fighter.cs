namespace MortalEngines.Entities
{
    using System;

    using MortalEngines.Entities.Contracts;
   

    public class Fighter : BaseMachine, IFighter
    {
        private const double healthPoints = 200;
        private const double increaseAttackPoints = 50;
        private const double decreaseDefensePoints = 25;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, healthPoints)
        {
            this.AggressiveMode = true;
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public string Mode { get; private set; }
      
        public void ToggleAggressiveMode()
        {
            ChangeMode();
        }

        public override string ToString()
        {
            return base.ToString() + $"{Environment.NewLine}{$" *Aggressive: {this.Mode}"}".TrimEnd();
        }

        private void ChangeMode()
        {
            if (AggressiveMode)
            {
                this.AttackPoints = this.AttackPoints + increaseAttackPoints;
                this.DefensePoints = this.DefensePoints - decreaseDefensePoints;

                this.Mode = "ON";

                this.AggressiveMode = false;
            }

            else if (!AggressiveMode)
            {
                this.AggressiveMode = false;

                this.AttackPoints = this.AttackPoints - increaseAttackPoints;
                this.DefensePoints = this.DefensePoints + decreaseDefensePoints;

                this.Mode = "OFF";

                this.AggressiveMode = true;
            }
        }
    }
}
