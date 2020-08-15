using AquaShop.Core.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Core.Factories
{
    public class FishFactory : IFactory
    {
        public object Create(params object[] value)
        {
            IFish fish = null;

            string fishType = value[1].ToString();
            string fishName = value[0].ToString();
            string fishSpecies = value[2].ToString();
            decimal fishPrice = Convert.ToDecimal(value[3]);

            if (fishType == "FreshwaterFish" || fishType == "SaltwaterFish")
            {

                if (fishType == "FreshwaterFish")
                {
                    fish = new FreshwaterFish(fishName, fishSpecies, fishPrice);
                }

                if (fishType == "SaltwaterFish")
                {
                    fish = new SaltwaterFish(fishName, fishSpecies, fishPrice);
                }

                return fish;

            }

            throw new InvalidOperationException(ExceptionMessages.InvalidFishType);



        }
    }
}
