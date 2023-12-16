using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Space_Rush
{
    public class PlayerDirector
    {
        private PlayerBuilder builder;

        public PlayerDirector(PlayerBuilder builder)
        {
            this.builder = builder;
        }

        public PlayableCharacter BuildPlayerWithShotgun(Vector2d spawnPoint)
        {
            WeaponDirector weaponMaker = new WeaponDirector(new WeaponBuilder());
            ControlsDirector controlsMaker = new ControlsDirector(new ControlsBuilder());

            this.builder.reset();

            this.builder.SetHitbox(new Vector2d(18, 32), "resourses//Ship_Default2.png");
            this.builder.SetMaxHP(150);
            this.builder.SetHP(150);
            this.builder.SetControls(controlsMaker.BuildWASDControls(new Vector2d(3,3)));
            this.builder.SetMaxVelosity(new Vector2d(3, 3));
            this.builder.SetWeapon(weaponMaker.BuildPlayersShotgun());
            this.builder.SetSprites("resourses//Ship_Default2.png", "resourses//Ship_Default3.png", "resourses//Ship_Default1.png");
            this.builder.SetPosition(spawnPoint);
            this.builder.SetHpBar();

            return this.builder.GetProduct();
        }

        public PlayableCharacter BuildPlayerWithMachinGun(Vector2d spawnPoint)
        {
            WeaponDirector weaponMaker = new WeaponDirector(new WeaponBuilder());
            ControlsDirector controlsMaker = new ControlsDirector(new ControlsBuilder());

            this.builder.reset();

            this.builder.SetHitbox(new Vector2d(18, 32), "resourses//Ship_Default2.png");
            this.builder.SetMaxHP(150);
            this.builder.SetHP(150);
            this.builder.SetControls(controlsMaker.BuildWASDControls(new Vector2d(3, 3)));
            this.builder.SetMaxVelosity(new Vector2d(3, 3));
            this.builder.SetWeapon(weaponMaker.BuildPlayersMachinegun());
            this.builder.SetSprites("resourses//Ship_Default2.png", "resourses//Ship_Default3.png", "resourses//Ship_Default1.png");
            this.builder.SetPosition(spawnPoint);
            this.builder.SetHpBar();

            return this.builder.GetProduct();
        }
    }
}
