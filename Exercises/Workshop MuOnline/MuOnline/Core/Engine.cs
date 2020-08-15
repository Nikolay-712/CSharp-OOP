namespace MuOnline.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using MuOnline.Core.Commands;
    using MuOnline.Utilities;

    public class Engine : IEngine
    {
        public void Run()
        {
            LoadUtilities loadUtilities = new LoadUtilities();
            string typeCommandAdd = "Add{0}";

            string command = Console.ReadLine();

            while (command != "End")
            {
                var commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (commandInfo[0])
                    {
                        case "Add":
                            var currentCommand = string.Format(typeCommandAdd, commandInfo[1]);
                            var typeCommand = Assembly.GetExecutingAssembly().GetTypes()
                                .FirstOrDefault(x => x.Name.Contains(currentCommand));

                            var instance = Activator.CreateInstance(typeCommand);
                            var method = typeCommand.GetMethod("Execute");

                            Console.WriteLine(method.Invoke(instance, new object[] { commandInfo }));
                            break;
                        case "AddItem":
                            AddItemToHero addItemToHero = new AddItemToHero();
                            Console.WriteLine(addItemToHero.Execute(commandInfo));
                            break;
                        case "Fight":
                            var hero = LoadUtilities.LoadHeroRepository().Get("Darkkk");
                            FightCommand fightCommand = new FightCommand();
                            fightCommand.Execute(commandInfo);
                            break;

                    }
                }
                catch (ArgumentNullException ex)
                {

                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}
