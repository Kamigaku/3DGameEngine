using GameEngine.Camera;
using GameEngine.Model;
using Labyrinthe.Controllers;
using Labyrinthe.Datas;
using Labyrinthe.Entities;
using Labyrinthe.Loops;
using Labyrinthe.Workers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Labyrinthe.Screens
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameScreen : GameEngine.Screens.GameScreen
    {
        #region Member fields
        private GraphicsWorker _graphicsWorker;
        #endregion Member fields

        public GameScreen()
        {
            _graphicsWorker = new GraphicsWorker(0, this);
            AddWorker(new PhysicsWorker(new GameTime(), 60));
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
            _graphicsWorker.Initialize();
            GameDatas.MainCamera = new PerspectiveCamera(GraphicsDevice, Vector3.Zero, new Vector3(0, 0, -10f), 5f);
            AddInputProcessor(new CameraController(GameDatas.MainCamera));
            GameDatas.Models.Add(new Block(1, 0, 1, 1, 1, 1, GraphicsDevice)); // va disparaitre plus tard

            Player mainPlayer = new Player(new Vector3(0, 0, -5), 0.05f, GraphicsDevice);
            GameDatas.Entities.Add(mainPlayer);
            AddInputProcessor(new PlayerController(mainPlayer));


            //new Labyrinthe.World.World();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _graphicsWorker.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {            
            base.Draw(gameTime);
            _graphicsWorker.Draw();
        }
    }
}
