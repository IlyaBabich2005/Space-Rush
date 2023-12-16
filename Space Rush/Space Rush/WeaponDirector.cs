using System;
using System.Collections.Generic;

namespace Space_Rush
{
    public class WeaponDirector
    {
        private WeaponBuilder builder;
        ProjectileDirector projectileDirector;

        public WeaponDirector(WeaponBuilder builder)
        {
            this.builder = builder;
            this.projectileDirector = new ProjectileDirector(new ProjectileBuilder());
        }

        public Weapon BuildPlayersShotgun()
        {
            this.builder.reset();

            this.builder.SetFirerate(1);
            this.builder.SetProjectile(this.projectileDirector.BuildPlayerShotGunProjectile());
            this.builder.SetMaxLevel(5);
            this.builder.SetWeaponType(WeaponTypes.SHOTGUN);
            this.builder.SetMuzzles(new List<Vector2d>() { new Vector2d(16, 0) });
            this.builder.SetProjectilesFromMuzzle(3);
            this.builder.SetShootAngle((float)Math.PI / 3);

            return this.builder.GetProduct();
        }

        public Weapon BuildEnemiesShotgun()
        {
            this.builder.reset();

            this.builder.SetFirerate((float)1);
            this.builder.SetProjectile(this.projectileDirector.BuildEnemyShotgunProjectile());
            this.builder.SetWeaponType(WeaponTypes.SHOTGUN);
            this.builder.SetMuzzles(new List<Vector2d>() { new Vector2d(16, 0) });
            this.builder.SetProjectilesFromMuzzle(4);
            this.builder.SetShootAngle((float)Math.PI / 4);

            return this.builder.GetProduct();
        }

        public Weapon BuildPlayersMachinegun()
        {
            this.builder.reset();

            this.builder.SetFirerate((float)0.7);
            this.builder.SetProjectile(this.projectileDirector.BuildPlayerMachinegunProjectile());
            this.builder.SetWeaponType(WeaponTypes.MACHINEGUN);
            this.builder.SetMuzzles(new List<Vector2d>() { new Vector2d(10, 0), new Vector2d(20,0) });
            this.builder.SetLevelUpCofficient((float)0.05);

            return this.builder.GetProduct();
        }

        public Weapon BuildEEnemiesMachinegun()
        {
            this.builder.reset();

            this.builder.SetFirerate((float)1.3);
            this.builder.SetProjectile(this.projectileDirector.BuildEnemyMachinegunProjectile());
            this.builder.SetWeaponType(WeaponTypes.MACHINEGUN);
            this.builder.SetMuzzles(new List<Vector2d>() { new Vector2d(10, 0), new Vector2d(20, 0) });

            return this.builder.GetProduct();
        }
    }
}
