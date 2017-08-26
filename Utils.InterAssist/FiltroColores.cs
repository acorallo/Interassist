using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;

namespace Utils.InterAssist
{
    public class FiltroColores : Filter
    {
        public int ID = Filter.NULL_ID;

        protected override void ResetElements()
        {
            this.ID = Filter.NULL_ID;
        }
    }
}
