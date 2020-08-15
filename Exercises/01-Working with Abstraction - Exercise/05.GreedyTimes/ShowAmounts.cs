using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class ShowAmounts
    {
        public static void Gold()
        {
            var goldInBag = Amount.Golds();
            if (goldInBag.Count != 0)
            {
                string type = "Gold";
                long amount = goldInBag.Select(x => x.Amount).Sum();


                Console.WriteLine($"<{type}> ${amount}");
                Console.WriteLine($"##{type} - {amount}");

            }

        }

        public static void Gem()
        {
            var gemInBag = Amount.Gems();
            if (gemInBag.Count != 0)
            {
                string type = "Gem";
                long amount = gemInBag.Select(x => x.Amount).Sum();

                Console.WriteLine($"<{type}> ${amount}");

                foreach (var item in gemInBag.OrderByDescending(x => x.Type).ThenBy(x => x.Amount))
                {
                    Console.WriteLine($"##{item.Type} - {item.Amount}");
                }
            }
           
        }

        public static void Cash()
        {
            var cashInBag = Amount.Cashes();
            if (cashInBag.Count != 0)
            {
                string type = "Cash";
                long amount = cashInBag.Select(x => x.Amount).Sum();

                Console.WriteLine($"<{type}> ${amount}");

                foreach (var item in cashInBag.OrderByDescending(x => x.Type).ThenBy(x => x.Amount))
                {
                    Console.WriteLine($"##{item.Type} - {item.Amount}");
                }
            }

            
        }

    }
}
