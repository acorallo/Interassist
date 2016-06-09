using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.InterAssist.Classes
{
    public class Ubicacion
    {

        public int IDLocalidad = -1;
        public int IDCiudad = -1;
        public int IDProvincia = -1;
        public int IDPais = -1;

        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Localidad { get; set; }


    }
}