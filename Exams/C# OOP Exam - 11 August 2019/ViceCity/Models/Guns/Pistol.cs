namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int bulletsPerBarrel = 10;
        private const int totalBullets = 100;
        
        public Pistol(string name) 
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
