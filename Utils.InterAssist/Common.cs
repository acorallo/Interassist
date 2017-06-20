using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.InterAssist
{
    public static class Common
    {
        public static string Ubicacion(string calle, string ubicacion)
        {
            return (calle + ", " + ubicacion).Trim().TrimEnd(',');
        }

        public static string ApeYNom(string nombre, string apellido)
        {
            return (apellido + ", " + nombre).Trim().TrimEnd(',');
        }
    }
}
