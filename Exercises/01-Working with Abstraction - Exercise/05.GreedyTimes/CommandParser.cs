using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class CommandParser
    {
        public static void Run(string[] command,long capacity)
        {
            Amount amountInBag = new Amount(capacity);

            for (int i = 0; i < command.Length; i += 2)
            {
                string type = command[i];
                long amount = long.Parse(command[i + 1]);

                string typeOfLoot = string.Empty;

                if (type.Length == 3)
                {
                    typeOfLoot = "Cash";
                }
                else if (type.ToLower().EndsWith("gem"))
                {
                    typeOfLoot = "Gem";
                }
                else if (type.ToLower() == "gold")
                {
                    typeOfLoot = "Gold";
                }

                if (typeOfLoot == "")
                {
                    continue;
                }

                switch (typeOfLoot)
                {
                    case "Gem":

                        Gem gem = new Gem(type, amount);
                        amountInBag.AddGem(gem);
                        break;

                    case "Cash":

                        Cash cash = new Cash(type, amount);
                        amountInBag.AddCash(cash);
                        break;

                    case "Gold":
                        Gold gold = new Gold(type, amount);
                        amountInBag.AddGold(gold);
                        break;
                }

            }


        }
    }
}
