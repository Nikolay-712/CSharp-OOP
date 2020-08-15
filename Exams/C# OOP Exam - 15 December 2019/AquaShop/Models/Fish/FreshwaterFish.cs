namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int size = 3;
        private const int increasesSize = 3;
        public FreshwaterFish(string name, string species, decimal price) 
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
