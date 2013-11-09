using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * File name : RadioGroup.cs
 * Author : Filipe
 * Date : 08/11/2013 18:24:41
 * Description :
 * 
*/

namespace MonoGame.UI
{
    /// <summary>
    /// MonoGame.UI RadioGroup control.
    /// </summary>
    public class RadioGroup : Control
    {
        #region FIELDS

        /// <summary>
        /// List of the RadioButtons
        /// </summary>
        public List<RadioButton> RadioButtons { get; set; }

        /// <summary>
        /// Get or set the RadioButtons placement in the RadioGroup
        /// </summary>
        public RadioButtonPlacement Placement { get; set; }

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Basic initialisation
        /// </summary>
        /// <param name="parent">Parent Window</param>
        public RadioGroup(Window parent)
            : base(parent)
        {
            this.Enabled = true;
            this.Visible = true;
            this.Placement = RadioButtonPlacement.Vertical;
            this.RadioButtons = new List<RadioButton>();
            this.Parent.AddControl(this);
        }

        /// <summary>
        /// Initialise RadioGroup with one RadioButton
        /// </summary>
        /// <param name="parent">Parent Window</param>
        /// <param name="_firstRadio">One RadioButton</param>
        public RadioGroup(Window parent, RadioButton _firstRadio)
            : base(parent)
        {
            this.Enabled = true;
            this.Visible = true;
            this.Placement = RadioButtonPlacement.Vertical;
            this.RadioButtons = new List<RadioButton>();
            this.AddRadioButton(_firstRadio);
            this.Parent.AddControl(this);
        }
        
        /// <summary>
        /// Initialise the RadioGroup with a list of RadioButtons
        /// </summary>
        /// <param name="parent">Parent Window</param>
        /// <param name="lstRadioButtons">RadioButton list</param>
        public RadioGroup(Window parent, List<RadioButton> lstRadioButtons)
            : base(parent)
        {
            this.Enabled = true;
            this.Visible = true;
            this.Placement = RadioButtonPlacement.Vertical;
            this.RadioButtons = lstRadioButtons;
            this.Parent.AddControl(this);
        }

        /// <summary>
        /// Initialise a RadioGroup with a RadioButton list and the placement
        /// </summary>
        /// <param name="parent">Parent Window</param>
        /// <param name="lstRadioButtons">RadioButton list</param>
        /// <param name="placement">RadioButton placement (Vertical or Horizontal)</param>
        public RadioGroup(Window parent, List<RadioButton> lstRadioButtons, RadioButtonPlacement placement)
            : base(parent)
        {
            this.Enabled = true;
            this.Visible = true;
            this.Placement = placement;
            this.RadioButtons = lstRadioButtons;
            this.Parent.AddControl(this);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Update the RadioButtons in the RadioGroup
        /// </summary>
        public override void Update()
        {
            foreach (RadioButton _radio in this.RadioButtons)
            {
                _radio.Update();
            }
            base.Update();
        }

        /// <summary>
        /// Draw the RadioButtons in the RadioGroup
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Texture2D _texture = this.Parent.Engine.Loader.RadioButton;
            Vector2 _position = new Vector2(this.RealPosition.X, this.RealPosition.Y);
            foreach (RadioButton _radio in this.RadioButtons)
            {
                _radio.Draw(spriteBatch, _position);
                if (this.Placement == RadioButtonPlacement.Horizontal)
                {
                    _position.X += (_texture.Width / 6) + this.Parent.Engine.Font.MeasureString(_radio.Text).X + 8;
                }
                else
                {
                    _position.Y += _texture.Height + 5;
                }
            }
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Add a RadioButton to this RadioGroup
        /// </summary>
        /// <param name="radio">RadioButton</param>
        public void AddRadioButton(RadioButton radio)
        {
            if (this.RadioButtons != null)
            {
                if (this.RadioButtons.Contains(radio) == false)
                {
                    this.RadioButtons.Add(radio);
                }
            }
        }

        /// <summary>
        /// Delete the RadioButton from the RadioGroup
        /// </summary>
        /// <param name="radio">RadioButton</param>
        public void DeleteRadioButton(RadioButton radio)
        {
            if (this.RadioButtons != null)
            {
                if (this.RadioButtons.Contains(radio) == true)
                {
                    this.RadioButtons.Remove(radio);
                    radio.Dispose();
                }
            }
        }

        /// <summary>
        /// Dispose all RadioButtons in the list
        /// </summary>
        public override void Dispose()
        {
            foreach (RadioButton _radio in this.RadioButtons)
            {
                _radio.Dispose();
            }
            this.RadioButtons.Clear();
            this.RadioButtons = null;
            base.Dispose();
        }

        #endregion
    }

    public class RadioButton
    {
        #region FIELDS

        /// <summary>
        /// Group of the RadioButton
        /// </summary>
        private RadioGroup MyGroup { get; set; }

        /// <summary>
        /// Get or set the RadioButton Text
        /// </summary>
        public String Text { get; set; }

        /// <summary>
        /// Get or set the RadioButton State
        /// </summary>
        public Boolean State { get; set; }

        /// <summary>
        /// Get or set the RadioButton hover state
        /// </summary>
        public Boolean Hover { get; set; }

        /// <summary>
        /// Get or set the RadioButton enable state
        /// </summary>
        public Boolean Enabled { get; set; }

        /// <summary>
        /// Get or set the RadioButton visible state
        /// </summary>
        public Boolean Visible { get; set; }

        /// <summary>
        /// Get or set if the RadioButton can be checked by clicking on the text
        /// </summary>
        public Boolean CheckOnText { get; set; }

        /// <summary>
        /// Get or set the RadioButton position in the RadioGroup
        /// </summary>
        private Vector2 Position { get; set; }

        /// <summary>
        /// Get or set the RadioButton rectangle
        /// </summary>
        public Rectangle Rectangle { get; set; }

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Basic initialisation
        /// </summary>
        /// <param name="myGroup">Parent RadioGroup</param>
        public RadioButton(RadioGroup myGroup)
        {
            this.Enabled = true;
            this.Visible = true;
            this.CheckOnText = true;
            this.Text = "RadioButton";
            this.MyGroup = myGroup;
            this.MyGroup.AddRadioButton(this);
        }

        /// <summary>
        /// Initialise a RadioButton
        /// </summary>
        /// <param name="myGroup">Parent RadioGroup</param>
        /// <param name="text">RadioButton text</param>
        public RadioButton(RadioGroup myGroup, String text)
        {
            this.Enabled = true;
            this.Visible = true;
            this.CheckOnText = true;
            this.Text = text;
            this.MyGroup = myGroup;
            this.MyGroup.AddRadioButton(this);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Update the Radio
        /// </summary>
        public void Update()
        {
            if (this.Enabled == true && this.Visible == true)
            {
                if (MouseHelper.IsMouseInRectangle(Mouse.GetState(), this.Rectangle) == true &&
                       MouseHelper.IsMouseInRectangle(Mouse.GetState(), this.MyGroup.Parent.Engine.CurrentWindow.Rectangle) == true &&
                       this.MyGroup.Parent == this.MyGroup.Parent.Engine.CurrentWindow)
                {
                    if (this.IsMouseOnText() == true && this.CheckOnText == false)
                    {
                        this.Hover = false;
                    }
                    else
                    {
                        this.Hover = true;
                        this.MyGroup.MouseHover(this);
                    } 
                    if (MouseHelper.IsMouseClick(Mouse.GetState(), MouseHelper.MouseButtons.Left) == true)
                    {
                        this.ProcessCheck();
                        this.MyGroup.MouseClick(this);
                    }
                }
                else
                {
                    this.Hover = false;
                }
            }
        }

        /// <summary>
        /// Draw the Radio
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            this.Position = new Vector2(position.X, position.Y);
            this.BuildRadioButtonRectangle();
            Texture2D _radioButtonTexture = this.MyGroup.Parent.Engine.Loader.RadioButton;
            Rectangle _sourceRectangle = this.GetSourceRectangle();

            spriteBatch.Draw(_radioButtonTexture, position, _sourceRectangle, Color.White);

            if (String.IsNullOrEmpty(this.Text) == false)
            {
                Vector2 _textPosition = new Vector2(position.X + _radioButtonTexture.Width / 6 + 5, position.Y - 3);
                spriteBatch.DrawString(this.MyGroup.Parent.Engine.Loader.Font, this.Text, _textPosition, Color.White);
            }
        }

        /// <summary>
        /// Dispose the RadioButton
        /// </summary>
        public void Dispose()
        {
            this.Text = null;
            this.State = false;
        }

        /// <summary>
        /// Get the correct rectangle from the texture
        /// </summary>
        /// <returns></returns>
        private Rectangle GetSourceRectangle()
        {
            Int32 _checkWidth = this.MyGroup.Parent.Engine.Loader.RadioButton.Width / 6;
            Int32 _checkHeight = this.MyGroup.Parent.Engine.Loader.RadioButton.Height;

            if (this.Enabled == false && this.State == true)
            {
                return new Rectangle(_checkWidth * 5, 0, _checkWidth, _checkHeight);
            }
            else if (this.Enabled == false && this.State == false)
            {
                return new Rectangle(_checkWidth * 4, 0, _checkWidth, _checkHeight);
            }
            else if (this.State == true && this.Hover == false)
            {
                return new Rectangle(_checkWidth * 3, 0, _checkWidth, _checkHeight);
            }
            else if (this.State == true && this.Hover == true)
            {
                return new Rectangle(_checkWidth * 2, 0, _checkWidth, _checkHeight);
            }
            else if (this.State == false && this.Hover == false)
            {
                return new Rectangle(_checkWidth, 0, _checkWidth, _checkHeight);
            }
            else if (this.State == false && this.Hover == true)
            {
                return new Rectangle(0, 0, _checkWidth, _checkHeight);
            }
            return new Rectangle();
        }

        /// <summary>
        /// Build the RadioButton rectangle
        /// </summary>
        private void BuildRadioButtonRectangle()
        {
            Texture2D _texture = this.MyGroup.Parent.Engine.Loader.RadioButton;
            Int32 _radioButtonWidth = _texture.Width / 6;
            Int32 _radioButtonHeight = _texture.Height;
            Int32 _radioButtonTextWidth = (Int32)this.MyGroup.Parent.Engine.Loader.Font.MeasureString(this.Text).X;
            Int32 _radioButtonTextHeight = (Int32)this.MyGroup.Parent.Engine.Loader.Font.MeasureString(this.Text).Y;

            this.Rectangle = new Rectangle((Int32)this.Position.X, (Int32)this.Position.Y, 
                _radioButtonWidth + _radioButtonTextWidth + 3, 
                _radioButtonHeight);
        }

        /// <summary>
        /// Check if the Mouse is on the RadioButton text area
        /// </summary>
        /// <returns></returns>
        private Boolean IsMouseOnText()
        {
            Texture2D _texture = this.MyGroup.Parent.Engine.Loader.RadioButton;
            Int32 _radioButtonWidth = _texture.Width / 6;
            Int32 _radioButtonHeight = _texture.Height;
            Int32 _radioButtonTextWidth = (Int32)this.MyGroup.Parent.Engine.Loader.Font.MeasureString(this.Text).X;
            Int32 _radioButtonTextHeight = (Int32)this.MyGroup.Parent.Engine.Loader.Font.MeasureString(this.Text).Y;
            return MouseHelper.IsMouseInRectangle(Mouse.GetState(), new Rectangle((Int32)(this.Position.X + _radioButtonWidth + 3), (Int32)(this.Position.Y - 3), _radioButtonTextWidth, _radioButtonTextHeight));
        }

        /// <summary>
        /// Process check control
        /// </summary>
        private void ProcessCheck()
        {
            if (this.State == false)
            {
                foreach (RadioButton _radio in this.MyGroup.RadioButtons)
                {
                    _radio.State = false;
                }
                this.State = true;
            }
        }

        #endregion

    }

    public enum RadioButtonPlacement
    {
        Vertical, Horizontal
    }
}
