namespace SpaceStation.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SpaceStation.Core.Contracts;
    using SpaceStation.IO;
    using SpaceStation.IO.Contracts;
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private Controller controller;
        private string name;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        var type = input[1];
                        this.name = input[2];

                        writer.WriteLine(this.controller.AddAstronaut(type, this.name));
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        string[] items = null;

                        var planetName = input[1];
                        if (input.Length > 2)
                        {
                            items = input.Skip(2).ToArray();
                        }

                        writer.WriteLine(this.controller.AddPlanet(planetName, items));
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        this.name = input[1];
                        writer.WriteLine(this.controller.RetireAstronaut(this.name));
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        var planetName = input[1];
                        writer.WriteLine(this.controller.ExplorePlanet(planetName));

                    }
                    else if (input[0] == "Report")
                    {
                        writer.WriteLine(this.controller.Report());
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
