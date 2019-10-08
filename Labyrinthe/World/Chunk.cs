using GameEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe.World
{
    class Chunk
    {

        private short[,,] _map;

        public Chunk()
        {
            _map = new short[256, 512, 256];
            ArrayUtility.FillArray(_map, (short)0);
        }

    }
}
