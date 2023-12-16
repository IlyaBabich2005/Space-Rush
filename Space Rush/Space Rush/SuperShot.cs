using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    internal class SuperShot : Skill
    {
        public void Play(PlayableCharacter user)
        {
            ProjectileDirector projectileDirector = new ProjectileDirector(new ProjectileBuilder());
            Alive rocketProjectile = projectileDirector.BuidSuperShotProjectile();

            rocketProjectile.SetPosition(user.GetPosition() + new Vector2d(6, 0));

            Game.GetInstanse().SpawnCollidebleEntity(rocketProjectile);
        }
    }
}
