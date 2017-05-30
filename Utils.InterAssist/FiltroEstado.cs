/* EGV 25May2017 Inicio
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;

namespace Utils.InterAssist
{
    public class FiltroEstado : Filter
    {
        public int ID = NULL_ID;
        public string Grupo = "";

        protected override void ResetElements()
        {
            this.ID = NULL_ID;
            this.Grupo = "";
        }

        public FiltroEstado()
        {
            ResetElements();
        }

        public FiltroEstado(string grupo)
        {
            ResetElements();
            this.Grupo = grupo;
        }
    }
}
