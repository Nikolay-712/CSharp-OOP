using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class SamPosition
    {
        private const int parameterSize = 2;
        private int[] samPositionInField;

        public SamPosition()
        {
            this.SamPositionInField = new int[parameterSize];
        }

        public int[] SamPositionInField
        {
            get { return this.samPositionInField; }
            set { this.samPositionInField = value; }
        }

        public int[] ShowSamPosition(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'S')
                    {
                        SamPositionInField[0] = row;
                        SamPositionInField[1] = col;
                    }
                }
            }

            return SamPositionInField;
        }

    }
}
