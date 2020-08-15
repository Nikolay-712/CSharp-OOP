namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int size = 5;
        private const int increasesSize = 2;

        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = size;
        }

        public override void Eat()
        {
            this.Size = this.Size + increasesSize;
        }
    }
}
