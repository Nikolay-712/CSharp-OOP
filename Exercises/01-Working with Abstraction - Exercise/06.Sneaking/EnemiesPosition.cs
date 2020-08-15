using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class EnemiesPosition
    {
        private const int parameterSize = 2;
		private int[] enemyPosition;

		public EnemiesPosition()
		{
			this.EnemyPosition = new int[parameterSize];
		}

		public int[] EnemyPosition
		{
			get { return this.enemyPosition; }
			set { this.enemyPosition = value; }
		}

		public int[] ShowEnemyPosition(char[][] field,int[] samPosition)
		{
			for (int j = 0; j < field[samPosition[0]].Length; j++)
			{
				if (field[samPosition[0]][j] != '.' && field[samPosition[0]][j] != 'S')
				{
					EnemyPosition[0] = samPosition[0];
					enemyPosition[1] = j;
				}
			}

			return EnemyPosition;
		}
	}
}
