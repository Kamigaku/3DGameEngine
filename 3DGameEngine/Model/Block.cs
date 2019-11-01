using GameEngine.Model;
using GameEngine.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Labyrinthe.Model
{
    public class Block : Model3D
    {

        // BoundingBox 

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

        public Block(Vector3 position, Vector3 rotation, float width, float height, float depth, GraphicsDevice graphicsDevice)
        {
            this.position = new Vector3(position.X, position.Y, position.Z);
            this.rotation = rotation;
            _width = width;
            _height = height;
            _depth = depth;

            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), 8, BufferUsage.WriteOnly);
            indexBuffer = new IndexBuffer(graphicsDevice, IndexElementSize.ThirtyTwoBits, INDICES.Length, BufferUsage.WriteOnly);

            CreateBlock();
            SetPosition(this.position, this.rotation);
            SetTranslationVector(Vector3.Zero);
            indexBuffer.SetData(INDICES);
        }

        private void CreateBlock()
        {
            vertices = new VertexPositionColor[]
            {
                    new VertexPositionColor(new Vector3(-(_width / 2) + position.X,  (_height / 2) + position.Y, -(_depth / 2) + position.Z), Color.Red), // top left
                    new VertexPositionColor(new Vector3(-(_width / 2) + position.X, -(_height / 2) + position.Y, -(_depth / 2) + position.Z), Color.Red), // bottom left
                    new VertexPositionColor(new Vector3( (_width / 2) + position.X, -(_height / 2) + position.Y, -(_depth / 2) + position.Z), Color.Red), // bottom right
                    new VertexPositionColor(new Vector3( (_width / 2) + position.X,  (_height / 2) + position.Y, -(_depth / 2) + position.Z), Color.Red), // top right
                    new VertexPositionColor(new Vector3(-(_width / 2) + position.X,  (_height / 2) + position.Y,  (_depth / 2) + position.Z), Color.Green),
                    new VertexPositionColor(new Vector3(-(_width / 2) + position.X, -(_height / 2) + position.Y,  (_depth / 2) + position.Z), Color.Green),
                    new VertexPositionColor(new Vector3( (_width / 2) + position.X, -(_height / 2) + position.Y,  (_depth / 2) + position.Z), Color.Green),
                    new VertexPositionColor(new Vector3( (_width / 2) + position.X,  (_height / 2) + position.Y,  (_depth / 2) + position.Z), Color.Green),
            };
            vertexBuffer.SetData(vertices);
        }

        public override void Update()
        {
            if (translationVector != Vector3.Zero || rotation != Vector3.Zero) // a changer ici
            {
                SetPosition(position + translationVector, rotation);
            }
        }

        public override void Draw(GraphicsDevice graphicsDevice, BasicEffect effect)
        {
            graphicsDevice.SetVertexBuffer(vertexBuffer);
            graphicsDevice.Indices = indexBuffer;
            effect.World = transform;
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, INDICES.Length / 3);
            }
        }
    }
}