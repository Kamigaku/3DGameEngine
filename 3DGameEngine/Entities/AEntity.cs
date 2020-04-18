using GameEngine.Camera;
using GameEngine.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameEngine.Entities
{
    public abstract class AEntity : IEntity
    {

        #region Member fields
        private Model3D _model;
        #endregion Member fields

        #region Constructor
        public AEntity(Model3D model)
        {
            _model = model;
        }
        #endregion Constructor

        public virtual Model3D GetModel()
        {
            return _model;
        }

        public virtual void Update() 
        {
            _model.Update();
        }

        public virtual void Draw(GraphicsDevice graphicsDevice, BasicEffect effect, ACamera camera) 
        {
            effect.Projection = camera.Projection;
            effect.View = camera.View;
            GetModel().Draw(graphicsDevice, effect);
        }

        public virtual void CollisionEnter(object sender, EventArgs args) {}

        public virtual void CollisionExit(object sender, EventArgs args) {}
    }
}
