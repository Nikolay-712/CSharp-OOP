namespace SimpleSnake.Core
{
    using System.Collections.Generic;

    using SimpleSnake.GameObjects;
    public class Border
    {
        public Border(Coordinate borderCoordinate, DrawManager drawManager)
        {
            BorderCordinate = borderCoordinate;
            DrawManager = drawManager;
            
        }

        private static Coordinate BorderCordinate { get; set; }
        private static DrawManager DrawManager { get; set; }
       
        private void InitializeHorizontalBorder(int coordinateY, List<Coordinate> allCoordinates)
        {
            for (int coordinateX = 0; coordinateX < BorderCordinate.CoordinateX; coordinateX++)
            {
                allCoordinates.Add(new Coordinate(coordinateX, coordinateY));
            }
        }

        private static void InitializeVerticalBorder(int coordinateX, List<Coordinate> allCoordinates)
        {
            for (int coordinateY = 0; coordinateY < BorderCordinate.CoordinateY; coordinateY++)
            {
                allCoordinates.Add(new Coordinate(coordinateX, coordinateY));
            }
        }
        public void InitializeBoard()
        {
            List<Coordinate> allCoordinates = new List<Coordinate>();

            InitializeHorizontalBorder(0, allCoordinates);
            InitializeHorizontalBorder(BorderCordinate.CoordinateY - 1, allCoordinates);

            InitializeVerticalBorder(0, allCoordinates);
            InitializeVerticalBorder(BorderCordinate.CoordinateX - 1, allCoordinates);

            DrawManager.Draw("\u25A0", allCoordinates);
        }
        
    }
}
