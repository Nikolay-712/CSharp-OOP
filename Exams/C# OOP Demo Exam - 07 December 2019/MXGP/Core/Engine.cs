using MXGP.Core.Contracts;
using MXGP.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        public  void Run()
        {
            ConsoleReader consoleReader = new ConsoleReader();
            ConsoleWriter consoleWriter = new ConsoleWriter();
            ChampionshipController championship = new ChampionshipController();

            var input = consoleReader.ReadLine();

            string riderName = string.Empty;
            string raceName = string.Empty;

            while (input != "End")
            {
                var inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (inputArgs[0])
                    {
                        case "CreateRider":

                            riderName = inputArgs[1];
                            consoleWriter.WriteLine(championship.CreateRider(riderName));
                            break;

                        case "CreateMotorcycle":

                            string motorcycleType = inputArgs[1];
                            string model = inputArgs[2];
                            int horsepower = int.Parse(inputArgs[3]);

                            consoleWriter.WriteLine(championship.CreateMotorcycle(motorcycleType, model, horsepower));
                            break;

                        case "AddMotorcycleToRider":

                            riderName = inputArgs[1];
                            string motorcycle = inputArgs[2];

                            consoleWriter.WriteLine(championship.AddMotorcycleToRider(riderName, motorcycle));
                            break;

                        case "AddRiderToRace":

                            raceName = inputArgs[1];
                            riderName = inputArgs[2];

                            consoleWriter.WriteLine(championship.AddRiderToRace(raceName, riderName));
                            break;

                        case "CreateRace":

                            raceName = inputArgs[1];
                            int laps = int.Parse(inputArgs[2]);

                            consoleWriter.WriteLine(championship.CreateRace(raceName, laps));
                            break;

                        case "StartRace":

                            raceName = inputArgs[1];
                            consoleWriter.WriteLine(championship.StartRace(raceName));
                            break;

                        default:
                            break;
                    }
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = consoleReader.ReadLine();
            }


        }
    }
}
