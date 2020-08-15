namespace SimpleSnake.Core
{
    using System;

    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects;
   
    public class SetDirection
    {
        public SetDirection(Snake snake)
        {
            Snake = snake;
        }
        private Direction SnakeDirection { get; set; }
        public Snake Snake { get; set; }

        public void GetCurrentDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            switch (userInput.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (this.SnakeDirection == Direction.Right)
                    {
                       this. Snake.CurrentDirection = Direction.Left;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (this.SnakeDirection != Direction.Left)
                    {
                       this. Snake.CurrentDirection = Direction.Right;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (this.SnakeDirection != Direction.Down)
                    {
                       this. Snake.CurrentDirection = Direction.Up;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (this.SnakeDirection != Direction.Up)
                    {
                       this. Snake.CurrentDirection = Direction.Down;
                    }
                    break;
            }
        }

    }
}
