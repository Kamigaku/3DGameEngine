using GameEngine.Utilities;
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

            // Test 1
            /*Matrix lookAt_1 = Matrix.Identity;
            Matrix lookAt_2 = Matrix.Identity;
            Matrix translate_1 = Matrix.Identity;
            
            Quaternion quat;
            Vector3 scaleDecompose;
            Vector3 translationDecompose;
            float thetaAngle = 0f;

            lookAt_1 = Matrix.CreateLookAt(new Vector3(0, 0, 0), new Vector3(-0.8459845f, 0, 0.533209f), Vector3.Up);
            lookAt_2 = Matrix.CreateLookAt(Vector3.Zero, new Vector3(1, 0, 0), Vector3.Up);


            for(int i = 0; i < 360; i++)
            {
                double x = Math.Sin(MathHelper.ToRadians(i));
                double y = Math.Cos(MathHelper.ToRadians(i));

                Matrix lookAt_matrix = Matrix.CreateLookAt(Vector3.Zero, new Vector3((float)x, 0f, (float)y), Vector3.Up);
                Vector3 eulerAngles = Vector3.Zero;
                lookAt_matrix.Decompose(out scaleDecompose, out quat, out translationDecompose);
                Console.WriteLine("Matrix of degree " + i + "(x: " + x + ", y: " + y + ") :");
                quat.ToEulerAngles(out eulerAngles);
                Console.WriteLine("X-Angle: " + eulerAngles.X +
                                  " / Y-Angle: " + eulerAngles.Y +
                                  " / Z-Angle: " + eulerAngles.Z);
                /*quat.ToAxisAngle(out translationDecompose, out thetaAngle);
                Console.WriteLine(translationDecompose + " / " + thetaAngle);
                Console.WriteLine("X-Angle: " + MathHelper.ToDegrees(translationDecompose.X * thetaAngle) + 
                                  " / Y-Angle: " + MathHelper.ToDegrees(translationDecompose.Y * thetaAngle) + 
                                  " / Z-Angle: " + MathHelper.ToDegrees(translationDecompose.Z * thetaAngle));*/
            /*Console.WriteLine("---------------------");
        }*/

            Vector3 target = Vector3.Forward;
            Console.WriteLine(target);
            target = Vector3.Transform(target, Matrix.CreateFromAxisAngle(Vector3.Up, MathHelper.ToRadians(90f))); // Rotate around Y
            target = Vector3.Transform(target, Matrix.CreateFromAxisAngle(Vector3.Forward, MathHelper.ToRadians(90f))); // Rotate around Z
            target = Vector3.Transform(target, Matrix.CreateFromAxisAngle(Vector3.Right, MathHelper.ToRadians(90f))); // Rotate around X
            Console.WriteLine(target);

            target = Vector3.Forward;
            Console.WriteLine(target);
            target = Vector3.Transform(target, Matrix.CreateFromAxisAngle(Vector3.Right, MathHelper.ToRadians(90f))); // Rotate around X
            target = Vector3.Transform(target, Matrix.CreateFromAxisAngle(Vector3.Forward, MathHelper.ToRadians(90f))); // Rotate around Z
            target = Vector3.Transform(target, Matrix.CreateFromAxisAngle(Vector3.Up, MathHelper.ToRadians(90f))); // Rotate around Y
            Console.WriteLine(target);

            target = Vector3.Forward;
            Console.WriteLine(target);
            target = Vector3.Transform(target, Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(90f), MathHelper.ToRadians(0), MathHelper.ToRadians(0)));
            Console.WriteLine(target);


            /*lookAt_1.Decompose(out scaleDecompose, out quat, out translationDecompose);
            quat.ToAxisAngle(out translationDecompose, out thetaAngle);
            Console.WriteLine(translationDecompose + " / " + thetaAngle);
            Console.WriteLine("---------------------");*/
            /*lookAt_2.Decompose(out scaleDecompose, out quat, out translationDecompose);
            quat.ToAxisAngle(out translationDecompose, out thetaAngle);
            Console.WriteLine(translationDecompose + " / " + thetaAngle);
            Console.WriteLine("---------------------");*/

            /*translate_1 *= Matrix.CreateRotationY(MathHelper.ToRadians(45f));
            translate_1.Decompose(out scaleDecompose, out quat, out translationDecompose);
            quat.ToAxisAngle(out translationDecompose, out thetaAngle);
            Console.WriteLine(translationDecompose + " / " + thetaAngle);
            Console.WriteLine("---------------------");*/
            //translate_1 *= Matrix.CreateRotationZ(MathHelper.ToRadians(180f));

            /*Matrix playerMatrix = Matrix.Identity;
            lookAt_1.Decompose(out scaleDecompose, out quat, out translationDecompose);
            Vector3 axisAngle;
            quat.ToAxisAngle(out axisAngle, out thetaAngle);

            playerMatrix *= Matrix.CreateFromYawPitchRoll(axisAngle.X * thetaAngle, axisAngle.Y * thetaAngle, axisAngle.Z * thetaAngle);

            displayMatrix(lookAt_1);
            Console.WriteLine("-------------");
            displayMatrix(playerMatrix);*/




            /*displayMatrix(lookAt_1);
            Console.WriteLine("=============");
            displayMatrix(translate_1);*/


            /*Vector3 blockSize = new Vector3(3, 1, 2);
            Vector3 blockPosition = new Vector3(2, 2, 2);

            Vector2 destination = new Vector2(blockPosition.X + (blockSize.X / 2f), blockPosition.Z + (blockSize.Z / 2f));

            Vector2 add = CreateRotation(new Vector2(blockPosition.X, blockPosition.Z), destination, MathHelper.ToRadians(45));
            Console.WriteLine(add);*/

            /*using (var game = new Game1())
                game.Run();*/
        }

        public static Vector2 CreateRotation(Vector2 origin, Vector2 destination, float radians)
        {
            Vector2 direction = new Vector2(destination.X - origin.X, destination.Y - origin.Y);
            return Vector2.Transform(direction, Matrix.CreateRotationZ(radians));
        }

        public static void displayMatrix(Matrix matrix)
        {
            Console.WriteLine(matrix.M11 + " / " + matrix.M12 + " / " + matrix.M13 + " / " + matrix.M14);
            Console.WriteLine(matrix.M21 + " / " + matrix.M22 + " / " + matrix.M23 + " / " + matrix.M24);
            Console.WriteLine(matrix.M31 + " / " + matrix.M32 + " / " + matrix.M33 + " / " + matrix.M34);
            Console.WriteLine(matrix.M41 + " / " + matrix.M42 + " / " + matrix.M43 + " / " + matrix.M44);
        }
    }
#endif
}
