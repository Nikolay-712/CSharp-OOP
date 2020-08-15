namespace AquaShop.Core.Factories
{
    using System;

    using AquaShop.Core.Contracts;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Utilities.Messages;

    public class DecorationFactory : IFactory
    {
        public object Create(params object[] value)
        {
            IDecoration decoration = null;

            string decorationType = value[0].ToString();
           

            if (decorationType == "Ornament" || decorationType == "Plant")
            {
                if (decorationType == "Ornament")
                {
                    decoration = new Ornament();
                }

                if (decorationType == "Plant")
                {
                    decoration = new Plant();
                }

                return decoration;

            }
            throw new ArgumentException(ExceptionMessages.InvalidDecorationType);

        }
    }
}
