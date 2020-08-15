
namespace P01_RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tires tires;
        public Car(string model, Engine engine, Cargo cargo, Tires tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public Tires Tires
        {
            get { return this.tires; }
            private set { this.tires = value; }
        }



        public Cargo Cargo
        {
            get { return this.cargo; }
            private set { this.cargo = value; }
        }



        public Engine Engine
        {
            get { return this.engine; }
            private set { this.engine = value; }
        }


        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }


    }
}
