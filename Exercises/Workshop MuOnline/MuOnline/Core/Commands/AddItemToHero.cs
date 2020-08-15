namespace MuOnline.Core.Commands
{
    using MuOnline.Core.Commands.Contracts;
    using MuOnline.Models.Heroes.HeroContracts;
    using MuOnline.Models.Items.Contracts;
    using MuOnline.Utilities;
    using System;

    public class AddItemToHero : ICommand
    {
        public string Execute(string[] inputArgs)
        {
            string itemName = inputArgs[1];
            string heroName = inputArgs[2];

            var targetItem = LoadUtilities.LoadItemRepository().Get(itemName);
            var targetHero = LoadUtilities.LoadHeroRepository().Get(heroName);


            if (targetItem.GetType().FullName.Contains("Set"))
            {
                var itemFullName = targetItem.GetType().FullName;
                var typeHero = targetHero.GetType().Name;

                if (!itemFullName.Contains(typeHero))
                {
                    return $"Not compatible Set with {typeHero}";
                }
                else
                {
                    targetHero.Inventory.AddItem(targetItem);
                    return $"Secsuful add Item: {itemName} to Hero: {heroName}";
                }

            }
            else
            {
                targetHero.Inventory.AddItem(targetItem);
                return $"Secsuful add Item: {itemName} to Hero: {heroName}";
            }

           

        }

       
    }
}
