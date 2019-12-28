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

        private float currentYaw;

        public Player(Vector3 position, Vector3 rotation, float scaling, float entitySpeed, GraphicsDevice graphicsDevice) 
            : base(entitySpeed, new Block(position, rotation, 1, 1, 1, scaling, graphicsDevice))
        {
        }

        public override void Update()
        {
            base.Update();


            SetRotationVector(-(((FPSCamera)GameDatas.MainCamera).currentYaw - currentYaw), 0f, 0f);
            currentYaw = ((FPSCamera)GameDatas.MainCamera).currentYaw;

            GetModel().Update();
        }

        public override void Draw(GraphicsDevice graphicsDevice, BasicEffect effect)
        {
            effect.Projection = GameDatas.MainCamera.Projection;
            effect.View = GameDatas.MainCamera.View;
            GetModel().Draw(graphicsDevice, effect);
        }
    }
}
