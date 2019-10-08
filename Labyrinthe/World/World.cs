using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe.World
{
    class World
    {

        public Chunk[] _activeChunks;

        public World()
        {
            _activeChunks = new Chunk[8];
            for(int i = 0; i < _activeChunks.Length; i++)
            {
                _activeChunks[i] = new Chunk();
                Console.WriteLine("Created chunk " + i);
            }
        }

    }
}
