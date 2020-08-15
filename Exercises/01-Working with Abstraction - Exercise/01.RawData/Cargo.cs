
namespace P01_RawData
{
    public class Cargo
    {
        private int cargoWeight;

        private string cargoType;


        public Cargo(int cargoWeight,string cargoType)
        {
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;

        }
        public string CargoType
        {
            get { return this.cargoType; }
            private set { this.cargoType = value; }
        }


        public int CargoWeight
        {
            get { return this.cargoWeight; }
            private set { this.cargoWeight = value; }
        }



    }
}
