namespace AquaShop.Core
{
    using System.Text;
    using System.Linq;

    using AquaShop.Core.Contracts;
    using AquaShop.Repositories;
    using AquaShop.Utilities.Messages;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Core.Factories;
    using AquaShop.Models.Fish.Contracts;
    public class Controller : IController
    {
        private DecorationRepository decorationRepository;
        private AquariumRepository aquariumRepository;

        private AquariumFactory aquariumFactory;
        private DecorationFactory decorationFactory;
        private FishFactory fishFactory;

        public Controller()
        {
            this.decorationRepository = new DecorationRepository();
            this.aquariumRepository = new AquariumRepository();

            this.aquariumFactory = new AquariumFactory();
            this.decorationFactory = new DecorationFactory();
            this.fishFactory = new FishFactory();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            var aquarium = this.aquariumFactory.Create(aquariumType, aquariumName);

            var byName = this.aquariumRepository.Models.Select(x => x.Name);


            this.aquariumRepository.Add((IAquarium)aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquarium.GetType().Name);
        }

          

        public string AddDecoration(string decorationType)
        {
            var decoration = this.decorationFactory.Create(decorationType);

            this.decorationRepository.Add((IDecoration)decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decoration.GetType().Name);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var message = OutputMessages.UnsuitableWater;

            var aquarium = this.aquariumRepository.FindByType(aquariumName);
           

            IFish fish = (IFish)this.fishFactory.Create(fishName, fishType, fishSpecies, price);

            var aquariumType = aquarium.GetType().Name;
            var fishFromType = fish.GetType().Name;

            if ( aquariumType.Contains("Fresh") && fishFromType.Contains("Fresh") )
            {
                aquarium.AddFish(fish);
                message = string.Format(OutputMessages.EntityAddedToAquarium, fishFromType, aquarium.Name);
            }


            if (aquariumType.Contains("Salt") && fishFromType.Contains("Salt"))
            {
                aquarium.Fish.Add(fish);
                message = string.Format(OutputMessages.EntityAddedToAquarium, fishFromType, aquarium.Name);
            }

            return message;
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariumRepository.FindByType(aquariumName);

            decimal fishPrice = aquarium.Fish.Select(x => x.Price).Sum();
            decimal decorationPrice = aquarium.Decorations.Select(x => x.Price).Sum();

            decimal totalPrice = fishPrice + decorationPrice;

            return string.Format(OutputMessages.AquariumValue, aquarium.Name, totalPrice);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariumRepository.FindByType(aquariumName);

            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorationRepository.FindByType(decorationType);

            var aquarium = this.aquariumRepository.FindByType(aquariumName);

            aquarium.AddDecoration(decoration);
            this.decorationRepository.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium,decoration.GetType().Name,aquarium.Name);

        }

        public string Report()
        {

            StringBuilder builder = new StringBuilder();

            foreach (var item in this.aquariumRepository.Models)
            {
                builder.AppendLine(item.GetInfo());

            }

            return builder.ToString().TrimEnd();
        }

       
    }
}
