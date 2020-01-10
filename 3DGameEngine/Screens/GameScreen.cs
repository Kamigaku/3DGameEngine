using GameEngine.Controllers;
using GameEngine.Input;
using GameEngine.Worker;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Screens
{
    public class GameScreen : Game
    {

        #region Properties
        public GraphicsDeviceManager Graphics
        {
            get { return _graphics; }
        }
        #endregion Properties

        #region Member fields
        private GraphicsDeviceManager _graphics;
        private GameInput _input;
        private List<AWorker> _workers;
        #endregion Member fields

        public GameScreen()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.SynchronizeWithVerticalRetrace = false;
            _graphics.PreparingDeviceSettings += (sender, e) =>
            {
                e.GraphicsDeviceInformation.PresentationParameters.PresentationInterval = PresentInterval.Immediate;
            };
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            _workers = new List<AWorker>();
            _input = new GameInput();
            IsMouseVisible = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //Console.WriteLine(gameTime.ElapsedGameTime.Ticks + "ms.");
            _input.Update();
            /*for(int i = 0; i < _workers.Count; i++)
            {
                _workers[i].Update(gameTime);
            }*/
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            base.Draw(gameTime);
            for (int i = 0; i < _workers.Count; i++)
            {
                _workers[i].Draw();
            }
        }

        #region Public methods
        /// <summary>
        /// Add a loop that need to be updated and draw. See <see cref="AWorker"/> for more information about worker.
        /// </summary>
        /// <param name="worker">The loop to add</param>
        /// <param name="duplicateCheck"></param>
        /// <returns></returns>
        public bool AddWorker(AWorker worker, bool duplicateCheck = false)
        {
            if(duplicateCheck)
            {
                for(int i = 0; i < _workers.Count; i++)
                {
                    if(_workers[i].GetType() == worker.GetType())
                    {
                        return false;
                    }
                }
            }
            _workers.Add(worker);
            worker.Initialize();
            return true;
        }

        /// <summary>
        /// Add an input processor to the scene that will be updated
        /// </summary>
        /// <param name="inputProcessor">The input processor to add</param>
        public void AddInputProcessor(InputProcessor inputProcessor)
        {
            _input.OnKeyDown += inputProcessor.KeyDown;
            _input.OnKeyUp += inputProcessor.KeyUp;
            _input.OnMouseButtonDown += inputProcessor.MouseDown;
            _input.OnMouseButtonUp += inputProcessor.MouseUp;
            _input.OnMouseWheelDown += inputProcessor.MouseWheelDown;
            _input.OnMouseWheelUp += inputProcessor.MouseWheelUp;
            _input.OnMouseMoved += inputProcessor.MouseMoved;
            _input.OnMouseDragged += inputProcessor.MouseDragged;
        }
        #endregion Public methods
    }
}