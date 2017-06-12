using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.InterAsisst;
using System.ComponentModel.DataAnnotations;        // EGV 11Jun2017

namespace InterAssistMVC.Models
{
    public class Observacion
    {
        public virtual int Id { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual bool Estado { get; set; }

        [Required]                  // EGV 11Jun2017
        [StringLength(3999)]        // EGV 11Jun2017
        public virtual string Descripcion { get; set; }

        [Required]                  // EGV 11Jun2017
        public virtual int IdOperador { get; set; }

        [Required]                  // EGV 11Jun2017
        public virtual int IdTicket { get; set; }

        public virtual string NombreOperador { get; set; }
        public virtual string ApellidoOperador { get; set; }

        public static Observacion EntityToModel(Entities.InterAsisst.Observacion e)
        {
            Observacion m = new Observacion();
            m.Id = e.ID;
            m.Fecha = e.Fecha;
            m.Estado = e.Estado;
            m.Descripcion = e.Descripcion;
            m.IdOperador = e.IdOperador;
            m.IdTicket = e.IdTicket;
            m.NombreOperador = e.NombreOperador;
            m.ApellidoOperador = e.ApellidoOperador;

            return m;
        }

        private Entities.InterAsisst.Observacion ModelToEntity()
        {
            Entities.InterAsisst.Observacion e = new Entities.InterAsisst.Observacion(25);

            //e.ID = this.Id;
            e.Fecha = this.Fecha;
            e.Estado = this.Estado;
            e.Descripcion = this.Descripcion;
            e.IdOperador = this.IdOperador;
            e.IdTicket = this.IdTicket;
            e.NombreOperador = this.NombreOperador;
            e.ApellidoOperador = this.ApellidoOperador;

            return e;
        }

    }
}