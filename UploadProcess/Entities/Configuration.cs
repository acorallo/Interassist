using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace UploadProcess.Entities
{
    public class Configuration
    {

        #region Properties


        public static void WriteConsole(string msg)
        {
            Console.WriteLine(DateTime.Now.ToString() + ": " + msg);
        }

        public static string PARAM_INBOUND_PATH
        {
            get
            {
                string Result = ConfigurationManager.AppSettings.Get(Entities.Constants.INBOUND_PATH_CFG);

                if (Result == null || Result.Trim() == string.Empty)
                {
                    throw new Exceptions.ConfigParamException(Entities.Constants.INBOUND_PATH_CFG);
                }

                return Result;

            }
        }

        public static string PARAM_OUTBOUND_PATH
        {
            get
            {
                string Result = ConfigurationManager.AppSettings.Get(Entities.Constants.OUTBOUND_PATH_CFG);

                if (Result == null || Result.Trim() == string.Empty)
                {
                    throw new Exceptions.ConfigParamException(Entities.Constants.OUTBOUND_PATH_CFG);
                }

                return Result;
            }
        }

        public static string PARAM_PREBOUND_PATH
        {
            get
            {
                string Result = ConfigurationManager.AppSettings.Get(Entities.Constants.PREBOUND_PATH_CFG);

                if (Result == null || Result.Trim() == string.Empty)
                {
                    throw new Exceptions.ConfigParamException(Entities.Constants.PREBOUND_PATH_CFG);
                }

                return Result;
            }
        }

        #endregion Properties
    }
}
