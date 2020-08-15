namespace MuOnline.Core.Commands
{
    using Contracts;
    using MuOnline.Core.Factories;
    using MuOnline.Utilities;
    public class AddItemCommand : ICommand
    {
        public string Execute(string[] inputArgs)
        {
            string itemType = inputArgs[2];

            ItemFactory itemFactory = new ItemFactory();
            var item = itemFactory.Create(itemType);

            LoadUtilities.LoadItemRepository().Add(item);

            return $"Successful create new Item {itemType}";
        }
    }
}
