using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public class BonusDirector
    {
        private BonusBuilder builder;

        public BonusDirector(BonusBuilder builder)
        {
            this.builder = builder;
        }

        public  BonusBox BuildRepairBox()
        {
            this.builder.reset();

            this.builder.SetTexture("resourses//repair_bonus.png");
            this.builder.SetSkill(new Repair(25));

            return this.builder.GetProduct();
        }

        public BonusBox BuildLevelUpBox()
        {
            this.builder.reset();

            this.builder.SetTexture("resourses//level_up_bonus.png");
            this.builder.SetSkill(new LevelUp());

            return this.builder.GetProduct();
        }

        public BonusBox BuildSuperShotBox()
        {
            this.builder.reset();

            this.builder.SetTexture("resourses//super_bomb_bonus.png");
            this.builder.SetSkill(new SuperShot());

            return this.builder.GetProduct();
        }
    }
}
