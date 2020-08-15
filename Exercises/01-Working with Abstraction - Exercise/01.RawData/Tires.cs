using System.Collections.Generic;

namespace P01_RawData
{
    public class Tires
    {
        private string[] tiresInfo;
        private  List<int> tiresAge;
        private  List<double> tiresPressure;

        public Tires(string[] tiresInfo)
        {
            this.TiresInfo = tiresInfo;

            tiresAge = new List<int>();
            tiresPressure = new List<double>();

            CalculateTiresInfo(tiresInfo,tiresPressure,tiresAge);
        }

        public List<double> TiresPressure
        {
            
            get { return tiresPressure; }
            set { tiresPressure = value; }
        }


        public List<int> TiresAge
        {
            get { return tiresAge; }
            set { tiresAge = value; }
        }

        public string[] TiresInfo
        {
            get { return this.tiresInfo; }
            private set { this.tiresInfo = value; }
        }

        private static void CalculateTiresInfo(string[] info,List<double> tiresPressure,List<int> tiresAge)
        {
            for (int i = 0; i < info.Length; i++)
            {
                if (i % 2 == 0)
                {
                    tiresPressure.Add(double.Parse(info[i]));
                }
                else
                {
                    tiresAge.Add(int.Parse(info[i]));
                }
            }


        }
    }
}
