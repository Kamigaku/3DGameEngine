using GameEngine.Geometry;
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
        // Transform
        private Transform _transform;

        // Graphics rendering
        protected VertexPositionColor[] vertices;
        protected VertexBuffer vertexBuffer;
        protected IndexBuffer indexBuffer;
        #endregion Variables

        #region Properties
        public Transform Transform 
        {
            get { return _transform; }
        }
        #endregion Properties

        #region Constructor

        protected Model3D(Vector3 position, Vector3 rotation, float scale)
        {
            _transform = new Transform(position, rotation, scale);
        }

        #endregion Constructor

        #region Methods
        /// <summary>
        /// Change the translation and angular rotation of the model to a new one
        /// </summary>
        /// <param name="newPosition">The new (x, y, z) position of the model</param>
        /// <param name="newRotation">The new (x, y, z) angular values of the model</param>
        /// <param name="newScaling">The new scaling value of the model</param>
        public virtual void SetTransform(Vector3 newPosition, Vector3 newRotation, float newScaling)
        {
            _transform.SetPosition(newPosition);
            _transform.SetRotation(newRotation);
            _transform.SetScaling(newScaling);
        }

        /// <summary>
        /// Update fired from the <see cref="GameEngine.Worker.PhysicsWorker"/> logic.
        /// </summary>
        public virtual void Update() 
        {
            _transform.Update();
        }

        /// <summary>
        /// Draw fired from the <see cref="GameEngine.Worker.GraphicsWorker"/> logic.
        /// </summary>
        /// <param name="graphicsDevice">The graphic device that will render the model</param>
        /// <param name="effect">The effect that will be used to render the model</param>
        public virtual void Draw(GraphicsDevice graphicsDevice, BasicEffect effect) {}
        #endregion Methods
    }
}
