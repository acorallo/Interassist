using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadProcess.Exceptions
{
    public class MoveFileException : InterassistSynchroException
    {

        private static readonly string errText = "An error has ocurred when try to move {0} file from INBONUD folder to OUTBOUND folder. InnerExecption: {1}";

        public MoveFileException(string filename, System.Exception ex)
            : base(string.Format(errText, filename, ex.Message))
        {

        }
    }
}
