using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * File name : EventArgs.cs
 * Author : Filipe
 * Date : 22/10/2013 17:58:48
 * Description :
 * 
*/

namespace MonoGame.UI
{
    /// <summary>
    /// MonoGame Event Args
    /// </summary>
    public class MonoGameEventArgs : EventArgs
    {
        public Control Control;

        public MonoGameEventArgs(Control control) 
        {
            this.Control = control;
        }
    }

    /// <summary>
    /// MonoGame Mouse Event Args class
    /// </summary>
    public class MonoGameMouseEventArgs : EventArgs
    {
        private MouseState MouseState;

        /// <summary>
        /// Get the LeftButton state
        /// </summary>
        public ButtonState LeftButton
        {
            get
            {
                return this.MouseState.LeftButton;
            }
        }

        /// <summary>
        /// Get the RightButton state
        /// </summary>
        public ButtonState RightButton
        {
            get
            {
                return this.MouseState.RightButton;
            }
        }

        /// <summary>
        /// Get the MiddleButton state
        /// </summary>
        public ButtonState MiddleButton
        {
            get
            {
                return this.MouseState.MiddleButton;
            }
        }

        /// <summary>
        /// Get the XButton1 state
        /// </summary>
        public ButtonState XButton1
        {
            get
            {
                return this.MouseState.XButton1;
            }
        }

        /// <summary>
        /// Get the XButton2 state
        /// </summary>
        public ButtonState XButton2
        {
            get
            {
                return this.MouseState.XButton2;
            }
        }

        /// <summary>
        /// Get the scroll wheel value
        /// </summary>
        public Int32 ScrollWheelValue
        {
            get
            {
                return this.MouseState.ScrollWheelValue;
            }
        }

        /// <summary>
        /// Get the X point of the mouse
        /// </summary>
        public Int32 X
        {
            get
            {
                return this.MouseState.X;
            }
        }
        
        /// <summary>
        /// Get the Y point of the mouse
        /// </summary>
        public Int32 Y
        {
            get
            {
                return this.MouseState.Y;
            }
        }

        public MonoGameMouseEventArgs(MouseState mouseState)
        {
            this.MouseState = mouseState;
        }
    }
}
