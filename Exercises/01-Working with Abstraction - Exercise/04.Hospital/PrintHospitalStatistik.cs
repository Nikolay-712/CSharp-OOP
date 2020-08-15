using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class PrintHospitalStatistik
    {
        public static void Run(string[] info)
        {
            if (info.Length == 1)
            {
                Console.WriteLine
                    (string.Join("\n", HospitalDepartments.ShowDepartments()[info[0]]
                    .Where(x => x.Count > 0)
                    .SelectMany(x => x.ToArray().Select(p => p.Name))));
            }
            else if (info.Length == 2 && int.TryParse(info[1], out int room))
            {
                var ss = HospitalDepartments
                    .ShowDepartments()[info[0]][room - 1].Select(x =>x.Name).OrderBy(x => x);



                Console.WriteLine
                    (string.Join("\n", HospitalDepartments
                    .ShowDepartments()[info[0]][room - 1]
                    .Select(x => x.Name).OrderBy(x => x)));
                    
            }
            else
            {
                var name = info[0] + info[1];

              

                Console.WriteLine
                   (string.Join("\n", HospiyalDoctors
                   .ShowDoctors()[name].Select(x => x.Name)
                   .OrderBy(x => x)));
            }
        }

    }
}
