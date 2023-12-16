using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public class HpBar : Entity
    {
        private Alive owner;

        public HpBar(HpBar newEntity) : 
            base(newEntity)
        {
            this.owner = newEntity.owner;
        }

        public HpBar() { }

        public void SetOwner(Alive owner)
        {
            this.owner = owner;
        }

        public override void Move()
        {
            Vector2d newHpBarPosition;

            if (this.owner.GetEntityType() == CollidebleEntityType.PLAYER)
            {
                newHpBarPosition = this.owner.GetPosition() + new Vector2d(0, this.owner.GetHitBox().Height + 3);
            }
            else
            {
                newHpBarPosition = this.owner.GetPosition() - new Vector2d(0, 3);
            }


            this.SetPosition(newHpBarPosition);
        }

        public override void UpdateDespawnState()
        {
            this.IsReadyToDespawn(this.owner.IsReadyToDespawn());
        }
    }
}
