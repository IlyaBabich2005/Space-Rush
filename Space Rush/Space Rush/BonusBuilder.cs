using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Rush
{
    public class BonusBuilder
    {
        private BonusBox buildedBox;

        public BonusBuilder()
        {
            this.reset();
        }

        public void reset()
        {
            this.buildedBox = new BonusBox();
            this.SetHitbox(new Vector2d(16, 17));
            this.SetMaxVelosity(new Vector2d(0, 1));
            this.SetVelosity(new Vector2d(0, 1));
            this.SetNewID();
            this.SetEntityType(CollidebleEntityType.BONUS_BOX);
            this.SetMovingState(true);
        }

        public void SetHitbox(Vector2d size)
        {
            this.buildedBox.SetHitbox(new PictureBox());

            this.buildedBox.SetSize(size);
        }

        public void SetTexture(string pathToTexture)
        {
            this.buildedBox.SetTexture(pathToTexture);
        }

        public void SetVelosity(Vector2d velosity)
        {
            this.buildedBox.SetVelosity(velosity);
        }

        public void SetNewID()
        {
            this.buildedBox.SetId(Game.GetInstanse().GetNewID());
        }

        public void SetMaxVelosity(Vector2d maxVelosity)
        {
            this.buildedBox.SetMaxVelosity(maxVelosity);
        }

        public void SetEntityType(CollidebleEntityType type)
        {
            this.buildedBox.SetEntityType(type);
        }

        public void SetMovingState(bool movingState)
        {
            this.buildedBox.IsMoving(movingState);
        }

        public void SetSkill(Skill skill)
        {
            this.buildedBox.SetSkill(skill);
        }

        public BonusBox GetProduct()
        {
            BonusBox bonusBox = this.buildedBox;

            this.reset();

            return bonusBox;
        }

    }
}
