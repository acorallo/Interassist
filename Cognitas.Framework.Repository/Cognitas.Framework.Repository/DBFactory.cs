using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cognitas.Framework.Repository.Exceptions;
using Cognitas.Framework.Repository.MSSqlserver;
using Cognitas.Framework.Repository.Oracle;

namespace Cognitas.Framework.Repository
{
    public abstract class DBFactory
    {
        #region Constantes

        // Prividers definition.
        private const string ORACLE_PROVIDER = "ORACLE";
        private const string MSSQLSERVER_PROVIDER = "MSSQL";
        private const string MSACCESS_PROVIDER = "MSACCESS";
        

        #endregion Constantes

        #region Members

        #endregion Members

        #region Static Methods

        public static DBFactory GetInstance(string dbProvider)
        {
            DBFactory resultFactory = null;

            switch (dbProvider)
            {
                case ORACLE_PROVIDER:
                    resultFactory = new OracleFactory();
                    break;
                case MSSQLSERVER_PROVIDER:
                    resultFactory = new MSSQLFactory();
                    break;
                default:
                    throw new FactoryTypeNotSupportedException(dbProvider);
                    break;

            }


            return resultFactory;
        }
      
        #endregion Static Methods

        #region abstract Methods

        public abstract IDbCommand getDBCommand();
        public abstract IDbConnection getDBConnection();
        public abstract IDbConnection getDBConnection(String connectionString);
        public abstract DBRepository getRepository();
        public abstract IDbDataAdapter getDataAdapter(IDbCommand cmd);
        public abstract IDbDataParameter getDataParameter();
        public abstract IDbDataParameter getDataParameter(string parameterName);
        public abstract IDbDataParameter getDataParameter(string parameterName, DbType parameterType);
        public abstract IDbDataParameter getDataParameter(string parameterName, DbType parameterType, object value);
        public abstract IDbDataParameter getDataParameter(string parameterName, DbType parameterType, object value, ParameterDirection direccion);
        
 

        #endregion abstract Methods

    }
}
