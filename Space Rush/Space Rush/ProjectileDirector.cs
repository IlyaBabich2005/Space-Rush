using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public class ProjectileDirector
    {
        private ProjectileBuilder builder;

        public ProjectileDirector(ProjectileBuilder builder)
        {
            this.builder = builder;
        }

        private void BuildShotGunProjectile()
        {
            this.builder.SetHitbox(new Vector2d(10, 10), "resourses//projectile_circle.png");
        }

        private void BuildMachinegunProjectile()
        {
            this.builder.SetHitbox(new Vector2d(6, 16), "resourses//projectile_long.png");
        }

        public Alive BuildEnemyShotgunProjectile()
        {
            this.BuildShotGunProjectile();
            this.builder.SetContactDamage(15);
            this.builder.SetMaxVelosity(new Vector2d(0, 6));
            this.builder.SetVelosity(new Vector2d(0, 6));
            this.builder.SetType(CollidebleEntityType.ENEMY_PROJECTILE);

            return this.builder.GetProduct();
        }

        public Alive BuildPlayerShotGunProjectile()
        {
            this.BuildShotGunProjectile();
            this.builder.SetContactDamage(30);
            this.builder.SetMaxVelosity(new Vector2d(0, -6));
            this.builder.SetVelosity(new Vector2d(0, -6));
            this.builder.SetType(CollidebleEntityType.PLAYERS_PROJECTILE);

            return this.builder.GetProduct();
        }

        public Alive BuildEnemyMachinegunProjectile()
        {
            this.BuildMachinegunProjectile();
            this.builder.SetContactDamage(20);
            this.builder.SetMaxVelosity(new Vector2d(0, 6));
            this.builder.SetVelosity(new Vector2d(0, 6));
            this.builder.SetType(CollidebleEntityType.ENEMY_PROJECTILE);

            return this.builder.GetProduct();
        }

        public Alive BuildPlayerMachinegunProjectile()
        {
            this.BuildMachinegunProjectile();
            this.builder.SetContactDamage(50);
            this.builder.SetMaxVelosity(new Vector2d(0, -6));
            this.builder.SetVelosity(new Vector2d(0, -6));
            this.builder.SetType(CollidebleEntityType.PLAYERS_PROJECTILE);

            return this.builder.GetProduct();
        }

        public Alive BuidSuperShotProjectile()
        {
            this.builder.SetHitbox(new Vector2d(25, 25), "resourses//super_bomb_projectile.png");
            this.builder.SetContactDamage(100);
            this.builder.SetMaxVelosity(new Vector2d(0, -6));
            this.builder.SetVelosity(new Vector2d(0, -6));
            this.builder.SetType(CollidebleEntityType.PLAYERS_PROJECTILE);

            return this.builder.GetProduct();
        }
    }
}
