using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace TestProject
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        //GameInput gameInput;
        Camera camera;
        Floor floor;
        BasicEffect effect;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //gameInput = new GameInput();
        }

        protected override void Initialize()
        {
            camera = new Camera(this, new Vector3(10f, 1f, 5f), Vector3.Zero, 5f);
            Components.Add(camera);
            floor = new Floor(GraphicsDevice, 20, 20);
            effect = new BasicEffect(GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent() { }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
            //gameInput.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            floor.Draw(camera, effect);
            base.Draw(gameTime);
        }
    }

    /*public class GameInput
    {
        public bool _dKeyPressed = false;
        public Color backgroundColor = Color.CornflowerBlue;

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.D))
            {
                if (!_dKeyPressed)
                {
                    //NonBlockingConsole.WriteLine("[GameInput] D key is pressed.");
                    Console.Out.Flush();
                    Console.WriteLine("[GameInput] D key is pressed.");
                    backgroundColor = Color.Red;
                }
                _dKeyPressed = true;
            }
            else if (_dKeyPressed)
            {
                backgroundColor = Color.CornflowerBlue;
                //NonBlockingConsole.WriteLine("[GameInput] D key is released.");
                Console.WriteLine("[GameInput] D key is released.");
                Console.Out.Flush();
                _dKeyPressed = false;
            }
        }
    }*/

    public static class NonBlockingConsole
    {
        private static BlockingCollection<string> m_Queue = new BlockingCollection<string>();

        static NonBlockingConsole()
        {
            var thread = new Thread(
              () =>
              {
                  while (true) Console.WriteLine(m_Queue.Take());
              });
            thread.IsBackground = true;
            thread.Start();
        }

        public static void WriteLine(string value)
        {
            m_Queue.Add(value);
        }
    }
}