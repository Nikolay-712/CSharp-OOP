using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _07.InfernoInfinity
{
    public class Program
    {
        static void Main(string[] args)
        {
			try
			{
				CommandInterpreter commandInterpreter = new CommandInterpreter();
				commandInterpreter.Run();
			}
			catch (Exception)
			{

				
			}
        }
    }
}
