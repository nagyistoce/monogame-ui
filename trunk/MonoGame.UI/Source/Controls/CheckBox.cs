using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * File name : CheckBox.cs
 * Author : Filipe
 * Date : 01/11/2013 12:12:48
 * Description :
 * 
*/

namespace MonoGame.UI
{
    public class CheckBox : Control
    {
        #region FIELDS

        /// <summary>
        /// Get or set the control state (check or not)
        /// </summary>
        public Boolean Checked { get; set; }

        /// <summary>
        /// Get or set if the control can be checked by clicking on the text
        /// </summary>
        public Boolean CheckOnText { get; set; }

        /// <summary>
        /// Check change event
        /// </summary>
        public event MonoGameCheckBoxEventHandler OnCheckChange;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialise a basic CheckBox
        /// </summary>
        /// <param name="parent">The Parent Window</param>
        public CheckBox(Window parent)
            : base(parent)
        {
            this.SetPosition(0, 0);
            this.Text = "CheckBox";
            this.CheckOnText = true;
            this.Parent.AddControl(this);
        }

        /// <summary>
        /// Initialise a CheckBox with X and Y position
        /// </summary>
        /// <param name="parent">The Parent Window</param>
        /// <param name="left">X position</param>
        /// <param name="top">Y position</param>
        public CheckBox(Window parent, Int32 left, Int32 top)
            : base(parent)
        {
            this.SetPosition(left, top);
            this.Text = "CheckBox";
            this.CheckOnText = true;
            this.Parent.AddControl(this);
        }

        /// <summary>
        /// Initialise a CheckBox with X and Y position and with a text
        /// </summary>
        /// <param name="parent">The Parent Window</param>
        /// <param name="left">X position</param>
        /// <param name="top">Y position</param>
        /// <param name="text">CheckBox text</param>
        public CheckBox(Window parent, Int32 left, Int32 top, String text)
            : base(parent)
        {
            this.SetPosition(left, top);
            this.Text = text;
            this.CheckOnText = true;
            this.Parent.AddControl(this);
        }

        /// <summary>
        /// Initialise a CheckBox with X and Y position, text
        /// </summary>
        /// <param name="parent">The Parent Window</param>
        /// <param name="left">X position</param>
        /// <param name="top">Y position</param>
        /// <param name="text">CheckBox text</param>
        /// <param name="checkOnText">Determines if you can check the control by clicking on the text</param>
        public CheckBox(Window parent, Int32 left, Int32 top, String text, Boolean checkOnText)
            : base(parent)
        {
            this.SetPosition(left, top);
            this.Text = text;
            this.CheckOnText = checkOnText;
            this.Parent.AddControl(this);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Update CheckBox
        /// </summary>
        public override void Update()
        {
            if (this.Enabled == true && this.Visible == true)
            {
                this.UpdateCheckBoxSize();
                if (MouseHelper.IsMouseInRectangle(Mouse.GetState(), this.Rectangle) == true &&
                    MouseHelper.IsMouseInRectangle(Mouse.GetState(), this.Parent.Engine.CurrentWindow.Rectangle) == true &&
                    this.Parent == this.Parent.Engine.CurrentWindow)
                {
                    if (this.IsMouseOnText() == true && this.CheckOnText == false)
                    {
                        this.Hover = false;
                    }
                    else
                    {
                        this.Hover = true;
                        this.MouseHover();
                    }
                    if (MouseHelper.IsMousePress(Mouse.GetState(), MouseHelper.MouseButtons.Left) == true ||
                        MouseHelper.IsMousePress(Mouse.GetState(), MouseHelper.MouseButtons.Right) == true)
                    {
                        this.MouseDown();
                    }
                    if (MouseHelper.IsMouseClick(Mouse.GetState(), MouseHelper.MouseButtons.Left) == true)
                    {
                        this.ProcessCheck();
                    }
                    if (MouseHelper.IsMouseReleased(Mouse.GetState(), MouseHelper.MouseButtons.Left) == true)
                    {
                        this.MouseUp();
                    }
                }
                else
                {
                    this.Hover = false;
                }
            }
            base.Update();
        }

        /// <summary>
        /// Draw CheckBox
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Texture2D _checkBoxTexture = this.Parent.Engine.Loader.CheckBox;
            spriteBatch.Draw(_checkBoxTexture, this.RealPosition, this.GetSourceRectangle(), Color.White);

            if (String.IsNullOrEmpty(this.Text) == false)
            {
                spriteBatch.DrawString(this.Parent.Engine.Loader.Font, 
                    this.Text, 
                    new Vector2(this.RealPosition.X + (_checkBoxTexture.Width / 6) + 3, this.RealPosition.Y - 3), 
                    Color.White);
            }

            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Get the correct rectangle from the texture
        /// </summary>
        /// <returns></returns>
        private Rectangle GetSourceRectangle()
        {
            Int32 _checkWidth = this.Parent.Engine.Loader.CheckBox.Width / 6;
            Int32 _checkHeight = this.Parent.Engine.Loader.CheckBox.Height;

            if (this.Enabled == false && this.Checked == true)
            {
                return new Rectangle(_checkWidth * 5, 0, _checkWidth, _checkHeight);
            }
            else if (this.Enabled == false && this.Checked == false)
            {
                return new Rectangle(_checkWidth * 4, 0, _checkWidth, _checkHeight);
            }
            else if (this.Checked == true && this.Hover == false)
            {
                return new Rectangle(_checkWidth * 3, 0, _checkWidth, _checkHeight);
            }
            else if (this.Checked == true && this.Hover == true)
            {
                return new Rectangle(_checkWidth * 2, 0, _checkWidth, _checkHeight);
            }
            else if (this.Checked == false && this.Hover == false)
            {
                return new Rectangle(_checkWidth, 0, _checkWidth, _checkHeight);
            }
            else if (this.Checked == false && this.Hover == true)
            {
                return new Rectangle(0, 0, _checkWidth, _checkHeight);
            }
            return new Rectangle();
        }

        /// <summary>
        /// Set the CheckBox size with the text length
        /// </summary>
        private void UpdateCheckBoxSize()
        {
            Texture2D _check = this.Parent.Engine.Loader.CheckBox;
            Int32 _textLength = (Int32)this.Parent.Engine.Loader.Font.MeasureString(this.Text).X;
            this.SetSize((_check.Width / 6) + _textLength, _check.Height);
        }

        /// <summary>
        /// Check is the mouse is on the text area
        /// </summary>
        /// <returns></returns>
        private Boolean IsMouseOnText()
        {
            Texture2D _check = this.Parent.Engine.Loader.CheckBox;
            Int32 _textLength = (Int32)this.Parent.Engine.Loader.Font.MeasureString(this.Text).X;
            return MouseHelper.IsMouseInRectangle(Mouse.GetState(), new Rectangle((Int32)(this.RealPosition.X + (_check.Width / 6) + 3), (Int32)this.RealPosition.Y - 3, _textLength, 25));
        }

        /// <summary>
        /// Process Check controls
        /// </summary>
        private void ProcessCheck()
        {
            if (this.CheckOnText == true)
            {
                this.MouseClick();
                if (this.Checked == true)
                {
                    this.Checked = false;
                }
                else
                {
                    this.Checked = true;
                }
                this.OnCheck();
            }
            else
            {
                if (this.IsMouseOnText() == false)
                {
                    this.MouseClick();
                    if (this.Checked == true)
                    {
                        this.Checked = false;
                    }
                    else
                    {
                        this.Checked = true;
                    }
                    this.OnCheck();
                }
            }
        }

        #endregion

        #region EVENT

        /// <summary>
        /// Event fired when the check state change
        /// </summary>
        protected void OnCheck()
        {
            if (this.OnCheckChange != null)
            {
                this.OnCheckChange(this, new MonoGameCheckBoxEventArgs(this.Checked));
            }
        }

        #endregion
    }
}
