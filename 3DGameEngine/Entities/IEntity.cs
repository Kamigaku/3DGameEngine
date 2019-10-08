using GameEngine.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Entities
{
    public interface IEntity
    {

        void Update();
        Model3D GetModel();
        Vector3 GetPosition();

    }
}
