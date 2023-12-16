using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Rush
{
    public class ControlsDirector
    {
        private ControlsBuilder builder;

        public ControlsDirector (ControlsBuilder builder)
        {
            this.builder = builder;
        }

        public PlayerControls BuildWASDControls(Vector2d velosity)
        {
            this.builder.SetDirectionUp(new Direction(false, new Vector2d(0, -velosity.y)));
            this.builder.SetDirectionDown(new Direction(false, new Vector2d(0, velosity.y)));
            this.builder.SetDirectionLeft(new Direction(false, new Vector2d(-velosity.x, 0)));
            this.builder.SetDirectionRight(new Direction(false, new Vector2d(velosity.x, 0)));

            this.builder.SetKeyUp(Keys.W);
            this.builder.SetKeyDown(Keys.S);
            this.builder.SetKeyLeft(Keys.A);
            this.builder.SetKeyRight(Keys.D);
            this.builder.SetKeyShoot(Keys.Space);
            this.builder.SetKeyUseSkill(Keys.R);

            return this.builder.GetProduct();
        }
    }
}
