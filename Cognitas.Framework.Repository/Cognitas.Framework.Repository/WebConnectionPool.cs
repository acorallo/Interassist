using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;

namespace Cognitas.Framework.Repository
{
    public class WebConnectionPool : ConnectionPool
    {

        #region Constants

        private const string CONNECTION_POOL_SESSION_KEY = "ConnectionPool";


        #endregion Constants

        #region Properties

        protected override StoredConnectionList list
        {
            get
            {
                if (System.Web.HttpContext.Current.Session[CONNECTION_POOL_SESSION_KEY] == null)
                    System.Web.HttpContext.Current.Session[CONNECTION_POOL_SESSION_KEY] = new StoredConnectionList();
                return (StoredConnectionList)System.Web.HttpContext.Current.Session[CONNECTION_POOL_SESSION_KEY];
            }
        }

        #endregion Properties

    }
            
}
