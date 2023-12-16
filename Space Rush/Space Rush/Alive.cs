using System.Drawing;

namespace Space_Rush
{
    public class Alive : CollidebleEntity
    {
        private float HP = 0;
        private float maxHp = 0;
        private float contactDamage;
        private bool canItDie;
        HpBar HpBar;

        public Alive(CollidebleEntity source, float HP, float contactDamage, bool canItDie, HpBar HpBar, float maxHp)
        : base(source)
        {
            this.canItDie = canItDie;
            this.HP = HP;
            this.contactDamage = contactDamage;
            this.HpBar = HpBar;
            this.maxHp = maxHp;

            if (canItDie)
            {
                this.UpdateHpBarColor();
            }
        }

        public Alive(Alive source) : base((CollidebleEntity)source)
        {
            this.canItDie = source.canItDie;
            this.HP = source.HP;
            this.contactDamage = source.contactDamage;
            this.HpBar = source.HpBar;
            this.maxHp = source.maxHp;

            if(this.canItDie)
            {
                this.UpdateHpBarColor();
                this.UpdateHpBarSize();
            }
        }

        public Alive() { }

        public Entity GetHpBar()
        {
            return this.HpBar;
        }

        public void SetContactDamage(float contactDamage)
        {
            this.contactDamage = contactDamage;
        }

        public void SetHP(float HP)
        {
            this.HP = HP;
        }

        public void SetMaxHp(float maxHP)
        {
            this.maxHp = maxHP;
        }

        public void SetHpBar(HpBar HpBar)
        {
            this.HpBar = HpBar;
            this.HpBar.Move();
        }

        public float GetContactDamage()
        {
            return this.contactDamage;
        }

        public float GetHP()
        {
            return this.HP;
        }

        public bool CanItDie()
        {
            return this.canItDie;
        }


        public void CanItDie(bool canItDie)
        {
            this.canItDie = canItDie;
        }

        public void TakeDamage(float damage)
        {
            if (this.canItDie)
            {
                this.HP -= damage;

                if (HP >= 0)
                {
                    this.UpdateHpBar();
                }
            }
        }

        public void Heal(float hp)
        {
            if (this.canItDie)
            {
                this.HP += hp;

                if (this.HP > this.maxHp)
                {
                    this.HP = this.maxHp;
                }

                this.UpdateHpBar();
            }

        }

        public void UpdateHpBarColor()
        {
            float greenProcent = this.HP / this.maxHp;
            float redProcent = 1 - greenProcent;

            this.HpBar.GetHitBox().BackColor = Color.FromArgb((int)(255 * redProcent), (int)(255 * greenProcent), 0);
        }

        public void UpdateHpBarSize()
        {
            float lengthProcent = this.HP / this.maxHp;

            this.HpBar.GetHitBox().Width = (int)(this.GetHitBox().Width * lengthProcent);
        }

        public override void UpdateDespawnState()
        {
            base.UpdateDespawnState();

            if (this.canItDie == true && this.HP <= 0)
            {
                this.IsReadyToDespawn(true);
            }
        }

        public void UpdateHpBar()
        {
            this.UpdateHpBarColor();
            this.UpdateHpBarSize();
        }

        public override void Move()
        {
            if (this.IsMoving())
            {
                Vector2d newPosition = new Vector2d((int)this.GetVelosity().x + this.GetHitBox().Location.X, (int)this.GetVelosity().y + this.GetHitBox().Location.Y);

                this.SetPosition(newPosition);
            }
        }
    }
}
