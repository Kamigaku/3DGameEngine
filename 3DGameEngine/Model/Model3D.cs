using GameEngine.Logging;
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
        /// Set the vector that will update the rotation matrix of the model
        /// </summary>
        /// <param name="rotationVector">The vector representing the yaw, pitch and roll value</param>
        public virtual void SetRotationVector(Vector3 rotationVector)
        {
            this.rotationVector = rotationVector;
        }

        /// <summary>
        /// Set angular values that will update the rotation matrix of the model
        /// </summary>
        /// <param name="yaw">The yaw that will be added to the rotation matrix</param>
        /// <param name="pitch">The pitch that will be added to the rotation matrix</param>
        /// <param name="roll">The roll that will be added to the rotation matrix</param>
        public virtual void SetRotationVector(float yaw, float pitch, float roll)
        {
            SetRotationVector(new Vector3(yaw, pitch, roll));
        }

        /// <summary>
        /// Change the translation and angular rotation of the model to a new one
        /// </summary>
        /// <param name="newPosition">The new (x, y, z) position of the model</param>
        /// <param name="yaw">The new yaw of the model</param>
        /// <param name="pitch">The new pitch of the model</param>
        /// <param name="roll">The new roll of the model</param>
        public virtual void SetTransform(Vector3 newPosition, float yaw, float pitch, float roll, float scaling)
        {
            SetTransform(newPosition, new Vector3(yaw, pitch, roll), scaling);
        }

        /// <summary>
        /// Change the translation and angular rotation of the model to a new one
        /// </summary>
        /// <param name="newPosition">The new (x, y, z) position of the model</param>
        /// <param name="newRotation">The new (x, y, z) angular values of the model</param>
        public virtual void SetTransform(Vector3 newPosition, Vector3 newRotation, float scaling)
        {
            worldPosition = Matrix.Identity * Matrix.CreateTranslation(newPosition);
            worldRotation = Matrix.Identity * Matrix.CreateFromYawPitchRoll(newRotation.X, newRotation.Y, newRotation.Z);
            this.scaling = scaling;
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
