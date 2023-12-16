using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public class BonusFabric
    {
        public BonusBox MakeBonus()
        {
            BonusDirector bonusMaker = new BonusDirector(new BonusBuilder());
            Random random = new Random();

            int spawnedEntity = random.Next(0, 3);

            switch (spawnedEntity)
            {
                case 0: return bonusMaker.BuildLevelUpBox();
                case 1: return bonusMaker.BuildRepairBox();
                case 2: return bonusMaker.BuildSuperShotBox();
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
