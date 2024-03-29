﻿#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using MonoGame.UI;
using System.Windows.Forms;
#endregion

namespace MonoGame.UI_Test
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GuiEngine Engine;
        Window win;
        Window win2;
        Window win3;

        MonoGame.UI.Button button1;
        MonoGame.UI.Label label1;
        MonoGame.UI.CheckBox checkBox1;

        MonoGame.UI.RadioGroup radioGroup1;
        MonoGame.UI.RadioGroup radioGroup2;

        MonoGame.UI.Label label2;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.Engine = new GuiEngine(this.Content, this.GraphicsDevice, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            /* Window 1 */
            this.win = new Window(this.Engine);

            /* Button */
            this.button1 = new UI.Button(this.win, 30, 200, 200, 24, "Leave Program");
            this.button1.Enabled = false;
            this.button1.OnMouseClick += button1_OnMouseClick;

            /* Label */
            this.label1 = new UI.Label(this.win, 55, 10, "Welcome to MonoGame.UI");

            /* CheckBox */
            this.checkBox1 = new UI.CheckBox(this.win, 20, 75, "Active leave button", true);
            this.checkBox1.OnCheckChange += checkBox1_OnCheckChange;

            /* Window 2 */
            this.win2 = new Window(this.Engine, 350, 10, 250, 150, "Gui Stats");
            this.win2.ShowCloseButton = false;
            this.label2 = new UI.Label(this.win2, 25, 10, "GuiEngine Stats :");

            this.win3 = new Window(this.Engine, 350, 200, 300, 225, "RadioButton tests");

            /* RadioButton 1 */
            this.radioGroup1 = new RadioGroup(this.win3);
            this.radioGroup1.Placement = RadioButtonPlacement.Horizontal;
            this.radioGroup1.SetPosition(20, 20);
            UI.RadioButton _r1 = new UI.RadioButton(this.radioGroup1);
            _r1.Text = "Power --";
            UI.RadioButton _r2 = new UI.RadioButton(this.radioGroup1);
            _r2.Text = "Power ++";
            this.radioGroup1.AddRadioButton(_r1);
            this.radioGroup1.AddRadioButton(_r2);

            /* RadioButton 2 */
            this.radioGroup2 = new RadioGroup(this.win3);
            this.radioGroup2.SetPosition(20, 50);

            UI.RadioButton _r3 = new UI.RadioButton(this.radioGroup2);
            _r3.Text = "XNA";
            UI.RadioButton _r4 = new UI.RadioButton(this.radioGroup2);
            _r4.Text = "MonoGame";


            this.radioGroup2.AddRadioButton(_r3);
            this.radioGroup2.AddRadioButton(_r4);

            this.Engine.AddWindow(this.win);
            this.Engine.AddWindow(this.win2);
            this.Engine.AddWindow(this.win3);

            base.Initialize();
        }

        void checkBox1_OnCheckChange(object sender, MonoGameCheckBoxEventArgs e)
        {
            if (e.State == true)
            {
                this.button1.Enabled = true;
            }
            else
            {
                this.button1.Enabled = false;
            }
        }


        void button1_OnMouseClick(object sender, MonoGameMouseEventArgs e)
        {
            this.Engine.Dispose();
            this.Exit();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            this.Engine.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.Engine.Draw();

            base.Draw(gameTime);
        }
    }
}
