using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Contracts
{
    public interface ICoordinate
    {
        int CoordinateX { get; }
        int CoordinateY { get; }
    }
}
