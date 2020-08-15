using System;
using System.Collections.Generic;
using System.Text;

namespace P03_JediGalaxy
{
    public class Player
    {
        private int playerPositionX;
        private int playerPositionY;
        private static long sum;

       

        public Player(int playerPositionX,int playerPositionY)
        {
            this.PlayerPositionX = playerPositionX;
            this.PlayerPositionY = playerPositionY;
        }

        public int PlayerPositionY
        {
            get { return this.playerPositionY; }
            set { this.playerPositionY = value; }
        }


        public int PlayerPositionX
        {
            get { return this.playerPositionX; }
            set { this.playerPositionX = value; }
        }

        public void MovePlayer(int[,] matrix)
        {
            while (this.PlayerPositionX >= 0 && PlayerPositionY < matrix.GetLength(1))
            {
                if (this.PlayerPositionX >= 0 
                    && this.PlayerPositionX < matrix.GetLength(0) 
                    && PlayerPositionY >= 0 
                    && PlayerPositionY < matrix.GetLength(1))
                {
                    sum += matrix[this.PlayerPositionX, PlayerPositionY];
                }

                this.PlayerPositionY++;
                this.PlayerPositionX--;
            }
        }

        public static long GetSum()
        {
            return sum;
        }

        

    }
}
