using DungeonsAndCodeWizards.Characters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Repositores
{
    public class CharactersRepository
    {
        private List<Character> characters;

        public CharactersRepository()
        {
            this.characters = new List<Character>();
        }

        public void AddCharacter(Character character)
        {
            this.characters.Add(character);
        }

        public Character GetCurrentCharacter(string characterName)
        {
            var character = this.characters.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return character;
        }

        public List<Character> OrderCharacters()
        {
            return this.characters.OrderByDescending(x => x.IsAlive).ThenByDescending(c => c.Health).ToList();
        }
    }
}
