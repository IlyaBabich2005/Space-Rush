using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public enum CollidebleEntityType
    {
        ENEMY = 0,
        PLAYER,
        ENEMY_PROJECTILE,
        PLAYERS_PROJECTILE, 
        BONUS_BOX
    }

    public class CollidebleEntity : Entity
    {
        private CollidebleEntityType type;

        public CollidebleEntity(Entity sourceEntity, CollidebleEntityType type) : base(sourceEntity)
        {
            this.type = type;
        }

        public CollidebleEntity(CollidebleEntity other) : base((Entity) other)
        {
            this.type = other.type;
        }

        public CollidebleEntity() { }

        public CollidebleEntityType GetEntityType()
        {
            return this.type;
        }

        public void SetEntityType(CollidebleEntityType type)
        {
            this.type = type;
        }

        public bool IsCollideWith(CollidebleEntity other)
        {
            return CollisionDetector.IsCollidebleEntitiesCollide(this, other);
        }

        public virtual void ReactToCollision(CollidebleEntity other) { }

        public void HandleCollision(CollidebleEntity other)
        {
            if(this.IsCollideWith(other))
            {
                this.ReactToCollision(other);
                other.ReactToCollision(this);
            }
        }
    }
}
