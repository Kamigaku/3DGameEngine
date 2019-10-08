using GameEngine.Controllers;
using GameEngine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe.Controllers
{
    public class PlayerController : InputProcessor
    {

        #region Member fields
        private readonly MoveableEntity _assignedEntity;
        private Vector3 _translationVector;
        #endregion Member fields

        public PlayerController(MoveableEntity assignedEntity)
        {
            _assignedEntity = assignedEntity;
        }

        public void KeyDown(object sender, Keys key)
        {
            Console.WriteLine("[Player controller] Key down");
            switch (key)
            {
                case Keys.Z:
                    _translationVector.Z += 1;
                    break;
                case Keys.S:
                    _translationVector.Z -= 1;
                    break;
                case Keys.Q:
                    _translationVector.X += 1;
                    break;
                case Keys.D:
                    _translationVector.X -= 1;
                    break;
            }
            _assignedEntity.SetTranslationVector(_translationVector);
        }

        public void KeyUp(object sender, Keys key)
        {
            switch (key)
            {
                case Keys.Z:
                    _translationVector.Z -= 1;
                    break;
                case Keys.S:
                    _translationVector.Z += 1;
                    break;
                case Keys.Q:
                    _translationVector.X -= 1;
                    break;
                case Keys.D:
                    _translationVector.X += 1;
                    break;
            }

            _assignedEntity.SetTranslationVector(_translationVector);
        }

        public void KeyTyped(object sender, Keys key) {}


        public void MouseDown(object sender, MouseState mouseState) {}

        public void MouseDragged(object sender, MouseState mouseState) {}

        public void MouseMoved(object sender, MouseState mouseState) {}

        public void MouseUp(object sender, MouseState mouseState) {}

        public void MouseWheelDown(object sender, MouseState mouseState) {}

        public void MouseWheelUp(object sender, MouseState mouseState) {}
    }
}
