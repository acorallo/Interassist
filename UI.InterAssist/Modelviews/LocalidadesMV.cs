using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace UI.InterAssist.Modelviews
{
    public class LocalidadesMV
    {
        int idPais { get; set; }
        int idProvincia { get; set; }
        int idLocalidad { get; set; }
        int idCiudad { get; set; }
        string Pais { get; set; }
        string Provincia { get; set; }
        string Ciudad { get; set; }
        string Localidad { get; set; }


        public static List<LocalidadesMV> getLocalidadesMV()
        {
            List<LocalidadesMV> result = new List<LocalidadesMV>();

            

            return result;
        }
            
    }
}