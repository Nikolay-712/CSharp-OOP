using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Characters.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Controller.Factories
{
    public class CharackterFactory
    {
        //CSharp Warrior Gosho
        public Character Create(Faction faction, string characterType, string characterName)
        {
            Character character = null;

            switch (characterType)
            {
                case "Warrior":
                    character = new Warrior(characterName, faction);
                    break;
                case "Cleric":
                    character = new Cleric(characterName, faction);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type { characterType }!");
            }

            return character;
        }
    }
}
