using System.Collections.Generic;
using System.Windows.Forms;

namespace Space_Rush
{
    public class PlayableCharacter : Ship
    {
        enum PlayerStatements
        {
            ROLL_RIGHT = 1,
            ROLL_LEFT,
            DIRECTLY
        }

        private string pathToLeftRollSprite;
        private string pathToRightRollSprite;
        private string pathToDirectlyPositionSprite;
        private PlayerControls controls;
        private List<BonusBox> skills = new List<BonusBox>();
        private string name = "";

        public PlayableCharacter(Ship newShip, string pathToRightRollSprite, string pathToLeftRollSprite,
            string pathToDirectlyPositionSprite, PlayerControls controls) :
            base(newShip)
        {
            this.pathToDirectlyPositionSprite = pathToDirectlyPositionSprite;
            this.pathToLeftRollSprite = pathToLeftRollSprite;
            this.pathToRightRollSprite = pathToRightRollSprite;

            this.controls = controls;

            this.skills = new List<BonusBox>();
        }

        public PlayableCharacter() { }

        public void SetControls(PlayerControls controls)
        {
            this.controls = controls;
        }

        public void SetSprites(string pathToDirectlyPositionSprite, string pathToRightRollSprite, string pathToLeftRollSprite)
        {
            this.pathToDirectlyPositionSprite = pathToDirectlyPositionSprite;
            this.pathToLeftRollSprite = pathToLeftRollSprite;
            this.pathToRightRollSprite = pathToRightRollSprite;
        }

        public List<BonusBox> GetSkills()
        {
            return this.skills;
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            this.controls.HandleKeysDown(this, e);
            this.SetVelosity(this.controls.GetMovementVector());

            this.UpdateMovingState();
            this.UpdateSprite();
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            this.controls.HandleKeysUp(this, e);

            this.UpdateMovingState();
            this.UpdateSprite();
        }

        private void UpdateSprite()
        {
            if (!this.controls.IsMoveLeft() && !this.controls.IsMoveRight())
            {
                this.StraightenUp();
            }
            else if (this.controls.IsMoveLeft())
            {
                this.RollLeft();
            }
            else
            {
                this.RollRight();
            }
        }

        private void UpdateMovingState()
        {
            if (this.controls.IsMove())
            {
                this.IsMoving(true);
            }
            else
            {
                this.IsMoving(false);
            }
        }

        private void RollLeft()
        {
            this.SetTexture(this.pathToLeftRollSprite);
        }

        private void RollRight()
        {
            this.SetTexture(this.pathToRightRollSprite);
        }

        private void StraightenUp()
        {
            this.SetTexture(this.pathToDirectlyPositionSprite);
        }

        public override void ReactToCollision(CollidebleEntity other)
        {
            if (other.GetEntityType() == CollidebleEntityType.BONUS_BOX
                && this.skills.Count < 3 && !this.skills.Contains((BonusBox)other))
            {
                this.skills.Add((BonusBox)other);
            }

            if (other.GetEntityType() == CollidebleEntityType.ENEMY || other.GetEntityType() == CollidebleEntityType.ENEMY_PROJECTILE)
            {
                Alive otherAlive = (Alive)other;

                this.TakeDamage(otherAlive.GetContactDamage());

                if(other.GetEntityType() == CollidebleEntityType.ENEMY_PROJECTILE)
                {
                    Game.GetInstanse().DespawnEntity(other);
                }
            }
        }

        public void CollectBonusBox(BonusBox newBox)
        {
            this.skills.Add(newBox);
        }

        public void UseSkill()
        {
            if(this.skills.Count > 0)
            {
                this.skills[this.skills.Count - 1].PlaySkill();
                this.skills.RemoveAt(this.skills.Count - 1);
            }
        }
    }
}