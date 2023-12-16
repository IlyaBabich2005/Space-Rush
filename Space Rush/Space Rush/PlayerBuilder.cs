using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Rush
{
    public class PlayerBuilder
    {
        private PlayableCharacter buildedShip = null;

        public PlayerBuilder()
        {
            this.reset();
        }

        public void reset()
        {
            this.buildedShip = new PlayableCharacter();
            this.buildedShip.CanItDie(true);
            this.SetId();
            this.SetDespawnState(false);
            this.SetMovingState(false);
            this.SetType(CollidebleEntityType.PLAYER);
        }

        public void SetHitbox(Vector2d size, string pathToTexture)
        {
            this.buildedShip.SetHitbox(new PictureBox());

            this.buildedShip.SetSize(size);
            this.buildedShip.SetTexture(pathToTexture);
        }

        public void SetVelosity(Vector2d velosity)
        {
            this.buildedShip.SetVelosity(velosity);
        }

        public void SetId()
        {
            this.buildedShip.SetId(Game.GetInstanse().GetNewID());
        }

        public void SetMovingState(bool isMoving)
        {
            this.buildedShip.IsMoving(isMoving);
        }

        public void SetMaxVelosity(Vector2d maxVelosity)
        {
            this.buildedShip.SetMaxVelosity(maxVelosity);
        }

        public void SetDespawnState(bool isReadyToDespawn)
        {
            this.buildedShip.IsReadyToDespawn(isReadyToDespawn);
        }

        public void SetType(CollidebleEntityType type)
        {
            this.buildedShip.SetEntityType(type);
        }

        public void SetContactDamage(float contactDamage)
        {
            this.buildedShip.SetContactDamage(contactDamage);
        }

        public void SetHP(float HP)
        {
            this.buildedShip.SetHP(HP);
        }

        public void SetMaxHP(float maxHP)
        {
            this.buildedShip.SetMaxHp(maxHP);
        }

        public void SetShootState(bool isShoot)
        {
            this.buildedShip.IsShoot(isShoot);
        }

        public void SetWeapon(Weapon weapon)
        {
            this.buildedShip.SetWeapon(weapon);
        }

        public void SetControls(PlayerControls controls)
        {
            this.buildedShip.SetControls(controls);
        }

        public void SetSprites(string pathToDirectlyPositionSprite, string pathToRightRollSprite, string pathToLeftRollSprite)
        {
            this.buildedShip.SetSprites(pathToDirectlyPositionSprite, pathToRightRollSprite, pathToLeftRollSprite);
        }

        public void SetPosition(Vector2d position)
        {
            this.buildedShip.SetPosition(position);
        }

        public void SetHpBar()
        {
            HpBarDirector hpBarMaker = new HpBarDirector(new HpBarBuilder());

            this.buildedShip.SetHpBar(hpBarMaker.BuildHpBar(this.buildedShip));
            this.buildedShip.UpdateHpBar();
        }

        public PlayableCharacter GetProduct()
        {
            PlayableCharacter product = this.buildedShip;

            this.reset();

            return product;
        }
    }
}