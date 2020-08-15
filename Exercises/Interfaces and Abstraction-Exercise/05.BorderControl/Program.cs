using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.BorderControl
{
    public class Program
    {
        static void Main()
        {

            int personCount = int.Parse(Console.ReadLine());

            for (int cnt = 0; cnt < personCount; cnt++)
            {
                var info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (info.Length == 4)
                {
                    Statistic.AddModelInCheckList(Model.CitizenCreator(info[0], int.Parse(info[1]), info[2], info[3]));
                }
                else
                {
                    Statistic.AddModelInCheckList(Model.RebelCreator(info[0], int.Parse(info[1]), info[2]));
                }
            }

            string currentName = Console.ReadLine();

            while (currentName != "End")
            {
                var currentBuyer = Statistic.ShowCheckList().Where(x => x.Name == currentName).FirstOrDefault();

                if (currentBuyer != null)
                {
                    currentBuyer.BuyFood();
                }

                currentName = Console.ReadLine();
            }

            Console.WriteLine(Statistic.ShowCheckList().Select(x => x.Food).Sum());
        }
    }
}
