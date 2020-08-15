using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Contracts
{
    public interface IFood
    {
        int FoodPoints { get; }
        string FoodSymbol { get; }
        Coordinate FoodCoordinate { get; }
    }
}
