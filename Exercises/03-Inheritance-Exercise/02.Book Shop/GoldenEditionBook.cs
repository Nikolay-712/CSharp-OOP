using System;
using System.Collections.Generic;
using System.Text;

namespace _02.BookShop
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, decimal price)
            : base(author, title, price)
        {
            IncreasePrice();
        }

        public override decimal Price
        {
            get { return base.Price; }
            protected set { base.Price = value; }
        }

        private void IncreasePrice()
        {

            this.Price = this.Price * 30 / 100 + base.Price;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
