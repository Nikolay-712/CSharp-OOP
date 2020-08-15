using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }
            , StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            CreateField createField = new CreateField(dimestions);

            createField.AddValueInMatrix(createField.GetMatrix(), dimestions);
            var matrix = createField.GetMatrix();


            string command = Console.ReadLine();
          

            while (command != "Let the Force be with you")
            {
                int[] ivoS = command.Split(new string[] { " " }
                , StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int[] evil = Console.ReadLine().Split(new string[] { " " }
                , StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int xE = evil[0];
                int yE = evil[1];

                Evil evil1 = new Evil(xE, yE);
                evil1.MoveEvil(matrix);



                int xI = ivoS[0];
                int yI = ivoS[1];

                Player player = new Player(xI, yI);
                player.MovePlayer(matrix);



                command = Console.ReadLine();

               
            }

            

            Console.WriteLine(Player.GetSum());

        }
    }
}
