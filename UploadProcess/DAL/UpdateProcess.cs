using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Configuration;

namespace UploadProcess.DAL
{
    public class UpdateProcess
    {

        private static readonly string RunProcess_ProcedureName = "upload_pkg.PROCESS_FILE";

        private static readonly string DEFAULT_CONNECTION_NAME = "DEFAULT";

        public bool RunUpdateProcess(string filePath)
        {
            bool result = false;

            ConnectionStringSettings cStringSetting = ConfigurationManager.ConnectionStrings[DEFAULT_CONNECTION_NAME];

            OracleConnection oCon = new OracleConnection(cStringSetting.ConnectionString);

            try
            {
                oCon.Open();

                OracleCommand oCommand = oCon.CreateCommand();


                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.CommandText = RunProcess_ProcedureName;


                OracleParameter paramFilePath = new OracleParameter("filePath", OracleType.VarChar);
                paramFilePath.Value = filePath;


                OracleParameter paramResult = new OracleParameter("p_result", OracleType.Int32);
                paramResult.Direction = System.Data.ParameterDirection.Output;

                oCommand.Parameters.Add(paramFilePath);
                oCommand.Parameters.Add(paramResult);

                oCommand.ExecuteNonQuery();

                result = ((Int32)paramResult.Value) == 1;

                oCon.Close();
                oCon.Dispose();
                oCommand.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                oCon.Close();
                oCon.Dispose();
            }

            return result;
        }
    }
}
