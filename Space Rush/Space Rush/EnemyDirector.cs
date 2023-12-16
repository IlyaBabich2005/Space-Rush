using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public class EnemyDirector
    {
        private EnemyBuilder enemyBuilder;

        public EnemyDirector(EnemyBuilder builder)
        {
            this.enemyBuilder = builder;
        }

        private void BuildHpBar()
        {
            this.enemyBuilder.SetHpBar();
        }

        public Enemy BuildSinEnemy(float cofficient)
        {
            WeaponDirector weaponMaker = new WeaponDirector(new WeaponBuilder());

            float sinusAmplitude = Game.GetInstanse().Width / (float)2.5;
            float sinusStep = Game.GetInstanse().Height / 10 * cofficient;

            MoveFunction getX = CustomSinus;

            float CustomSinus(float y) => (float)(sinusAmplitude * Math.Sin((double)y / sinusStep) + sinusAmplitude);

            this.enemyBuilder.SetHitbox(new Vector2d(26, 30), "resourses//enemy.png");
            this.enemyBuilder.SetMaxVelosity(new Vector2d(0, 2));
            this.enemyBuilder.SetVelosity(new Vector2d(0, 2));
            this.enemyBuilder.SetHP(50);
            this.enemyBuilder.SetMaxHP(50);
            this.enemyBuilder.SetMoveFunction(getX);
            this.enemyBuilder.SetPointsForKill(20);
            this.BuildHpBar();
            this.enemyBuilder.SetWeapon(weaponMaker.BuildEnemiesShotgun());
            this.SetRandomSkill();

            return this.enemyBuilder.GetProduct();
        }

        public Enemy BuildDiagonalEnemy(float cofficient)
        {
            WeaponDirector weaponMaker = new WeaponDirector(new WeaponBuilder());

            MoveFunction getX = function;

            float function(float y) => y - cofficient * 50;

            this.enemyBuilder.SetHitbox(new Vector2d(26, 30), "resourses//enemy2.png");
            this.enemyBuilder.SetMaxVelosity(new Vector2d(0, 2));
            this.enemyBuilder.SetVelosity(new Vector2d(0, 2));
            this.enemyBuilder.SetHP(50);
            this.enemyBuilder.SetMaxHP(50);
            this.enemyBuilder.SetMoveFunction(getX);
            this.enemyBuilder.SetWeapon(weaponMaker.BuildEEnemiesMachinegun());
            this.enemyBuilder.SetPointsForKill(40);
            this.BuildHpBar();
            this.SetRandomSkill();

            return this.enemyBuilder.GetProduct();
        }

        public Enemy BuildParbolEnemy(float cofficient)
        {
            WeaponDirector weaponMaker = new WeaponDirector(new WeaponBuilder());

            float startPosY = 20 * Math.Abs(cofficient);
            float lenght = 2 * cofficient;
            float startPosX = 100 * Math.Abs(cofficient);

            MoveFunction getX = function;

            float function(float y) => startPosX - (float)Math.Pow(((y - startPosY) / lenght), 2);

            this.enemyBuilder.SetHitbox(new Vector2d(26, 30), "resourses//enemy3.png");
            this.enemyBuilder.SetMaxVelosity(new Vector2d(0, 2));
            this.enemyBuilder.SetVelosity(new Vector2d(0, 2));
            this.enemyBuilder.SetHP(25);
            this.enemyBuilder.SetMaxHP(25);
            this.enemyBuilder.SetMoveFunction(getX);
            this.enemyBuilder.SetPointsForKill(50);
            this.BuildHpBar();
            this.enemyBuilder.SetWeapon(weaponMaker.BuildEnemiesShotgun());
            this.SetRandomSkill();

            return this.enemyBuilder.GetProduct();
        }

        public Enemy BuildLinearEnemy(float cofficient)
        {
            WeaponDirector weaponMaker = new WeaponDirector(new WeaponBuilder());

            MoveFunction getX = function;

            float function(float y) => cofficient * 100;

            this.enemyBuilder.SetHitbox(new Vector2d(30, 30), "resourses//enemy4.png");
            this.enemyBuilder.SetMaxVelosity(new Vector2d(0, 2));
            this.enemyBuilder.SetVelosity(new Vector2d(0, 2));
            this.enemyBuilder.SetHP(50);
            this.enemyBuilder.SetMaxHP(50);
            this.enemyBuilder.SetMoveFunction(getX);
            this.enemyBuilder.SetPointsForKill(10);
            this.BuildHpBar();
            this.enemyBuilder.SetWeapon(weaponMaker.BuildEEnemiesMachinegun());
            this.SetRandomSkill();

            return this.enemyBuilder.GetProduct();
        }

        public void SetRandomSkill()
        {
            BonusFabric bonusMaker = new BonusFabric();

            this.enemyBuilder.SetBonusBox(bonusMaker.MakeBonus());
        }
    }
}
