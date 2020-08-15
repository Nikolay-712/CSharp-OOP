namespace MuOnline
{
    using System;

    using Core;
    using Core.Contracts;
    using MuOnline.Core.Factories;
    using MuOnline.Repositories;

    public class StartUp
    {
        public static void Main(string[] args)
        {
          
            IEngine engine = new Engine();
            engine.Run();
        }

       
    }
}
