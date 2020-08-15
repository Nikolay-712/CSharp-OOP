namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int bulletsPerBarrel = 50;
        private const int totalBullets = 500;

        public Rifle(string name)
            : base(name, bulletsPerBarrel, totalBullets)
        {
        }

        public override int Fire()
        {
            if (this.CanFire)
            {
                this.BulletsPerBarrel = this.BulletsPerBarrel - 1;

                if (this.BulletsPerBarrel == 0)
                {
                    this.BulletsPerBarrel = bulletsPerBarrel;
                    this.TotalBullets = this.TotalBullets - bulletsPerBarrel;
                }

                return 1;
            }

            return 0;
        }
    }
}

