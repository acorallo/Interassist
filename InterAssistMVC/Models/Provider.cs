using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.InterAsisst;
using System.Collections;
using Ext.Net.MVC;

namespace InterAssistMVC.Models
{
    public class Provider
    {
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Pais { get; set; }
        public virtual string Provincia { get; set; }
        public virtual string Ciudad { get; set; }
        public virtual string Localidad { get; set; }
        public virtual string Domicilio { get; set; }
        public virtual string Telefono { get; set; }
        
        public static Provider EntityToModel(Prestador p)
        {
            Provider resultProvider = new Provider();

            resultProvider.Id = p.ID;
            resultProvider.Nombre = p.Nombre;
            resultProvider.Pais = p.NombrePais;
            resultProvider.Provincia = p.ProvinciaNombre;
            resultProvider.Ciudad = p.NombreCiudad;
            resultProvider.Localidad = p.LocalidadNombre;
            resultProvider.Domicilio = p.Domicilio;
            resultProvider.Telefono = p.Telefono1;


            return resultProvider;
        }

        public static List<Provider> EntityToModel(List<Prestador> lp)
        {
            List<Provider> resultList = new List<Provider>();


            foreach(Prestador p in lp)
            {
                resultList.Add(EntityToModel(p));
            }

            return resultList;
        }

        
        
    }
}