using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private ManagerController managerController;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.managerController = new ManagerController();
        }


        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                    if (input[0] == "AddPlayer")
                    {
                        string playerType = input[1];
                        string playerName = input[2];

                        result = this.managerController.AddPlayer(playerType, playerName);
                    }
                    else if (input[0] == "AddCard")
                    {
                        string cardType = input[1];
                        string cardName = input[2];

                        result = this.managerController.AddCard(cardType, cardName);
                    }
                    else if (input[0] == "AddPlayerCard")
                    {
                        string playerName = input[1];
                        string cardName = input[2];

                        result = this.managerController.AddPlayerCard(playerName, cardName);

                    }
                    else if (input[0] == "Fight")
                    {
                        string attackPlayer = input[1];
                        string enemyPlayer = input[2];

                        result = this.managerController.Fight(attackPlayer, enemyPlayer);


                    }
                    else if (input[0] == "Report")
                    {
                        result = this.managerController.Report();
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }

            }
        }
    }
}
