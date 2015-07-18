using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository.Exceptions
{

    public class RepositoryException : System.ApplicationException
    {

        public static readonly string errMsg = "An unknow error ocurrs into repository framework.";

        public RepositoryException(Exception innerEx) 
            : base(errMsg, innerEx)
        {
            
        }

        public RepositoryException(string txtError)
            : base(txtError)
        {

        }
    }
}
