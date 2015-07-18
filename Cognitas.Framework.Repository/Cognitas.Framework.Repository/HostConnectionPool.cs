using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository
{
    public class HostConnectionPool : ConnectionPool
    {
        #region Members

        private static StoredConnectionList _connectionlist;

        #endregion Member

        #region Properties

        protected override StoredConnectionList list
        {
            get
            {
                if (_connectionlist == null)
                    _connectionlist = new StoredConnectionList();
                return _connectionlist;
            }
        }

        #endregion Properties

        #region Methods



        #endregion Methdos
    }
}
