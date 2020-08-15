using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        ManagerController managerController;
        private Reader reader;
        private Writer writer;
        private string message;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.managerController = new ManagerController();
        }

        public void Run()
        {
            var args = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


            while (args[0] != "Exit")
            {
                try
                {
                    switch (args[0])
                    {
                        case "AddPlayer":
                            this.message = this.managerController.AddPlayer(args[1], args[2]);
                            break;
                        case "AddCard":
                            this.message = this.managerController.AddCard(args[1], args[2]);
                            break;
                        case "AddPlayerCard":
                            this.message = this.managerController.AddPlayerCard(args[1], args[2]);
                            break;
                        case "Fight":
                            this.message = this.managerController.Fight(args[1], args[2]);
                            break;
                        case "Report":
                            this.message = this.managerController.Report();
                            break;
                        default:
                            break;
                    }
                    this.writer.WriteLine(message);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }

                args = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

        }


    }
}

