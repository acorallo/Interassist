/* EGV 03Jun2017
 Creación de Clase Prestacion
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.InterAsisst;

namespace InterAssistMVC.Models
{
    public class UbicacionModel
    {
        public virtual int IdLocalidad { get; set; }
        public virtual int IdCiudad { get; set; }
        public virtual int IdProvincia { get; set; }
        public virtual int IdPais { get; set; }
        public virtual string Localidad { get; set; }
        public virtual string Ciudad { get; set; }
        public virtual string Provincia { get; set; }
        public virtual string Pais { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string CalleUbicacion { get; set; }
        public virtual string Calle { get; set; }
        public virtual string DatosUbicacion { get; set; }

        public static UbicacionModel EntityToModel(Ubicacion e)
        {
            UbicacionModel m = new UbicacionModel();

            m.IdLocalidad = e.idLocalidad;
            m.IdCiudad = e.idCiudad;
            m.IdProvincia = e.idProvincia;
            m.IdPais = e.idPais;
            m.Localidad = e.Localidad;
            m.Ciudad = e.Ciudad;
            m.Provincia = e.Provincia;
            m.Pais = e.Pais;
            m.Nombre = e.Nombre;

            return m;

        }

        public static List<UbicacionModel> EntityToModel(List<Ubicacion> le)
        {
            List<UbicacionModel> resultList = new List<UbicacionModel>();


            foreach (Ubicacion e in le)
            {
                resultList.Add(EntityToModel(e));
            }

            return resultList;
        }

    }
}