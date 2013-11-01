using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * File name : Label.cs
 * Author : Filipe
 * Date : 01/11/2013 11:44:53
 * Description :
 * 
*/

namespace MonoGame.UI
{
    public class Label : Control
    {
        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialise a basic label
        /// </summary>
        /// <param name="parent">The Parent Window</param>
        public Label(Window parent)
            : base(parent)
        {
            this.SetPosition(0, 0);
            this.Text = "Label";
            this.Parent.AddControl(this);
        }

        /// <summary>
        /// Initialise a label with X and Y position
        /// </summary>
        /// <param name="parent">The Parent Window</param>
        /// <param name="left">X position</param>
        /// <param name="top">Y position</param>
        public Label(Window parent, Int32 left, Int32 top)
            : base(parent)
        {
            this.SetPosition(left, top);
            this.Text = "Label";
            this.Parent.AddControl(this);
        }

        /// <summary>
        /// Initialise a label with X and Y position, and a default text
        /// </summary>
        /// <param name="parent">The Parent Window</param>
        /// <param name="left">X position</param>
        /// <param name="top">Y position</param>
        /// <param name="text">Label text</param>
        public Label(Window parent, Int32 left, Int32 top, String text)
            : base(parent)
        {
            this.SetPosition(left, top);
            this.Text = text;
            this.Parent.AddControl(this);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Update the Label
        /// </summary>
        public override void Update()
        {
            if (this.Enabled == true && this.Visible == true)
            {
                if (MouseHelper.IsMouseInRectangle(Mouse.GetState(), this.Rectangle) == true &&
                    MouseHelper.IsMouseInRectangle(Mouse.GetState(), this.Parent.Engine.CurrentWindow.Rectangle) == true &&
                    this.Parent == this.Parent.Engine.CurrentWindow)
                {
                    this.MouseHover();
                    if (MouseHelper.IsMousePress(Mouse.GetState(), MouseHelper.MouseButtons.Left) == true ||
                        MouseHelper.IsMousePress(Mouse.GetState(), MouseHelper.MouseButtons.Right) == true)
                    {
                        this.MouseDown();
                    }
                }
            }
            base.Update();
        }

        /// <summary>
        /// Draw the label
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (String.IsNullOrEmpty(this.Text) == false)
            {
                spriteBatch.DrawString(this.Parent.Engine.Font, this.Text, this.RealPosition, Color.White);
            }
            base.Draw(spriteBatch);
        }

        #endregion
    }
}
