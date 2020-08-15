using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace INStock
{
    public class ProductFactory
    {
        public static IProduct CreateProduct(string type,string label,decimal price,int quantity)
        {
            IProduct product = new Product(type,label,price,quantity);

            return product;

        }

    }
}
