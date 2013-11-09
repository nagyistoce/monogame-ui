using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * File name : Loader.cs
 * Author : Filipe
 * Date : 20/10/2013 12:37:25
 * Description :
 * 
*/

namespace MonoGame.UI
{
    public class Loader
    {
        #region FIELDS

        private ContentManager Content;

        public SpriteFont Font;
        public Texture2D[] WndTiles;
        public Texture2D WndButtonExit;
        public Texture2D Buttons;
        public Texture2D CheckBox;
        public Texture2D RadioButton;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        public Loader(ContentManager content)
        {
            this.Content = content;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Load theme content
        /// </summary>
        public void LoadContent()
        {
            /* Load font */
            this.Font = this.Content.Load<SpriteFont>(@"Theme//GUI");

            /* Load window tiles */
            this.WndTiles = new Texture2D[12];
            for (Int32 i = 0; i < 12; i++)
            {
                this.WndTiles[i] = this.Content.Load<Texture2D>(@"Theme/WndTile" + i.ToString());
            }

            /* Load window close button */
            this.WndButtonExit = this.Content.Load<Texture2D>(@"Theme/WndButtonExit");

            /* Load Button */
            this.Buttons = this.Content.Load<Texture2D>(@"Theme/WndButton");

            /* Load CheckBox */
            this.CheckBox = this.Content.Load<Texture2D>(@"Theme/WndCheckBox");

            /* Load RadioButton */
            this.RadioButton = this.Content.Load<Texture2D>(@"Theme/ButtRadio");
        }

        /// <summary>
        /// Dispose resources
        /// </summary>
        public void Dispose()
        {
            this.Font = null;
            foreach (Texture2D _texture in this.WndTiles)
            {
                _texture.Dispose();
            }
            this.WndButtonExit.Dispose();
            this.Buttons.Dispose();
            this.CheckBox.Dispose();
        }

        #endregion
    }
}
