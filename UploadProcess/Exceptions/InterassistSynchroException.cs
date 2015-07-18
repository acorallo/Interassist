using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadProcess.Exceptions
{
    public class InterassistSynchroException: ApplicationException
    {
        public InterassistSynchroException()
        {

        }

        public InterassistSynchroException(string errMsg) : base (errMsg)
        {

        }
    }
}
