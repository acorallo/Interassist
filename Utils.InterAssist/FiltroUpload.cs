using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;

namespace Utils.InterAssist
{
    [Serializable]
    public class FiltroUpload : Filter
    {
        public int ID { get; set; }
        public string Search { get; set; }

        public FiltroUpload()
        {
            this.ResetElements();
        }

        protected override void ResetElements()
        {
            this.ID=NULL_ID;
            this.Search = String.Empty;
            this.OrderBY = " order by ST_DATETIME desc";

        }
    }
}
