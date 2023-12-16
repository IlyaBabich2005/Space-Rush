using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public class WeaponBuilder
    {
        private Weapon buildedWeapon;

        public WeaponBuilder()
        {
            this.reset();
        }

        public void reset()
        {
            this.buildedWeapon = new Weapon();
        }

        public void SetFirerate(float firerate)
        {
            this.buildedWeapon.SetFirerate(firerate);
        }

        public void SetProjectile(Alive projectile)
        {
            this.buildedWeapon.SetProjectile(projectile);
        }

        public void SetMaxLevel(int maxLevel)
        {
            this.buildedWeapon.SetMaxLevel(maxLevel);
        }

        public void SetWeaponType(WeaponTypes type)
        {
            this.buildedWeapon.SetWeaponType(type);
        }

        public void SetLevelUpCofficient(float levelUoCofficient)
        {
            this.buildedWeapon.SetLevelUpCofficient(levelUoCofficient);
        }

        public void SetMuzzles(List<Vector2d> muzzles)
        {
            this.buildedWeapon.SetMuzzles(muzzles);
        }

        public void SetProjectilesFromMuzzle(int projectilesFromMuzzle)
        {
            this.buildedWeapon.SetProjectilesFromMuzzle(projectilesFromMuzzle);
        }

        public void SetShootAngle(float shootAngle)
        {
            this.buildedWeapon.SetShootAngle(shootAngle);
        }

        public Weapon GetProduct()
        {
            Weapon product = this.buildedWeapon;

            this.reset();

            return product;
        }
    }
}