using System;

namespace P06_Sneaking
{
    public class Sneaking
    {
        static char[][] field;
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            field = CreateBattlefield.Field(size);

            SamPosition samPosition1 = new SamPosition();
            int[] samPosition = samPosition1.ShowSamPosition(field);

            var moves = Console.ReadLine().ToCharArray();


            for (int i = 0; i < moves.Length; i++)
            {
                MoveEnemies.EnemiesPosition(field);
                EnemiesPosition enemiesPosition = new EnemiesPosition();

                int[] getEnemy = enemiesPosition.ShowEnemyPosition(field,samPosition);
                MoveEnemies.CheckForContactWithEnemy(field,samPosition,getEnemy);


                MoveSam.ChangeSamPosition(field,samPosition,moves[i]);
                MoveSam.CheckForContactWithEnemy(field,samPosition,getEnemy);

               
            }
        }

    }
}
