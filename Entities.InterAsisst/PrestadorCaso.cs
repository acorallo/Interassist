﻿using System;
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
    public class PrestadorCaso
    {
        public int ID { get; set; }
        public Prestador Prestador { get; set; }
        public TipoServicio TipoServicio { get; set; }
        public string Comentarios;
        public Decimal Kilometros;
        public Decimal Costo;
        public int IdPrestador { get; set; }
        public int IdTipoServicio { get; set; }
        public int IdPaisOrigen { get; set; }
        public int IdPaisDestino { get; set; }
        public int IdProvinciaOrigen { get; set; }
        public int IdProvinciaDestino { get; set; }
        public int IdCiudadOrigen { get; set; }
        public int IdCiudadDestino { get; set; }
        public string CalleOrigen { get; set; }
        public int IdLocalidadOrigen { get; set; }
        public int IdLocalidadDestino { get; set; }
        public string CalleDestino { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public int IdTicketPrestadorRetrabajo { get; set; }
        public string Patente { get; set; }
        public string NombreChofer { get; set; }
        public virtual string NombreLocalidadOrigen { get; set; }
        public virtual string NombreLocalidadDestino { get; set; }
        public virtual int IdFinalizacion { get; set; }
        public string DemoraEst { get; set; }
        public string DemoraReal { get; set; }
        public int IdTipoPrestacion { get; set; }
        public string CodigoTipoPrestacion { get; set; }

        public Utils.InterAssist.Constants.PersistOperationType TipoOperacion = Utils.InterAssist.Constants.PersistOperationType.Persist;

        public PrestadorCaso()
            : this(PersistEntity.NULL_ID)
        {
        }

        public PrestadorCaso(int id)
        {
            this.ID = id;
            this.IdCiudadDestino = PersistEntity.NULL_ID;
            this.IdCiudadOrigen = PersistEntity.NULL_ID;
            this.IdEstado = PersistEntity.NULL_ID;
            this.IdLocalidadDestino = PersistEntity.NULL_ID;
            this.IdLocalidadOrigen = PersistEntity.NULL_ID;
            this.IdPaisDestino = PersistEntity.NULL_ID;
            this.IdPaisOrigen = PersistEntity.NULL_ID;
            this.IdProvinciaDestino = PersistEntity.NULL_ID;
            this.IdProvinciaOrigen = PersistEntity.NULL_ID;
            this.IdTicketPrestadorRetrabajo = PersistEntity.NULL_ID;
            this.IdPrestador = PersistEntity.NULL_ID;
            this.IdTipoServicio = PersistEntity.NULL_ID;
            this.IdFinalizacion = PersistEntity.NULL_ID;
            this.IdTipoPrestacion = PersistEntity.NULL_ID;
        }

        public void ObjectToRow(Ticket_Prestador.TICKET_PRESTADORESRow resultRow)
        {
            resultRow.IDTICKETPRESTADOR = this.ID;
            resultRow.IDPRESTADOR = this.IdPrestador;
            resultRow.IDTIPOSERVICIO = this.IdTipoServicio;
            resultRow.COMENTARIOS = this.Comentarios;
            resultRow.PERSISTOPERATION = (int)this.TipoOperacion;
            resultRow.COSTO = this.Costo;
            resultRow.KILOMETROS = this.Kilometros;
            resultRow.IDPAIS_ORIGEN = this.IdPaisOrigen;
            resultRow.IDPAIS_DESTINO = this.IdPaisDestino;
            resultRow.IDPROVINCIA_ORIGEN = this.IdProvinciaOrigen;
            resultRow.IDPROVINCIA_DESTINO = this.IdProvinciaDestino;
            resultRow.IDCIUDAD_ORIGEN = this.IdCiudadOrigen;
            resultRow.IDCIUDAD_DESTINO = this.IdCiudadDestino;
            resultRow.CALLE_ORIGEN = this.CalleOrigen;
            resultRow.IDLOCALIDAD_ORIGEN = this.IdLocalidadOrigen;
            resultRow.IDLOCALIDAD_DESTINO = this.IdLocalidadDestino;
            resultRow.CALLE_DESTINO = this.CalleDestino;
            resultRow.IDESTADO = this.IdEstado;
            resultRow.IDTICKETPRESTADOR_RETRABAJO = this.IdTicketPrestadorRetrabajo;
            resultRow.PATENTE = this.Patente;
            resultRow.NOMBRE_CHOFER = this.NombreChofer;
            resultRow.IDFINALIZACION = this.IdFinalizacion;
            resultRow.DEMORA_EST = this.DemoraEst;
            resultRow.DEMORA_REAL = this.DemoraReal;
            resultRow.IDTIPOPRESTACION = this.IdTipoPrestacion;
        }

        public DAL.InterAssist.Datasets.Ticket_Prestador.TICKET_PRESTADORESRow ObjectToRow()
        {
            Ticket_Prestador.TICKET_PRESTADORESRow resultRow = (new Ticket_Prestador.TICKET_PRESTADORESDataTable()).NewTICKET_PRESTADORESRow();

            ObjectToRow(resultRow);

            return resultRow;
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
