using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;

namespace Utils.InterAssist
{
    public class FiltroCiudad : Filter
    {
        public int ID = Filter.NULL_ID;
        public int IDProvinca = Filter.NULL_ID;
        public int IDPais = Filter.NULL_ID;

        protected override void ResetElements()
        {
            this.ID = NULL_ID;
            this.IDProvinca = NULL_ID;
            this.IDPais = NULL_ID;
        }
    }
}
