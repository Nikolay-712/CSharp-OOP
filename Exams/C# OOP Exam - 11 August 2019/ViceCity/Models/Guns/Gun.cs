namespace ViceCity.Models.Guns
{
    using System;

    using ViceCity.Models.Guns.Contracts;

    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;

        public Gun(string name,int bulletsPerBarrel,int totalBullets)
        {
            this.Name = name;
            this.bulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
            
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or a white space!");

                }

                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get { return this.bulletsPerBarrel; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below zero!");
                }

                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get { return this.totalBullets; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total bullets cannot be below zero!");
                }

                this.totalBullets = value;
            }
        }

        public bool CanFire => this.TotalBullets > 0;

        public abstract int Fire();
        
    }
}
