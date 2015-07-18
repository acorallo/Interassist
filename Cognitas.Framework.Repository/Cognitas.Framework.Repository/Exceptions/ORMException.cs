using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository.Exceptions
{
    public class ORMException : RepositoryException 
    {
        public ORMException(string objectName)
            : base(objectName)
        {

        }
            
    }
}
