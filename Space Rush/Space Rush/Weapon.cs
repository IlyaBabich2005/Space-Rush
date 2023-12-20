using System;
using System.Collections.Generic;

namespace Space_Rush
{
    public enum WeaponTypes
    {
        SHOTGUN = 1,
        MACHINEGUN
    }

    public class Weapon
    {
        private float firerate;
        private float timeOfLastShot;
        private Alive projectile;
        private int level = 1;
        private int maxLevel = 5;
        private WeaponTypes type;
        private float levelUpCoficient;
        private List<Vector2d> muzzles;
        private int projectilesFromMuzzle;
        private float shootAngle;
        private string name = "";

        public Weapon() { }

        public void SetFirerate(float firerate)
        {
            this.firerate = firerate;
        }

        public void SetProjectile(Alive projectile)
        {
            this.projectile = projectile;
        }

        public void SetMaxLevel(int maxLevel)
        {
            this.maxLevel = maxLevel;
        }

        public void SetWeaponType(WeaponTypes type)
        {
            this.type = type;
        }

        public void SetLevelUpCofficient(float levelUoCofficient)
        {
            this.levelUpCoficient = levelUoCofficient;
        }

        public void SetMuzzles(List<Vector2d> muzzles)
        {
            this.muzzles = muzzles;
        }

        public void SetProjectilesFromMuzzle(int projectilesFromMuzzle)
        {
            this.projectilesFromMuzzle = projectilesFromMuzzle;
        }

        public void SetShootAngle(float shootAngle)
        {
            this.shootAngle = shootAngle;
        }

        public void Fire(Vector2d shooterPosition)
        {
            if (Game.GetInstanse().GetTimeSinceGameStart() - this.timeOfLastShot >= firerate)
            {
                for (int i = 0; i < this.muzzles.Count; i++)
                {
                    if (this.type == WeaponTypes.MACHINEGUN)
                    {
                        this.MachinegunFire(shooterPosition, muzzles[i]);
                    }
                    else if (this.type == WeaponTypes.SHOTGUN)
                    {
                        this.ShotgunFire(shooterPosition, muzzles[i]);
                    }
                }
                this.timeOfLastShot = Game.GetInstanse().GetTimeSinceGameStart();
            }
        }

        private void MachinegunFire(Vector2d shooterPosition, Vector2d curentMuzzle)
        {
            Alive newProjectile = new Alive(this.projectile);
            this.ShootProjectile(shooterPosition, curentMuzzle, newProjectile);
        }

        private void ShotgunFire(Vector2d shooterPosition, Vector2d curentMuzzle)
        {
            float projectileStartAngle = this.projectile.GetVelosity().GetAngle() - this.shootAngle / 2;
            float projectileStep = this.shootAngle / (projectilesFromMuzzle - 1);

            for (int j = 0; j < this.projectilesFromMuzzle; j++)
            {
                 this.ShootShotGunProjectile(shooterPosition, curentMuzzle, j, projectileStartAngle, projectileStep);
            }
        }  

        private void FormNewProjectile(Vector2d shooterPosition, Vector2d curentMuzzle, Alive newProjectile)
        {
            newProjectile.SetPosition(new Vector2d(shooterPosition.x + curentMuzzle.x, shooterPosition.y + curentMuzzle.y));
            newProjectile.IsMoving(true);
            newProjectile.SetId(Game.GetInstanse().GetNewID());
        }

        private void ShootProjectile(Vector2d shooterPosition, Vector2d curentMuzzle, Alive newProjectile)
        {
            this.FormNewProjectile(shooterPosition, curentMuzzle, newProjectile);
            Game.GetInstanse().SpawnCollidebleEntity(newProjectile);
        }

        private void ShootShotGunProjectile(Vector2d shooterPosition, Vector2d curentMuzzle,
            int projectileNum, float projectileStartAngle, float projectileStep)
        {
            Alive newProjectile = new Alive(this.projectile);
            newProjectile.GetVelosity().SetAngle(projectileStep * projectileNum + projectileStartAngle);
            this.ShootProjectile(shooterPosition, curentMuzzle, newProjectile);
        }

        public void LevelUp()
        {
            if(this.level < this.maxLevel)
            {
                if (this.type == WeaponTypes.MACHINEGUN)
                {
                    this.firerate -= this.levelUpCoficient;
                }
                else if (this.type == WeaponTypes.SHOTGUN)
                {
                    this.projectilesFromMuzzle++;
                }

                this.level++;
            }
        }
    }
}
