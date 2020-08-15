namespace MuOnline.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using MuOnline.Core.Factories.Contracts;
    using MuOnline.Models.Monsters.Contracts;


    public class MonsterFactory : IMonsterFactory
    {
        public IMonster Create(string monsterType)
        {
            var targetName = monsterType.ToLower();

            var typeMonster = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == targetName);

            if (typeMonster == null)
            {
                throw new ArgumentNullException("Invalid monster type!");
            }

            var monster = (IMonster)Activator.CreateInstance(typeMonster, new object[] { });

            return monster;
        }
    }
}
