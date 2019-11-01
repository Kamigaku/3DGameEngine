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
        public PerspectiveCamera(GraphicsDevice graphicsDevice, Vector3 target, Vector3 position, float speed, float fov = 45f, float distanceView = 1000f, InputProcessor controller = null) 
            : base(target, position, speed)
        {
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(fov), graphicsDevice.DisplayMode.AspectRatio, 0.7f, distanceView);
        }
    }
}
