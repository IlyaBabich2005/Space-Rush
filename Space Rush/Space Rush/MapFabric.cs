using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    internal class MapFabric
    {
        public Map MakeMap(MapDifficulty difficulty = MapDifficulty.NORMAL)
        {
            MapDirector mapMaker = new MapDirector(new MapBuilder());

            switch (difficulty)
            {
                case MapDifficulty.EASY: return mapMaker.BuildEasyMap();
                case MapDifficulty.NORMAL: return mapMaker.BuildNormalMap();
                case MapDifficulty.HARD: return mapMaker.BuildHardMap();
                default: throw new ArgumentException();
            }
        }
    }
}
