using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private double totalCal;

        private string pizzaName;
        private Dough pizzaDough;
        private List<Topping> toppings;
        

        public Pizza(string pizzaName)
        {
            this.PizzaName = pizzaName;
            this.Toppings = new List<Topping>();

        }

        public string PizzaName
        {
            get { return this.pizzaName; }
            private set
            {
                if (value.Length < 1 || value.Length > 15 || value == null)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                
                this.pizzaName = value;
            }
        }

        private List<Topping> Toppings
        {
            get { return this.toppings; }
            set
            {
                this.toppings = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count < 10)
            {
                this.Toppings.Add(topping);
            }
            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }

        public void AddDough(Dough dough)
        {
            this.pizzaDough = dough;
        }

        public double TotalCalories()
        {
            foreach (var topping in this.Toppings)
            {
                totalCal = totalCal + topping.Calories;
            }

            return this.pizzaDough.Calories + totalCal;
        }
       
    }
}
