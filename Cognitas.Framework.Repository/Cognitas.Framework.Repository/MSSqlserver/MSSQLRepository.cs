using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository.MSSqlserver
{
    public class MSSQLRepository : DBRepository
    {
        public override bool SupportProcedures
        {
            get
            {
                return true;
            }
        }

        public override bool SupportTransaction
        {
            get
            {
                return true;
            }
        }
    }
}
