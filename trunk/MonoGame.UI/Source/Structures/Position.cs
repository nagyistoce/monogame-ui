using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * File name : Position.cs
 * Author : Filipe
 * Date : 19/10/2013 20:35:11
 * Description :
 * 
*/

namespace MonoGame.UI
{
    public class Position
    {
        #region FIELDS

        private Int32 left;
        private Int32 top;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Get or set the X value
        /// </summary>
        public Int32 Left
        {
            get
            {
                return this.left;
            }
            set
            {
                this.left = value;
            }
        }

        /// <summary>
        /// Get or set the Y value
        /// </summary>
        public Int32 Top
        {
            get
            {
                return this.top;
            }
            set
            {
                this.top = value;
            }
        }

        #endregion

        #region CONSTRUCTORS

        public Position() 
        {
            this.left = 0;
            this.top = 0;
        }

        public Position(Int32 left, Int32 top)
        {
            this.left = left;
            this.top = top;
        }

        #endregion

        #region METHODS
        #endregion
    }
}
