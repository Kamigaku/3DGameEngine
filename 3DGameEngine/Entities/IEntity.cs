using GameEngine.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Entities
{
    public interface IEntity
    {

        void Update();
        void Draw(GraphicsDevice graphicsDevice, BasicEffect effect);
        Model3D GetModel();
        Vector3 GetPosition();

    }
}
