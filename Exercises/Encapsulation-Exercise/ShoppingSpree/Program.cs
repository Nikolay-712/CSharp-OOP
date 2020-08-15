using System;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
                var customers = Console.ReadLine();
                var products = Console.ReadLine();

                ShoppingInfo.CustomersInfo(customers);
                ShoppingInfo.ProductsInfo(products);

                var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                while (commands[0] != "END")
                {

                    string name = commands[0];
                    string product = commands[1];

                    try
                    {
                        var currentCustmer = ShoppingInfo.ShowCustomersList().Where(x => x.Name == name).FirstOrDefault();
                        var currentProduct = ShoppingInfo.ShowProductsList().Where(x => x.Name == product).FirstOrDefault();

                        currentCustmer.AddProduct(currentProduct);
                        Console.WriteLine($"{currentCustmer.Name} bought {currentProduct.Name}");


                    }
                    catch (ArgumentException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                    commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                }

                Console.WriteLine(ShoppingInfo.GetCustumersStats());
            }
			catch (ArgumentException ex)
			{

                Console.WriteLine(ex.Message);
			}
        }
    }
}
