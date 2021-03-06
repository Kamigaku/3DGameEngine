﻿using GameEngine.Camera;
using GameEngine.Controllers;
using Labyrinthe.Datas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe.Controllers
{
    public class FPSCameraController : InputProcessor
    {

        #region Member fields
        private bool _moveCamera; // To remove later, only usefull because camera is automaticaly recentered
        private readonly ACamera _assignedCamera;
        #endregion Member fields

        #region Constructor
        public FPSCameraController(ACamera camera)
        {
            _assignedCamera = camera;
            _moveCamera = true;
        }
        #endregion Constructor

        #region Private methods
        public void KeyDown(object sender, Keys key) {}

        public void KeyUp(object sender, Keys key) {}

        public void KeyTyped(object sender, Keys key) {}

        public void MouseDown(object sender, MouseState mouseState) {}

        public void MouseUp(object sender, MouseState mouseState) {}

        public void MouseDragged(object sender, MouseState mouseState) {}

        public void MouseMoved(object sender, MouseState mouseState)
        {
            if (_moveCamera)
            {
                Vector3 vectorMousePosition = new Vector3((GameDatas.Height / 2) - mouseState.Y,
                                                          (GameDatas.Width / 2) - mouseState.X,
                                                          0f);
                _assignedCamera.Transform.SetRotationVelocity(vectorMousePosition);
                Mouse.SetPosition(GameDatas.Width / 2, GameDatas.Height / 2);
            }
        }

        public void MouseWheelUp(object sender, MouseState mouseState) {}

        public void MouseWheelDown(object sender, MouseState mouseState) {}
        #endregion Private methods

    }
}
