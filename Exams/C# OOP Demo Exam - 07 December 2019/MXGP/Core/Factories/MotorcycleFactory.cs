using MXGP.Models.Motorcycles;
namespace MXGP.Core
{
    using MXGP.Models.Motorcycles.Contracts;

    public abstract class MotorcycleFactory
    {
        public static IMotorcycle CreateMotorcycle(string type, string model, int horsePower)
        {
          
            switch (type)
            {
                case "Speed":
                    return new SpeedMotorcycle(model, horsePower);
                case "Power":
                    return new PowerMotorcycle(model, horsePower);
                default:
                    break;
            }

            return null;
        }
    }
}
