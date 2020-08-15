using System;
using System.Collections.Generic;
using System.Text;

namespace P03_JediGalaxy
{
    public class Evil
    {
        private int evilPositionX;
        private int evilPositionY;

        public Evil(int evilPositionX,int evilPositionY)
        {
            this.EvilPositionX = evilPositionX;
            this.EvilPositionY = evilPositionY;
        }

        public int EvilPositionY
        {
            get { return this.evilPositionY; }
            set { this.evilPositionY = value; }
        }


        public int EvilPositionX
        {
            get { return this.evilPositionX; }
            set { this.evilPositionX = value; }
        }

        public void MoveEvil(int[,] matrix)
        {
            while (this.EvilPositionX >= 0 && this.EvilPositionY >= 0)
            {
                if (this.EvilPositionX >= 0 && this.EvilPositionX < matrix.GetLength(0) && this.EvilPositionY >= 0 && this.EvilPositionY < matrix.GetLength(1))
                {
                    matrix[this.EvilPositionX, this.EvilPositionY] = 0;
                }
                this.EvilPositionX--;
                this.EvilPositionY--;
            }
        }
    }
}
