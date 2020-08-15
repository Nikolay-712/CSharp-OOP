namespace SoftUniRestaurant.Core
{
    using System;
    using SoftUniRestaurant.Factories;
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;

        private FoodFactory foodFactory;
        private DrinkFactory drinkFactory;

        decimal income = 0;

        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();

            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
        }


        public string AddFood(string type, string name, decimal price)
        {
            var food = this.foodFactory.Create(type, name, price);

            this.menu.Add(food);
            return $"Added {food.Name} ({food.GetType().Name}) with price {food.Price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            var drink = this.drinkFactory.Create(type, name, servingSize, brand);

            this.drinks.Add(drink);
            return $"Added {drink.Name} ({drink.Brand}) to the drink pool";

            
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            switch (type)
            {
                case "Inside":
                    table = new InsideTable(tableNumber, capacity);
                    break;
                case "Outside":
                    table = new OutsideTable(tableNumber, capacity);
                    break;
            }

            this.tables.Add(table);

            return $"Added table number {table.TableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var chckForTable = this.tables.Where(x => x.IsReserved == false);

            foreach (var table in chckForTable)
            {
                if (table.Capacity >= numberOfPeople)
                {
                    table.Reserve(numberOfPeople);
                    return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
                }
            }
            return $"No available table for {numberOfPeople} people";

        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var currentTabe = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var foodForTable = this.menu.FirstOrDefault(x => x.Name == foodName);

            if (currentTabe == null)
            {
                return $"Could not find table with {tableNumber}";

            }

            if (foodForTable == null)
            {
                return $"No {foodName} in the menu";

            }

            currentTabe.OrderFood(foodForTable);
            return $"Table {currentTabe.TableNumber} ordered {foodForTable.Name}";

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var currentTabe = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var drinkForTable = this.drinks.FirstOrDefault(x => x.Name == drinkName);

            if (currentTabe == null)
            {
                return $"Could not find table with {tableNumber}";

            }

            if (drinkForTable == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }


            currentTabe.OrderDrink(drinkForTable);

            return $"Table {currentTabe.TableNumber} ordered {drinkForTable.Name} {drinkForTable.Brand}";

        }

        public string LeaveTable(int tableNumber)
        {
            var currentTabel = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);


            var bill = currentTabel.GetBill() + currentTabel.Price;
            currentTabel.Clear();

            income = income + bill;

            return $"Table: {currentTabel.TableNumber}{Environment.NewLine}{$"Bill: {bill:f2}"}";

        }

        public string GetFreeTablesInfo()
        {
            var notReservedTables = this.tables.Where(x => x.IsReserved == false);
            StringBuilder builder = new StringBuilder();

            foreach (var table in notReservedTables)
            {
                builder.AppendLine(table.GetFreeTableInfo());
            }

            return builder.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            var allReservedTables = this.tables.Where(x => x.IsReserved == true);
            StringBuilder builder = new StringBuilder();

            foreach (var table in allReservedTables)
            {
                builder.AppendLine(table.GetOccupiedTableInfo());
            }

            return builder.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {income:f2}lv";

        }

    }
}
