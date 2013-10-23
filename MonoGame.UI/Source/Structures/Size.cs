using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * File name : Size.cs
 * Author : Filipe
 * Date : 19/10/2013 20:37:56
 * Description :
 * 
*/

namespace MonoGame.UI
{
    public class Size
    {
        #region FIELDS

        private Int32 width;
        private Int32 height;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Get or set the width
        /// </summary>
        public Int32 Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        /// <summary>
        /// Get or set the height
        /// </summary>
        public Int32 Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        #endregion

        #region CONSTRUCTORS
        #endregion

        #region METHODS
        #endregion
    }
}
