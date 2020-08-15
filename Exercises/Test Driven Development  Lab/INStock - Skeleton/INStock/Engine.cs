using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace INStock
{
    public class Engine
    {
        private ProductStock productsStock;

        public Engine()
        {
            this.productsStock = new ProductStock();
        }

        public void Run()
        {
            var input = Console.ReadLine();


            while (input != "End")
            {


                var inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (inputArgs[0])
                {
                    case "Add":

                        string productType = inputArgs[1];
                        string productLabel = inputArgs[2];
                        decimal productPrice = decimal.Parse(inputArgs[3]);
                        int productQuantity = int.Parse(inputArgs[4]);

                        var product = ProductFactory.CreateProduct(productType, productLabel, productPrice, productQuantity);
                        this.productsStock.Add(product);

                        break;
                    case "Find":

                        try
                        {
                            string typeCommand = inputArgs[1];
                            string method = "Find{0}";

                            string methodName = string.Format(method, typeCommand);

                            var methodInfo = typeof(ProductStock)
                                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                .FirstOrDefault(x => x.Name == methodName);

                            CheckMethodParameters(methodInfo, inputArgs.Skip(2).ToArray());
                        }
                        catch (TargetInvocationException ex)
                        {

                            Console.WriteLine(ex.InnerException.Message);

                        }

                        break;
                    case "Remove":
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

           
        }



        private void CheckMethodParameters<T>(MethodInfo methodInfo, params T[] value)
        {
            var parameters = methodInfo.GetParameters();

            if (parameters.Length == 0)
            {
                methodInfo.Invoke(this.productsStock, new object[] { });
            }
            else if (parameters.Length == 1)
            {
                var parmaterType = parameters[0].ParameterType.Name;


                if (parmaterType == "Decimal")
                {
                    var price = Convert.ToDecimal(value[0]);
                    methodInfo.Invoke(this.productsStock, new object[] { price });
                }

                if (parmaterType == "Int32")
                {
                    var quantity = Convert.ToInt32(value[0]);
                    methodInfo.Invoke(this.productsStock, new object[] { quantity });
                }

                if (parmaterType == "String")
                {
                    var label = Convert.ToString(value[0]);
                    methodInfo.Invoke(this.productsStock, new object[] { label });
                }


            }
            else if (parameters.Length == 2)
            {
                methodInfo.Invoke(this.productsStock, new object[] { Convert.ToDecimal(value[0]), Convert.ToDecimal(value[1]) });
            }

        }
    }
}
