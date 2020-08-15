namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        private const int energy = 100;
        private const int neededEnergy = 10;

        public HappyDwarf(string name)
            : base(name, energy)
        {
        }

        public override void Work()
        {
            var currentEnergy = this.Energy - neededEnergy;
            if (currentEnergy < 0)
            {
                this.Energy = 0;
            }
            else
            {
                this.Energy = this.Energy - neededEnergy;
            }
        }
    }
}
