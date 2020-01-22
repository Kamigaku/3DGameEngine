using GameEngine.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Geometry;

namespace GameEngine.Camera
{
    public abstract class ACamera
    {

        #region Variables

        // Transform
        private Transform _transform;

        // Camera positionning
        protected Vector3 camUp;
        protected Vector3 camTarget;

        // Camera matrix
        private Matrix _projectionMatrix;
        #endregion Variables

        #region Properties
        public Matrix View 
        {
            get 
            {
                return Matrix.CreateLookAt(_transform.Position, _transform.Position + camTarget, camUp);
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

        public Transform Transform 
        {
            get { return _transform; }
        }

        #endregion Properties

        #region Constructor
        protected ACamera(Vector3 target, Vector3 position, Vector3 up)
        {
            _transform = new Transform(position, Vector3.Zero, 1.0f);


            camTarget = target;
            camUp = up;
        }
        #endregion Constructor

        #region Public methods
        public virtual void Update(GameTime gameTime)
        {
            _transform.Update();
            camTarget = Vector3.Transform(Vector3.Forward, Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(_transform.EulerAngles.Y),
                                                                                         MathHelper.ToRadians(_transform.EulerAngles.X),
                                                                                         MathHelper.ToRadians(_transform.EulerAngles.Z)));
        }
        #endregion Public methods

    }
}
