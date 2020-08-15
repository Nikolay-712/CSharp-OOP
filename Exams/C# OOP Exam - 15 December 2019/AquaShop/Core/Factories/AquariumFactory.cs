namespace AquaShop.Core
{
    using System;

    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Utilities.Messages;

    public class AquariumFactory : IFactory
    {

        public object Create(params object[] value)
        {
            IAquarium aquarium = null;

            string aquariumType = value[0].ToString();
            string aquariumName = value[1].ToString();


            if (aquariumType == "FreshwaterAquarium" || aquariumType == "SaltwaterAquarium")
            {

                if (aquariumType == "FreshwaterAquarium")
                {
                    aquarium = new FreshwaterAquarium(aquariumName);
                }

                if (aquariumType == "SaltwaterAquarium")
                {
                    aquarium = new SaltwaterAquarium(aquariumName);
                }

                return aquarium;


            }

            throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);

        }
    }
}
