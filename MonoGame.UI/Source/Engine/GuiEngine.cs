﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
 * File name : GuiEngine.cs
 * Author : Filipe
 * Date : 20/10/2013 12:02:22
 * Description :
 * 
*/

namespace MonoGame.UI
{
    public class GuiEngine
    {
        #region FIELDS

        public GraphicsDevice GraphicsDevice;
        private ContentManager Content;
        private SpriteBatch SpriteBatch;
        private Boolean DisposeEngine;

        public Int32 ClientWidth;
        public Int32 ClientHeight;

        public List<Window> lstWindows;

        public SpriteFont Font;

        public Window CurrentWindow;
        public Window CurrentWindowMoving;
        public Control CurrentControl;
        public Loader Loader;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize the GuiEngine
        /// </summary>
        /// <param name="content">Content</param>
        /// <param name="graphics">GraphicsDeviceManager</param>
        public GuiEngine(ContentManager content, GraphicsDevice graphics, Int32 clientWidth, Int32 clientHeight)
        {
            this.Content = content;
            this.GraphicsDevice = graphics;
            this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);
            this.DisposeEngine = false;
            this.ClientWidth = clientWidth;
            this.ClientHeight = clientHeight;
            
            // Load resources
            this.Loader = new Loader(this.Content);
            this.Loader.LoadContent();

            // Initialize GuiFont
            this.Font = this.Loader.Font;

            // Initialize windows list
            this.lstWindows = new List<Window>();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Update the GuiEngine
        /// </summary>
        /// <param name="gameTime">Current game time</param>
        public void Update(GameTime gameTime)
        {
            MouseState _mouseState = Mouse.GetState();
            MouseHelper.UpdateMouse(_mouseState);
            if (MouseHelper.IsMouseInRectangle(_mouseState, new Rectangle(0, 0, this.ClientWidth, this.ClientHeight)) == true)
            {
                    this.ProcessMouseInput(_mouseState);
                    this.ProcessKeyboardInput();
                    foreach (Window _win in this.lstWindows)
                    {
                        _win.Update();
                        if (_win.Disposed == true)
                        {
                            return;
                        }
                    }
            }
            MouseHelper.UpdateLastMousePosition(_mouseState);
        }

        /// <summary>
        /// Draw all controls visible in the GuiEngine
        /// </summary>
        public void Draw()
        {
            this.SpriteBatch.Begin();
            foreach (Window _win in this.lstWindows)
            {
                if (_win != this.CurrentWindow)
                {
                    _win.Draw(this.SpriteBatch);
                }
            }
            if (this.CurrentWindow != null)
            {
                this.CurrentWindow.Draw(this.SpriteBatch);
            }
            this.SpriteBatch.End();
        }

        /// <summary>
        /// Add window to the GuiEngine window list
        /// </summary>
        /// <param name="window"></param>
        public void AddWindow(Window window)
        {
            if (window == null)
            {
                return;
            }
            if (this.lstWindows.Contains(window) == false)
            {
                foreach (Window _win in this.lstWindows)
                {
                    _win.Focused = false; // Lost focus
                }
                window.Focused = true;
                this.lstWindows.Add(window);
                this.CurrentWindow = window;
            }
        }

        /// <summary>
        /// Delete window from the GuiEngine list
        /// </summary>
        /// <param name="window"></param>
        /// <param name="dispose"></param>
        public void RemoveWindow(Window window, Boolean dispose)
        {
            if (window == null)
            {
                return;
            }
            if (this.lstWindows.Contains(window) == true)
            {
                this.lstWindows.Remove(window);
                if (dispose == true)
                {
                    window.Dispose();
                    window = null;
                    if (this.lstWindows.Count >= 1)
                    {
                        this.CurrentWindow = this.lstWindows.Last();
                        this.CurrentWindow.Focused = true;
                    }
                    else
                    {
                        this.CurrentWindow = null;
                    }
                }
            }
        }

        /// <summary>
        /// Dispose the GuiEngine
        /// </summary>
        public void Dispose()
        {
            foreach (Window _window in this.lstWindows)
            {
                _window.Dispose();
            }
            this.lstWindows.Clear();
            this.CurrentWindow = null;
            this.Loader.Dispose();
            this.Loader = null;
            this.DisposeEngine = true;
        }

        /// <summary>
        /// Process the mouse Input for the moving window
        /// </summary>
        /// <param name="mouseState"></param>
        private void ProcessMouseInput(MouseState mouseState)
        {
            if (this.CurrentWindowMoving != null)
            {
                if (MouseHelper.mouseDown && this.CurrentWindowMoving.Enabled)
                {
                    this.CurrentWindowMoving.Left -= MouseHelper.lastMouseState.X - mouseState.X;
                    this.CurrentWindowMoving.Top -= MouseHelper.lastMouseState.Y - mouseState.Y;

                    if (this.CurrentWindowMoving.Rectangle.X < 0)
                    {
                        this.CurrentWindowMoving.Left = 0;
                    }
                    else if (this.CurrentWindowMoving.Rectangle.X + this.CurrentWindowMoving.Rectangle.Width > this.ClientWidth)
                    {
                        this.CurrentWindowMoving.Left = this.ClientWidth - this.CurrentWindowMoving.Rectangle.Width;
                    }

                    if (this.CurrentWindowMoving.Rectangle.Y < 0)
                    {
                        this.CurrentWindowMoving.Top = 0;
                    }
                    else if (this.CurrentWindowMoving.Rectangle.Y + this.CurrentWindowMoving.Rectangle.Height > this.ClientHeight)
                    {
                        this.CurrentWindowMoving.Top = this.ClientHeight - this.CurrentWindowMoving.Rectangle.Height;
                    }
                }
                else
                {
                    this.CurrentWindowMoving = null;
                }
            }
        }

        private void ProcessKeyboardInput()
        { 
        }

        #endregion
    }
}
