using GameEngine.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameEngine.Utilities;
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

        // Camera positionning
        protected Vector3 camUp;
        protected Vector3 camPosition;
        protected Vector3 camTarget;

        // Testing camera angles
        private float _yaw; // Y
        private float _pitch; // X
        private float _roll; // Z

        // Camera speeds
        protected float camTranslationSpeed;
        protected float camRotationSpeed;

        // Camera matrix
        private Matrix _projectionMatrix;

        // Camera movements vectors
        protected Vector3 cameraRotationVector;
        protected Vector3 cameraTranslationVector;

        #endregion Variables

        #region Properties
        public Matrix View 
        {
            get 
            {
                return Matrix.CreateLookAt(camPosition, camPosition + camTarget, camUp);
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
        public Vector3 EulerAngles 
        {
            get 
            {
                return new Vector3(_pitch, _yaw, _roll);
            }
        }
        #endregion Properties

        #region Constructor
        protected ACamera(Vector3 target, Vector3 position, Vector3 up, float translationSpeed, float rotationSpeed)
        {
            camTarget = target;
            camPosition = position;
            camUp = up;
            camTranslationSpeed = translationSpeed;
            camRotationSpeed = rotationSpeed;
        }
        #endregion Constructor

        #region Public methods
        public virtual void Update(GameTime gameTime)
        {
            camTarget = Vector3.Transform(Vector3.Forward, Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(_yaw),
                                                                                         MathHelper.ToRadians(_pitch), 
                                                                                         MathHelper.ToRadians(_roll)));
        }

        public void SetCameraRotation(Vector3 rotationVector)
        {
            cameraRotationVector = rotationVector * camRotationSpeed;
            _yaw += cameraRotationVector.X;
            _roll += cameraRotationVector.Z;
            _pitch += cameraRotationVector.Y;
        }

        public void SetCameraTranslation(Vector3 translationVector)
        {
            cameraTranslationVector = translationVector * camTranslationSpeed;
        }
        #endregion Public methods

    }
}
