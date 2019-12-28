using GameEngine.Controllers;
using GameEngine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameEngine.Camera
{
    public class FPSCamera : PerspectiveCamera
    {

        #region Member fields
        private IEntity _target;

        private readonly float MAX_PITCH = MathHelper.PiOver4;
        public float currentPitch = 0;
        public float currentYaw = 0;
        #endregion Member fields

        #region Constructor
        public FPSCamera(GraphicsDevice graphicsDevice, IEntity target, float fov = 45, float distanceView = 1000, InputProcessor controller = null) 
                        : base(graphicsDevice, Vector3.Forward, target.GetPosition(), Vector3.Up, 5f, fov, distanceView, controller)
        {
            _target = target;
            camPosition = _target.GetPosition();
            Logging.Logger.Log(Logging.Logger.LogLevel.DEBUG, "Camera position: " + camPosition + " / " + camTarget + " / " + camUp);

            // WIP
        }
        #endregion Constructor

        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            float pitchAngle = CameraRotationVector.Y;
            currentYaw += CameraRotationVector.X;

            camTarget = Vector3.Transform(camTarget, Matrix.CreateFromAxisAngle(camUp, -CameraRotationVector.X));
            if (Math.Abs(currentPitch + pitchAngle) < MAX_PITCH)
            {
                camTarget = Vector3.Transform(camTarget, Matrix.CreateFromAxisAngle(Vector3.Cross(camUp, camTarget), pitchAngle));
                currentPitch += pitchAngle;
            }

            camPosition = _target.GetPosition();
            /*camPosition.Z -= 2;
            camPosition.Y += 2;*/
        }
    }
}
