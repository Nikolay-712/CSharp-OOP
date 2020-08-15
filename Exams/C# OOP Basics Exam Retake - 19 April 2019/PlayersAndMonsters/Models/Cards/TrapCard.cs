using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        //Has 120 damage points and 5 health points.

        private const int damagePoints = 120;
        private const int healthPoints = 5;

        public TrapCard(string name) 
            : base(name, damagePoints, healthPoints)
        {
        }
    }
}
