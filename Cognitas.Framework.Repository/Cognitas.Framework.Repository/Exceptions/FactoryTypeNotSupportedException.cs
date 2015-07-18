using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository.Exceptions
{
    public class FactoryTypeNotSupportedException : RepositoryException
    {
        
        public static readonly string errMsg = "Database factory try to create a {1}, type but It's not supported. Please, ensure that the database provider into configuration file is correct."; 
         
        public FactoryTypeNotSupportedException(Exception innerEx) 
            : base(innerEx)
        {
            
        }

        public FactoryTypeNotSupportedException(string dbProvider)
            : base(string.Format(errMsg, dbProvider))
        {

        }
    }
}
