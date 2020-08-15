using System;


namespace _03.Mankind
{
    public class Program
    {
        static void Main()
        {
            try
            {
                var studentInput = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var workerInput = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Student student = new Student(studentInput[0],
                    studentInput[1],
                    studentInput[2]);

                Worker worker = new Worker(workerInput[0],
                    workerInput[1],
                    double.Parse(workerInput[2]),
                    double.Parse(workerInput[3]));

                Console.WriteLine(student);
                
                Console.WriteLine(worker);

            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
