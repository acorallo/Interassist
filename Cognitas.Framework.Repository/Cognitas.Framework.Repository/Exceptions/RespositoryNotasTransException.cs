using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository.Exceptions
{


    public class RespositoryNotasTransException : RepositoryException
    {
        private static string ERR_MSG = "Repository {0} has not been declared as transactioable.";

        public RespositoryNotasTransException(string respository)
            : base(string.Format(ERR_MSG, respository))
        {
        }
    }
}
