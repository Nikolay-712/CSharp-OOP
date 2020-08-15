using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class CreateBattlefield
    {
        private static char[][] room;

        public static char[][] Field(int size)
        {
            room = new char[size][];

            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }

            return room;
        }
    }
}
