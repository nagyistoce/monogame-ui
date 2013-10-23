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
        private GuiEngine Engine;

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
            // Set rectangle
            this.Left = 10;
            this.Top = 10;
            this.Width = 300;
            this.Height = 300;
            this.RebuildRectangle();
            this.lstControl = new List<Control>();
        }

        public Window(GuiEngine engine, Int32 left, Int32 top, Int32 width, Int32 height)
            : base()
        {
            this.Engine = engine;
            this.Text = "MonoGame.UI Window";
            this.Visible = true;
            this.Enabled = true;
            // Set rectangle
            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.Height = height;
            this.RebuildRectangle();
            this.lstControl = new List<Control>();
        }

        public Window(GuiEngine engine, Rectangle rectangle)
            : base()
        {
            this.Engine = engine;
            this.Text = "MonoGame.UI Window";
            this.Visible = true;
            this.Enabled = true;
            // Set rectangle
            this.Rectangle = rectangle;
            this.RebuildPositionAndSize();
            this.lstControl = new List<Control>();
        }

        public Window(GuiEngine engine, Int32 left, Int32 top, Int32 width, Int32 height, String title)
            : base()
        {
            this.Engine = engine;
            this.Text = title;
            this.Visible = true;
            this.Enabled = true;
            // Set rectangle
            this.Left = left;
            this.Top = top;
            this.Width = width;
            this.Height = height;
            this.RebuildRectangle();
            this.lstControl = new List<Control>();
        }

        public Window(GuiEngine engine, Rectangle rectangle, String title)
            : base()
        {
            this.Engine = engine;
            this.Text = title;
            this.Visible = true;
            this.Enabled = true;
            // Set rectangle
            this.Rectangle = rectangle;
            this.RebuildPositionAndSize();
            this.lstControl = new List<Control>();
        }

        #endregion

        #region METHODS

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
                            Mouse.GetState().Y >= this.Rectangle.Y && Mouse.GetState().Y <= this.Rectangle.Y + 24)
                        {
                            this.Engine.CurrentWindowMoving = this;
                        }
                    }
                }
            }
            base.Update();
        }

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
                spriteBatch.Draw(this.Engine.Loader.WndTiles[0], new Rectangle(this.Rectangle.X, this.Rectangle.Y, 16, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[1], new Rectangle(this.Rectangle.X + 16, this.Rectangle.Y, this.Rectangle.Width - 32, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[2], new Rectangle(this.Rectangle.Right - 16, this.Rectangle.Y, 16, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[3], new Rectangle(this.Rectangle.X, this.Rectangle.Y + 16, 16, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[4], new Rectangle(this.Rectangle.X + 16, this.Rectangle.Y + 16, this.Rectangle.Width - 32, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[5], new Rectangle(this.Rectangle.Right - 16, this.Rectangle.Y + 16, 16, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[6], new Rectangle(this.Rectangle.X, this.Rectangle.Y + 32, 16, this.Rectangle.Height - 48), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[7], new Rectangle(this.Rectangle.X + 16, this.Rectangle.Y + 32, this.Rectangle.Width - 32, this.Rectangle.Height - 48), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[8], new Rectangle(this.Rectangle.Right - 16, this.Rectangle.Y + 32, 16, this.Rectangle.Height - 48), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[9], new Rectangle(this.Rectangle.X, this.Rectangle.Bottom - 16, 16, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[10], new Rectangle(this.Rectangle.X + 16, this.Rectangle.Bottom - 16, this.Rectangle.Width - 32, 16), _winColor);
                spriteBatch.Draw(this.Engine.Loader.WndTiles[11], new Rectangle(this.Rectangle.Right - 16, this.Rectangle.Bottom - 16, 16, 16), _winColor);

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

        #endregion
    }
}
