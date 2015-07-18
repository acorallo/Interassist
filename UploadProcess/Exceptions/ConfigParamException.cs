using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadProcess.Exceptions
{
    public class ConfigParamException : InterassistSynchroException
    {

        private static readonly string errText = "An error has ocurred while trying to read the {0} configuration parameter. Please check the application configuration file. ";

        public ConfigParamException (string ParamName) : base(string.Format(errText, ParamName.ToString()))
        {
            
        }
    }
}
