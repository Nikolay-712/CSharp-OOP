using System.Collections.Generic;
using System.Linq;

namespace P02_CarsSalesman
{
    public class CarFactory
    {
        private static List<Car> carList = new List<Car>();

        public static void CreateCar(string[] parameters)
        {
            string model = parameters[0];
            string engineModel = parameters[1];

            Engine engine = EngineFactory.GetEngine().FirstOrDefault(x => x.Modeel == engineModel);

            int weight = -1;

            if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
            {
                carList.Add(new Car(model, engine, weight));
            }
            else if (parameters.Length == 3)
            {
                string color = parameters[2];
                carList.Add(new Car(model, engine, color));
            }
            else if (parameters.Length == 4)
            {
                string color = parameters[3];
                carList.Add(new Car(model, engine, int.Parse(parameters[2]), color));
            }
            else
            {
                carList.Add(new Car(model, engine));
            }
        }

        public static List<Car> GetCar()
        {
            return carList;
        }

    }
}
