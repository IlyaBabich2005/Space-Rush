using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public class Ship : Alive
    {
        private Weapon weapon;
        private bool isShoot;

        public Ship(Alive source, Weapon weapon) : 
            base(source)
        {
            this.weapon = weapon;
            this.isShoot = false;
        }

        public Ship(Ship newShip)
            : base((Alive)newShip)
        {
            this.weapon = newShip.weapon;
            return;
        }

        public Ship() { }

        public void SetWeapon(Weapon weapon)
        {
            this.weapon = weapon;
        }

        public Weapon GetWeapon()
        {
            return this.weapon;
        }

        public void IsShoot(bool isShoot)
        {
            this.isShoot = isShoot;
        }

        public override void UpdateState()
        {
            base.UpdateState();
            this.Shoot();
        }

        public virtual void Shoot() 
        {
            if(isShoot) 
            {
                weapon.Fire(this.GetPosition());
            }
        }
    }
}
