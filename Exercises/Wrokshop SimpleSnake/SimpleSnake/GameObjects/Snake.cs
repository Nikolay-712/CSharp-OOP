namespace SimpleSnake.GameObjects
{
    using System.Collections.Generic;
    using System.Linq;

    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects.Foods;

    public class Snake
    {
        public const char Symbol = '\u25CF';

        private List<Coordinate> snakeBody;
        
        public Snake()
        {
            this.snakeBody = new List<Coordinate>();
            this.InitializeDefaultSnake();
            this.CurrentDirection = Direction.Right;
        }

        public IReadOnlyCollection<Coordinate> SnakeBody
            => this.snakeBody.AsReadOnly();

        public Direction CurrentDirection { get; set; }
        public Coordinate Head { get; set; }


        public void InitializeDefaultSnake()
        {
            int x = 5;
            int y = 6;

            for (int i = 1; i <= 6; i++)
            {
                this.snakeBody.Add(new Coordinate(x++, y));
            }
        }

        public Coordinate CalculateNewCoordinate(Coordinate newCoordinate)
        {
            switch (this.CurrentDirection)
            {
                case Direction.Right:
                    newCoordinate.CoordinateX = newCoordinate.CoordinateX + 1;
                    break;
                case Direction.Left:
                    newCoordinate.CoordinateX = newCoordinate.CoordinateX - 1;
                    break;
                case Direction.Up:
                    newCoordinate.CoordinateY = newCoordinate.CoordinateY - 1;
                    break;
                case Direction.Down:
                    newCoordinate.CoordinateY = newCoordinate.CoordinateY + 1;
                    break;
            }
          
            return newCoordinate;
        }

        public void Move()
        {
            Coordinate headPosition = this.SnakeBody.Last();

            Coordinate newHeadPosition =
                this.CalculateNewCoordinate(new Coordinate(headPosition.CoordinateX, headPosition.CoordinateY));

            this.snakeBody.Add(newHeadPosition);
            this.snakeBody.RemoveAt(0);

          this.  Head = headPosition;
        }

        public void Eat(Food food)
        {
            for (int i = 0; i < food.FoodPoints; i++)
            {
                Coordinate coordinate = new Coordinate(this.Head.CoordinateX, this.Head.CoordinateY);

                this.snakeBody.Add(CalculateNewCoordinate(coordinate));
            }
        }

    }
}
