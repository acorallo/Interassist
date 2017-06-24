/******************
 * EGV 24Jun2017 
 * Creación de Archivo
*******************/ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository.Interfaces;
using Cognitas.Framework.Repository;
using DAL.InterAssist.Datasets;
using DAL.InterAssist;
using System.Data;
using Utils.InterAssist;
using System.Globalization;

namespace Entities.InterAsisst
{
    public class TicketTrack
    {
        public int ID { get; set; }
        public int IdTicket { get; set; }
        public DateTime FechaHora { get; set; }
        public int IdOperador { get; set; }
        public int IdEstado { get; set; }
        public string NombreOperador { get; set; }
        public string Estado { get; set; }


        // EGV 25May2017 Inicio
        public TicketTrack()
        {
        }

        public TicketTrack(int id)
        {
            this.ID = id;
            this.IdOperador = PersistEntity.NULL_ID;
            this.IdEstado = PersistEntity.NULL_ID;
        }

        public bool IsNew
        {
            get
            {
                return ID == PersistEntity.NULL_ID;
            }
        }


    }
}
