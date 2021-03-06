﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.InterAsisst;
using System.ComponentModel.DataAnnotations;
using Utils.InterAssist;

namespace InterAssistMVC.Models
{
    public class Prestacion
    {
        public virtual int Id { get; set; }
        public virtual int IdPrestador { get; set; }
        public virtual string NombrePrestador { get; set; }
        
        [Required]
        public virtual int IdTipoServicio { get; set; }

        public virtual string DescripcionServicio { get; set; }

        public virtual int Numero { get; set; }
        public virtual string NombrePrestacion { get; set; }
        
        [StringLength(1024)]
        public virtual string Comentarios { get; set; }

        [Range(-1, 9999999)]
        public virtual Decimal Kilometros { get; set; }

        [Range(-1, 9999999)]
        public virtual Decimal Costo { get; set; }

        public virtual int IdPaisOrigen { get; set; }
        public virtual int IdPaisDestino { get; set; }
        public virtual int IdProvinciaOrigen { get; set; }
        public virtual int IdProvinciaDestino { get; set; }
        public virtual int IdCiudadOrigen { get; set; }
        public virtual int IdCiudadDestino { get; set; }

        [StringLength(1024)]
        public virtual string CalleOrigen { get; set; }
        public virtual int IdLocalidadOrigen { get; set; }
        public virtual int IdLocalidadDestino { get; set; }

        [StringLength(1024)]
        public virtual string CalleDestino { get; set; }
        public virtual int IdEstado { get; set; }
        public virtual int IdTicketPrestadorRetrabajo { get; set; }

        [StringLength(20)]
        public virtual string Patente { get; set; }

        [StringLength(255)]
        public virtual string NombreChofer { get; set; }

        public virtual string Estado { get; set; }

        public virtual string NombreLocalidadOrigen { get; set; }
        public virtual string NombreLocalidadDestino { get; set; }
        public virtual string UbicacionOrigen { get; set; }
        public virtual string UbicacionDestino { get; set; }
        public virtual int IdFinalizacion { get; set; }

        [StringLength(20)]
        public virtual string DemoraEst { get; set; }

        [StringLength(20)]
        public virtual string DemoraReal { get; set; }
        
        public virtual int IdTipoPrestacion { get; set; }

        [StringLength(5)]
        public virtual string CodigoTipoPrestacion { get; set; }

        public static Prestacion EntityToModel(PrestadorCaso e, int numPrest)
        {
            Prestacion m = new Prestacion();

            m.Id = e.ID;

            m.IdPrestador = e.IdPrestador;
            if (e.Prestador != null)
                m.NombrePrestador = e.Prestador.Nombre;
            m.IdTipoServicio = e.IdTipoServicio;
            if (e.TipoServicio != null)
                m.DescripcionServicio = e.TipoServicio.Descripcion;
            m.Numero = numPrest;
            m.NombrePrestacion = (m.Numero.ToString() + " " + m.DescripcionServicio).Trim();
            m.Comentarios = e.Comentarios;
            m.Kilometros = e.Kilometros;
            m.Costo = e.Costo;
            m.IdPaisOrigen = e.IdPaisOrigen;
            m.IdPaisDestino = e.IdPaisDestino;
            m.IdProvinciaOrigen = e.IdProvinciaOrigen;
            m.IdProvinciaDestino = e.IdProvinciaDestino;
            m.IdCiudadOrigen = e.IdCiudadOrigen;
            m.IdCiudadDestino = e.IdCiudadDestino;
            m.CalleOrigen = e.CalleOrigen;
            m.IdLocalidadOrigen = e.IdLocalidadOrigen;
            m.IdLocalidadDestino = e.IdLocalidadDestino;
            m.CalleDestino = e.CalleDestino;
            m.IdEstado = e.IdEstado;
            m.Estado = e.Estado;
            m.IdTicketPrestadorRetrabajo = e.IdTicketPrestadorRetrabajo;
            m.Patente = e.Patente;
            m.NombreChofer = e.NombreChofer;
            m.IdFinalizacion = e.IdFinalizacion;
            m.DemoraEst = e.DemoraEst;
            m.DemoraReal = e.DemoraReal;
            m.IdTipoPrestacion = e.IdTipoPrestacion;
            m.CodigoTipoPrestacion = e.CodigoTipoPrestacion;

            m.UbicacionOrigen = e.NombreLocalidadOrigen;
            m.UbicacionDestino = e.NombreLocalidadDestino;

            return m;

        }

        public PrestadorCaso ModelToEntity()
        {
            PrestadorCaso e = new PrestadorCaso();

            e.ID = this.Id;
            e.IdPrestador = this.IdPrestador;
            e.IdTipoServicio = this.IdTipoServicio;
            if (this.IdPrestador > 0)
            {
                e.Prestador = Prestador.GetById(this.IdPrestador);
            }
            if (this.IdTipoServicio > 0)
            {
                e.TipoServicio = TipoServicio.GetById(this.IdTipoServicio);
            }
            
            e.Comentarios = this.Comentarios;
            e.Kilometros = this.Kilometros;
            e.Costo = this.Costo;
            e.IdPaisOrigen = this.IdPaisOrigen;
            e.IdPaisDestino = this.IdPaisDestino;
            e.IdProvinciaOrigen = this.IdProvinciaOrigen;
            e.IdProvinciaDestino = this.IdProvinciaDestino;
            e.IdCiudadOrigen = this.IdCiudadOrigen;
            e.IdCiudadDestino = this.IdCiudadDestino;
            e.CalleOrigen = this.CalleOrigen;
            e.IdLocalidadOrigen = this.IdLocalidadOrigen;
            e.IdLocalidadDestino = this.IdLocalidadDestino;
            e.CalleDestino = this.CalleDestino;
            e.IdEstado = this.IdEstado;
            e.IdTicketPrestadorRetrabajo = this.IdTicketPrestadorRetrabajo;
            e.Patente = this.Patente;
            e.NombreChofer = this.NombreChofer;
            e.IdFinalizacion = this.IdFinalizacion;
            e.DemoraEst = this.DemoraEst;
            e.DemoraReal = this.DemoraReal;
            e.IdTipoPrestacion = this.IdTipoPrestacion;
            
            return e;

        }

        public static List<Prestacion> EntityToModel(List<PrestadorCaso> le)
        {
            List<Prestacion> resultList = new List<Prestacion>();
            int numPrest = 1;

            foreach (PrestadorCaso e in le)
            {
                resultList.Add(EntityToModel(e, numPrest++));
            }

            return resultList;
        }
    }
}
