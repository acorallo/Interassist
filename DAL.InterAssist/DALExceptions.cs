using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DAL.InterAssist
{
    public class DALExceptions : ApplicationException
    {
        public DALExceptions() : base (Constants.TXT_ERR_UKN_DALEXCEPTION)
        {

        }

        public DALExceptions(string errMsg) : base (errMsg)
        {
            
        }
    }
}
