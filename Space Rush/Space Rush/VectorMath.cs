using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Rush
{
    public static class VectorMath
    {
        public static float Dot(Vector2d first, Vector2d second)
        {
            return first.x * second.x + first.y * second.y;
        }
    }
}
