using GameEngine.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Camera
{
    public abstract class ACamera
    {

        #region Variables
        protected Vector3 camUp;
        protected Vector3 camPosition;
        public Vector3 camTarget; // for testing purpose, it has been set to public
        protected float camSpeed;
        private Matrix _projectionMatrix;
        private Vector3 _cameraPositionVector;
        private Vector3 _cameraRotationVector;
        #endregion Variables

        #region Properties
        public Matrix View 
        {
            get 
            {
                return Matrix.CreateLookAt(camPosition, CameraDirection, camUp);
            }
        }
        public Matrix Projection 
        {
            get 
            {
                return _projectionMatrix;
            }
            protected set 
            {
                _projectionMatrix = value;
            }
        }
        public Vector3 CameraRotationVector 
        {
            get { return _cameraRotationVector; }
        }
        public Vector3 CameraDirection 
        {
            get { return camPosition + camTarget; }
        }
        #endregion Properties

        #region Constructor
        protected ACamera(Vector3 target, Vector3 position, Vector3 up, float speed)
        {
            camTarget = target;
            camPosition = position;
            camUp = up;
            camSpeed = speed;
            _cameraRotationVector = Vector3.Zero;
            _cameraPositionVector = Vector3.Zero;
        }
        #endregion Constructor

        #region Public methods
        public virtual void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            /*bool updateFired = false;
            if (cameraPositionVector != Vector3.Zero)
            {
                Matrix rotate = Matrix.CreateRotationY(camRotation.Y);
                Vector3 movement = new Vector3(cameraPositionVector.X, cameraPositionVector.Y, cameraPositionVector.Z) * deltaTime;
                camPosition += Vector3.Transform(movement, rotate);
                updateFired = true;
            }

            if(cameraRotationVector != Vector3.Zero)
            {

                mouseRotationBuffer.X -= 0.01f * cameraRotationVector.X * deltaTime;
                mouseRotationBuffer.Y -= 0.01f * cameraRotationVector.Y * deltaTime;

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
                updateFired = true;
            }

            if(updateFired)
            {
                Matrix rotationMatrix = Matrix.CreateRotationX(camRotation.X) * Matrix.CreateRotationY(camRotation.Y);
                Vector3 lookAtOffset = Vector3.Transform(Vector3.UnitZ, rotationMatrix);
                camTarget = camPosition + lookAtOffset;
            }*/
        }

        public void SetPositionTranslateVector(Vector3 translationVector)
        {
            if (translationVector != Vector3.Zero)
            {
                translationVector.Normalize();
            }
            _cameraPositionVector = translationVector * camSpeed;
        }

        public void SetCameraRotation(Vector2 axisRotation)
        {
            // TODO: change the constant value to something else
            _cameraRotationVector = (MathHelper.PiOver4 / 150) * new Vector3(axisRotation, 0f);
        }

        public void Zoom(int amount)
        {
            _cameraPositionVector.Z = amount;
        }
        #endregion Public methods

    }
}
