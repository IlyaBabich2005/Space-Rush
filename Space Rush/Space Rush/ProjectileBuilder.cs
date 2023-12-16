using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Rush
{
    public class ProjectileBuilder
    {
        private Alive buildedProjectile = null;
        
        public ProjectileBuilder()
        {
            this.reset();
        }

        public void reset()
        {
            this.buildedProjectile = new Alive();
            this.buildedProjectile.CanItDie(false);
            this.SetId();
            this.SetDespawnState(false);
            this.SetMovingState(true);
        }

        public void SetHitbox(Vector2d size, string pathToTexture)
        {
            this.buildedProjectile.SetHitbox(new PictureBox());

            this.buildedProjectile.SetSize(size);
            this.buildedProjectile.SetTexture(pathToTexture);
        }

        public void SetVelosity(Vector2d velosity)
        {
            this.buildedProjectile.SetVelosity(velosity);
        }
        
        public void SetId()
        {
            this.buildedProjectile.SetId(Game.GetInstanse().GetNewID());
        }

        public void SetMovingState(bool isMoving)
        {
            this.buildedProjectile.IsMoving(isMoving);
        }

        public void SetMaxVelosity(Vector2d maxVelosity)
        {
            this.buildedProjectile.SetMaxVelosity(maxVelosity);
        }

        public void SetDespawnState(bool isReadyToDespawn)
        {
            this.buildedProjectile.IsReadyToDespawn(isReadyToDespawn);
        }

        public void SetType(CollidebleEntityType type)
        {
            this.buildedProjectile.SetEntityType(type);
        }

        public void SetContactDamage(float contactDamage)
        {
            this.buildedProjectile.SetContactDamage(contactDamage);
        }

        public Alive GetProduct()
        {
            Alive product = this.buildedProjectile;

            this.reset();

            return product;
        }
    }
}