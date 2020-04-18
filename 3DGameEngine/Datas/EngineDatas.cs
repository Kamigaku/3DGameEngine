using GameEngine.Geometry;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Datas
{
    internal abstract class EngineDatas
    {

        public static List<Collider> Colliders;

        static EngineDatas()
        {
            Colliders = new List<Collider>();
        }

    }
}
