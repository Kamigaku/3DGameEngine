using GameEngine.Camera;
using GameEngine.Entities;
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

            /*AEntity bloc = new Blob(new Vector3(0, 0, 5), Vector3.Zero, 1f, GraphicsDevice);
            bloc = ComponentFactory.AddCollision(bloc, 1, 1, 1);
            GameDatas.Entities.Add(bloc);

            AEntity mainPlayer = new Player(Vector3.Zero, Vector3.Zero, 1f, GraphicsDevice);
            mainPlayer = ComponentFactory.AddCollision(mainPlayer, 1, 1, 1);
            mainPlayer = ComponentFactory.AddMovement(mainPlayer, 0.05f, 0.05f);
            GameDatas.Entities.Add(mainPlayer);

            AEntity bloc2 = new Blob(new Vector3(0, 0, -5), Vector3.Zero, 1f, GraphicsDevice);
            bloc2 = ComponentFactory.AddCollision(bloc2, 1, 1, 1);
            GameDatas.Entities.Add(bloc2);*/

            AEntity bloc1 = new CollidableEntity(new Block(new Vector3(0, 0, 5), Vector3.Zero, 1, 1, 1, 1, GraphicsDevice), 
                                                 1, 1, 1);
            GameDatas.Entities.Add(bloc1);

            AEntity mainPlayer = new Player(new Block(new Vector3(0, 0, 0), Vector3.Zero, 1, 1, 1, 1, GraphicsDevice), 
                                                    1, 1, 1, new Vector3(0.05f), new Vector3(1f));
            GameDatas.Entities.Add(mainPlayer);

            AEntity bloc2 = new CollidableEntity(new Block(new Vector3(0, 0, -5), Vector3.Zero, 1, 1, 1, 1, GraphicsDevice),
                                                 1, 1, 1);
            GameDatas.Entities.Add(bloc2);

            GameDatas.MainCamera = new FPSCamera(GraphicsDevice, mainPlayer);

            AddInputProcessor(new PlayerController((MoveableEntity)mainPlayer));
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
