using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository.Exceptions
{
    public class ConnectionNameNotFoundException : RepositoryException
    {
        public static readonly string errMsg = "Connection name {0} couldn't be found into applicaction configuration file.";

        public ConnectionNameNotFoundException(string connectionName)
            : base(string.Format(errMsg, connectionName))
        {
        }

    }
}
