namespace ViceCity.Models.Players
{
    using System;

    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Repositories;
    using ViceCity.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        

        protected Player(string name,int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.GunRepository = new GunRepository();
            this.IsAlive = true;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Player's name cannot be null or a whitespace!");

                }

                this.name = value;
            }
        }

        public int LifePoints
        {
            get { return this.lifePoints; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }

                this.lifePoints = value;
            }
        }
        public bool IsAlive { get; private set; }

        public IRepository<IGun> GunRepository { get; }

        public void TakeLifePoints(int points)
        {
            if (this.LifePoints - points > 0)
            {
                this.LifePoints = this.LifePoints - points;
            }
            else
            {
                this.lifePoints = 0;
            }

            

            if (lifePoints == 0)
            {
                this.IsAlive = false;
            }
        }
    }
}
