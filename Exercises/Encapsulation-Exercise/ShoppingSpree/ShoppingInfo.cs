using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class ShoppingInfo
    {
        private static List<Person> people = new List<Person>();
        private static List<Product> productsList = new List<Product>();

        private static StringBuilder stringBuilder = new StringBuilder();

        public static void CustomersInfo(string customers)
        {
            var info = customers.Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var custumer in info)
            {
                var args = custumer.Split("=", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(args[0], decimal.Parse(args[1]));
                people.Add(person);
            }
        }

        public static void ProductsInfo(string products)
        {
            var info = products.Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var product in info)
            {
                var args = product.Split("=", StringSplitOptions.RemoveEmptyEntries);

                Product product1 = new Product(args[0], decimal.Parse(args[1]));
                productsList.Add(product1);
            }
        }

        public static string GetCustumersStats()
        {
            foreach (var person in people)
            {
                stringBuilder.Append($"{person.Name} - ");

                if (person.Bag.Count == 0)
                {
                    stringBuilder.Append("Nothing bought");
                }
                else
                {
                    stringBuilder.AppendLine(string.Join(", ", person.Bag.Select(x => x.Name)));
                }
            }

            return stringBuilder.ToString();
        }

        public static List<Person> ShowCustomersList()
        {
            return people;
        }

        public static List<Product> ShowProductsList()
        {
            return productsList;
        }
    }
}
