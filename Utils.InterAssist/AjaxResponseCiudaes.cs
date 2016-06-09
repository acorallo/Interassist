using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace Utils.InterAssist
{
    public class AjaxResponseCiudaes
    {
        public string value;
        public string label;
        public int id;

        public AjaxResponseCiudaes(string value, string label, int id)
        {
            this.value = value;
            this.label = label;
            this.id = id;
        }

        public static DataTable _ubicaciones;

    }
}
