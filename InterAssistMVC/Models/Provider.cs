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

        // EGV 10Jun2017 Inicio
        public virtual string Descripcion { get; set; }
        public virtual string Telefono2 { get; set; }
        public virtual string Celular { get; set; }
        public virtual string Celular2 { get; set; }
        public virtual string Nextel { get; set; }
        public virtual string Email { get; set; }
        public virtual string Cuit { get; set; }
        public virtual string Iva { get; set; }
        public virtual float? LivMovida { get; set; }
        public virtual float? LivKm { get; set; }
        public virtual float? Sp1Movida { get; set; }
        public virtual float? Sp1Km { get; set; }
        public virtual float? Sp2Movida { get; set; }
        public virtual float? Sp2Km { get; set; }
        public virtual float? Ps1Movida { get; set; }
        public virtual float? Ps1Km { get; set; }
        public virtual float? Ps2Movida { get; set; }
        public virtual float? Ps2Km { get; set; }

        public virtual string DatosPrestador { get; set; }
        // EGV 10Jun2017 Fin
        
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

            // EGV 10Jun2017 Inicio
            resultProvider.Descripcion = p.Descripcion;
            resultProvider.Telefono2 = p.Telefono2;
            resultProvider.Celular = p.Celular1;
            resultProvider.Celular2 = p.Celular2;
            resultProvider.Nextel = p.Nextel;
            resultProvider.Email = p.Email;
            resultProvider.Cuit = p.Cuit;
            resultProvider.Iva = p.Iva;
            resultProvider.LivMovida = p.LIV_MOVIDA;
            resultProvider.LivKm = p.LIV_KM;
            resultProvider.Sp1Movida = p.SP1_MOVIDA;
            resultProvider.Sp1Km = p.SP1_KM;
            resultProvider.Sp2Movida = p.SP2_MOVIDA;
            resultProvider.Sp2Km = p.SP2_KM;
            resultProvider.Ps1Movida = p.PS1_MOVIDA;
            resultProvider.Ps1Km = p.PS1_KM;
            resultProvider.Ps2Movida = p.PS2_MOVIDA;
            resultProvider.Ps2Km = p.PS2_KM;

            resultProvider.DatosPrestador = Newtonsoft.Json.JsonConvert.SerializeObject(new { Id = resultProvider.Id, Nombre = resultProvider.Nombre, Pais = resultProvider.Pais, Provincia = resultProvider.Provincia, Ciudad = resultProvider.Ciudad, Localidad = resultProvider.Localidad, Domicilio = resultProvider.Domicilio, Telefono = resultProvider.Telefono, Descripcion = resultProvider.Descripcion, Telefono2 = resultProvider.Telefono2, Celular = resultProvider.Celular, Celular2 = resultProvider.Celular2, Nextel = resultProvider.Nextel, Email = resultProvider.Email, Cuit = resultProvider.Cuit, Iva = resultProvider.Iva, LivMovida = resultProvider.LivMovida, LivKm = resultProvider.LivKm, Sp1Movida = resultProvider.Sp1Movida, Sp1Km = resultProvider.Sp1Km, Sp2Movida = resultProvider.Sp2Movida, Sp2Km = resultProvider.Sp2Km, Ps1Movida = resultProvider.Ps1Movida, Ps1Km = resultProvider.Ps1Km, Ps2Movida = resultProvider.Ps2Movida, Ps2Km = resultProvider.Ps2Km });
            // EGV 10Jun2017 Fin

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