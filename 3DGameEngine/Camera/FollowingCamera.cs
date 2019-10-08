using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Controllers;
using GameEngine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Camera
{
    public class FollowingCamera : PerspectiveCamera
    {
        #region Constructor
        public FollowingCamera(GraphicsDevice graphicsDevice, IEntity target, float fov = 45, float distanceView = 1000, 
                               InputProcessor controller = null) : base(graphicsDevice, Vector3.Zero, Vector3.Zero, 0, fov, distanceView, controller)
        {
            camPosition = target.GetPosition();

            // WIP
        }
        #endregion Constructor

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
