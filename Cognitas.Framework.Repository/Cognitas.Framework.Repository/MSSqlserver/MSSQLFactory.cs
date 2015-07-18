using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Cognitas.Framework.Repository.MSSqlserver
{
    public class MSSQLFactory : DBFactory
    {

        #region Class Constructors



        public MSSQLFactory()
        {

        }

        #endregion Constructors

        #region Static Methods

        public static MSSQLFactory GetInstance()
        {
            return new MSSQLFactory();
        }

        #endregion Static Methods

        #region Methods

        public override System.Data.IDbCommand getDBCommand()
        {
             return new SqlCommand();
        }

        public override System.Data.IDbConnection getDBConnection()
        {
            return new SqlConnection();
        }

        public override System.Data.IDbConnection getDBConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        public override DBRepository getRepository()
        {
            return new MSSQLRepository();
        }
        
        public override System.Data.IDbDataAdapter getDataAdapter(IDbCommand command)
        {
            return new SqlDataAdapter();
        }

        public override IDbDataParameter getDataParameter()
        {
            return new SqlParameter();
        }

        public override IDbDataParameter getDataParameter(string parameterName)
        {
            SqlParameter sResult = new SqlParameter();
            sResult.ParameterName = parameterName;
            return sResult;
        }

        public override IDbDataParameter getDataParameter(string parameterName, DbType parameterType)
        {
            return new SqlParameter(parameterName, parameterType); 
        }

        public override IDbDataParameter getDataParameter(string parameterName, DbType parameterType, object value)
        {
            SqlParameter oParam = new SqlParameter();
            oParam.ParameterName = parameterName;
            oParam.DbType = parameterType;
            oParam.Value = value;
            return oParam;
        }

        public override IDbDataParameter getDataParameter(string parameterName, DbType parameterType, object value, ParameterDirection direction)
        {
            SqlParameter oParam = new SqlParameter();
            oParam.ParameterName = parameterName;
            oParam.DbType = parameterType;
            oParam.Value = value;
            oParam.Direction = direction;

            return oParam;
        }

        

        #endregion Methods

    }
}
