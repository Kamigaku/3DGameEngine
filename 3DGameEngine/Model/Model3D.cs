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
        protected VertexPositionColor[] vertices;
        protected VertexBuffer vertexBuffer;
        protected IndexBuffer indexBuffer;
        protected Vector3 translationVector;

        public Vector3 GetPosition()
        {
            return position;
        }

        public virtual void SetTranslationVector(Vector3 translationVector)
        {
            this.translationVector = translationVector;
        }
        public virtual void SetPosition(Vector3 position) {}

        public virtual void Update() {}


        public virtual void Draw(GraphicsDevice graphicsDevice, Effect effect)
        {
            /*graphicsDevice.SetVertexBuffer(vertexBuffer);
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, indices.Length / 3);
            }*/
        }

    }
}
