using ViceCity.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.IO.Contracts;
using ViceCity.IO;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private Controller controller;


        string playerName = string.Empty;
        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();

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
                    if (input[0] == "AddPlayer")
                    {
                        playerName = input[1];
                        writer.WriteLine(controller.AddPlayer(playerName));
                    }
                    else if (input[0] == "AddGun")
                    {
                        string gunType = input[1];
                        string gunName = input[2];
                        writer.WriteLine(controller.AddGun(gunType, gunName));
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        playerName = input[1];
                        writer.WriteLine(controller.AddGunToPlayer(playerName));

                    }
                    else if (input[0] == "Fight")
                    {
                        writer.WriteLine(controller.Fight());
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
