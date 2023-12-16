using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    static public class CollisionDetector
    {
        public static bool IsAABBCollide(Vector2d firstObjectPosition, Vector2d firstObjectSize, Vector2d secondObjectPosition, Vector2d secondObjectSize)
        {
            bool xCollision = firstObjectPosition.x + firstObjectSize.x >= secondObjectPosition.x
                && firstObjectPosition.x <= secondObjectPosition.x + secondObjectSize.x;

            bool yCollision = firstObjectPosition.y + firstObjectSize.y >= secondObjectPosition.y
                && firstObjectPosition.y <= secondObjectPosition.y + secondObjectSize.y;

            return xCollision && yCollision;
        }

        public static bool IsApperThanLowerWindowBound(Entity entity)
        {
            if(entity.GetHitBox().Location.Y <= Game.GetInstanse().Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsLowerThanUpperWindowBound(Entity entity)
        {
            if (entity.GetHitBox().Location.Y >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsLefterThanRightWindowBound(Entity entity)
        {
            if (entity.GetHitBox().Location.X <= Game.GetInstanse().Width)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsRighterThanLeftWindowBound(Entity entity)
        {
            if (entity.GetHitBox().Location.X >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsCollidebleEntitiesCollide(CollidebleEntity first, CollidebleEntity second)
        {
            if (CollisionDetector.IsAABBCollide(first.GetPosition(), first.GetSize(), second.GetPosition(), second.GetSize()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsEntityCollideWitGameWindow(Entity entity)
        {
            return CollisionDetector.IsAABBCollide(entity.GetPosition(), entity.GetSize(), new Vector2d(0,0), Game.GetInstanse().GetWindowSize());
        }
    }
}
