using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Rush
{
    public class PlayerControls
    {
        private Direction up;
        private Direction down;
        private Direction left;
        private Direction right;
        private Direction lastDirection;
        private Keys keyUp;
        private Keys keyDown;
        private Keys keyLeft;
        private Keys keyRight;
        private Keys keyShoot;
        private Keys keyUseSkill;
        private Vector2d movementVector = new Vector2d(0,0);

        public PlayerControls(Direction up, Direction down, Direction left, Direction right, 
            Keys keyUp, Keys keyDown, Keys keyLeft, Keys keyRight, Keys keyShoot, Keys keyUseSkill)
        {
            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;
            this.lastDirection = null;
            this.keyUp = keyUp;
            this.keyDown = keyDown;
            this.keyLeft = keyLeft;
            this.keyRight = keyRight;
            this.keyShoot = keyShoot;
            this.keyUseSkill = keyUseSkill;
            this.movementVector = new Vector2d(0, 0);
        }

        public PlayerControls() { }

        public Vector2d GetMovementVector()
        {
            return this.movementVector;
        }

        public void SetDirectionUp(Direction up)
        {
            this.up = up;
        }

        public void SetDirectionDown(Direction down)
        {
            this.down = down;
        }

        public void SetDirectionLeft(Direction left)
        {
            this.left = left;
        }

        public void SetDirectionRight(Direction right)
        {
            this.right = right;
        }

        public void SetKeyUp(Keys key)
        {
            this.keyUp = key;
        }

        public void SetKeyDown(Keys key)
        {
            this.keyDown = key;
        }


        public void SetKeyLeft(Keys key)
        {
            this.keyLeft = key;
        }


        public void SetKeyRight(Keys key)
        {
            this.keyRight = key;
        }


        public void SetKeyShoot(Keys key)
        {
            this.keyShoot = key;
        }


        public void SetKeyUseSkill(Keys key)
        {
            this.keyUseSkill = key;
        }

        public bool IsMove()
        {
            if (this.down.IsActive() || this.left.IsActive() || this.right.IsActive() || this.up.IsActive())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsMoveRight()
        {
            if (this.right.IsActive())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsMoveLeft()
        {
            if (this.left.IsActive())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void HandleKeysDown(PlayableCharacter player, KeyEventArgs e)
        {
            this.HandleMoveKeysDown(e);
            this.HandleShootKeyDown(e, player);
            this.HandleUseSkillKeyDown(e, player);
        }

        public void HandleKeysUp(PlayableCharacter player, KeyEventArgs e)
        {
            this.HandleMoveKeysUp(e);
            this.HandleShootKeyUp(e, player);
        }

        private void HandleUpKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == this.keyUp)
            {
                this.MoveAcrossDirection(this.up);
            }
        }

        private void HandleDownKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == this.keyDown)
            {
                this.MoveAcrossDirection(this.down);
            }
        }

        private void HandleLeftKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == this.keyLeft)
            {
                this.MoveAcrossDirection(this.left);
            }
        }

        private void HandleRightKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == this.keyRight)
            {
                this.MoveAcrossDirection(this.right);
            }
        }

        private void HandleShootKeyDown(KeyEventArgs e, PlayableCharacter player)
        {
            if (e.KeyCode == this.keyShoot)
            {
                player.IsShoot(true);
                if (this.lastDirection != null)
                {
                    this.MoveAcrossDirection(this.lastDirection);
                }
            }
        }

        private void HandleUseSkillKeyDown(KeyEventArgs e, PlayableCharacter player)
        {
            if(e.KeyCode == this.keyUseSkill)
            {
                player.UseSkill();
            }
        }

        private void HandleMoveKeysDown(KeyEventArgs e)
        {
            this.ResetDirections();

            this.HandleDownKeyDown(e);
            this.HandleUpKeyDown(e);
            this.HandleLeftKeyDown(e);
            this.HandleRightKeyDown(e);
        }

        private void HandleUpKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == this.keyUp)
            {
                this.StopMovingAcrossDirection(this.up);
            }
        }

        private void HandleDownKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == this.keyDown)
            {
                this.StopMovingAcrossDirection(this.down);
            }
        }

        private void HandleLeftKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == this.keyLeft)
            {
                this.StopMovingAcrossDirection(this.left);
            }
        }

        private void HandleRightKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == this.keyRight)
            {
                this.StopMovingAcrossDirection(this.right);
            }
        }

        private void HandleShootKeyUp(KeyEventArgs e, PlayableCharacter player)
        {
            if (e.KeyCode == this.keyShoot)
            {
                player.IsShoot(false);
            }
        }

        private void HandleMoveKeysUp(KeyEventArgs e)
        {
            this.HandleDownKeyUp(e);
            this.HandleUpKeyUp(e);
            this.HandleLeftKeyUp(e);
            this.HandleRightKeyUp(e);
        }

        private void MoveAcrossDirection(Direction direction)
        {
            this.movementVector += direction.GetAcceleration();
            direction.IsActive(true);
            this.lastDirection = direction;
        }

        private void StopMovingAcrossDirection(Direction direction)
        {
            this.lastDirection = null;
            direction.IsActive(false);
        }

        private void ResetDirections()
        {
            this.up.IsActive(false);
            this.down.IsActive(false);
            this.left.IsActive(false);
            this.right.IsActive(false);
            this.movementVector = new Vector2d(0, 0);
        }
    }
}
