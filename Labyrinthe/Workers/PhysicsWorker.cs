using GameEngine.Logging;
using Labyrinthe.Datas;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Labyrinthe.Workers
{
    public class PhysicsWorker : GameEngine.Worker.PhysicsWorker
    {

        public PhysicsWorker(GameTime gameTime, int refreshingRate) : base(gameTime, refreshingRate) {}

        public override void Initialize()
        {
            _logicThread.Start();
        }

        public override void Update(GameTime gameTime) // Il faudrait peut-être supprimer le paramètre ?
        {
            //GameTime gameTime = new GameTime();
            Logger.Log(Logger.LogLevel.DEBUG, "Starting PhysicsLoop thread");
            while (true)
            {
                DateTime startTime = DateTime.Now;

                //GameDatas.MainCamera?.Update(gameTime);
                for (int i = 0; i < GameDatas.Entities.Count; i++)
                {
                    GameDatas.Entities[i].Update(/*gameTime.ElapsedGameTime.TotalSeconds*/);
                }

                Thread.Sleep(1000 / RefreshingRate);
                DateTime endTime = DateTime.Now;
                TimeSpan timeSpend = endTime - startTime;
                gameTime.ElapsedGameTime = timeSpend;
                gameTime.TotalGameTime.Add(timeSpend);
                //Logger.Log(Logger.LogLevel.DEBUG, "Updating PhysicsLoop took " + gameTime.ElapsedGameTime.Milliseconds + "ms.");
            }
            Logger.Log(Logger.LogLevel.DEBUG, "End PhysicsLoop thread");
        }

    }
}
