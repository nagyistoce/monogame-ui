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
 * Date : 23/10/2013 20:34:15
 * Description :
 * Label control class
*/

namespace MonoGame.UI
{
    public class Label : Control
    {
        #region FIELDS
        #endregion

        #region PROPERTIES
        #endregion

        #region CONTRUCTORS

        public Label(Window parent)
            : base(parent)
        {
            this.Text = "Label";
            this.SetPosition(0, 0);
            parent.AddControl(this);
        }

        public Label(Window parent, String text)
            : base(parent)
        {
            this.Text = text;
            this.SetPosition(0, 0);
            parent.AddControl(this);
        }

        public Label(Window parent, String text, Int32 left, Int32 top)
            : base(parent)
        {
            this.Text = text;
            this.SetPosition(left, top);
            parent.AddControl(this);
        }

        #endregion

        #region METHODS

        public override void Update()
        {
            if (this.Enabled == true && this.Visible == true)
            {
                if (MouseHelper.IsMouseInRectangle(Mouse.GetState(), this.Rectangle) == true &&
                    MouseHelper.IsMouseInRectangle(Mouse.GetState(), this.Parent.Engine.CurrentWindow.Rectangle) == false)
                {
                    this.MouseHover();
                    if (MouseHelper.IsMousePress(Mouse.GetState(), MouseHelper.MouseButtons.Left) == true)
                    {
                        this.MouseDown();
                    }
                    else if (MouseHelper.IsMousePress(Mouse.GetState(), MouseHelper.MouseButtons.Right) == true)
                    {
                        this.MouseDown();
                    }
                    if (MouseHelper.IsMouseClick(Mouse.GetState(), MouseHelper.MouseButtons.Left) == true)
                    {
                        this.MouseClick();
                    }
                }
            }
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.Parent.Engine.Font, this.Text, this.RealPosition, Color.White);
            base.Draw(spriteBatch);
        }

        #endregion
    }
}
