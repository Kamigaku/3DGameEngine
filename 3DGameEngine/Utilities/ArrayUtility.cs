using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Utilities
{
    public class ArrayUtility
    {
        /// <summary>
        /// Fill a one dimension array with a default value.
        /// </summary>
        /// <param name="array">The array to fill.</param>
        /// <param name="defaultValue">The default value to fill the array with.</param>
        public static void FillArray<T>(T[] array, T defaultValue)
        {
            for(int x = 0; x < array.Length; x++)
            {
                array[x] = defaultValue;
            }
        }

        /// <summary>
        /// Fill a two dimension array with a default value.
        /// </summary>
        /// <param name="array">The array to fill.</param>
        /// <param name="defaultValue">The default value to fill the array with.</param>
        public static void FillArray<T>(T[,] array, T defaultValue)
        {
            for (int x = 0; x < array.Length; x++)
            {
                for(int y = 0; y < array.GetLength(1); y++)
                {
                    array[x, y] = defaultValue;
                }
            }
        }

        /// <summary>
        /// Fill a three dimension array with a default value.
        /// </summary>
        /// <param name="array">The array to fill.</param>
        /// <param name="defaultValue">The default value to fill the array with.</param>
        public static void FillArray<T>(T[,,] array, T defaultValue)
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    for(int z = 0; z < array.GetLength(2); z++)
                    {
                        array[x, y, z] = defaultValue;
                    }
                }
            }
        }

    }
}
