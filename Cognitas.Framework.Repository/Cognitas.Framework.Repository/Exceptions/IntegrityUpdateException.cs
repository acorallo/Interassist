using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository.Exceptions
{
    public class IntegrityUpdateException : RepositoryException
    {
        private const string ERR_MSG = "Integrity update exception in {0} Store Procedure.";

        public IntegrityUpdateException(string procedureName)
            : base(string.Format(ERR_MSG, procedureName))
        {
        }

    }
}
