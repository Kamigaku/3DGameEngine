using GameEngine.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Entities
{
    public abstract class AEntity : IEntity
    {

        #region Member fields
        private Model3D _model;
        #endregion Member fields

        #region Properties

        #endregion Properties

        #region Constructor
        public AEntity(Model3D model)
        {
            _model = model;
        }
        #endregion Constructor

        public Model3D GetModel()
        {
            return _model;
        }

        public Vector3 GetPosition()
        {
            return _model.Position;
        }

        public virtual void Update() 
        {
            _model.Update();
        }

        public virtual void Draw(GraphicsDevice graphicsDevice, BasicEffect effect) {}
    }
}
