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
        protected Vector3 camPosition;
        public Vector3 camRotation;
        protected Vector3 camTarget;
        protected float camSpeed;
        protected Matrix projectionMatrix;

        protected Vector3 mouseRotationBuffer;
        private Vector3 cameraPositionVector;
        private Vector3 cameraRotationVector;
        #endregion Variables

        #region Properties
        public Matrix View 
        {
            get 
            {
                return Matrix.CreateLookAt(camPosition, camTarget, Vector3.Up);
            }
        }

        public Matrix Projection 
        {
            get 
            {
                return projectionMatrix;
            }
        }

        public Vector3 CameraRotationVector 
        {
            get { return cameraRotationVector; }
        }

        public Vector3 MouseRotationBuffer 
        {
            get { return mouseRotationBuffer; }
        }

        public Vector3 CameraTarget 
        {
            get { return camTarget; }
        }
        #endregion Properties


        #region Constructor
        protected ACamera(Vector3 target, Vector3 position, float speed)
        {
            camTarget = target;
            camPosition = position;
            camSpeed = speed;
            cameraRotationVector = Vector3.Zero;
            cameraPositionVector = Vector3.Zero;
        }
        #endregion Constructor

        #region Public methods
        public virtual void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            bool updateFired = false;
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
            }
        }

        public void SetPositionTranslateVector(Vector3 translationVector)
        {
            if (translationVector != Vector3.Zero)
            {
                translationVector.Normalize();
            }
            cameraPositionVector = translationVector * camSpeed;
        }

        public void SetCameraRotation(Vector2 axisRotation)
        {
            // TODO: change the camSpeed to maybe something else ? camRotationSpeed ?
            cameraRotationVector = new Vector3(axisRotation, 0f) * camSpeed * 3;
        }

        public void Zoom(int amount)
        {
            cameraPositionVector.Z = amount;
        }
        #endregion Public methods

    }
}
