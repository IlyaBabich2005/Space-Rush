using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public class EnemyFabric
    {
        public Enemy MakeEnemy()
        {
            EnemyDirector enemyMaker = new EnemyDirector(new EnemyBuilder());
            Random random = new Random();

            int spawnedEntity = random.Next(0, 4);
            int cofficient = random.Next(1, 7);

            switch(spawnedEntity)
            {
                case 0: return enemyMaker.BuildDiagonalEnemy(cofficient);
                case 1: return enemyMaker.BuildLinearEnemy(cofficient);
                case 2: return enemyMaker.BuildSinEnemy(cofficient);
                case 3: return enemyMaker.BuildParbolEnemy(cofficient); 
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
