using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Rush
{
    public class Entity
    {
        private PictureBox hitbox = null;
        private Vector2d velosity = new Vector2d(0,0);
        private int id = 0;
        private bool isMoving = false;
        private Vector2d maxVelosity = new Vector2d(0, 0);
        private bool isReadyToDespawn;

        public Entity(Entity newEntity)
        {
            this.hitbox = new PictureBox();
            this.hitbox.Size = newEntity.hitbox.Size;
            this.hitbox.Location = newEntity.hitbox.Location;
            this.hitbox.Image = newEntity.hitbox.Image;
            this.maxVelosity = newEntity.maxVelosity;
            this.velosity = new Vector2d(newEntity.velosity.x, newEntity.velosity.y);
            this.id = newEntity.id;

#if DEBUG
            this.hitbox.BorderStyle = BorderStyle.FixedSingle;
#endif
        }

        public Entity() { }

        public PictureBox GetHitBox()
        {
            return this.hitbox;
        }
         
        public Vector2d GetVelosity()
        {
            return this.velosity;
        }

        public Vector2d GetPosition()
        {
            return new Vector2d(this.hitbox.Location.X, this.hitbox.Location.Y);
        }

        public Vector2d GetSize()
        {
            return new Vector2d(this.hitbox.Width, this.hitbox.Height);
        }

        public bool IsReadyToDespawn()
        {
            return this.isReadyToDespawn;
        }

        public void IsReadyToDespawn(bool isReadyToDespawn)
        {
            this.isReadyToDespawn = isReadyToDespawn;
        }

        public void IsMoving(bool isMoving)
        {
            this.isMoving = isMoving;
        }

        public bool IsMoving()
        {
            return isMoving;
        }

        public void SetVelosity(Vector2d newVelosity)
        {
            if(newVelosity <= this.maxVelosity)
            {
                this.velosity = newVelosity;
            }
        }

        public void SetTexture(string pathToTexture)
        {
            this.hitbox.Image = Image.FromFile(pathToTexture);
        }

        public void SetPosition(Vector2d newPosition)
        {
            this.hitbox.Location = new Point((int)newPosition.x, (int)newPosition.y);
        }

        public void SetId(int newId)
        {
            this.id = newId;
        }

        public void SetSize(Vector2d newSize)
        {
            this.hitbox.Size = new Size((int)newSize.x, (int)newSize.y);
        }

        public void SetHitbox(PictureBox newHitBox)
        {
            this.hitbox = newHitBox;


#if DEBUG
            this.hitbox.BorderStyle = BorderStyle.FixedSingle;
#endif
        }

        public void SetMaxVelosity(Vector2d maxVelosity)
        {
            this.maxVelosity = maxVelosity;
        }

        virtual public void UpdateState()
        {
            this.UpdateDespawnState();
            this.Move();
        }

        virtual public void UpdateDespawnState()
        {
            this.isReadyToDespawn = !CollisionDetector.IsEntityCollideWitGameWindow(this);
        }

        virtual public void Move()
        {
            if (isMoving)
            {
                Vector2d newPosition = new Vector2d((int)this.velosity.x + this.hitbox.Location.X, (int)this.velosity.y + this.hitbox.Location.Y);

                this.SetPosition(newPosition);
            }
        }
    }
}
