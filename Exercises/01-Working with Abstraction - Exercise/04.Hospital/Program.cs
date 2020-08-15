using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {

            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] hospitalInfo = command.Split();
                var departament = hospitalInfo[0];
                Department department = new Department(departament);


                var purvoIme = hospitalInfo[1];
                var vtoroIme = hospitalInfo[2];
                Doctor doctor = new Doctor(purvoIme, vtoroIme);


                var pacient = hospitalInfo[3];
                Patient patient = new Patient(pacient);

                HospiyalDoctors.AddDoctor(doctor);
                HospiyalDoctors.AddPatients(doctor.FullName, patient);


                HospitalDepartments.AddDepartment(department);
                HospitalDepartments.AddPatientInDepartment(department.Name, patient);

                command = Console.ReadLine();
            }



            command = Console.ReadLine();

            while (command != "End")
            {
                string[] info = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                PrintHospitalStatistik.Run(info);

                command = Console.ReadLine();
            }
        }
    }
}
