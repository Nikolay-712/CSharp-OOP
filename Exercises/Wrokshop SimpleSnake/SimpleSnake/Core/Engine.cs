namespace SimpleSnake.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using SimpleSnake.Core.Factories;
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.Foods;
    public class Engine
    {
        
        public DrawManager DrawManager { get; set; }
        public Snake Snake { get; set; }
        public int SuspensionTime { get; private set; }
        public Food Food { get; set; }
        public Coordinate BorderCordinate { get; set; }
      
        public const char SnakeSymbol = '\u25CF';

        public Engine(DrawManager drawManager, Snake snake, Coordinate borderCoordinate)
        {
            this.DrawManager = drawManager;
            this.Snake = snake;
            this.BorderCordinate = borderCoordinate;
        }

        public void Run()
        {
            this.InitializeFood();
           
            Border border = new Border(this.BorderCordinate, this.DrawManager);
            border.InitializeBoard();

            while (true)
            {
                PlayerInfo.ShowPlayerStatistic(this.BorderCordinate.CoordinateX);

                if (Console.KeyAvailable)
                {

                }

                this.DrawManager.Draw(Food.FoodSymbol, new List<Coordinate>() { Food.FoodCoordinate });
                this.DrawManager.Draw(Convert.ToString(SnakeSymbol), this.Snake.SnakeBody);


                this.Snake.Move();
                this.DrawManager.UndoDraw();

                Thread.Sleep(SuspensionTime);

                
                SetDirection setDirection = new SetDirection(this.Snake);
                setDirection.GetCurrentDirection();
               
                if (this.HasEatCollision())
                {
                    this.Snake.Eat(this.Food);
                    this.InitializeFood();

                 
                    PlayerInfo.GameScore = PlayerInfo.GameScore + this.Food.FoodPoints;
                }

                if (HasBorderCollision())
                {
                    PlayerInfo.AskUserForRestart();
                }

            }
        }

        

        private void InitializeFood()
        {
            this.Food = FoodFactory.GenerateRandomFood(119, 39);
            var position = new List<Coordinate>() { Food.FoodCoordinate }.AsReadOnly();

            this.DrawManager.Draw(Food.FoodSymbol, position);

        }

        private bool HasEatCollision()
        {
            int snakeHeadPositionX = this.Snake.Head.CoordinateX;
            int snakeHeadPositionY = this.Snake.Head.CoordinateY;

            int foodPositionX = this.Food.FoodCoordinate.CoordinateX;
            int foodPositionY = this.Food.FoodCoordinate.CoordinateY;

            return (snakeHeadPositionX == foodPositionX && snakeHeadPositionY == foodPositionY);
        }

       

        private bool HasBorderCollision()
        {
            int snakeHeadPositionX = this.Snake.Head.CoordinateX;
            int snakeHeadPositionY = this.Snake.Head.CoordinateY;

            var hasLeftBorder = snakeHeadPositionY <= 0 || snakeHeadPositionY > this.BorderCordinate.CoordinateY - 1;
            var hasTopBorder = snakeHeadPositionX <= 0 || snakeHeadPositionX > this.BorderCordinate.CoordinateX - 1;

            return hasLeftBorder || hasTopBorder;
        }

        

       
    }  
}
