namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using P03_BarraksWars.Core.Commands;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            var currentCommandName = commandName + "command";
            var currentCommand = typeof(Command).Assembly.GetTypes().FirstOrDefault(x => x.Name.ToLower() == currentCommandName);

            var instance = Activator.CreateInstance(currentCommand, new object[] { data, repository, unitFactory });

            var result = currentCommand.GetMethod("Execute").Invoke(instance, new object[] { });

            return result.ToString();
        }



    }
}
