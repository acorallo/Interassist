using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;


namespace Utils.InterAssist
{
    public class FiltroOberservaciones : Filter
    {
        public int ID = Filter.NULL_ID;
        public int IDOperador = Filter.NULL_ID;
        public int IDTicket = Filter.NULL_ID;

        protected override void ResetElements()
        {
            this.ID = Filter.NULL_ID;
            this.IDOperador = Filter.NULL_ID;
            this.IDTicket = Filter.NULL_ID;
        }
    }
}
