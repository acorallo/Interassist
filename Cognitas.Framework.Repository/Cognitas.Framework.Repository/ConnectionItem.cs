using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Cognitas.Framework.Repository
{
    public class ConnectionItem
    {

        #region Members

        private string _connectionName;
        private IDbConnection _dbConnection;

        #endregion Members

        #region Properties

        public IDbConnection DbConnection
        {
            get { return _dbConnection; }
            set { _dbConnection = value; }
        }

        public string ConnectionName
        {
            get { return _connectionName; }
        }

        #endregion Properties;

        #region Constructors

        public ConnectionItem(string connectionName, IDbConnection dbConnection)
        {
            this._connectionName = connectionName;
            this._dbConnection = dbConnection;
        }

        #endregion Constructors
    }
}
