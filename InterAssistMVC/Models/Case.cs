using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.InterAsisst;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Utils.InterAssist;

namespace InterAssistMVC.Models
{
    public class Case
    {
        public virtual int Id { get; set; }
        public virtual int IDOperador { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual int IdPaisOrigen { get; set; }
        public virtual int IdAfiliado { get; set; }
        public virtual string Telefono { get; set; }

        [Required]
        public virtual int IdEstado { get; set; }

        public virtual int IdProvinciaOrigen { get; set; }
        public virtual int IdCiudadOrigen { get; set; }
        public virtual int IdLocalidadOrigen { get; set; }
        public virtual int IdPaisDestino { get; set; }
        public virtual int IdProvinciaDestino { get; set; }
        public virtual int IdCiudadDestino { get; set; }
        public virtual int IdLocalidadDestino { get; set; }
        public virtual string CalleOrigen { get; set; }
        public virtual string CalleDestino { get; set; }

        public virtual List<Observacion> Observaciones { get; set; }

        [StringLength(3999)]
        public virtual string Observacion { get; set; }

        public virtual string Poliza { get; set; }
        public virtual string NombrePrestador { get; set; }
        public virtual string Patente { get; set; }

        public virtual string NombreOperador { get; set; }
        public virtual string NombreEmpresa { get; set; }
        public virtual string NombreAfiliado { get; set; }
        public virtual string TipoTicket { get; set; }

        public virtual string Categoria { get; set; }
        public virtual string CategoriaNombre { get; set; }

        public virtual string NombreLocalidadOrigen { get; set; }
        public virtual string NombreLocalidadDestino { get; set; }
        public virtual string UbicacionOrigen { get; set; }
        public virtual string UbicacionDestino { get; set; }
        public virtual string Modelo { get; set; }
        public virtual string Marca { get; set; }

        public virtual bool OkAfiliado { get; set; }
        public virtual int CantTicketsAfil { get; set; }

        public virtual int IdColor { get; set; }
        public virtual int IdProblema { get; set; }

        [StringLength(1024)]
        public virtual string UbicacionDescr { get; set; }

        [StringLength(20)]
        public virtual string DemoraEst { get; set; }

        [StringLength(1024)]
        public virtual string UrlOrigen { get; set; }

        [StringLength(1024)]
        public virtual string UrlDestino { get; set; }

        public virtual AfiliadoModel Afiliado { get; set; }

        public virtual List<Prestacion> Prestaciones { get; set; }
        public virtual List<TicketTrackModel> Tracking { get; set; }
        public virtual string DatosPrestaciones { get; set; }

        public virtual int CantidadCasosAnteriores { get; set; }
        public virtual bool AceptaAfiliado { get; set; }

        public virtual string Estado { get; set; }

        public virtual int IdOperadorTrack { get; set; }

        public virtual string FechaDisplay { get { return this.Fecha.ToString("dd/MM/yyyy H:mm:ss"); } }

        public virtual Common.ModoGrabacion ModoGraba { get; set; }

        public virtual int NumTabActive { get; set; }

        // Combos
        public SelectList CaseEstados { get; set; }
        public SelectList TiposServicio { get; set; }
        public SelectList Problemas { get; set; }
        public SelectList PrestacionEstados { get; set; }
        public SelectList PrestacionesRetrabajo { get; set; }
        public SelectList FinalizacionesPretaciones { get; set; }
        public SelectList Colores { get; set; }
        public SelectList TipoPrestaciones { get; set; }

        public Case()
        {
            this.Observaciones = new List<Observacion>();
            this.Prestaciones = new List<Prestacion>();
            this.Tracking = new List<TicketTrackModel>();
            this.ModoGraba = Common.ModoGrabacion.GrabarYEditar;
            this.NumTabActive = 0;
        }


        public static Case EntityToModel(Ticket e)
        {
            Case m = new Case();

            m.Id = e.ID;

            m.IDOperador = e.IDOperador;
            m.Fecha = e.Fecha;
            m.IdPaisOrigen = e.IdPaisOrigen;
            m.IdAfiliado = e.IdAfiliado;
            m.Telefono = e.Telefono;
            m.IdEstado = e.IdEstado;
            m.Estado = e.Estado;
            m.IdProvinciaOrigen = e.IdProvinciaOrigen;
            m.IdCiudadOrigen = e.IdCiudadOrigen;
            m.IdLocalidadOrigen = e.IdLocalidadOrigen;
            m.IdPaisDestino = e.IdPaisDestino;
            m.IdProvinciaDestino = e.IdProvinciaDestino;
            m.IdCiudadDestino = e.IdCiudadDestino;
            m.IdLocalidadDestino = e.IdLocalidadDestino;
            m.CalleOrigen = e.CalleOrigen;
            m.CalleDestino = e.CalleDestino;

            m.Poliza = e.Poliza;
            m.NombrePrestador = e.NombrePrestador;
            m.Patente = e.Patente;

            m.NombreOperador = e.NombreOperador;
            m.NombreEmpresa = e.NombreEmpresa;
            m.NombreAfiliado = e.NombreAfiliado;
            m.TipoTicket = e.TipoTicket;

            m.Categoria = e.Categoria;
            m.CategoriaNombre = e.CategoriaNombre;

            m.NombreLocalidadOrigen = e.NombreLocalidadOrigen;
            m.NombreLocalidadDestino = e.NombreLocalidadDestino;
            m.UbicacionOrigen = m.NombreLocalidadOrigen;
            m.UbicacionDestino = m.NombreLocalidadDestino;
            m.Modelo = e.Modelo;
            m.Marca = e.Marca;

            m.OkAfiliado = e.OkAfiliado;
            m.CantTicketsAfil = e.CantTicketsAfil;

            m.IdProblema = e.IdProblema;
            m.IdColor = e.IdColor;

            m.UbicacionDescr = e.UbicacionDescr;
            m.DemoraEst = e.DemoraEst;

            m.UrlOrigen = e.UrlOrigen;
            m.UrlDestino = e.UrlDestino;

            if (e.Afiliado != null)
                m.Afiliado = AfiliadoModel.EntityToModel(e.Afiliado);

            foreach (Entities.InterAsisst.Observacion o in e.ObservacionesHistoricas)
            {
                m.Observaciones.Add(InterAssistMVC.Models.Observacion.EntityToModel(o));
            }

            m.Prestaciones = Prestacion.EntityToModel(e.PrestadorCaso);

            m.DatosPrestaciones = Newtonsoft.Json.JsonConvert.SerializeObject(m.Prestaciones);

            m.Tracking = TicketTrackModel.EntityToModel(e.TicketTracking);

            return m;

        }

        public Ticket ModelToEntity()
        {
            Ticket e;

            if (this.Id > 0)
            {
                e = Ticket.GetById(this.Id);
            }
            else
            {
                e = new Ticket();
            }

            this.IDOperador = Utils.UISecurityManager.GetOperador();

            e.IDOperador = this.IDOperador;
            e.Fecha = this.Fecha;
            e.IdPaisOrigen = this.IdPaisOrigen;
            e.IdAfiliado = this.IdAfiliado;
            e.Telefono = this.Telefono;
            e.IdEstado = this.IdEstado;
            e.IdProvinciaOrigen = this.IdProvinciaOrigen;
            e.IdCiudadOrigen = this.IdCiudadOrigen;
            e.IdLocalidadOrigen = this.IdLocalidadOrigen;
            e.IdPaisDestino = this.IdPaisDestino;
            e.IdProvinciaDestino = this.IdProvinciaDestino;
            e.IdCiudadDestino = this.IdCiudadDestino;
            e.IdLocalidadDestino = this.IdLocalidadDestino;
            e.CalleOrigen = this.CalleOrigen;
            e.CalleDestino = this.CalleDestino;

            e.TipoTicket = this.TipoTicket;

            e.OkAfiliado = this.OkAfiliado;
            e.CantTicketsAfil = this.CantTicketsAfil;

            e.IdColor = this.IdColor;
            e.IdProblema = this.IdProblema;

            e.UbicacionDescr = this.UbicacionDescr;
            e.DemoraEst = this.DemoraEst;

            e.UrlOrigen = this.UrlOrigen;
            e.UrlDestino = this.UrlDestino;

            if (Observacion != null && Observacion.Trim() != "")
            {
                e.Observacion = new Entities.InterAsisst.Observacion(this.IDOperador);
                e.Observacion.Descripcion = this.Observacion;
                e.Observacion.IdTicket = this.Id;
                e.Observacion.Fecha = System.DateTime.Today;
            }

            e.PrestadorCaso.Clear();
            foreach (Prestacion p in this.Prestaciones)
            {
                e.PrestadorCaso.Add(p.ModelToEntity());
            }

            e.Afiliado = this.Afiliado.ModelToEntity();

            return e;

        }

        public static List<Case> EntityToModel(List<Ticket> le)
        {
            List<Case> resultList = new List<Case>();


            foreach (Ticket e in le)
            {
                resultList.Add(EntityToModel(e));
            }

            return resultList;
        }
    }
}
