using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public class MapBuilder
    {
        Map buildedMap;

        public MapBuilder()
        {
            this.reset();
        }

        public void reset()
        {
            this.buildedMap = new Map();
        }

        public void SetDifficultu(MapDifficulty difficulty)
        {
            this.buildedMap.SetDifficulty(difficulty);
        }

        public void SetSpawnRate(float spawnRate)
        {
            this.buildedMap.SetSpawnRate(spawnRate);
        }

        public Map GetProduct()
        {
            Map product = this.buildedMap;

            this.reset();

            return product;
        }
    }
}
