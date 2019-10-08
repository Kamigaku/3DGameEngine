using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Controllers
{
    public interface InputProcessor
    {

        #region Overridable method
        /// <summary>Called when a key was pressed</summary>
        /// <param name="key">Key pressed</param>
        void KeyDown(object sender, Keys key);

        /// <summary>Called when a key was released</summary>
        /// <param name="keycode">Key who was release</param>
        void KeyUp(object sender, Keys key);

        /// <summary>Called when a key was typed</summary>
        /// <param name="character">The character</param>
        void KeyTyped(object sender, Keys key);

        /// <summary>Called when the a mouse button was pressed.</summary>
        /// <param name="mouseState">The state of the current mouse</param>
        void MouseDown(object sender, MouseState mouseState);

        /// <summary>Called when the a mouse button was released.</summary>
        /// <param name="mouseState">The state of the current mouse</param>
        void MouseUp(object sender, MouseState mouseState);

        /// <summary>Called when the mouse was dragged.</summary>
        /// <param name="mouseState">The state of the current mouse</param>
        void MouseDragged(object sender, MouseState mouseState);

        /// <summary>Called when the mouse was moved without any buttons being pressed.</summary>
        /// <param name="mouseState">The state of the current mouse</param>
        void MouseMoved(object sender, MouseState mouseState);

        /// <summary>Called when the mouse wheel was scrolled up.</summary>
        /// <param name="mouseState">The state of the current mouse</param>
        void MouseWheelUp(object sender, MouseState mouseState);

        /// <summary>Called when the mouse wheel was scrolled down.</summary>
        /// <param name="mouseState">The state of the current mouse</param>
        void MouseWheelDown(object sender, MouseState mouseState);

        #endregion Overridable method
    }
}
