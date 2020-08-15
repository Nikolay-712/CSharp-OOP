using System;
using System.Collections.Generic;
using System.Text;

namespace P03_JediGalaxy
{
    class CreateField
    {
        private int[,] matrix;


        public CreateField(int[] dimestions)
        {
            this.Matrix = new int[dimestions[0], dimestions[1]];
        }

        private int[,] Matrix
        {
            get { return this.matrix; }
            set { this.matrix = value; }
        }

       public int[,] GetMatrix()
        {
            return this.Matrix;
        }

        public void AddValueInMatrix(int[,] matrix, int[] dimestions)
        {
            int dimestionsX = dimestions[0];
            int dimestionsY = dimestions[1];


            int value = 0;
            for (int i = 0; i < dimestionsX; i++)
            {
                for (int j = 0; j < dimestionsY; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }

    }
}
