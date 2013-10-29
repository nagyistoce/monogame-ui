using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
 * File name : Button.cs
 * Author : Filipe
 * Date : 27/10/2013 14:28:52
 * Description :
 * 
*/

namespace MonoGame.UI
{
    public class Button : Control
    {
        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        public Button(Window parent)
            : base(parent)
        {
            this.Text = "Button";
            this.SetPosition(0, 0);
            this.SetPosition(75, 25);
            this.Parent.AddControl(this);
        }

        public Button(Window parent, Int32 left, Int32 top, Int32 width, Int32 height)
            : base(parent)
        {
            this.Text = "Button";
            this.SetPosition(left, top);
            this.SetSize(width, height);
            this.Parent.AddControl(this);
        }

        public Button(Window parent, Int32 left, Int32 top, Int32 width, Int32 height, String text)
            : base(parent)
        {
            this.Text = text;
            this.SetPosition(left, top);
            this.SetSize(width, height);
            this.Parent.AddControl(this);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Draw the control
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Color _color = Color.White;
            Texture2D _button_texture = this.GetCurrentButtonTexture();

            if (this.Parent != this.Parent.Engine.CurrentWindow)
            {
                _color *= 0.8f;
            }

            // Draw logic
            #region Top

            spriteBatch.Draw(_button_texture,
                new Vector2(this.RealPosition.X, this.RealPosition.Y),
                new Rectangle(0, 0, 7, 7),
                _color);

            spriteBatch.Draw(_button_texture,
                new Vector2(this.RealPosition.X + 7, this.RealPosition.Y),
                new Rectangle(7, 0, this.Width - 14, 7),
                _color);

            #endregion

            #region Middle

            #endregion

            #region Bottom

            #endregion
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Update the control
        /// </summary>
        public override void Update()
        {
            if (this.Enabled == true && this.Visible == true)
            {
                if (MouseHelper.IsMouseInRectangle(Mouse.GetState(), this.Rectangle) == true &&
                    MouseHelper.IsMouseInRectangle(Mouse.GetState(), this.Parent.Engine.CurrentWindow.Rectangle) == true)
                {
                    this.Hover = true;
                    this.Pressed = false;
                    this.MouseHover();
                    if (MouseHelper.IsMousePress(Mouse.GetState(), MouseHelper.MouseButtons.Left) == true ||
                        MouseHelper.IsMousePress(Mouse.GetState(), MouseHelper.MouseButtons.Right) == true)
                    {
                        this.Pressed = true;
                        this.MouseDown();
                    }
                }
                else
                {
                    this.Hover = false;
                    this.Pressed = false;
                }
            }
            base.Update();
        }

        /// <summary>
        /// Get the current button texture
        /// </summary>
        /// <returns></returns>
        private Texture2D GetCurrentButtonTexture()
        {
            if (this.Enabled == false)
            {
                return this.Parent.Engine.Loader.Buttons[3];
            }
            else if (this.Pressed == true)
            {
                return this.Parent.Engine.Loader.Buttons[2];
            }
            else if (this.Hover == true)
            {
                return this.Parent.Engine.Loader.Buttons[1];
            }
            else
            {
                return this.Parent.Engine.Loader.Buttons[0];
            }
        }

        #endregion
    }
}
