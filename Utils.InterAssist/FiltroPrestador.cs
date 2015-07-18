using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;

namespace Utils.InterAssist
{
    [Serializable]
    public class FiltroPrestador : Filter
    {
        public int ID = NULL_ID;
        public string Nombre = string.Empty;
        public string Descripcion = string.Empty;
        public int ESTADO = NULL_ID;
        public int IdProvincia = NULL_ID;
        public int IdPais = NULL_ID;
        public string Localidad = string.Empty;
        public string Search = string.Empty;

        public const int ESTADO_ACTIVO = 1;
        public const int ESTADO_NO_ACTIVO = 0;

        protected override void ResetElements()
        {
            this.ID = NULL_ID;
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
            this.ESTADO = NULL_ID;    
            this.IdProvincia = NULL_ID;
            this.IdPais = NULL_ID;
            this.Localidad = string.Empty;
            this.Search = string.Empty;
        }

    }
}
