using GameEngine.Logging;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameEngine.Worker
{
    public class PhysicsWorker : AWorker
    {

        public PhysicsWorker(GameTime gameTime, int refreshingRate) : base(gameTime, refreshingRate) {}

        #region Public methods
        public override void Initialize()
        {
            _logicThread.Start();
        }

        /// <summary>
        /// Stop the physics loop
        /// </summary>
        public void Stop()
        {
            Logger.Log(Logger.LogLevel.DEBUG, "Stopping PhysicsLoop thread.");
            _cancellationToken.Cancel(); 
            Logger.Log(Logger.LogLevel.DEBUG, "PhysicsLoop thread has stopped.");
        }
        #endregion Public methods

    }
}
