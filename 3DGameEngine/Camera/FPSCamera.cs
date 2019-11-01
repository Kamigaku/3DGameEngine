using GameEngine.Controllers;
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
        public FPSCamera(GraphicsDevice graphicsDevice, IEntity target, float fov = 45, float distanceView = 1000, 
                               InputProcessor controller = null) : base(graphicsDevice, Vector3.Zero, Vector3.Zero, 5f, fov, distanceView, controller)
        {
            _target = target;
            camPosition = _target.GetPosition();

            // WIP
        }
        #endregion Constructor

        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            camPosition = _target.GetModel().transform.Translation;
            //camPosition.Z -= 5;
            //camPosition.Y += 2;

            if (CameraRotationVector != Vector3.Zero)
            {

                mouseRotationBuffer.X -= 0.01f * CameraRotationVector.X * deltaTime;
                mouseRotationBuffer.Y -= 0.01f * CameraRotationVector.Y * deltaTime;

                if (mouseRotationBuffer.Y < MathHelper.ToRadians(-75.0f))
                    mouseRotationBuffer.Y -= (mouseRotationBuffer.Y - MathHelper.ToRadians(-75.0f));
                if (mouseRotationBuffer.Y > MathHelper.ToRadians(75.0f))
                    mouseRotationBuffer.Y -= (mouseRotationBuffer.Y - MathHelper.ToRadians(75.0f));

                camRotation = new Vector3(-MathHelper.Clamp(
                                          mouseRotationBuffer.Y,
                                          MathHelper.ToRadians(-75.0f),
                                          MathHelper.ToRadians(75.0f)),
                                          MathHelper.WrapAngle(mouseRotationBuffer.X),
                                          0);
            }
            Matrix rotationMatrix = Matrix.CreateRotationX(camRotation.X) * Matrix.CreateRotationY(camRotation.Y);
            Vector3 lookAtOffset = Vector3.Transform(Vector3.UnitZ, rotationMatrix);
            camTarget = camPosition + lookAtOffset;
        }
    }
}
