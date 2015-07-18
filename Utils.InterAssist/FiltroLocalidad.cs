using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;


namespace Utils.InterAssist
{
    public class FiltroLocalidad : Filter
    {
        public int ID = Filter.NULL_ID;
        public int IDCiudad = Filter.NULL_ID;
        public string Search = string.Empty;

        protected override void ResetElements()
        {
            this.ID = NULL_ID;
            this.IDCiudad = NULL_ID;
            this.Search = string.Empty;

        }
    }
}
