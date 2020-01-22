using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Geometry
{
    public class Transform
    {

        #region Member fields

        // Angles => TODO: les angles doivent être -180 < angle < 180
        private float _yaw; // Y
        private float _pitch; // X
        private float _roll; // Z

        // Scaling
        private float _scaling;

        // Update values
        private Vector3 _translationVelocity;
        private Vector3 _rotationVelocity;

        // Matrix
        private Matrix _translation;
        private Matrix _rotation;

        #endregion Member fields

        #region Properties

        public Matrix World 
        {
            get { return _rotation * _translation * Matrix.CreateScale(_scaling); }
        }

        public Vector3 EulerAngles 
        {
            get { return new Vector3(_pitch, _yaw, _roll); }
        }

        public Vector3 Position 
        {
            get { return _translation.Translation; }
        }

        public float Scale 
        {
            get { return _scaling; }
        }

        public Vector3 Forward 
        {
            get { return World.Forward; }        
        }

        public Vector3 Left 
        {
            get { return World.Left; }
        }

        public Vector3 Up 
        {
            get { return World.Up; }
        }
        #endregion Properties

        #region Constructor

        public Transform(Vector3 position, Vector3 rotation, float scale)
        {
            SetTransform(position, rotation, scale);
        }

        public Transform(float x, float y, float z, float yaw, float pitch, float roll, float scale)
        {
            SetTransform(new Vector3(x, y, z), new Vector3(pitch, yaw, roll), scale);
        }
        #endregion Constructor

        #region Public methods

        public void SetTransform(Vector3 position, Vector3 rotation, float scale)
        {
            // Position
            SetPosition(position);

            // Rotation
            SetRotation(rotation);

            // Scale
            _scaling = scale;

            _rotationVelocity = Vector3.Zero;
            _translationVelocity = Vector3.Zero;
        }

        /// <summary>
        /// Set the new position of the transform.
        /// </summary>
        /// <param name="translationValues">The new position of the transform</param>
        public void SetPosition(Vector3 position)
        {
            _translation = Matrix.Identity * Matrix.CreateTranslation(position);
        }

        /// <summary>
        /// Set the new rotation of the transform.
        /// </summary>
        /// <param name="rotationValues">The rotation values of the transform</param>
        public void SetRotation(Vector3 rotation)
        {
            _yaw = rotation.Y;
            _pitch = rotation.X;
            _roll = rotation.Z;
            _rotation = Matrix.Identity * Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(_yaw),
                                                                        MathHelper.ToRadians(_pitch),
                                                                        MathHelper.ToRadians(_roll));
        }

        public void SetScaling(float scale)
        {
            _scaling = scale;
        }

        /// <summary>
        /// Set the vector that will update the position matrix of the transform.
        /// </summary>
        /// <param name="velocity">The vector representing the new translation velocity.</param>
        public void SetTranslationVelocity(Vector3 velocity)
        {
            //Logging.Logger.Debug("" + velocity);
            _translationVelocity = velocity;
        }

        /// <summary>
        /// Set the rotation vector that will be added to the yaw, pitch and roll values.
        /// </summary>
        /// <param name="rotationVector">The vector representing the new rotation velocity.</param>
        public void SetRotationVelocity(Vector3 velocity)
        {
            if (velocity != Vector3.Zero)
            {
                _yaw += velocity.Y;
                //Console.WriteLine(_yaw);
                _pitch += velocity.X;
                _roll += velocity.Z;
            }
            _rotationVelocity = velocity;
        }

        public void Update()
        {
            if (_rotationVelocity != Vector3.Zero)
            {
                //Console.WriteLine(_rotationVelocity);
                _rotation *= Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(_rotationVelocity.Y),
                                                           MathHelper.ToRadians(_rotationVelocity.X),
                                                           MathHelper.ToRadians(_rotationVelocity.Z));
            }

            if(_translationVelocity != Vector3.Zero)
            {
                _translation *= Matrix.CreateTranslation((_translationVelocity.X * _rotation.Left) +
                                                         (_translationVelocity.Y * _rotation.Up) +
                                                         (_translationVelocity.Z * _rotation.Forward));
                /*Logging.Logger.Debug("" + _translationVelocity);
                Logging.Logger.Debug("Left: " + _rotation.Left + " / Up: " + _rotation.Up + " / Forward: " + _rotation.Forward);
                Logging.Logger.Debug("Result: " + ((_translationVelocity.X * _rotation.Left) +
                                                         (_translationVelocity.Y * _rotation.Up) +
                                                         (_translationVelocity.Z * _rotation.Forward)));*/
            }
        }

        #endregion Public methods

    }
}
