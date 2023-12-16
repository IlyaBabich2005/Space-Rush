using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    internal class PlayerFabric
    {
        public PlayableCharacter MakePlayer(WeaponTypes weapon = WeaponTypes.MACHINEGUN)
        {
            PlayerDirector playerMaker = new PlayerDirector(new PlayerBuilder());

            switch (weapon)
            {
                case WeaponTypes.MACHINEGUN: return playerMaker.BuildPlayerWithMachinGun(new Vector2d(300, 550));
                case WeaponTypes.SHOTGUN: return playerMaker.BuildPlayerWithShotgun(new Vector2d(300, 550));
                default: throw new ArgumentException();
            }
        }
    }
}
