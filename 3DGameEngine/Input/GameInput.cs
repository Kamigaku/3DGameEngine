using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Input
{
    public class GameInput
    {

        #region Events
        public event EventHandler<Keys> OnKeyDown;
        public event EventHandler<Keys> OnKeyUp;
        public event EventHandler<MouseState> OnMouseButtonUp;
        public event EventHandler<MouseState> OnMouseButtonDown;
        public event EventHandler<MouseState> OnMouseWheelUp;
        public event EventHandler<MouseState> OnMouseWheelDown;
        public event EventHandler<MouseState> OnMouseMoved;
        public event EventHandler<MouseState> OnMouseDragged;
        #endregion Events

        #region Field variables
        private Keys[] _pressedKeys;
        private ButtonState _previousLeftButtonState;
        private ButtonState _previousRightButtonState;
        private int _previousScrollValue;
        private Point _previousMousePosition;
        #endregion Field variables

        #region Constructor
        public GameInput()
        {
            _pressedKeys = new Keys[0];
            _previousLeftButtonState = ButtonState.Released;
            _previousRightButtonState = ButtonState.Released;
            _previousScrollValue = Mouse.GetState().ScrollWheelValue;
            _previousMousePosition = Mouse.GetState().Position;
        }
        #endregion Constructor

        #region Public methods
        public void Update()
        {
            #region Keybaord
            KeyboardState keyboardState = Keyboard.GetState();
            Keys[] keyPressed = keyboardState.GetPressedKeys();
            IEnumerable<Keys> keyJustPressed = keyPressed.Where(key => !_pressedKeys.Any(k => k == key));

            foreach (Keys key in keyJustPressed)
            {
                OnKeyDown?.Invoke(null, key);
            }

            IEnumerable<Keys> keyJustUpped = _pressedKeys.Where(key => !keyPressed.Any(k => k == key));

            foreach (Keys key in keyJustUpped)
            {
                OnKeyUp?.Invoke(null, key);
            }
            _pressedKeys = keyPressed;
            #endregion Keybaord

            #region Mouse
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton != _previousLeftButtonState)
            {
                _previousLeftButtonState = mouseState.LeftButton;
                if (_previousLeftButtonState == ButtonState.Pressed)
                {
                    OnMouseButtonDown?.Invoke(this, mouseState);
                }
                else
                {
                    OnMouseButtonUp?.Invoke(this, mouseState);
                }
            }

            if (mouseState.RightButton != _previousRightButtonState)
            {
                _previousRightButtonState = mouseState.RightButton;
                if (_previousRightButtonState == ButtonState.Pressed)
                {
                    OnMouseButtonDown?.Invoke(this, mouseState);
                }
                else
                {
                    OnMouseButtonUp?.Invoke(this, mouseState);
                }
            }

            if (mouseState.ScrollWheelValue != _previousScrollValue)
            {
                if (mouseState.ScrollWheelValue < _previousScrollValue)
                {
                    OnMouseWheelUp?.Invoke(this, mouseState);
                }
                else
                {
                    OnMouseWheelDown?.Invoke(this, mouseState);
                }
                _previousScrollValue = mouseState.ScrollWheelValue;
            }

            if(mouseState.Position != _previousMousePosition)
            {
                OnMouseMoved?.Invoke(this, mouseState);
                if(mouseState.LeftButton == ButtonState.Pressed)
                {
                    OnMouseDragged?.Invoke(this, mouseState);
                }
            }

            _previousMousePosition = mouseState.Position;
            #endregion Mouse
        }
        #endregion Public methods

    }
}
