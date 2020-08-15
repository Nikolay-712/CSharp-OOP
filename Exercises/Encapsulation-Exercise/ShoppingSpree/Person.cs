using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Bag = new List<Product>();
        }

        public List<Product> Bag
        {
            get { return this.bag; }
            private set { this.bag = value; }
        }


        private decimal Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }


        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        private void CalculateCurrentMoney(Product product)
        {
            if (product.Cost > this.money)
            {
                throw new ArgumentException($"{this.name} can't afford {product.Name}");
            }
        }

        public void AddProduct(Product product)
        {
            CalculateCurrentMoney(product);

            this.bag.Add(product);
            this.money = this.money - product.Cost;
        }
    }
}
