using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public delegate float MoveFunction(float y);

    public class Enemy : Ship
    {
        private MoveFunction getX;
        private bool wasIsOutOfBounds = false;
        private BonusBox dropedBonus;
        private int pointsForKill = 0;

        public Enemy(Ship source, MoveFunction moveFunction)
            : base(source)
        {
            this.getX = moveFunction;
        }

        public Enemy()
        {
            
        }

        public void SetPointsForKill(int points)
        {
            this.pointsForKill = points;
        }

        public void SetMoveFunction(MoveFunction func)
        {
            this.getX = func;
        }

        public void SetDroppedBonus(BonusBox bonusBox)
        {
            this.dropedBonus = bonusBox;
        }

        public int GetPointsForKill()
        {
            return this.pointsForKill;
        }

        public override void UpdateDespawnState()
        {
            if (this.wasIsOutOfBounds && !CollisionDetector.IsEntityCollideWitGameWindow(this))
            {
                this.IsReadyToDespawn(true);
            }
            else
            {
                this.GetHpBar().IsReadyToDespawn(false);
            }

            if (CollisionDetector.IsEntityCollideWitGameWindow(this))
            {
                this.wasIsOutOfBounds = true;
            }

            if (this.CanItDie() == true && this.GetHP() <= 0)
            {
                this.IsReadyToDespawn(true);
                this.dropedBonus.SetPosition(this.GetPosition());
                Game.GetInstanse().SpawnCollidebleEntity(this.dropedBonus);
            }
        }

        public override void ReactToCollision(CollidebleEntity other)
        {
            if(other.GetEntityType() == CollidebleEntityType.PLAYER || other.GetEntityType() == CollidebleEntityType.PLAYERS_PROJECTILE)
            {
                Alive otherAlive = (Alive)other;

                this.TakeDamage(otherAlive.GetContactDamage());

                if(this.GetHP() <= 0)
                {
                    Game.GetInstanse().TakePoints(this.pointsForKill);
                }

                if (other.GetEntityType() == CollidebleEntityType.PLAYERS_PROJECTILE)
                {
                    Game.GetInstanse().DespawnEntity(other);
                }
            }
        }

        public override void Move()
        {
            float newYPosition = this.GetPosition().y + this.GetVelosity().y;
            float newXPosition = this.getX(this.GetPosition().y);

            Vector2d newPosition = new Vector2d(newXPosition, newYPosition);

            this.SetPosition(newPosition);
        }
    }
}