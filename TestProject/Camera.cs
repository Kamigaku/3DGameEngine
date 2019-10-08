using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class Camera : GameComponent
    {
        private Vector3 cameraPosition;
        private Vector3 cameraRotation;
        private float cameraSpeed;
        private Vector3 cameraLookAt;
        private Vector3 mouseRotationBuffer;
        private MouseState currentMouseState;
        private MouseState prevMouseState;

        public Vector3 Position 
        {
            get { return cameraPosition; }        
            set 
            {
                cameraPosition = value;
                UpdateLookAt();
            }
        }

        public Vector3 Rotation {
            get { return cameraRotation; }
            set {
                cameraRotation = value;
                UpdateLookAt();
            }
        }


        public Matrix Projection 
        {
            get;
            protected set;
        }

        public Matrix View 
        {
            get 
            {
                return Matrix.CreateLookAt(cameraPosition, cameraLookAt, Vector3.Up);
            }
        }

        public Camera(Game game, Vector3 position, Vector3 rotation, float speed) : base(game)
        {
            cameraSpeed = speed;
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                             Game.GraphicsDevice.Viewport.AspectRatio,
                                                             0.05f,
                                                             1000.0f);
            MoveTo(position, rotation);

            prevMouseState = Mouse.GetState();
        }

        private void MoveTo(Vector3 pos, Vector3 rot)
        {
            Position = pos;
            Rotation = rot;
        }

        private void UpdateLookAt()
        {
            Matrix rotationMatrix = Matrix.CreateRotationX(cameraRotation.X) * Matrix.CreateRotationY(cameraRotation.Y);
            Vector3 lookAtOffset = Vector3.Transform(Vector3.UnitZ, rotationMatrix);
            cameraLookAt = cameraPosition + lookAtOffset;
        }

        private Vector3 PreviewMove(Vector3 amount)
        {
            Matrix rotate = Matrix.CreateRotationY(cameraRotation.Y);
            Vector3 movement = new Vector3(amount.X, amount.Y, amount.Z);
            movement = Vector3.Transform(movement, rotate);
            return cameraPosition + movement;
        }

        private void Move(Vector3 scale)
        {
            MoveTo(PreviewMove(scale), Rotation);
        }

        public override void Update(GameTime gameTime)
        {

            currentMouseState = Mouse.GetState();

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            KeyboardState ks = Keyboard.GetState();
            Vector3 moveVector = Vector3.Zero;

            if (ks.IsKeyDown(Keys.Z))
                moveVector.Z = 1;
            if (ks.IsKeyDown(Keys.S))
                moveVector.Z = -1;
            if (ks.IsKeyDown(Keys.Q))
                moveVector.X = 1;
            if (ks.IsKeyDown(Keys.D))
                moveVector.X = -1;

            if(moveVector != Vector3.Zero)
            {
                moveVector.Normalize();
                moveVector *= dt * cameraSpeed;
                Move(moveVector);
            }

            float deltaX;
            float deltaY;

            if(currentMouseState != prevMouseState)
            {
                deltaX = currentMouseState.X - (Game.GraphicsDevice.Viewport.Width / 2);
                deltaY = currentMouseState.Y - (Game.GraphicsDevice.Viewport.Height / 2);

                mouseRotationBuffer.X -= 0.01f * deltaX * dt;
                mouseRotationBuffer.Y -= 0.01f * deltaY * dt;

                if (mouseRotationBuffer.Y < MathHelper.ToRadians(-75.0f))
                    mouseRotationBuffer.Y = mouseRotationBuffer.Y - (mouseRotationBuffer.Y - MathHelper.ToRadians(-75.0f));
                if (mouseRotationBuffer.Y > MathHelper.ToRadians(75.0f))
                    mouseRotationBuffer.Y = mouseRotationBuffer.Y - (mouseRotationBuffer.Y - MathHelper.ToRadians(75.0f));

                Rotation = new Vector3(-MathHelper.Clamp(
                                            mouseRotationBuffer.Y, 
                                            MathHelper.ToRadians(-75.0f), 
                                            MathHelper.ToRadians(75.0f)), 
                                        MathHelper.WrapAngle(mouseRotationBuffer.X), 
                                        0);
                deltaX = 0;
                deltaY = 0;

            }

            Mouse.SetPosition(Game.GraphicsDevice.Viewport.Width / 2, Game.GraphicsDevice.Viewport.Height / 2);

            prevMouseState = currentMouseState;

            base.Update(gameTime);
        }
    }
}
