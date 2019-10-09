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
        protected Vector3 camRotation;
        protected Vector3 camTarget;
        protected Vector3 mouseRotationBuffer;

        protected Matrix viewMatrix;
        protected Matrix worldMatrix;
        protected Vector3 cameraPositionVector;
        protected Vector3 cameraTargetVector;
        #endregion Variables

        #region Properties
        public Matrix Projection {
            get;
            protected set;
        }

        public Matrix View {
            get {
                return Matrix.CreateLookAt(camPosition, camTarget, Vector3.Up);
            }
        }
        #endregion Properties


        #region Constructor
        protected ACamera(Vector3 target, Vector3 position)
        {
            camTarget = target;
            camPosition = position;
            //viewMatrix = Matrix.CreateLookAt(camPosition, camTarget, new Vector3(0f, 1f, 0f));
            //worldMatrix = Matrix.CreateWorld(camTarget, Vector3.Forward, Vector3.Up);
            //cameraPositionVector = Vector3.Zero;
            //cameraTargetVector = Vector3.Zero;
        }
        #endregion Constructor

        #region Public methods
        public void Update(GameTime gameTime)
        {
            bool updateFired = false;
            if (cameraPositionVector != Vector3.Zero)
            {
                Matrix rotate = Matrix.CreateRotationY(camRotation.Y);
                Vector3 movement = new Vector3(cameraPositionVector.X, cameraPositionVector.Y, cameraPositionVector.Z);
                movement = Vector3.Transform(movement, rotate);


                /*camPosition = new Vector3(camPosition.X + (float)(cameraPositionVector.X * Forward.X * gameTime.ElapsedGameTime.TotalSeconds * 15),
                                          camPosition.Y + (float)(cameraPositionVector.Y * Forward.Y * gameTime.ElapsedGameTime.TotalSeconds * 15),
                                          camPosition.Z + (float)(cameraPositionVector.Z * Forward.Z * gameTime.ElapsedGameTime.TotalSeconds) * 15);
                camTarget = new Vector3(camTarget.X + (float)(cameraPositionVector.X * Forward.X * gameTime.ElapsedGameTime.TotalSeconds),
                                        camTarget.Y + (float)(cameraPositionVector.Y * Forward.Y * gameTime.ElapsedGameTime.TotalSeconds),
                                        camTarget.Z);*/
                updateFired = true;
            }

            if (cameraTargetVector != Vector3.Zero)
            {
                camTarget = new Vector3(camTarget.X + (float)(cameraTargetVector.X * gameTime.ElapsedGameTime.TotalSeconds * 15),
                                        camTarget.Y + (float)(cameraTargetVector.Y * gameTime.ElapsedGameTime.TotalSeconds * 15),
                                        camTarget.Z);
                cameraTargetVector = Vector3.Zero;
                updateFired = true;
            }

            if (updateFired)
            {
                Matrix rotationMatrix = Matrix.CreateRotationX(camRotation.X) * Matrix.CreateRotationY(camRotation.Y);
                Vector3 lookAtOffset = Vector3.Transform(Vector3.UnitZ, rotationMatrix);
                camTarget = camPosition + lookAtOffset;

                //viewMatrix = Matrix.CreateLookAt(camPosition, camTarget, Vector3.Up);
            }

            //cameraPositionVector.Z = 0;




        }

        public virtual void Draw(BasicEffect basicEffect) { }

        public void SetPositionTranslateVector(Vector3 translationVector)
        {
            translationVector.Normalize();
            cameraPositionVector = translationVector;
        }

        public void SetCameraTargetVector(Vector2 axisRotation)
        {
            cameraTargetVector = new Vector3(axisRotation, 0f);
        }

        public void Zoom(int amount)
        {
            cameraPositionVector.Z = amount;
        }
        #endregion Public methods

    }
}
