using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * File name : MouseHelper.cs
 * Author : Filipe
 * Date : 20/10/2013 20:52:21
 * Description :
 * 
*/

namespace MonoGame.UI
{
    public class MouseHelper
    {
        #region FIELDS

        public enum MouseButtons { Left, Right, Middle }
        public static MouseState lastMouseState;
        public static Boolean mouseUp = false;
        public static Boolean mouseDown = false;
        public static Boolean firstMouseDown = false;

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS

        /// <summary>
        /// Update Last mouse position
        /// </summary>
        /// <param name="mouseState">Previous MouseState</param>
        public static void UpdateLastMousePosition(MouseState mouseState)
        {
            lastMouseState = mouseState;
        }

        /// <summary>
        /// Convert the MousePosition to a Microsoft.Xna.Framework.Vector2 object
        /// </summary>
        /// <param name="mouseState">Current MouseState</param>
        /// <returns>New vector2 mouse position</returns>
        public static Vector2 MousePositionAsVector2(MouseState mouseState)
        {
            return new Vector2(mouseState.X, mouseState.Y);
        }

        /// <summary>
        /// Convert the LastMousePosition to a Microsoft.Xna.Framework.Vector2 object
        /// </summary>
        /// <param name="lastMouseState">LastMouseState</param>
        /// <returns>New vector2 mouse posisiton</returns>
        public static Vector2 LastMousePositionAsVector2(MouseState lastMouseState)
        {
            return new Vector2(lastMouseState.X, lastMouseState.Y);
        }

        /// <summary>
        /// Convert the MousePosition to a Microsoft.Xna.Framework.Point object
        /// </summary>
        /// <param name="mouseState">MouseState</param>
        /// <returns>New Microsoft.Xna.Framework.Point mouse position</returns>
        public static Point MousePositionAsPoint(MouseState mouseState)
        {
            return new Point(mouseState.X, mouseState.Y);
        }

        /// <summary>
        /// Convert the MousePosition to a Microsoft.Xna.Framework.Point object
        /// </summary>
        /// <param name="lastMouseState"></param>
        /// <returns></returns>
        public static Point LastMousePositionAsPoint(MouseState lastMouseState)
        {
            return new Point(lastMouseState.X, lastMouseState.Y);
        }

        /// <summary>
        /// Check if Mouse position is in rectangle
        /// </summary>
        /// <param name="mouseState">MouseState</param>
        /// <param name="rectangle">Rectangle</param>
        /// <returns>In rectangle or not</returns>
        public static Boolean IsMouseInRectangle(MouseState mouseState, Rectangle rectangle)
        {
            return rectangle.Contains(MousePositionAsPoint(mouseState));
        }

        /// <summary>
        /// Check if the Mouse button is pressed
        /// </summary>
        /// <param name="state">MouseState</param>
        /// <returns></returns>
        public static Boolean IsMousePress(MouseState mouseState, MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left: return mouseState.LeftButton == ButtonState.Pressed;
                case MouseButtons.Right: return mouseState.RightButton == ButtonState.Pressed;
                case MouseButtons.Middle: return mouseState.MiddleButton == ButtonState.Pressed;
            }
            return false;
        }

        /// <summary>
        /// Check if the Mouse button is Realased
        /// </summary>
        /// <param name="state">Mouse State</param>
        /// <returns></returns>
        public static Boolean IsMouseReleased(MouseState mouseState, MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left: return mouseState.LeftButton == ButtonState.Released;
                case MouseButtons.Right: return mouseState.RightButton == ButtonState.Released;
                case MouseButtons.Middle: return mouseState.MiddleButton == ButtonState.Released;
            }
            return false;
        }

        /// <summary>
        /// Return the value if the mouse button is clicked.
        /// </summary>
        /// <param name="mouseState">Mouse State</param>
        /// <param name="button">Mouse button</param>
        /// <returns></returns>
        public static Boolean IsMouseClick(MouseState mouseState, MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    return mouseState.LeftButton == ButtonState.Released &&
                           lastMouseState.LeftButton == ButtonState.Pressed;
                case MouseButtons.Right:
                    return mouseState.RightButton == ButtonState.Released &&
                           lastMouseState.RightButton == ButtonState.Pressed;
                case MouseButtons.Middle:
                    return mouseState.MiddleButton == ButtonState.Released &&
                           lastMouseState.MiddleButton == ButtonState.Pressed;
            }

            return false;
        }

        /// <summary>
        /// Update mouse states
        /// </summary>
        /// <param name="mouseState"></param>
        public static void UpdateMouse(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && mouseDown == false)
            {
                mouseDown = true;
                firstMouseDown = true;
            }
            else if (mouseState.LeftButton == ButtonState.Pressed)
            {
                firstMouseDown = false;
            }
            else
            {
                mouseDown = false;
                firstMouseDown = false;
            }
        }

        #endregion
    }
}
