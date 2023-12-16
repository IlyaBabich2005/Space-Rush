using System.Windows.Forms;

namespace Space_Rush
{
    public class HpBarBuilder
    {
        private HpBar buildedHpBar;

        public HpBarBuilder()
        {
            this.reset();
        }

        public void reset()
        {
            this.buildedHpBar = new HpBar();

            this.SetMovingState(true);
            this.buildedHpBar.SetHitbox(new PictureBox());
        }

        public void SetSize(Vector2d size)
        {
            this.buildedHpBar.SetSize(size);
        }

        public void SetOwner(Alive owner)
        {
            this.buildedHpBar.SetOwner(owner);
        }

        public void SetPosition(Vector2d position)
        {
            this.buildedHpBar.SetPosition(position);
        }

        public void SetMovingState(bool isMoving)
        {
            this.buildedHpBar.IsMoving(isMoving);
        }

        public HpBar GetProduct()
        {
            HpBar hpBar = this.buildedHpBar;
            this.buildedHpBar = new HpBar();

            return hpBar;
        }
    }
}
