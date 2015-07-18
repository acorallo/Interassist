using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;

namespace Utils.InterAssist
{
    [Serializable]
    public class FiltroUploadError : Filter
    {
        public int ID { get; set; }
        public Int64 ID_UPLOAD { get; set; }

        public FiltroUploadError()
        {
            this.ResetElements();
        }

        protected override void ResetElements()
        {
            this.ID = NULL_ID;
            this.ID_UPLOAD = NULL_ID;
            this.OrderBY = " order by FILELINE ASC ";
        }

    }
}
