using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Core
{
    public class Engine
    {
        private RestaurantController restaurantController;
        private string Messages;

        public Engine()
        {
            this.restaurantController = new RestaurantController();
        }
        public void Run()
        {

            string input = Console.ReadLine();

            while (true)
            {
                var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (args[0])
                    {
                        case "AddFood":
                            string foodType = args[1];
                            string foodName = args[2];
                            decimal foodPrice = decimal.Parse(args[3]);

                            this.Messages = this.restaurantController.AddFood(foodType, foodName, foodPrice);
                            break;
                        case "AddDrink":
                            string drinkType = args[1];
                            string drinkName = args[2];
                            int servingSize = int.Parse(args[3]);
                            string brand = args[4];

                            this.Messages = this.restaurantController.AddDrink(drinkType, drinkName, servingSize, brand);
                            break;
                        case "AddTable":
                            string tableType = args[1];
                            int tableNumber = int.Parse(args[2]);
                            int capacity = int.Parse(args[3]);

                            this.Messages = this.restaurantController.AddTable(tableType, tableNumber, capacity);
                            break;
                        case "ReserveTable":
                            int numberOfPeople = int.Parse(args[1]);

                            this.Messages = this.restaurantController.ReserveTable(numberOfPeople);
                            break;
                        case "OrderFood":
                            int tableNumberOrderFood = int.Parse(args[1]);
                            string orderName = args[2];

                            this.Messages = this.restaurantController.OrderFood(tableNumberOrderFood, orderName);
                            break;
                        case "OrderDrink":
                            int tableNumberOrderDrink = int.Parse(args[1]);
                            string drinkNameOrder = args[2];
                            string drinkBrand = args[3];

                            this.Messages = this.restaurantController.OrderDrink(tableNumberOrderDrink, drinkNameOrder, drinkBrand);
                            break;
                        case "LeaveTable":
                            int leaveTableNumber = int.Parse(args[1]);
                            this.Messages = this.restaurantController.LeaveTable(leaveTableNumber);
                            break;
                        case "GetFreeTablesInfo":
                            this.Messages = this.restaurantController.GetFreeTablesInfo();
                            break;
                        case "GetOccupiedTablesInfo":
                            this.Messages = this.restaurantController.GetOccupiedTablesInfo();
                            break;
                        case "END":
                            this.Messages = this.restaurantController.GetSummary();
                            Console.WriteLine(Messages);
                            return;
                    }
                    Console.WriteLine(this.Messages);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }

                

                input = Console.ReadLine();
            }
        }

    }
}
