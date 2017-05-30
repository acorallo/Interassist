using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.InterAsisst;

namespace InterAssistMVC.Models
{
    public class Observacion
    {
        public virtual int Id { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual bool Estado { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual int IdOperador { get; set; }
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