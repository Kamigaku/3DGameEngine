using GameEngine.Controllers;
using GameEngine.Entities;
using GameEngine.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameEngine.Camera
{
    public class FPSCamera : PerspectiveCamera
    {

        #region Member fields
        private IEntity _target;
        #endregion Member fields

        #region Constructor
        public FPSCamera(GraphicsDevice graphicsDevice, IEntity target, float translationSpeed, 
                         float rotationSpeed, float fov = 45, float distanceView = 1000) 
                        : base(graphicsDevice, Vector3.Forward, target.GetPosition(), Vector3.Up, 
                               translationSpeed, rotationSpeed, fov, distanceView)
        {
            _target = target;
            camPosition = _target.GetPosition();
        }
        #endregion Constructor

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            camPosition = _target.GetPosition();

            /*camPosition.Y += 2;
            camPosition.Z += 2;*/
        }
    }
}
