using GameEngine.Camera;
using GameEngine.Model;
using Labyrinthe.Controllers;
using Labyrinthe.Datas;
using Labyrinthe.Entities;
using Labyrinthe.Loops;
using Labyrinthe.Model;
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

            Blob bloc = new Blob(new Vector3(0, 0, 5), Vector3.Zero, 1f, 0, GraphicsDevice);
            GameDatas.Entities.Add(bloc);
            Player mainPlayer = new Player(Vector3.Zero, Vector3.Zero, 1f, 0.05f, GraphicsDevice);
            GameDatas.Entities.Add(mainPlayer);
            Blob bloc2 = new Blob(new Vector3(0, 0, -5), Vector3.Zero, 1f, 0, GraphicsDevice);
            GameDatas.Entities.Add(bloc2);

            GameDatas.MainCamera = new FPSCamera(GraphicsDevice, mainPlayer);

            AddInputProcessor(new PlayerController(mainPlayer));
            AddInputProcessor(new FPSCameraController(GameDatas.MainCamera));

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
