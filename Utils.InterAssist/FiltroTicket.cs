using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;


namespace Utils.InterAssist
{
    [Serializable]
    public class FiltroTicket : Filter
    {
        public int ID = NULL_ID;
        public int IDOperador = NULL_ID;
        public int IDAfiliado = NULL_ID;
        public int IDCiudadOrigen = NULL_ID;
        public int IDCiudadDestino = NULL_ID;
        public int IDPrestador = NULL_ID;
        public string Search = string.Empty;

        protected override void ResetElements()
        {
            this.ID = NULL_ID;
            this.IDOperador = NULL_ID;
            this.IDAfiliado = NULL_ID;
            this.IDCiudadOrigen = NULL_ID;
            this.IDCiudadDestino = NULL_ID;
            this.IDPrestador = NULL_ID;
            this.Search = string.Empty;
        }

    }
}
