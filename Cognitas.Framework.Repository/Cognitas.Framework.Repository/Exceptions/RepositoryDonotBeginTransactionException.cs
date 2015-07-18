using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository.Exceptions
{
    public class RepositoryDonotBeginTransactionException : RepositoryException
    {
        private static string ERR_MSG = "Repository {0} has not a transaction begined.";

        public RepositoryDonotBeginTransactionException(string repository) : base(string.Format(ERR_MSG, repository))
        {

        }
    }
}
