using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split(new char[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries);

            CommandParser.Run(input, capacity);

            ShowAmounts.Gold();
            ShowAmounts.Gem();
            ShowAmounts.Cash();


        }
    }
}