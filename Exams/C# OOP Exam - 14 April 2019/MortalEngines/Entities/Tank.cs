namespace MortalEngines.Entities
{
    using System;

    using MortalEngines.Entities.Contracts;
    
    public class Tank : BaseMachine, ITank
    {
        private const double healthPoints = 100;
        private const double increaseDefensePoints = 30;
        private const double decreaseAttackPoints = 40;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, healthPoints)
        {
            DefenseMode = true;
            this.ToggleDefenseMode();

        }

        public double HealthPointss { get { return this.HealthPoints; } }

        public bool DefenseMode { get; private set; }

        public string Mode { get; private set; }

        public void ToggleDefenseMode()
        {
            ChangeMode();
        }

        public override string ToString()
        {
            return base.ToString() + $"{Environment.NewLine}{$" *Defense: {this.Mode}"}".TrimEnd();
        }

        private void ChangeMode()
        {
            if (DefenseMode)
            {
                this.AttackPoints = this.AttackPoints - decreaseAttackPoints;
                this.DefensePoints = this.DefensePoints + increaseDefensePoints;

                this.Mode = "ON";

                this.DefenseMode = false;
            }

            else if (!DefenseMode)
            {
                this.DefenseMode = false;

                this.AttackPoints = this.AttackPoints + decreaseAttackPoints;
                this.DefensePoints = this.DefensePoints - increaseDefensePoints;

                this.Mode = "OFF";

                this.DefenseMode = true;
            }
        }
    }
}
