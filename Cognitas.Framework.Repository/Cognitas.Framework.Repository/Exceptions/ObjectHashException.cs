using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository.Exceptions
{
    public class ObjectHashException : RepositoryException
    {
        private static string ERR_MSG = "It Couldn't persist the object {0} because hass't a valid UOBJECTHASH.";

        public ObjectHashException(string objectName): base(string.Format(ERR_MSG, objectName))
        {
        }
        
    }
}
