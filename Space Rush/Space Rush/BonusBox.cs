using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public class BonusBox : CollidebleEntity
    {
        private Skill skill;
        private PlayableCharacter owner;

        public BonusBox(CollidebleEntity source, Skill skill) :
            base(source)
        {
            this.skill = skill;
            this.IsMoving(true);
        }

        public BonusBox() { }

        public BonusBox(BonusBox source): 
            base((CollidebleEntity)source) 
        {
            this.skill = source.skill;
            this.IsMoving(true);
        }

        public Skill GetSkill()
        {
            return this.skill;
        }

        public void SetSkill(Skill skill)
        {
            this.skill = skill;
        }

        public override void ReactToCollision(CollidebleEntity other)
        {
            if(other.GetEntityType() == CollidebleEntityType.PLAYER)
            {
                PlayableCharacter player = (PlayableCharacter)other;

                if(player.GetSkills().Count <= 3)
                {
                    this.owner = player;
                }
            }
        }

        public override void Move()
        {
            if (this.owner != null)
            {
                this.FollowByOwner();
            }
            else
            {
                base.Move();
            }
        }

        private void FollowByOwner()
        {
            if(this.owner.IsMoving())
            {
                float newXPosition = this.owner.GetPosition().x + this.owner.GetSize().x + 3;
                float newYPosition = this.owner.GetPosition().y + this.owner.GetSkills().IndexOf(this) * this.GetSize().y + 2;

                Vector2d newPosition = new Vector2d(newXPosition, newYPosition);

                this.SetPosition(newPosition);
            }
        }

        public void PlaySkill()
        {
            this.skill.Play(this.owner);
            Game.GetInstanse().DespawnEntity(this);
        }
    }
}
