using GameEngine.Logging;
using GameEngine.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Model
{
    public abstract class Model3D
    {

        #region Variables
        // World positioning
        protected Matrix worldPosition;
        protected Matrix worldRotation;

        // Movement vectors
        protected Vector3 translationVector;
        protected Vector3 rotationVector;

        // Angles
        protected float yaw;
        protected float pitch;
        protected float roll;

        // Scaling
        protected float scaling;

        // Graphics rendering
        protected VertexPositionColor[] vertices;
        protected VertexBuffer vertexBuffer;
        protected IndexBuffer indexBuffer;
        #endregion Variables

        #region Properties
        public Vector3 Position 
        {
            get { return World.Translation; }
        }
        
        public Matrix World 
        {
            get { return worldRotation * worldPosition * Matrix.CreateScale(scaling); }
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Set the vector that will update the position matrix of the model
        /// </summary>
        /// <param name="translationVector">The vector representing the new translation that will be added to the position matrix</param>
        public virtual void SetTranslationVector(Vector3 translationVector)
        {
            this.translationVector = translationVector;
        }

        /// <summary>
        /// Set the rotation vector that will be added to the yaw, pitch and roll values.
        /// </summary>
        /// <param name="rotationVector"></param>
        public virtual void SetRotationVector(Vector3 rotationVector)
        {
            this.rotationVector = rotationVector;
        }

        /// <summary>
        /// Set a new position of the model.
        /// </summary>
        /// <param name="translationValues">The new position of the model</param>
        public virtual void SetTranslationValues(Vector3 translationValues)
        {
            worldPosition = Matrix.Identity * Matrix.CreateTranslation(translationValues);
        }

        /// <summary>
        /// Set the new rotation of the model.
        /// </summary>
        /// <param name="rotationValues">The rotation values of the model</param>
        public virtual void SetRotationValues(Vector3 rotationValues)
        {
            yaw = rotationValues.Y;
            pitch = rotationValues.X;
            roll = rotationValues.Z;
            worldRotation = Matrix.Identity * Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(yaw),
                                                                            MathHelper.ToRadians(pitch),
                                                                            MathHelper.ToRadians(roll));
        }

        /// <summary>
        /// Change the translation and angular rotation of the model to a new one
        /// </summary>
        /// <param name="newPosition">The new (x, y, z) position of the model</param>
        /// <param name="newRotation">The new (x, y, z) angular values of the model</param>
        /// <param name="newScaling">The new scaling value of the model</param>
        public virtual void SetTransform(Vector3 newPosition, Vector3 newRotation, float newScaling)
        {
            SetTranslationValues(newPosition);
            SetRotationValues(newRotation);
            scaling = newScaling;
        }

        /// <summary>
        /// Update fired from the <see cref="GameEngine.Worker.PhysicsWorker"/> logic.
        /// </summary>
        public virtual void Update() {}

        /// <summary>
        /// Draw fired from the <see cref="GameEngine.Worker.GraphicsWorker"/> logic.
        /// </summary>
        /// <param name="graphicsDevice">The graphic device that will render the model</param>
        /// <param name="effect">The effect that will be used to render the model</param>
        public virtual void Draw(GraphicsDevice graphicsDevice, BasicEffect effect) {}
        #endregion Methods
    }
}
