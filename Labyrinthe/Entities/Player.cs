using GameEngine.Entities;
using Labyrinthe.Datas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe.Entities
{
    public class Player : MoveableEntity
    {
        public Player(Vector3 position, float entitySpeed, GraphicsDevice graphicsDevice) : base(position, entitySpeed, graphicsDevice)
        {
            GameDatas.Models.Add(GetModel());
        }

    }
}
