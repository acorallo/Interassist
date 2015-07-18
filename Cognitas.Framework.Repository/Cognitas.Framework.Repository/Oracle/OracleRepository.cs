using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace Cognitas.Framework.Repository.Oracle
{
    public class OracleRepository : DBRepository
    {

        #region Constants

        private const string PARAM_REF_CURSOR = "R_CURSOR";

        #endregion Constants

        #region Properties

        public override bool SupportProcedures
        {
            get
            {
                return true;
            }
        }

        public override bool SupportTransaction
        {
            get
            {
                return true;
            }
        }

        #endregion Propeties

        #region Methods

        public override bool ExecuteProcedure(string ProcedureName, List<System.Data.IDbDataParameter> parameters, System.Data.DataSet ds)
        {
            bool result = false;

            try
            {

                this.DBCommand.CommandType = CommandType.StoredProcedure;
                this.DBCommand.CommandText = ProcedureName;
                this.DBCommand.Connection = this.DBConnection; 
                this.DBCommand.Parameters.Clear();

                foreach (IDataParameter parameter in parameters)
                {
                    this.DBCommand.Parameters.Add(parameter);
                }

                OracleParameter paramRefCursor = new OracleParameter();
                paramRefCursor.OracleDbType = OracleDbType.RefCursor;
                paramRefCursor.Direction = ParameterDirection.Output;
                paramRefCursor.ParameterName = PARAM_REF_CURSOR;
                this.DBCommand.Parameters.Add(paramRefCursor);


                OracleDataAdapter da = new OracleDataAdapter((OracleCommand)this.DBCommand);
                da.Fill(ds);
                result = true;
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
                

            return result;
        }

        #endregion Methods
    }
}
