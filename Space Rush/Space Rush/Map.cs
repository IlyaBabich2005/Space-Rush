using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public enum MapDifficulty
    {
        EASY = 0,
        NORMAL,
        HARD
    }

    public enum MapWeather
    {

    }

    public enum MapRelief
    {

    }

    public class Map
    {
        private MapDifficulty difficulty;
        private MapWeather weather;
        private MapRelief relief;
        private float timeOfLastSpawn = 0;
        private float spawnRate;
        private EnemyFabric enemySpawner = new EnemyFabric();
        private bool isSpawn = true;
        private string name = "";

        public void SetDifficulty(MapDifficulty difficulty)
        {
            this.difficulty = difficulty;
        }

        public void SetSpawnRate(float spawnRate)
        {
            this.spawnRate = spawnRate;
        }

        public MapDifficulty GetDifficulty()
        {
            return this.difficulty;
        }

        public void IsSpawn(bool isSpawn)
        {
            this.isSpawn = isSpawn;
        }

        public void SpawnEnemy()
        {
            if(Game.GetInstanse().GetTimeSinceGameStart() - this.timeOfLastSpawn >= spawnRate && this.isSpawn)
            {
                this.timeOfLastSpawn = Game.GetInstanse().GetTimeSinceGameStart();

                Enemy newEnemy = this.enemySpawner.MakeEnemy();

                Game.GetInstanse().SpawnCollidebleEntity(newEnemy);
                Game.GetInstanse().SpawnEntity(newEnemy.GetHpBar());
            }
        }
    }
}
