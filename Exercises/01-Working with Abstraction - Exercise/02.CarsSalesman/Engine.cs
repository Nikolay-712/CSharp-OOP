using System.Text;

namespace P02_CarsSalesman
{
    public class Engine
    {
        private const string offset = "  ";
        private const string defaultValValueEfficiency = "n/a";


        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
            : this(model, power, -1, defaultValValueEfficiency) { }


        public Engine(string model, int power, int displacement)
            : this(model, power, displacement, defaultValValueEfficiency) { }


        public Engine(string model, int power, string efficiency)
            : this(model, power, -1, efficiency) { }



        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public string Modeel
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}:\n", offset, this.model);
            sb.AppendFormat("{0}{0}Power: {1}\n", offset, this.power);
            sb.AppendFormat("{0}{0}Displacement: {1}\n", offset, this.displacement == -1 ? "n/a" : this.displacement.ToString());
            sb.AppendFormat("{0}{0}Efficiency: {1}\n", offset, this.efficiency);

            return sb.ToString();
        }
    }
}
