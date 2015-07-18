using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository.Exceptions
{
    public class RepositoryAttributeException : RepositoryException
    {
        public RepositoryAttributeException(string objectName) : base (objectName)
        {

        }
    }
}
