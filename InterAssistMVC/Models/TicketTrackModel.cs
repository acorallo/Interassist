/* EGV 24Jun2017
 * Creación de Archivos
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.InterAsisst;
using System.ComponentModel.DataAnnotations;
using Utils.InterAssist;

namespace InterAssistMVC.Models
{
    public class TicketTrackModel
    {
        public virtual int Id { get; set; }
        public virtual int IdTicket { get; set; }
        public virtual int IdOperador { get; set; }
        public virtual int IdEstado { get; set; }
        public virtual DateTime FechaHora { get; set; }
        public virtual string NombreOperador { get; set; }
        public virtual string Estado { get; set; }

        public static TicketTrackModel EntityToModel(TicketTrack e)
        {
            TicketTrackModel m = new TicketTrackModel();

            m.Id = e.ID;
            m.IdEstado = e.IdEstado;
            m.IdOperador = e.IdOperador;
            m.IdEstado = e.IdEstado;
            m.FechaHora = e.FechaHora;
            m.NombreOperador = e.NombreOperador;
            m.Estado = e.Estado;

            return m;

        }

        public TicketTrack ModelToEntity()
        {
            TicketTrack e = new TicketTrack();

            e.ID = this.Id;
            e.IdEstado = this.IdEstado;
            e.IdOperador = this.IdOperador;
            e.IdEstado = this.IdEstado;
            e.FechaHora = this.FechaHora;

            return e;

        }

        public static List<TicketTrackModel> EntityToModel(List<TicketTrack> le)
        {
            List<TicketTrackModel> resultList = new List<TicketTrackModel>();

            foreach (TicketTrack e in le)
            {
                resultList.Add(EntityToModel(e));
            }

            return resultList;
        }
    }
}
