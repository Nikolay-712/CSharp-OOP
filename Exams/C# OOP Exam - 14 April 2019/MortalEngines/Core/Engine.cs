namespace MortalEngines.Core
{
    using System;

    using MortalEngines.Core.Contracts;
   
    public class Engine : IEngine
    {
        public void Run()
        {
            string input = Console.ReadLine();
            IMachinesManager machinesManager = new MachinesManager();

            var message = string.Empty;

            while (input != "Quit")
            {
                var args = input.Split(" ");

                try
                {
                    switch (args[0])
                    {
                        case "HirePilot":
                            message = machinesManager.HirePilot(args[1]);
                            Console.WriteLine(message);
                            break;
                        case "PilotReport":
                            message = machinesManager.PilotReport(args[1]);
                            Console.WriteLine(message);
                            break;
                        case "ManufactureTank":
                            message = machinesManager.ManufactureTank(args[1], double.Parse(args[2]), double.Parse(args[3]));
                            Console.WriteLine(message);
                            break;
                        case "ManufactureFighter":
                            message = machinesManager.ManufactureFighter(args[1], double.Parse(args[2]), double.Parse(args[3]));
                            Console.WriteLine(message);
                            break;
                        case "MachineReport":
                            message = machinesManager.MachineReport(args[1]);
                            Console.WriteLine(message);
                            break;
                        case "AggressiveMode":
                            message = machinesManager.ToggleFighterAggressiveMode(args[1]);
                            Console.WriteLine(message);
                            break;
                        case "DefenseMode":
                            message = machinesManager.ToggleTankDefenseMode(args[1]);
                            Console.WriteLine(message);
                            break;
                        case "Engage":
                            message = machinesManager.EngageMachine(args[1], args[2]);
                            Console.WriteLine(message);
                            break;
                        case "Attack":
                            message = machinesManager.AttackMachines(args[1], args[2]);
                            Console.WriteLine(message);
                            break;


                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error:{ex.InnerException.Message}");
                }


                input = Console.ReadLine();
            }
        }
    }
}
