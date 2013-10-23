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
    public delegate void MonoGameEventHandler(Object sender, MonoGameEventArgs e);
    public delegate void MonoGameMouseEventHandler(Object sender, MonoGameMouseEventArgs e);
}
