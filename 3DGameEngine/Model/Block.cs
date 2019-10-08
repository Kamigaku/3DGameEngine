using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Model
{
    public class Block : Model3D
    {

        private float _width;
        private float _height;
        private float _depth;

        private readonly int[] INDICES = new int[] // 6 faces, each containing 2 triangles of 3 vertices
        {
            0, 1, 2, 0, 2, 3, // front
            3, 2, 6, 3, 6, 7,
            4, 0, 3, 4, 3, 7,
            1, 5, 6, 1, 6, 2,
            4, 5, 1, 4, 1, 0,
            4, 7, 6, 4, 6, 5 // back
        };

        public Block(Vector3 position, float width, float height, float depth, GraphicsDevice graphicsDevice)
        {
            this.position = new Vector3(position.X, position.Y, position.Z);
            _width = width;
            _height = height;
            _depth = depth;



            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), 8, BufferUsage.WriteOnly);
            indexBuffer = new IndexBuffer(graphicsDevice, IndexElementSize.ThirtyTwoBits, INDICES.Length, BufferUsage.WriteOnly);

            SetPosition(this.position);
            SetTranslationVector(Vector3.Zero);
            indexBuffer.SetData(INDICES);
        }

        public Block(float x, float y, float z, float width, float height, float depth, GraphicsDevice graphicsDevice) : 
            this(new Vector3(x, y, z), width, height, depth, graphicsDevice) {}

        public override void SetPosition(Vector3 position)
        {
            // peut-être un petit problème sur le fait que la position soit le milieu du bloc et non le bas gauche (centre ?)
            this.position = position;
            vertices = new VertexPositionColor[]
            {
                    new VertexPositionColor(new Vector3(-(_width / 2) + this.position.X,  (_height / 2) + this.position.Y, -(_depth / 2) + this.position.Z), Color.Red), // top left
                    new VertexPositionColor(new Vector3(-(_width / 2) + this.position.X, -(_height / 2) + this.position.Y, -(_depth / 2) + this.position.Z), Color.Red), // bottom left
                    new VertexPositionColor(new Vector3( (_width / 2) + this.position.X, -(_height / 2) + this.position.Y, -(_depth / 2) + this.position.Z), Color.Red), // bottom right
                    new VertexPositionColor(new Vector3( (_width / 2) + this.position.X,  (_height / 2) + this.position.Y, -(_depth / 2) + this.position.Z), Color.Red), // top right
                    new VertexPositionColor(new Vector3(-(_width / 2) + this.position.X,  (_height / 2) + this.position.Y,  (_depth / 2) + this.position.Z), Color.Green),
                    new VertexPositionColor(new Vector3(-(_width / 2) + this.position.X, -(_height / 2) + this.position.Y,  (_depth / 2) + this.position.Z), Color.Green),
                    new VertexPositionColor(new Vector3( (_width / 2) + this.position.X, -(_height / 2) + this.position.Y,  (_depth / 2) + this.position.Z), Color.Green),
                    new VertexPositionColor(new Vector3( (_width / 2) + this.position.X,  (_height / 2) + this.position.Y,  (_depth / 2) + this.position.Z), Color.Green),
            };
            vertexBuffer.SetData(vertices);
        }

        public override void Update()
        {
            if (translationVector != Vector3.Zero)
            {
                SetPosition(position + translationVector);
            }
        }

        public override void Draw(GraphicsDevice graphicsDevice, Effect effect)
        {
            graphicsDevice.SetVertexBuffer(vertexBuffer);
            graphicsDevice.Indices = indexBuffer;
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, INDICES.Length / 3);
            }
        }

    }
}
