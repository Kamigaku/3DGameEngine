using GameEngine.Worker;
using Labyrinthe.Datas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe.Loops
{
    class GraphicsWorker : GameEngine.Worker.GraphicsWorker
    {

        #region Constructor
        /// <summary>
        /// Represent the Graphic loop that will render everything visual on screen.
        /// </summary>
        /// <param name="refreshingRate">The number of time the screen will refresh in a second. Can be set to less or equal than 0 for a non fixed timestamp</param>
        /// <param name="gameScreen">The game screen in which the graphic loop will render</param>
        public GraphicsWorker(int refreshingRate, Game gameScreen) : base(refreshingRate, gameScreen)
        {
        }
        #endregion Constructor

        #region Public methods
        public override void Initialize()
        {
            base.Initialize();

            Microsoft.Xna.Framework.Input.Mouse.SetPosition(GameDatas.Width / 2, GameDatas.Height / 2);
        }

        // This method should not be available here
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            GameDatas.MainCamera?.Update(gameTime);
        }

        public override void Draw()
        {
            base.Draw();
            _graphicDevice.Clear(Color.CornflowerBlue);
            GameDatas.MainCamera?.Draw(_basicEffect);
            for(int i = 0; i < GameDatas.Models.Count; i++)
            {
                GameDatas.Models[i].Draw(_graphicDevice, _basicEffect);
            }
        }
        #endregion Public methods

    }
}
