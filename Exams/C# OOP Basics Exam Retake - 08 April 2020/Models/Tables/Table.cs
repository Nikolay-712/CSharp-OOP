using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables.Contracts
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;

        private readonly List<IFood> foodOrders;
        private readonly List<IDrink> drinkOrders;


        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();

            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.IsReserved = false;
        }

        public IReadOnlyCollection<IFood> FoodOrders => this.foodOrders;

        public IReadOnlyCollection<IDrink> DrinkOrders => this.drinkOrders;

        public int TableNumber { get; }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                this.capacity = value;
            }
        }
        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                this.numberOfPeople = value;
            }
        }
        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price => this.PricePerPerson * this.NumberOfPeople;



        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;

            
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            var foodTotalPrice = this.foodOrders.Select(x => x.Price).Sum();
            var drinksTotalPrice = this.drinkOrders.Select(x => x.Price).Sum();

            var totalPrice = foodTotalPrice + drinksTotalPrice;

            return totalPrice;
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();

            this.IsReserved = false;
           
        }

        public string GetFreeTableInfo()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Table: { this.TableNumber}");
            builder.AppendLine($"Type: {this.GetType().Name}");
            builder.AppendLine($"Capacity: {this.Capacity}");
            builder.AppendLine($"Price per Person: {this.PricePerPerson:F2}");

            return builder.ToString().TrimEnd();

        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Table: { this.TableNumber}");
            builder.AppendLine($"Type: {this.GetType().Name}");
            builder.AppendLine($"Number of people: {this.NumberOfPeople}");

            if (this.foodOrders.Count == 0)
            {
                builder.AppendLine("Food orders: None");

            }
            else
            {
                builder.AppendLine($"Food orders: {this.foodOrders.Count}");
                foreach (var food in foodOrders)
                {
                    builder.AppendLine(food.ToString());
                }

                builder.ToString().TrimEnd();

            }


            if (this.drinkOrders.Count == 0)
            {
                builder.AppendLine("Drink orders: None");

            }
            else
            {
                builder.AppendLine($"Drink orders: {this.drinkOrders.Count}");
                foreach (var drink in this.drinkOrders)
                {
                    builder.AppendLine(drink.ToString());
                }
                builder.ToString().TrimEnd();

            }

            return builder.ToString().TrimEnd();
        }
    }
}
