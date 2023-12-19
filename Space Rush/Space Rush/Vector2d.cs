using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public class Vector2d
    {
        public float x = 0;
        public float y = 0;
        private float length = 0;
        private float angle = 0;

        public Vector2d(float x, float y)
        {
            this.x = x;
            this.y = y;

            this.length = (float)Math.Sqrt(this.x * this.x + this.y * this.y);

            if(this.y > 0)
            {
                this.angle = (float)Math.Acos(this.x / this.length);
            }
            else
            {
                this.angle = (float)Math.Acos(this.x / this.length) + (float)Math.PI;
            }
            
        }

        public static Vector2d operator +(Vector2d a, Vector2d b)
        {
            return new Vector2d(a.x + b.x, a.y + b.y);
        }

        public static Vector2d operator -(Vector2d a, Vector2d b)
        {
            return new Vector2d(a.x - b.x, a.y - b.y);
        }

        public static bool operator>(Vector2d left, Vector2d right)
        {
            if(left.length > right.length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator<(Vector2d left, Vector2d right)
        {
            if (left.length < right.length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator<=(Vector2d left, Vector2d right)
        {
            if (left.length <= right.length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator>=(Vector2d left, Vector2d right)
        {
            if (left.length >= right.length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetAngle(float angle)
        {
            this.y = 0;
            this.x = this.length;

            float rotatedX = this.x * (float)Math.Cos(angle) - this.y * (float)Math.Sin(angle);
            float rotatedY = this.x * (float)Math.Sin(angle) + this.y * (float)Math.Cos(angle);

            this.x = rotatedX;
            this.y = rotatedY;
        }

        public float GetLength()
        {
            return this.length;
        }

        public float GetAngle()
        {
            return this.angle;
        }
    }
}
