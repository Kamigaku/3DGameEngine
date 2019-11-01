﻿using GameEngine.Entities;
using Labyrinthe.Datas;
using Labyrinthe.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Labyrinthe.Entities
{
    public class Player : MoveableEntity
    {
        public Player(Vector3 position, Vector3 rotation, float entitySpeed, GraphicsDevice graphicsDevice) 
            : base(position, entitySpeed, graphicsDevice, new Block(position, rotation, 1, 1, 1, graphicsDevice))
        {
            //GameDatas.Models.Add(GetModel());
        }

        public override void Update()
        {
            base.Update();
            GetModel().Rotation = new Vector3(GameDatas.MainCamera.camRotation.X,
                                              GameDatas.MainCamera.camRotation.Y,
                                              GameDatas.MainCamera.camRotation.Z);
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
