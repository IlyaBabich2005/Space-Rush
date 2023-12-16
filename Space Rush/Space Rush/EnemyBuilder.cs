using System;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Rush
{

    public class EnemyBuilder
    {
        private Enemy buildedEnemy = null;

        public EnemyBuilder()
        {
            this.reset();
        }

        public void reset()
        {
            this.buildedEnemy = new Enemy();
            this.buildedEnemy.CanItDie(true);
            this.SetId();
            this.SetDespawnState(false);
            this.SetType(CollidebleEntityType.ENEMY);
            this.SetMovingState(true);
            this.SetShootState(true);
        }

        public void SetHitbox(Vector2d size, string pathToTexture)
        {
            this.buildedEnemy.SetHitbox(new PictureBox());

            this.buildedEnemy.SetSize(size);
            this.buildedEnemy.SetTexture(pathToTexture);
            this.buildedEnemy.SetPosition(new Vector2d(0, -50));
        }

        public void SetId()
        {
            this.buildedEnemy.SetId(Game.GetInstanse().GetNewID());
        }

        public void SetMovingState(bool isMoving)
        {
            this.buildedEnemy.IsMoving(isMoving);
        }

        public void SetMaxVelosity(Vector2d maxVelosity)
        {
            this.buildedEnemy.SetMaxVelosity(maxVelosity);
        }

        public void SetDespawnState(bool isReadyToDespawn)
        {
            this.buildedEnemy.IsReadyToDespawn(isReadyToDespawn);
        }

        public void SetType(CollidebleEntityType type)
        {
            this.buildedEnemy.SetEntityType(type);
        }

        public void SetContactDamage(float contactDamage)
        {
            this.buildedEnemy.SetContactDamage(contactDamage);
        }

        public void SetHP(float HP)
        {
            this.buildedEnemy.SetHP(HP);
        }

        public void SetMaxHP(float maxHP)
        {
            this.buildedEnemy.SetMaxHp(maxHP);
        }

        public void SetShootState(bool isShoot)
        {
            this.buildedEnemy.IsShoot(isShoot);
        }

        public void SetWeapon(Weapon weapon)
        {
            this.buildedEnemy.SetWeapon(weapon);
        }

        public void SetHpBar()
        {
            HpBarDirector hpBarMaker = new HpBarDirector(new HpBarBuilder());

            this.buildedEnemy.SetHpBar(hpBarMaker.BuildHpBar(this.buildedEnemy));
            this.buildedEnemy.UpdateHpBar();
        }

        public void SetMoveFunction(MoveFunction function)
        {
            this.buildedEnemy.SetMoveFunction(function);
        }

        public void SetVelosity(Vector2d velosity)
        {
            this.buildedEnemy.SetVelosity(velosity);
        }

        public void SetBonusBox(BonusBox box)
        {
            this.buildedEnemy.SetDroppedBonus(box);
        }

        public void SetPointsForKill(int points)
        {
            this.buildedEnemy.SetPointsForKill(points);
        }

        public Enemy GetProduct()
        {
            Enemy product = this.buildedEnemy;

            this.reset();

            return product;
        }
    }
}
