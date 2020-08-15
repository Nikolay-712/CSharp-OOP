using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Characters.Enums;
using DungeonsAndCodeWizards.Controller.Factories;
using DungeonsAndCodeWizards.Repositores;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Controller
{
    public class DungeonMaster
    {
        private CharackterFactory charackterFactory;
        private CharactersRepository charactersRepository;

        private ItemFactory itemFactory;
        private ItemRepository itemRepository;

        public DungeonMaster()
        {
            this.charackterFactory = new CharackterFactory();
            this.charactersRepository = new CharactersRepository();

            this.itemFactory = new ItemFactory();
            this.itemRepository = new ItemRepository();
        }

        public string JoinParty(string[] args)
        {
            Faction faction;

            Enum.TryParse("Active", out faction);

            var character = this.charackterFactory.Create(faction, args[2], args[3]);
            this.charactersRepository.AddCharacter(character);

            return $"{character.Name} joined the party!";

        }

        public string AddItemToPool(string[] args)
        {
            var item = this.itemFactory.Create(args[1]);
            this.itemRepository.AddItem(item);

            return $"{args[1]} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var item = this.itemRepository.GetLastItem();
            var character = this.charactersRepository.GetCurrentCharacter(args[1]);

            character.Bag.AddItem(item);

            this.itemRepository.RemoveItem(item);

            return $"{character.Name} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var character = this.charactersRepository.GetCurrentCharacter(args[1]);
            var item = character.Bag.GetItem(args[2]);

            character.UseItem(item);

            return $"{character.Name} used {item.GetType().Name}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[1];
            string receiverName = args[2];
            string itemName = args[3];

            var giverCharacter = this.charactersRepository.GetCurrentCharacter(giverName);
            var receiverCharacter = this.charactersRepository.GetCurrentCharacter(receiverName);

            var item = giverCharacter.Bag.GetItem(itemName);

            receiverCharacter.UseItem(item);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[1];
            string receiverName = args[2];
            string itemName = args[3];

            var giverCharacter = this.charactersRepository.GetCurrentCharacter(giverName);
            var receiverCharacter = this.charactersRepository.GetCurrentCharacter(receiverName);

            var item = giverCharacter.Bag.GetItem(itemName);

            receiverCharacter.Bag.AddItem(item);

            return $"{giverName} gave {receiverName} {itemName}";
        }

        public string GetStats()
        {
            StringBuilder builder = new StringBuilder();

            var characters = this.charactersRepository.OrderCharacters();
            var status = "Dead";


            foreach (var character in characters)
            {
                if (character.IsAlive)
                {
                    status = "Alive";
                }


                builder.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}" +
                    $", AP: {character.Armor}/{character.BaseArmor}, Status: {status}");

            }

            return builder.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            StringBuilder builder = new StringBuilder();

            var info = string.Empty;

            var attackerCharacter = this.charactersRepository.GetCurrentCharacter(args[1]);
            var receiverCharacter = this.charactersRepository.GetCurrentCharacter(args[2]);

            if (attackerCharacter.GetType().Name == "Cleric")
            {
                throw new ArgumentException($"{attackerCharacter.Name} cannot attack!");
            }

            ((Warrior)attackerCharacter).Attack(receiverCharacter);

            if (!receiverCharacter.IsAlive)
            {

                info = ($"{receiverCharacter.Name} is dead!");
            }


            builder.AppendLine
            ($"{attackerCharacter.Name} attacks {receiverCharacter.Name}" +
            $" for {attackerCharacter.AbilityPoints} hit points! {receiverCharacter.Name} " +
            $"has {receiverCharacter.Health}/{receiverCharacter.BaseHealth}" +
            $" HP and {receiverCharacter.Armor}/{receiverCharacter.BaseArmor} AP left!").AppendLine(info);


            return builder.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            var healerCharacter = this.charactersRepository.GetCurrentCharacter(args[1]);
            var healingReceiverCharacter = this.charactersRepository.GetCurrentCharacter(args[2]);

            if (healerCharacter.GetType().Name != "Cleric")
            {
                throw new ArgumentException($"{healerCharacter.Name} cannot heal!");
            }

            ((Cleric)healerCharacter).Heal(healingReceiverCharacter);

            return
                $"{healerCharacter.Name} heals {healingReceiverCharacter.Name} for" +
                $" {healerCharacter.AbilityPoints}! {healingReceiverCharacter.Name} has" +
                $" {healingReceiverCharacter.Health} health now!";

        }

        public string EndTurn(string[] args)
        {
            throw new NotImplementedException();
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }

    }
}
