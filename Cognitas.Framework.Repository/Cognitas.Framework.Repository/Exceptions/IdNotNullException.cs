using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository.Exceptions
{
    public class IdNotNullException : RepositoryException
    {
        private const string ERR_MSG = "ID value cannot be null";

        public IdNotNullException() : base(ERR_MSG)
        {

        }
    }
}
