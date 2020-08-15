using System.Collections.Generic;

namespace P02_CarsSalesman
{
    public class EngineFactory
    {
        private static List<Engine> engineList = new List<Engine>();

        public static void CreateEngine(string[] parameters)
        {
            string model = parameters[0];
            int power = int.Parse(parameters[1]);

            int displacement = -1;

            if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
            {

                engineList.Add(new Engine(model, power, displacement));
            }
            else if (parameters.Length == 3)
            {
                string efficiency = parameters[2];
                engineList.Add(new Engine(model, power, efficiency));
            }
            else if (parameters.Length == 4)
            {
                string efficiency = parameters[3];
                engineList.Add(new Engine(model, power, int.Parse(parameters[2]), efficiency));
            }
            else
            {
                engineList.Add(new Engine(model, power));
            }
        }

        public static List<Engine> GetEngine()
        {
            return engineList;
        }
    }
}
