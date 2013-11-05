using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * File name : EventArgs.cs
 * Author : Filipe
 * Date : 22/10/2013 17:58:48
 * Description :
 * 
*/

namespace MonoGame.UI
{
    /// <summary>
    /// MonoGame Event Args
    /// </summary>
    public class MonoGameEventArgs : EventArgs
    {
        public Object EventObject;

        public MonoGameEventArgs(Object obj) 
        {
            this.EventObject = obj;
        }
    }

    /// <summary>
    /// MonoGame CheckBox Event Args
    /// </summary>
    public class MonoGameCheckBoxEventArgs : EventArgs
    {
        public Boolean State { get; set; }

        public MonoGameCheckBoxEventArgs(Boolean state)
        {
            this.State = state;
        }
    }

    /// <summary>
    /// MonoGame Mouse Event Args class
    /// </summary>
    public class MonoGameMouseEventArgs : EventArgs
    {
        public MouseState MouseState;

        public MonoGameMouseEventArgs(MouseState mouseState)
        {
            this.MouseState = mouseState;
        }
    }
}
