using INStock.Contracts;
using System;

namespace INStock
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;
        private string prdoductType;

        public Product(string productType, string label, decimal price, int quantity)
        {
            this.ProductType = productType;
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label
        {
            get { return label; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Label information is not valid!");
                }
                this.label = value;
            }
        }


        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value <= 0 || value > 50)
                {
                    throw new ArgumentException("Price should be in range {1 ... 50}$");
                }
                this.price = value;
            }
        }

        public int Quantity
        {
            get { return this.quantity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity cannot be negative!");
                }

                quantity = value;
            }
        }


        public string ProductType
        {
            get { return this.prdoductType; }
            private set { this.prdoductType = value; }
        }


        public int CompareTo(IProduct other)
        {
            throw new NotImplementedException();
        }
    }
}
