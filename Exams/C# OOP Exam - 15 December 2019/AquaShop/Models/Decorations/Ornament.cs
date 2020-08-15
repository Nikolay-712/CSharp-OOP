namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int confort = 1;
        private const decimal price = 5;
        public Ornament()
            : base(confort, price)
        {
        }
    }
}
