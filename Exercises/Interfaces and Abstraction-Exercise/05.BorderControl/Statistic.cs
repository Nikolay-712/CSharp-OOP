using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public static class Statistic
    {
        private static List<Model> list = new List<Model>();

        public static void AddModelInCheckList(Model model)
        {
            list.Add(model);
        }

        public static List<Model> ShowCheckList()
        {
            return list;
        }

    }
}
