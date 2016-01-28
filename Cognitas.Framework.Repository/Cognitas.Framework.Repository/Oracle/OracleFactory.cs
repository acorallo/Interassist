using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace Cognitas.Framework.Repository.Oracle
{
    public class OracleFactory : DBFactory
    {

        #region Members

       
        #endregion Members

        #region Class Constructors

        public OracleFactory()
        {

        }

        #endregion Class Constructors

        #region Static Methods

        public static OracleFactory GetInstance()
        {
            return new OracleFactory();
        }

       

        #endregion Static Methods

        #region Methods

        public override IDbCommand getDBCommand()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.BindByName = true;
            return cmd;

        }

        public override IDbConnection getDBConnection()
        {
            return new OracleConnection();
        }

        public override IDbConnection getDBConnection(string connectionString)
        {
            return new OracleConnection(connectionString);
        }

        public override DBRepository getRepository()
        {
            return new OracleRepository();
        }
        
        public override IDbDataAdapter getDataAdapter(IDbCommand command)
        {
            return new OracleDataAdapter((OracleCommand)command);
            }

        public override IDbDataParameter getDataParameter()
        {
            return new OracleParameter();
        }

        public override IDbDataParameter getDataParameter(string parameterName)
        {
            OracleParameter oResult = new OracleParameter();
            oResult.ParameterName = parameterName;
            oResult.SourceColumn = parameterName;
            return oResult;
        }

        public override IDbDataParameter getDataParameter(string parameterName, DbType parameterType)
        {
            OracleParameter oParam = new OracleParameter();
            oParam.ParameterName = parameterName;
            oParam.SourceColumn = parameterName;
            oParam.DbType = parameterType;

            return oParam;
            
        }

        public override IDbDataParameter getDataParameter(string parameterName, DbType parameterType, object value)
        {
            OracleParameter oParam = new OracleParameter();
            oParam.ParameterName = parameterName;
            oParam.SourceColumn = parameterName;
            oParam.DbType = parameterType;
            oParam.Value = value;

            return oParam;

        }

        public override IDbDataParameter getDataParameter(string parameterName, DbType parameterType, object value, ParameterDirection direction)
        {
            OracleParameter oParam = new OracleParameter();
            oParam.ParameterName = parameterName;
            oParam.SourceColumn = parameterName;
            oParam.DbType = parameterType;
            oParam.Value = value;
            oParam.Direction = direction;
            return oParam;

        }
        
        #endregion Methods

    }
}
