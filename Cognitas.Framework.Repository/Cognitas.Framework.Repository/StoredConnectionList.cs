using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository
{
    public class StoredConnectionList : List<StoredConnection>
    {
        public StoredConnection Get(string connectionName)
        {
            StoredConnection result = null;

            foreach (StoredConnection s in this)
            {
                if (s.ConnectionName == connectionName)
                {
                    result = s;
                    break;
                }
            }

            return result;

        }
    }
}
