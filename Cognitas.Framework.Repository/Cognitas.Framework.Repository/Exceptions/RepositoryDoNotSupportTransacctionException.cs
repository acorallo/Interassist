using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository.Exceptions;

namespace Cognitas.Framework.Repository.Exceptions
{
    public class RepositoryDoNotSupportTransacctionException : RepositoryException
    {
        private static string ERR_MSG = "Repository type {0} does not support transaction.";

        public RepositoryDoNotSupportTransacctionException(string repositoryType)
            : base(string.Format(ERR_MSG, repositoryType))
        {
        }
    }
}
