using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Cognitas.Framework.Repository
{
    public abstract class ConnectionPool
    {
        #region Constants
        #endregion Constants

        #region Properties

        protected abstract StoredConnectionList list { get; }

        #endregion Properties

        #region Metodos

        public IDbConnection GetConnection(string connectionSting, string connectionName, DBFactory factory)
        {
            IDbConnection result = null;

            StoredConnection s = list.Get(connectionName);
            if (s == null)
            {
                result = factory.getDBConnection(connectionSting);
                this.list.Add(new StoredConnection(result, connectionName));
            }
            else
            {
                result = s.DbConnection;
            }


            return result;
        }

        

        #endregion Metodos
    }
}
