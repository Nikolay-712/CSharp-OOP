using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class MoveEnemies
    {
        public static void EnemiesPosition(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'b')
                    {
                        if (row >= 0 && row < field.Length && col + 1 >= 0 && col + 1 < field[row].Length)
                        {
                            field[row][col] = '.';
                            field[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            field[row][col] = 'd';
                        }
                    }
                    else if (field[row][col] == 'd')
                    {
                        if (row >= 0 && row < field.Length && col - 1 >= 0 && col - 1 < field[row].Length)
                        {
                            field[row][col] = '.';
                            field[row][col - 1] = 'd';
                        }
                        else
                        {
                            field[row][col] = 'b';
                        }
                    }
                }
            }
        }

        public static void CheckForContactWithEnemy(char[][] field, int [] samPosition,int [] getEnemy)
        {
            if (samPosition[1] < getEnemy[1] && field[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
            {
                field[samPosition[0]][samPosition[1]] = 'X';
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
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


            else if (getEnemy[1] < samPosition[1] && field[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
            {
                field[samPosition[0]][samPosition[1]] = 'X';
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
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
