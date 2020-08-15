using MuOnline.Core.Commands.Contracts;
using MuOnline.Core.Factories;
using MuOnline.Core.Factories.Contracts;
using MuOnline.Utilities;

namespace MuOnline.Core.Commands
{
    public class AddMonsterCommand : ICommand
    {
        public string Execute(string[] inputArgs)
        {
            string monsterType = inputArgs[2];
           

            MonsterFactory monsterFactory = new MonsterFactory();
            var monster = monsterFactory.Create(monsterType);

            LoadUtilities.LoadMonsterRepository().Add(monster);

            return $"Successful create new Monster {monsterType}";
        }
    }
}
