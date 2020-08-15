using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;
        
        public RandomList()
        {
            this.random = new Random();
        }

        public string RandomString(List<string> list)
        {
            int index = this.random.Next(0, list.Count);

            string element = list[index];

            list.RemoveAt(index);

            return element;
        }
    }
}
