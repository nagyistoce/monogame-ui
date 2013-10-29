using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * File name : Controls.cs
 * Author : Filipe
 * Date : 19/10/2013 20:29:21
 * Description :
 * 
*/

namespace MonoGame.UI
{
    public class Control : IDisposable
    {
        #region FIELDS

        private String name;
        private String text;
        private Boolean enabled;
        private Boolean visible;
        private Boolean disposed;
        private Boolean focused;
        private Boolean hover;
        private Boolean pressed;

        private Window parent;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Get or set the name of the control.
        /// </summary>
        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Get or set the text associated with this control.
        /// </summary>
        public String Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }

        /// <summary>
        /// Get or set the left position of this control.
        /// </summary>
        public Int32 Left
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the top position of this control.
        /// </summary>
        public Int32 Top
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the width of this control.
        /// </summary>
        public Int32 Width
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the height of this control.
        /// </summary>
        public Int32 Height
        {
            get;
            set;
        }

        /// <summary>
        /// Get the control position as Vector2
        /// </summary>
        public Vector2 Position
        {
            get
            {
                if (this.Parent == null)
                {
                    return new Vector2(this.Left, this.Top);
                }
                else
                {
                    return new Vector2(this.Left + this.Parent.Left, this.Top + this.Parent.Top + 25);
                }
            }
        }

        /// <summary>
        /// Get the real position of the control in the app
        /// </summary>
        public Vector2 RealPosition
        {
            get
            {
                if (this.Parent == null)
                {
                    return new Vector2(this.Rectangle.X, this.Rectangle.Y);
                }
                else
                {
                    return new Vector2(this.Left + this.Parent.Rectangle.X, this.Top + this.Parent.Rectangle.Y + 25);
                }
            }
        }

        /// <summary>
        /// Get or set a value indicating whether the control can respond to user interaction.
        /// </summary>
        public Boolean Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

        /// <summary>
        /// Get or set a value indicating whether the control and all its child controls are displayed.
        /// </summary>
        public Boolean Visible
        {
            get
            {
                return this.visible;
            }
            set
            {
                this.visible = value;
            }
        }

        /// <summary>
        /// Get a value indicating whether the control has been disposed of.
        /// </summary>
        public Boolean Disposed
        {
            get
            {
                return this.disposed;
            }
        }

        /// <summary>
        /// Get the parent window of the control.
        /// </summary>
        public Window Parent
        {
            get
            {
                return this.parent;
            }
        }

        /// <summary>
        /// Get or set the control focus
        /// </summary>
        public Boolean Focused
        {
            get
            {
                return this.focused;
            }
            set
            {
                this.focused = value;
            }
        }

        /// <summary>
        /// Get or set the control hover
        /// </summary>
        public Boolean Hover
        {
            get
            {
                return this.hover;
            }
            set
            {
                this.hover = value;
            }
        }

        /// <summary>
        /// Get or set the control pressed
        /// </summary>
        public Boolean Pressed
        {
            get
            {
                return this.pressed;
            }
            set
            {
                this.pressed = value;
            }
        }

        /// <summary>
        /// Get the rectangle control
        /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(this.Left, this.Top, this.Width, this.Height);
            }
        }

        #endregion

        #region CONSTRUCTORS & DESTRUCTORS

        public Control() { }

        public Control(Window parent)
        {
            this.enabled = true;
            this.visible = true;
            this.parent = parent;
        }

        ~Control()
        {
            this.Dispose(false);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Releases all resources
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(Boolean disposing)
        {
            if (this.disposed == false)
            {
                if (disposing == true)
                {
                    // Dispose all resources
                    this.name = null;
                    this.text = null;
                }
                this.disposed = true;
            }
        }

        /// <summary>
        /// Set the control position
        /// </summary>
        /// <param name="left">Left distance</param>
        /// <param name="top">Top distance</param>
        public void SetPosition(Int32 left, Int32 top) 
        {
            if (this.Parent == null)
            {
                this.Left = left;
                this.Top = top;
            }
            else
            {
                this.Left = this.Parent.Left + left;
                this.Top = this.Parent.Top + 25 + top;
            }
        }

        /// <summary>
        /// Set the control size
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetSize(Int32 width, Int32 height) 
        {
            this.Width = width;
            this.Height = height;
        }

        //public void PointToClient() { }

        //public void PointToScreen() { }

        //public void RectangleToScreen() { }

        //public void RectangleToClient() { }

        #endregion

        #region EVENTS

        // General events
        public event MonoGameEventHandler
            OnFocus, OnFocusLost, OnTextChange, OnNameChange;

        // Mouse events
        public event MonoGameMouseEventHandler
            OnMouseClick, OnMouseDoubleClick, OnMouseDown, OnMouseUp, OnMouseWheel, OnMouseHover, OnMouseMove;

        #endregion

        #region VIRTUAL

        // General virtual function

        public virtual void Update() { }
        public virtual void Draw(SpriteBatch spriteBatch) { }

        // Mouse virtual functions

        /// <summary>
        /// Function firing the MouseClick event
        /// </summary>
        public virtual void MouseClick() 
        {
            if (this.OnMouseClick != null)
            {
                this.OnMouseClick(this, new MonoGameMouseEventArgs(Mouse.GetState()));
            }
        }

        /// <summary>
        /// Function firing the MouseDoubleClick event
        /// </summary>
        public virtual void MouseDoubleClick() 
        {
            if (this.OnMouseDoubleClick != null)
            {
                this.OnMouseDoubleClick(this, new MonoGameMouseEventArgs(Mouse.GetState()));
            }
        }

        /// <summary>
        /// Function firing the MouseHover event
        /// </summary>
        public virtual void MouseHover()
        {
            if (this.OnMouseHover != null)
            {
                this.OnMouseHover(this, new MonoGameMouseEventArgs(Mouse.GetState()));
            }
        }

        /// <summary>
        /// Function firing the MouseWheel event
        /// </summary>
        public virtual void MouseWheel() 
        {
            if (this.OnMouseWheel != null)
            {
                this.OnMouseWheel(this, new MonoGameMouseEventArgs(Mouse.GetState()));
            }
        }

        /// <summary>
        /// Function firing the MouseMove event
        /// </summary>
        public virtual void MouseMove() 
        {
            if (this.OnMouseMove != null)
            {
                this.OnMouseMove(this, new MonoGameMouseEventArgs(Mouse.GetState()));
            }
        }

        /// <summary>
        /// Function firing the MouseDown event
        /// </summary>
        public virtual void MouseDown()
        {
            if (this.OnMouseDown != null)
            {
                this.OnMouseDown(this, new MonoGameMouseEventArgs(Mouse.GetState()));
            }
        }

        /// <summary>
        /// Function firing the MouseUp event
        /// </summary>
        public virtual void MouseUp()
        {
            if (this.OnMouseUp != null)
            {
                this.OnMouseUp(this, new MonoGameMouseEventArgs(Mouse.GetState()));
            }
        }

        // Keyboard virtual functions

        protected virtual void KeyPress() { }
        protected virtual void KeyDown() { }
        protected virtual void KeyUp() { }

        #endregion
    }
}
