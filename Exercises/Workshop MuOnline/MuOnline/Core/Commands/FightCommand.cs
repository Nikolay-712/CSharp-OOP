using MuOnline.Core.Commands.Contracts;
using MuOnline.Utilities;
using System;
using System.Collections.Generic;
using System.Text;


namespace MuOnline.Core.Commands
{
    public class FightCommand : ICommand
    {
        public string Execute(string[] inputArgs)
        {
            var heroName = inputArgs[1];
            var monsterName = inputArgs[2];

            var hero = LoadUtilities.LoadHeroRepository().Get(heroName);
            var monster = LoadUtilities.LoadMonsterRepository().Get(monsterName);

            while (true)
            {
                //Fight

                break;
            }

            if (true)
            {

            }


            return $"Winer....";
        }
    }
}
