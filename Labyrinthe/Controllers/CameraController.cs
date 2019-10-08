using GameEngine.Camera;
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
    public class CameraController : InputProcessor
    {

        #region Member fields
        private bool _moveCamera; // To remove later, only usefull because camera is automaticaly recentered
        private readonly ACamera _assignedCamera;
        private Vector3 _translationVector;
        #endregion Member fields

        #region Constructor
        public CameraController(ACamera camera)
        {
            _assignedCamera = camera;
            _moveCamera = true;
            _translationVector = Vector3.Zero;
        }
        #endregion Constructor

        #region Private methods
        public void KeyDown(object sender, Keys key)
        {
            Console.WriteLine("[Camera controller] Key down");
            /*switch (key)
            {
                case Keys.Z:
                    _translationVector.Z += 1;
                    break;
                case Keys.S:
                    _translationVector.Z += -1;
                    break;
                case Keys.Q:
                    _translationVector.X += 1;
                    break;
                case Keys.D:
                    _translationVector.X += -1;
                    break;
                case Keys.Escape:
                    _moveCamera = !_moveCamera;
                    break;
            }
            _assignedCamera.SetPositionTranslateVector(_translationVector);*/
        }

        public void KeyUp(object sender, Keys key)
        {
            /*switch (key)
            {
                case Keys.Z:
                    _translationVector.Z -= 1;
                    break;
                case Keys.S:
                    _translationVector.Z -= -1;
                    break;
                case Keys.Q:
                    _translationVector.X -= 1;
                    break;
                case Keys.D:
                    _translationVector.X -= -1;
                    break;
            }

            _assignedCamera.SetPositionTranslateVector(_translationVector);
            Console.WriteLine(_assignedCamera);*/
        }

        public void KeyTyped(object sender, Keys key) {}

        public void MouseDown(object sender, MouseState mouseState) {}

        public void MouseUp(object sender, MouseState mouseState) {}

        public void MouseDragged(object sender, MouseState mouseState) {}

        public void MouseMoved(object sender, MouseState mouseState)
        {
            if (_moveCamera)
            {
                Vector2 vectorMousePosition = new Vector2(mouseState.X - (GameDatas.Width / 2),
                                                          mouseState.Y - (GameDatas.Height / 2));
                _assignedCamera.SetCameraRotation(vectorMousePosition);
                Mouse.SetPosition(GameDatas.Width / 2, GameDatas.Height / 2);
            }
        }

        public void MouseWheelUp(object sender, MouseState mouseState)
        {
            //_translationVector.Z = -1f;
            _assignedCamera.Zoom(-1);
            //_assignedCamera.SetTranslationVector(_translationVector);
            // appeler une méthode "zoom" plutot ? ou un boolean à true ?
        }

        public void MouseWheelDown(object sender, MouseState mouseState)
        {
            _assignedCamera.Zoom(1);
            //_translationVector.Z = 1f;
            //_assignedCamera.SetTranslationVector(_translationVector);
        }
        #endregion Private methods

    }
}
