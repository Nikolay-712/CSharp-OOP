using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class MoveSam
    {
        public static void ChangeSamPosition(char[][] field, int[] samPosition, char move)
        {
            field[samPosition[0]][samPosition[1]] = '.';
            switch (move)
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
            field[samPosition[0]][samPosition[1]] = 'S';
        }

        public static void CheckForContactWithEnemy(char[][] field, int[] samPosition, int[] getEnemy)
        {
            for (int j = 0; j < field[samPosition[0]].Length; j++)
            {
                if (field[samPosition[0]][j] != '.' && field[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }
            if (field[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
            {
                field[getEnemy[0]][getEnemy[1]] = 'X';
                Console.WriteLine("Nikoladze killed!");
                for (int row = 0; row < field.Length; row++)
                {
                    for (int col = 0; col < field[row].Length; col++)
                    {
                        Console.Write(field[row][col]);
                    }
                    Console.WriteLine();
                }
                Environment.Exit(0);
            }
        }

    }
}
