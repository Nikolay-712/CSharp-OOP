using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Controller
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;
        string message = string.Empty;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "EndTurn")
            {
                var args = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (args[0])
                    {
                        case "JoinParty":
                            message = this.dungeonMaster.JoinParty(args);
                            break;
                        case "AddItemToPool":
                            message = this.dungeonMaster.AddItemToPool(args);
                            break;
                        case "PickUpItem":
                            message = this.dungeonMaster.PickUpItem(args);
                            break;
                        case "UseItem":
                            message = this.dungeonMaster.UseItem(args);
                            break;
                        case "UseItemOn":
                            message = this.dungeonMaster.UseItem(args);
                            break;
                        case "GiveCharacterItem":
                            message = this.dungeonMaster.GiveCharacterItem(args);
                            break;
                        case "GetStats":
                            message = this.dungeonMaster.GetStats();
                            break;
                        case "Attack":
                            message = this.dungeonMaster.Attack(args);
                            break;
                        case "Heal":
                            message = this.dungeonMaster.Heal(args);
                            break;
                        case "EndTurn":
                            break;
                        case "IsGameOver":
                            break;

                        default:
                            break;
                    }
                    Console.WriteLine(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid Operation: {ex.Message}");
                    
                }

               

                input = Console.ReadLine();
            }
        }
    }
}
