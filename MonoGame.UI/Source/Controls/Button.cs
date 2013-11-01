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
            this.SetSize(140, 24);
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
            Texture2D _buttonTexture = this.Parent.Engine.Loader.Buttons;
            Rectangle _buttonSource = this.GetButtonRectangle();

            if (this.Parent != this.Parent.Engine.CurrentWindow)
            {
                _color *= 0.8f;
            }

            // Draw button
            spriteBatch.Draw(_buttonTexture, this.Rectangle, _buttonSource, _color);

            if (String.IsNullOrEmpty(this.Text) == false)
            {
                Vector2 _text_len = this.Parent.Engine.Font.MeasureString(this.Text);
                Vector2 _position = new Vector2(this.RealPosition.X + this.Width / 2 - _text_len.X / 2, this.RealPosition.Y + this.Height / 2 - _text_len.Y / 2);
                spriteBatch.DrawString(this.Parent.Engine.Font, this.Text, new Vector2(_position.X, _position.Y), Color.Black);
            }

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
        /// Get the current rectangle of the button
        /// </summary>
        /// <returns></returns>
        private Rectangle GetButtonRectangle()
        {
            Int32 _buttonWidth = this.Parent.Engine.Loader.Buttons.Width / 4;
            Int32 _buttonHeight = this.Parent.Engine.Loader.Buttons.Height;
            if (this.Enabled == false)
            {
                return new Rectangle(_buttonWidth * 3, 0, _buttonWidth, _buttonHeight);
            }
            else if (this.Pressed == true)
            {
                return new Rectangle(_buttonWidth * 2, 0, _buttonWidth, _buttonHeight);
            }
            else if (this.Hover == true)
            {
                return new Rectangle(0, 0, _buttonWidth, _buttonHeight);
            }
            else
            {
                return new Rectangle(_buttonWidth, 0, _buttonWidth, _buttonHeight);
            }
        }

        /// <summary>
        /// Dispose Button resources
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
        }

        #endregion
    }
}
