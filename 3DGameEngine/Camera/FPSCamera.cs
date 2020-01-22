using GameEngine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Camera
{
    public class FPSCamera : PerspectiveCamera
    {

        #region Member fields
        private IEntity _target;
        #endregion Member fields

        #region Constructor
        public FPSCamera(GraphicsDevice graphicsDevice, IEntity target, float fov = 45, float distanceView = 1000) 
                        : base(graphicsDevice, Vector3.Forward, target.GetModel().Transform.Position, Vector3.Up, fov, distanceView)
        {
            _target = target;
        }
        #endregion Constructor

        public override void Update(GameTime gameTime)
        {
            Vector3 camPosition = _target.GetModel().Transform.Position;
            /*camPosition.Y += 2;
            camPosition.Z += 2;*/
            Transform.SetPosition(camPosition);
            base.Update(gameTime);
        }
    }
}
