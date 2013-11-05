using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * File name : EventEngine.cs
 * Author : Filipe
 * Date : 22/10/2013 17:57:51
 * Description :
 * 
*/

namespace MonoGame.UI
{
    /* DELEGATES */

    /// <summary>
    /// MonoGame.UI basic event handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void MonoGameEventHandler(Object sender, MonoGameEventArgs e);

    /// <summary>
    /// MonoGame.UI CheckBox event handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void MonoGameCheckBoxEventHandler(Object sender, MonoGameCheckBoxEventArgs e);

    /// <summary>
    /// MonoGame.UI Mouse event handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void MonoGameMouseEventHandler(Object sender, MonoGameMouseEventArgs e);
}
