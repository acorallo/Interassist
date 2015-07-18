using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Cognitas.Framework.Repository
{
    public class StoredConnection
    {


        #region Constructors

        public StoredConnection(IDbConnection connection, string connectionName)
        {
            this.DbConnection = connection;
            this._connectionName = connectionName;
        }

        #endregion Constructors;

        #region Members

        private IDbConnection _dbConnection;
        private string _connectionName;

        #endregion Members

        #region Properties

        public string ConnectionName
        {
            get { return _connectionName; }
            set { _connectionName = value; }
        }

        public IDbConnection DbConnection
        {
            get { return _dbConnection; }
            set { _dbConnection = value; }
        }

        #endregion Properties


    }
}
