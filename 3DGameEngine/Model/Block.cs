using GameEngine.Model;
using GameEngine.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Labyrinthe.Model
{
    public class Block : Model3D
    {

        // BoundingBox : not used for the moment
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

        public Block(Vector3 initialPosition, Vector3 initialRotation, float width, float height, float depth, float scaling, GraphicsDevice graphicsDevice)
        {
            SetTransform(initialPosition, initialRotation, scaling);

            _width = width;
            _height = height;
            _depth = depth;

            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), 8, BufferUsage.WriteOnly);
            indexBuffer = new IndexBuffer(graphicsDevice, IndexElementSize.ThirtyTwoBits, INDICES.Length, BufferUsage.WriteOnly);

            CreateBlock();

            indexBuffer.SetData(INDICES);
        }

        private void CreateBlock()
        {
            vertices = new VertexPositionColor[]
            {
                    new VertexPositionColor(new Vector3(-_width / 2,  _height / 2, -_depth / 2), Color.Red), // top left
                    new VertexPositionColor(new Vector3(-_width / 2, -_height / 2, -_depth / 2), Color.Red), // bottom left
                    new VertexPositionColor(new Vector3( _width / 2, -_height / 2, -_depth / 2), Color.Red), // bottom right
                    new VertexPositionColor(new Vector3( _width / 2,  _height / 2, -_depth / 2), Color.Red), // top right
                    new VertexPositionColor(new Vector3(-_width / 2,  _height / 2,  _depth / 2), Color.Green),
                    new VertexPositionColor(new Vector3(-_width / 2, -_height / 2,  _depth / 2), Color.Green),
                    new VertexPositionColor(new Vector3( _width / 2, -_height / 2,  _depth / 2), Color.Green),
                    new VertexPositionColor(new Vector3( _width / 2,  _height / 2,  _depth / 2), Color.Green),
            };
            vertexBuffer.SetData(vertices);
        }

        /// <summary>
        /// Update fired from the <see cref="GameEngine.Worker.PhysicsWorker"/> logic.
        /// </summary>
        public override void Update()
        {
            if(rotationVector != Vector3.Zero)
            {
                worldRotation *= Matrix.CreateFromYawPitchRoll(rotationVector.X, rotationVector.Y, rotationVector.Z);
            }

            if(translationVector != Vector3.Zero)
            {
                worldPosition *= Matrix.CreateTranslation((translationVector.X * worldRotation.Left) 
                                                          + (translationVector.Y * worldRotation.Up) 
                                                          + (translationVector.Z * worldRotation.Forward));
            }
            GameEngine.Logging.Logger.Log(GameEngine.Logging.Logger.LogLevel.DEBUG, "Rot: " + worldRotation.Forward + " / Pos: " + worldPosition.Forward + " / World: " + World.Forward);
        }

        /// <summary>
        /// Draw fired from the <see cref="GameEngine.Worker.GraphicsWorker"/> logic.
        /// </summary>
        /// <param name="graphicsDevice">The graphic device that will render the model</param>
        /// <param name="effect">The effect that will be used to render the model</param>
        public override void Draw(GraphicsDevice graphicsDevice, BasicEffect effect)
        {
            graphicsDevice.SetVertexBuffer(vertexBuffer);
            graphicsDevice.Indices = indexBuffer;
            effect.World = World;
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, INDICES.Length / 3);
            }
        }
    }
}