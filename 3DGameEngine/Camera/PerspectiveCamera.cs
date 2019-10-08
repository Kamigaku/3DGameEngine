using GameEngine.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Camera
{
    public class PerspectiveCamera : ACamera
    {
        #region Member fields
        private Matrix _projectionMatrix;
        #endregion Member fields

        public PerspectiveCamera(GraphicsDevice graphicsDevice, Vector3 target, Vector3 position, float speed, float fov = 45f, float distanceView = 1000f, InputProcessor controller = null) 
            : base(target, position, speed)
        {
            _projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(fov), graphicsDevice.DisplayMode.AspectRatio, 0.05f, distanceView);
        }

        public override void Draw(BasicEffect basicEffect)
        {
            base.Draw(basicEffect);
            basicEffect.Projection = _projectionMatrix;
            basicEffect.View = View;
            basicEffect.World = Matrix.Identity;
        }        

    }
}
