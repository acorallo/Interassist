using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.InterAsisst
{
    public class Ubicacion
    {
        public int idPais { get; set; }
        public int idProvincia { get; set; }
        public int idLocalidad { get; set; }
        public int idCiudad { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Localidad { get; set; }

        public List<Ubicacion> getUbicaciones()
        {
            List<Ubicacion> resultList = new List<Ubicacion>();

            return resultList;
        }

    }
}
