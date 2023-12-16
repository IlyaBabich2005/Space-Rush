using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public class LevelUp : Skill
    {
        public void Play(PlayableCharacter user)
        {
            user.GetWeapon().LevelUp();
        }
    }
}
