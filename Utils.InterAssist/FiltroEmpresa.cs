using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;

namespace Utils.InterAssist
{
    public class FiltroEmpresa : Filter
    {
        public int ID = NULL_ID;
        public string Search = string.Empty;

        protected override void ResetElements()
        {
            this.ID = NULL_ID;
            this.Search= string.Empty;    
        }
    }
}
