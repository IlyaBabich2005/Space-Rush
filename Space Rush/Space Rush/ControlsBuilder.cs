using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Rush
{
    public class ControlsBuilder
    {
        PlayerControls buildedCintrols;

        public ControlsBuilder()
        {
            this.reset();
        }

        public void reset()
        {
            this.buildedCintrols = new PlayerControls();
        }

        public void SetDirectionUp(Direction up)
        {
            this.buildedCintrols.SetDirectionUp(up);
        }

        public void SetDirectionDown(Direction up)
        {
            this.buildedCintrols.SetDirectionDown(up);
        }

        public void SetDirectionLeft(Direction up)
        {
            this.buildedCintrols.SetDirectionLeft(up);
        }

        public void SetDirectionRight(Direction up)
        {
            this.buildedCintrols.SetDirectionRight(up);
        }

        public void SetKeyUp(Keys key)
        {
            this.buildedCintrols.SetKeyUp(key);
        }

        public void SetKeyDown(Keys key)
        {
            this.buildedCintrols.SetKeyDown(key);
        }


        public void SetKeyLeft(Keys key)
        {
            this.buildedCintrols.SetKeyLeft(key);
        }


        public void SetKeyRight(Keys key)
        {
            this.buildedCintrols.SetKeyRight(key);
        }


        public void SetKeyShoot(Keys key)
        {
            this.buildedCintrols.SetKeyShoot(key);
        }


        public void SetKeyUseSkill(Keys key)
        {
            this.buildedCintrols.SetKeyUseSkill(key);
        }
        
        public PlayerControls GetProduct()
        {
            PlayerControls controls = this.buildedCintrols;

            this.buildedCintrols = null;

            return controls;
        }
    }
}
