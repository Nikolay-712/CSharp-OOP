namespace AquaShop.Models.Decorations
{
    using AquaShop.Models.Decorations.Contracts;

    public abstract class Decoration : IDecoration
    {
        protected Decoration(int confort, decimal price)
        {
            this.Comfort = confort;
            this.Price = price;
        }

        public int Comfort { get; }

        public decimal Price { get; }
    }
}
