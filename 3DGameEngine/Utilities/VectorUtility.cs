using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Utilities
{
    public abstract class VectorUtility
    {

        /// <summary>
        /// Rotate a vector from a given radians
        /// </summary>
        /// <param name="origin">The origin point</param>
        /// <param name="destination">The destination point</param>
        /// <param name="radians">The angle to rotate</param>
        /// <returns>The vector rotated</returns>
        public static Vector2 CreateRotation(Vector2 origin, Vector2 destination, float radians)
        {
            Vector2 direction = new Vector2(destination.X - origin.X, destination.Y - origin.Y);
            return Vector2.Transform(direction, Matrix.CreateRotationZ(radians));
        }

    }
}
