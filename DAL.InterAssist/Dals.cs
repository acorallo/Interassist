using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using Utils.InterAssist;
using Cognitas.Framework.Repository;


namespace DAL.InterAssist
{
    public abstract class Dals
    {
        #region Miembros

        private DBRepository _repository;



        #endregion Miembros

        #region Propiedades

        public abstract String TABLE_NAME { get; }
        public DBRepository Repository
        {
            get
            {
                return _repository;
            }
        }

        #endregion Propiedades
    }
}
