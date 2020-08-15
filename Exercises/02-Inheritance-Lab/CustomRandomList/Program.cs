using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main()
        {
            RandomList vs = new RandomList();

            List<string> list = new List<string>()
            {
                "dada",
                "nene",
                "kone",
                "eene"
            };

            vs.RandomString(list);
           
        }
    }
}
