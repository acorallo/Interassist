using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;

namespace Utils.InterAssist
{
    [Serializable]
    public class FiltroAfiliado : Filter
    {
        public int ID = NULL_ID;
        public string Apellido = string.Empty;
        public string Nombre = string.Empty;
        public string Poliza = string.Empty;
        public string Documento = string.Empty;
        public string Patente = string.Empty;
        public int IDEmpresa = FiltroAfiliado.NULL_ID;
        public string Search = string.Empty;
        public bool Vigente = false;        // EGV 10Jun2017

        protected override void ResetElements()
        {
           this.ID = NULL_ID;
           this.Apellido = string.Empty;
           this.Nombre = string.Empty;
           this.Poliza = string.Empty;
           this.Documento = string.Empty;
           this.Patente = string.Empty;
           this.IDEmpresa = FiltroAfiliado.NULL_ID;
           this.Search = string.Empty;
           this.Vigente = false;        // EGV 10Jun2017
        }

    }
}
