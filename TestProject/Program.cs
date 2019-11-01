using Microsoft.Xna.Framework;
using System;

namespace TestProject
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Vector3 blockSize = new Vector3(3, 1, 2);
            Vector3 blockPosition = new Vector3(2, 2, 2);

            Vector2 destination = new Vector2(blockPosition.X + (blockSize.X / 2f), blockPosition.Z + (blockSize.Z / 2f));

            Vector2 add = CreateRotation(new Vector2(blockPosition.X, blockPosition.Z), destination, MathHelper.ToRadians(45));
            Console.WriteLine(add);

            /*using (var game = new Game1())
                game.Run();*/
        }

        public static Vector2 CreateRotation(Vector2 origin, Vector2 destination, float radians)
        {
            Vector2 direction = new Vector2(destination.X - origin.X, destination.Y - origin.Y);
            return Vector2.Transform(direction, Matrix.CreateRotationZ(radians));
        }
    }
#endif
}
