using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Utilities
{
    public static class MatrixUtility
    {
        public static void displayMatrix(this Matrix matrix)
        {
            Logging.Logger.Log(Logging.Logger.LogLevel.DEBUG, matrix.M11 + " / " + matrix.M12 + " / " + matrix.M13 + " / " + matrix.M14);
            Logging.Logger.Log(Logging.Logger.LogLevel.DEBUG, matrix.M21 + " / " + matrix.M22 + " / " + matrix.M23 + " / " + matrix.M24);
            Logging.Logger.Log(Logging.Logger.LogLevel.DEBUG, matrix.M31 + " / " + matrix.M32 + " / " + matrix.M33 + " / " + matrix.M34);
            Logging.Logger.Log(Logging.Logger.LogLevel.DEBUG, matrix.M41 + " / " + matrix.M42 + " / " + matrix.M43 + " / " + matrix.M44);
        }

    }
}
