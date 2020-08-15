namespace SimpleSnake.Core
{
    using System;

    public class PlayerInfo
    {
        public static int GameScore { get; set; }

        public static void ShowPlayerStatistic(int position)
        {
            Console.SetCursorPosition(position + 10, 10);
            Console.Write($"Game score {GameScore}");
        }

        public static void AskUserForRestart()
        {
            int x = 45;
            int y = 20;

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Would you like to continue ? ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Y/N");

            string input = Console.ReadLine();

            if (input == "Y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
