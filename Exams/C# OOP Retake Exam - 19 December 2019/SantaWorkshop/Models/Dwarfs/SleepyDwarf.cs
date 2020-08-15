namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int energy = 50;
        private const int neededEnergy = 15;

        public SleepyDwarf(string name) 
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
