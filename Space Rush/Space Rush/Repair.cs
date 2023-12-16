using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public class Repair : Skill
    {
        private float capasity;

        public Repair(float capasity)
        {
            this.capasity = capasity;
        }

        public void Play(PlayableCharacter user)
        {
            user.Heal(this.capasity);
        }
    }
}
