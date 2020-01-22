using GameEngine.Camera;
using GameEngine.Entities;
using GameEngine.Logging;
using GameEngine.Utilities;
using Labyrinthe.Datas;
using Labyrinthe.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Labyrinthe.Entities
{
    public class Player : MoveableEntity
    {

        public Player(Vector3 position, Vector3 rotation, float scaling, float entitySpeed, GraphicsDevice graphicsDevice) 
            : base(entitySpeed, new Block(position, rotation, 1, 1, 1, scaling, graphicsDevice))
        {
        }

        public override void Update()
        {
            Vector3 rotationVelocity = new Vector3(0f,
                                                   GameDatas.MainCamera.Transform.EulerAngles.Y - GetModel().Transform.EulerAngles.Y,
                                                   0f);
            GetModel().Transform.SetRotationVelocity(rotationVelocity);
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
