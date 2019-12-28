using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Utilities
{
    public static class QuaternionUtility
    {

        /// <summary>
        /// Converts a quaternion to axis/angle representation. A present from the PlazSoft team.
        /// 
        /// Reversable with Quaternion.CreateFromAxisAngle(Vector3, float)
        /// </summary>
        /// <param name="q"></param>
        /// <param name="axis">The axis that is rotated around, or (0,0,0)</param>
        /// <param name="angle">Angle around axis, in radians</param>
        public static void ToAxisAngle(this Quaternion q, out Vector3 axis, out float angle)
        {
            //From
            //http://social.msdn.microsoft.com/Forums/en-US/c482c19a-c566-4a64-aa9c-7a79ba7564d6/the-reverse-of-quaternioncreatefromaxisangle?forum=xnaframework
            //Modified to return 0,0,0 when it would have returned NaN
            //due to divide by zero.
            angle = (float)Math.Acos(q.W);
            float sa = (float)Math.Sin(angle);
            float ooScale = 0f;
            if (sa != 0)
                ooScale = 1.0f / sa;
            angle *= 2.0f;

            axis = new Vector3(q.X, q.Y, q.Z) * ooScale;
        }

    }
}
