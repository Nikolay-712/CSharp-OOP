using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class HospiyalDoctors
    {
        private static Dictionary<string, List<Patient>> Doctors = new Dictionary<string, List<Patient>>();

        public static void AddDoctor(Doctor doctor)
        {
            string name = doctor.FullName;

            if (!Doctors.ContainsKey(name))
            {
                Doctors[name] = new List<Patient>();
            }
        }

        public static Dictionary<string, List<Patient>> ShowDoctors()
        {
            return Doctors;
         }

        public static void AddPatients(string doctorName, Patient patient)
        {
            Doctors[doctorName].Add(patient);
        }
    }
}
