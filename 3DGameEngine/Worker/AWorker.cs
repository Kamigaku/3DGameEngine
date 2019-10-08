using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameEngine.Worker
{
    public abstract class AWorker
    {

        #region Member variables
        protected int RefreshingRate { get; }
        protected GameTime GameTime { get; }
        protected readonly Task _logicThread;
        protected readonly CancellationTokenSource _cancellationToken;
        #endregion Member variables

        #region Constructor
        protected AWorker(GameTime gameTime, int refreshingRate)
        {
            RefreshingRate = refreshingRate;
            GameTime = gameTime;
            _cancellationToken = new CancellationTokenSource();
            _logicThread = new Task(() =>
            {
                Update(GameTime);
            }, _cancellationToken.Token);
        }
        #endregion Constructor

        #region Overridable methods
        public virtual void Initialize() {}
        public virtual void Update(GameTime gameTime) {}
        public virtual void Draw() {}
        #endregion Overridable methods

    }
}
