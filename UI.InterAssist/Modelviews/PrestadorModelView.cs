using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.InterAssist.Modelviews
{
    
    [Serializable]
    public class PrestadorModelView
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Comentarios { get; set; }
    }
}