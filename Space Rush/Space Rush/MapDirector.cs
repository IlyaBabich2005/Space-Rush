using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public class MapDirector
    {
        private MapBuilder builder;

        public MapDirector(MapBuilder builder)
        {
            this.builder = builder;
        }

        public Map BuildEasyMap()
        {
            this.builder.reset();

            this.builder.SetDifficultu(MapDifficulty.EASY);
            this.builder.SetSpawnRate(5);

            return this.builder.GetProduct();
        }

        public Map BuildNormalMap()
        {
            this.builder.reset();

            this.builder.SetDifficultu(MapDifficulty.EASY);
            this.builder.SetSpawnRate((float)2.5);

            return this.builder.GetProduct();
        }

        public Map BuildHardMap()
        {
            this.builder.reset();

            this.builder.SetDifficultu(MapDifficulty.EASY);
            this.builder.SetSpawnRate(1);

            return this.builder.GetProduct();
        }
    }
}
