using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class HospitalDepartments
    {
        private static Dictionary<string, List<List<Patient>>> departments = new Dictionary<string, List<List<Patient>>>();

        public static void AddDepartment(Department department)
        {
            string departmentName = department.Name;

            if (!departments.ContainsKey(departmentName))
            {
                departments[departmentName] = new List<List<Patient>>();
                for (int stai = 0; stai < 20; stai++)
                {
                    departments[departmentName].Add(new List<Patient>());
                }
            }

        }

        public static Dictionary<string, List<List<Patient>>> ShowDepartments()
        {
            return departments;
        }

        public static void AddPatientInDepartment(string departamentName, Patient patient)
        {
            bool AvailableRooms = departments[departamentName].SelectMany(x => x).Count() < 60;

            if (AvailableRooms)
            {
                int room = 0;
               
                for (int roomNumber = 0; roomNumber < departments[departamentName].Count; roomNumber++)
                {
                    if (departments[departamentName][roomNumber].Count < 3)
                    {
                        room = roomNumber;
                        break;
                    }
                }
                departments[departamentName][room].Add(patient);
            }
        }

    }
}
