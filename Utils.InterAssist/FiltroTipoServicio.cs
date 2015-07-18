using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;

namespace Utils.InterAssist
{
    public class FiltroTipoServicio : Filter
    {
        public int ID = NULL_ID;

        protected override void ResetElements()
        {
            this.ID = NULL_ID;
        }
        
    }
}
