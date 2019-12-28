using GameEngine.Entities;
using Labyrinthe.Datas;
using Labyrinthe.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe.Entities
{
    class Blob : MoveableEntity
    {

        public Blob(Vector3 position, Vector3 rotation, float scaling, float entitySpeed, GraphicsDevice graphicsDevice)
                    : base(entitySpeed, new Block(position, rotation, 1, 1, 1, scaling, graphicsDevice))
        {
            //GameDatas.Models.Add(GetModel());
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(GraphicsDevice graphicsDevice, BasicEffect effect)
        {
            effect.Projection = GameDatas.MainCamera.Projection;
            effect.View = GameDatas.MainCamera.View;
            GetModel().Draw(graphicsDevice, effect);
        }

    }
}
