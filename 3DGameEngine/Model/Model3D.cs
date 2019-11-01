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

        protected Vector3 position;
        protected Vector3 rotation;
        protected VertexPositionColor[] vertices;
        protected VertexBuffer vertexBuffer;
        protected IndexBuffer indexBuffer;
        protected Vector3 translationVector;
        public Matrix transform;

        #region Properties

        public Vector3 Position 
        {
            get { return position; }
        }

        public Vector3 Rotation 
        {
            get { return rotation; }
            set { rotation = value; }
        }
        #endregion Properties

        public virtual void SetTranslationVector(Vector3 translationVector)
        {
            this.translationVector = translationVector;
        }

        public virtual void SetPosition(Vector3 position, Vector3 rotation)
        {
            this.position = position;
            this.rotation = rotation;
            if (rotation == Vector3.Zero)
            {
                transform = Matrix.CreateTranslation(position);
            }
            else
            {
                transform = Matrix.CreateRotationY(rotation.Y) * Matrix.CreateTranslation(position);
            }
        }

        public virtual void Update() {}

        public virtual void Draw(GraphicsDevice graphicsDevice, BasicEffect effect) {}

    }
}
