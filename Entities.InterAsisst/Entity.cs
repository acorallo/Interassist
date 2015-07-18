using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.InterAsisst
{
    public abstract class Entity
    {
        #region Constantes

        private const int NEW_ENTITY = 0;

        #endregion Constantes

        #region Miembros

        protected int _id = NEW_ENTITY;
        
        
        #endregion Miembros.

        #region Propiedades

        public int ID
        {
            get
            {
                return this._id;
            }
        
        }

        public bool IsNew
        {
            get
            {
                return (this._id == NEW_ENTITY);
            }

        }

        #endregion Propiedades

    }
}
