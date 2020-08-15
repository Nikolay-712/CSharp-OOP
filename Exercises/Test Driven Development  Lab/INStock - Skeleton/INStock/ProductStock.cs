namespace INStock
{
    using INStock.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    public class ProductStock : IProductStock
    {
        private Dictionary<string, List<IProduct>> Products;

        public ProductStock()
        {
            this.Products = new Dictionary<string, List<IProduct>>();
        }

        public IProduct this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int Count => CalculateProductsCount();



        public void Add(IProduct product)
        {
            string productType = product.ProductType;

            if (!this.Products.ContainsKey(productType))
            {
                this.Products[productType] = new List<IProduct>();
            }
            else
            {
                var labelsInColection = this.Products[productType].Select(x => x.Label);

                if (labelsInColection.Contains(product.Label))
                {
                    var currentProduct = this.Products[productType].FirstOrDefault(x => x.Label == product.Label);

                    var quantytity = currentProduct
                        .GetType()
                        .GetRuntimeProperties()
                        .FirstOrDefault(x => x.Name == "Quantity");

                    int newAmount = currentProduct.Quantity + product.Quantity;

                    quantytity.SetValue(currentProduct, newAmount);

                    if (currentProduct.Price < product.Price)
                    {
                        var price = currentProduct
                            .GetType()
                            .GetProperties()
                            .FirstOrDefault(x => x.Name == "Price");

                        price.SetValue(currentProduct, product.Price);
                    }

                    return;

                }

            }

            this.Products[productType].Add(product);

        }

        public bool Contains(IProduct product)
        {
            var targetProductType = product.ProductType;
            var targetProductLabel = product.Label;

            foreach (var productsList in this.Products.Values)
            {
                foreach (var wantedProduct in productsList)
                {
                    var wantedProductType = wantedProduct.ProductType;
                    var wantedProductLabel = wantedProduct.Label;

                    if (targetProductType == wantedProductType && targetProductLabel == wantedProductLabel)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public IProduct Find(string type, int index)
        {

            if (!this.Products.ContainsKey(type))
            {
                throw new ArgumentException("The requested type does not exist!");
            }

            var productsFromType = this.Products[type];

            if (productsFromType.Count < index)
            {
                throw new ArgumentException("The position you are looking is empty!");
            }

            var product = productsFromType[index];

            return product;


        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {

            if (price > 50 || price <= 0)
            {
                throw new ArgumentException("Price should be in range {1 ... 50}$");
            }

            var productsByPrice = FindeProducts("Price", price);

            if (productsByPrice.Count == 0)
            {
                throw new InvalidOperationException("There are no products with the required price!");
            }

            return productsByPrice;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative");
            }

            var productsBytQuantity = FindeProducts("Quantity", quantity);

            if (productsBytQuantity.Count == 0)
            {
                throw new ArgumentException("There are no products with the required qunatity!");
            }

            return productsBytQuantity;
        }

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
        {
            if (hi > 50 || lo <= 0)
            {
                throw new ArgumentException("Price should be in range {1 ... 50}$");
            }

            var productsByPriceRange = FindeProducts("PriceRange", lo, hi);


            if (productsByPriceRange.Count == 0)
            {
                throw new ArgumentException("There are no products with the required price range!");
            }

            return productsByPriceRange.OrderBy(x => x.Price);

        }

        public IProduct FindByLabel(string label)
        {
            if (string.IsNullOrEmpty(label) || string.IsNullOrWhiteSpace(label))
            {
                throw new ArgumentException("The given label is not valid!");
            }

            var productsByLabel = FindeProducts("Label", label);

            if (productsByLabel.Count == 0)
            {
                throw new ArgumentException("No products with this label!");
            }

            return productsByLabel.FirstOrDefault();
        }

        public IProduct FindMostExpensiveProduct()
        {

            if (this.Products.Count == 0)
            {
                throw new ArgumentException("The product list is empty!");
            }

            IProduct mostExpensive = null;
            var mostBigPrice = 0m;
           
            foreach (var item in this.Products.Values)
            {
                var currentProduct = item.OrderByDescending(x => x.Price).FirstOrDefault();

                if (currentProduct.Price > mostBigPrice)
                {
                    mostExpensive = currentProduct;
                    mostBigPrice = mostExpensive.Price;
                }
            }

            return mostExpensive;

        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IProduct product)
        {
            var productType = product.ProductType;

            this.Products[productType].Remove(product);

            if (this.Products[productType].Count == 0)
            {
                this.Products.Remove(productType);
            }

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private int CalculateProductsCount()
        {
            var count = 0;

            foreach (var item in this.Products)
            {
                count = count + item.Value.Count;

            }


            return count;
        }

        private List<IProduct> FindeProducts<T>(string targetParameter, params T[] value)
        {
            var targetProductsList = new List<IProduct>();

            foreach (var productsList in this.Products.Values)
            {
                foreach (var product in productsList)
                {
                    switch (targetParameter)
                    {
                        case "Price":
                            if (product.Price == Convert.ToDecimal(value[0]))
                            {
                                targetProductsList.Add(product);
                            }
                            break;
                        case "Quantity":
                            if (product.Quantity == Convert.ToInt32(value[0]))
                            {
                                targetProductsList.Add(product);
                            }
                            break;
                        case "PriceRange":
                            if (product.Price == Convert.ToDecimal(value[0]) || product.Price == Convert.ToDecimal(value[1]))
                            {
                                targetProductsList.Add(product);
                            }
                            break;
                        case "Label":
                            if (product.Label == Convert.ToString(value[0]))
                            {
                                targetProductsList.Add(product);

                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return targetProductsList;
        }
    }
}
