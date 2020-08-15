using SimpleSnake.GameObjects.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : IFood
    {
        protected Food(string symbol,int foodPoint,Coordinate coordinate)
        {
            this.FoodSymbol = symbol;
            this.FoodPoints = foodPoint;
            this.FoodCoordinate = coordinate;
        }
        public int FoodPoints { set; get; }

        public string FoodSymbol { set; get; }

        public Coordinate FoodCoordinate { set; get; }
    }
}
