using GameEngine.Camera;
using GameEngine.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameEngine.Entities
{
    public interface IEntity
    {

        void Update();
        void Draw(GraphicsDevice graphicsDevice, BasicEffect effect, ACamera camera);
        Model3D GetModel();
        void CollisionEnter(object sender, EventArgs args);
        void CollisionExit(object sender, EventArgs args);

    }
}
