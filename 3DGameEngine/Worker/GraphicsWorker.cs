using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Worker
{
    public class GraphicsWorker
    {

        #region Member fields
        protected readonly GraphicsDevice _graphicDevice;
        protected BasicEffect _basicEffect;
        #endregion Member fields

        public GraphicsWorker(int refreshingRate, Game gameScreen)
        {
            if (refreshingRate > 0)
            {
                gameScreen.IsFixedTimeStep = true;
                gameScreen.TargetElapsedTime = TimeSpan.FromMilliseconds(1000d / refreshingRate);
            }
            else
            {
                // Cette ligne pose problème avec la classe GameInput => elle lag avec un FixedTimeStep à false
                gameScreen.IsFixedTimeStep = false;
            }
            _graphicDevice = gameScreen.GraphicsDevice;

        }

        public virtual void Initialize()
        {
            //BasicEffect
            _basicEffect = new BasicEffect(_graphicDevice);
            _basicEffect.Alpha = 1f;

            // Want to see the colors of the vertices, this needs to be on
            _basicEffect.VertexColorEnabled = true;

            //Lighting requires normal information which VertexPositionColor does not have
            //If you want to use lighting and VPC you need to create a custom def
            _basicEffect.LightingEnabled = false;
        }
        public virtual void Draw() {}

        public virtual void Update(GameTime gameTime) {}
    }
}
