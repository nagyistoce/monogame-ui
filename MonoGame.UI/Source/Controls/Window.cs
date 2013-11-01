using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

/*
 * File name : Window.cs
 * Author : Filipe
 * Date : 20/10/2013 12:11:01
 * Description :
 * 
*/

namespace MonoGame.UI
{
    public class Window : Control
    {
        #region FIELDS

        public List<Control> lstControl;
        public GuiEngine Engine;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        public Window(GuiEngine engine)
            : base()
        {
            this.Engine = engine;
            this.Text = "MonoGame.UI Window";
            this.Visible = true;
            this.Enabled = true;
            // Set position ans size
            this.SetPosition(10, 10);
            this.SetSize(300, 300);
            this.lstControl = new List<Control>();
        }

        public Window(GuiEngine engine, Int32 left, Int32 top, Int32 width, Int32 height)
            : base()
        {
            this.Engine = engine;
            this.Text = "MonoGame.UI Window";
            this.Visible = true;
            this.Enabled = true;
            // Set position ans size
            this.SetPosition(left, top);
            this.SetSize(width, height);
            this.lstControl = new List<Control>();
        }

        public Window(GuiEngine engine, Int32 left, Int32 top, Int32 width, Int32 height, String title)
            : base()
        {
            this.Engine = engine;
            this.Text = title;
            this.Visible = true;
            this.Enabled = true;
            // Set position ans size
            this.SetPosition(left, top);
            this.SetSize(width, height);
            this.lstControl = new List<Control>();
        }

        #endregion

        #region METHODS
        
        /// <summary>
        /// Update the window
        /// </summary>
        public override void Update()
        {
            if (this.Enabled == true && this.Visible == true)
            {
                if (MouseHelper.IsMouseInRectangle(Mouse.GetState(), this.Rectangle) == true &&
                    MouseHelper.IsMouseInRectangle(Mouse.GetState(), this.Engine.CurrentWindow.Rectangle) == false || this == this.Engine.CurrentWindow)
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
                    if (MouseHelper.firstMouseDown == true)
                    {
                        if (MouseHelper.IsMouseInRectangle(Mouse.GetState(), this.Engine.CurrentWindow.Rectangle) == false)
                        {
                            this.Engine.CurrentWindow = this;
                        }
                        if (Mouse.GetState().X >= this.Rectangle.X && Mouse.GetState().X <= this.Rectangle.X + this.Rectangle.Width &&
                            Mouse.GetState().Y >= this.Rectangle.Y && Mouse.GetState().Y <= this.Rectangle.Y + 25)
                        {
                            this.Engine.CurrentWindowMoving = this;
                        }
                    }
                }
                foreach (Control _control in this.lstControl)
                {
                    _control.Update();
                    if (this.Disposed == true)
                    {
                        return;
                    }
                }
            }
            base.Update();
        }

        /// <summary>
        /// Draw the window
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Color _winColor;
            if (this.Visible == true)
            {
                if (this == this.Engine.CurrentWindow)
                {
                    _winColor = Color.White;
                }
                else
                {
                    _winColor = Color.White * 0.8f;
                }
                // Window draw logic
                spriteBatch.Draw(this.Engine.Loader.WndTiles[0], new Rectangle(Rectangle.X, Rectangle.Y, 16, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[1], new Rectangle(Rectangle.X + 16, Rectangle.Y, Rectangle.Width - 32, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[2], new Rectangle(Rectangle.Right - 16, Rectangle.Y, 16, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[3], new Rectangle(Rectangle.X, Rectangle.Y + 16, 16, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[4], new Rectangle(Rectangle.X + 16, Rectangle.Y + 16, Rectangle.Width - 32, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[5], new Rectangle(Rectangle.Right - 16, Rectangle.Y + 16, 16, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[6], new Rectangle(Rectangle.X, Rectangle.Y + 32, 16, Rectangle.Height - 48), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[7], new Rectangle(Rectangle.X + 16, Rectangle.Y + 32, Rectangle.Width - 32, Rectangle.Height - 48), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[8], new Rectangle(Rectangle.Right - 16, Rectangle.Y + 32, 16, Rectangle.Height - 48), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[9], new Rectangle(Rectangle.X, Rectangle.Bottom - 16, 16, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[10], new Rectangle(Rectangle.X + 16, Rectangle.Bottom - 16, Rectangle.Width - 32, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[11], new Rectangle(Rectangle.Right - 16, Rectangle.Bottom - 16, 16, 16), _winColor);
                
                if (this.Text != null)
                {
                    spriteBatch.DrawString(this.Engine.Font, this.Text,
                        new Vector2((Single)(this.Rectangle.X + 16), (Single)this.Rectangle.Y + 8), _winColor);
                }

                // Draw controls
                foreach (Control _c in this.lstControl)
                {
                    _c.Draw(spriteBatch);
                }
            }
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Add the control to the window control list
        /// </summary>
        /// <param name="control">Control to add</param>
        public void AddControl(Control control)
        {
            if (control is Window)
            {
                return;
            }
            if (this.lstControl.Contains(control) == false)
            {
                this.lstControl.Add(control);
            }
        }

        /// <summary>
        /// Delete the control from the window control list and dispose it
        /// </summary>
        /// <param name="control">Control to delete</param>
        public void DeleteControl(Control control)
        {
            if (control is Window)
            {
                return;
            }
            if (this.lstControl.Contains(control) == true)
            {
                this.lstControl.Remove(control);
            }
            control.Dispose();
            control = null;
        }

        /// <summary>
        /// Dispose the window controls
        /// </summary>
        public override void Dispose()
        {
            foreach (Control _control in this.lstControl)
            {
                _control.Dispose();
            }
            this.lstControl.Clear();
            this.lstControl = null;
            base.Dispose();
        }

        #endregion
    }
}
