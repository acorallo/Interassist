using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Cognitas.Framework.Repository
{
    public class ConnectionList
    {
        #region Members

        private List<ConnectionItem> _list = new List<ConnectionItem>();

        #endregion Members

        #region Properties


        public IDbConnection this[string Name]
        {
            get
            {
                return getConnection(Name);
            }
        }

        

        #endregion Properties

        #region Constructors

        #endregion Constructors

        #region Methods

        public bool SetConnection(string name, IDbConnection DBConnection)
        {
            bool result = false;

            if (getConnection(name) == null)
            {
                _list.Add(new ConnectionItem(name, DBConnection));
            }

            return result;
        }

        private IDbConnection getConnection(string name)
        {
            IDbConnection resultConnection = null;

            foreach (ConnectionItem c in _list)
            {
                if (c.ConnectionName == name)
                {
                    resultConnection = c.DbConnection;
                    break;
                }
            }

            return resultConnection;
        }

        #endregion Methods
    }
}
