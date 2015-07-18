using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;

namespace Utils.InterAssist
{
    public class FiltroOperador : Filter
    {
        public int ID = NULL_ID;
        public string Apellido = string.Empty;
        public int Estado = NULL_ID;
        public int Admin = NULL_ID;
        public string Clave = string.Empty;
        public string Usuario = string.Empty;
        public string Nombre = string.Empty;
        public string Search = string.Empty;

        protected override void ResetElements()
        {
            this.ID = NULL_ID;
            this.Apellido = string.Empty;
            this.Estado = NULL_ID;
            this.Admin = NULL_ID;
            this.Clave = string.Empty;
            this.Usuario = string.Empty;
            this.Nombre = string.Empty;
            this.Search = string.Empty;
        }

    }


}
