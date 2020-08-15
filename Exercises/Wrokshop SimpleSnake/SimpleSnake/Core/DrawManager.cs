namespace SimpleSnake.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SimpleSnake.GameObjects;
    public class DrawManager
    {
        public List<Coordinate> lastDrawElements;

        public DrawManager()
        {
            this.lastDrawElements = new List<Coordinate>();
        }
        public IReadOnlyCollection<Coordinate> LastDrawElements
            => this.lastDrawElements.AsReadOnly();

        public void Draw(string symbol, IReadOnlyCollection<Coordinate> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                if (symbol == Convert.ToString(Snake.Symbol))
                {
                    this.lastDrawElements.Add(new Coordinate(coordinate.CoordinateX, coordinate.CoordinateY));
                }

                this.DrawOperation(symbol, coordinate);
            }
        }

        private void DrawOperation(string symbol, Coordinate coordinate)
        {
            Console.SetCursorPosition(coordinate.CoordinateX, coordinate.CoordinateY);
            Console.Write(symbol);
        }

        public void UndoDraw()
        {
            if (this.lastDrawElements.Any())
            {
                DrawOperation(" ", this.lastDrawElements.First());
                this.lastDrawElements.Clear();
            }
        }
    }
}
