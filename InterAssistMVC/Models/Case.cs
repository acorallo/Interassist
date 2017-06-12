/* EGV 25May2017
 Creación de Clase Case
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.InterAsisst;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

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

        //public virtual Observacion Observacion { get; set; }
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

        public virtual string NombreLocalidadOrigen { get; set; }
        public virtual string NombreLocalidadDestino { get; set; }
        public virtual string UbicacionOrigen { get; set; }
        public virtual string UbicacionDestino { get; set; }
        public virtual string Modelo { get; set; }
        public virtual string Marca { get; set; }

        public virtual AfiliadoModel Afiliado { get; set; }

        public virtual List<Prestacion> Prestaciones { get; set; }

        public virtual string DatosPrestaciones { get; set; }

        // Combos
        public SelectList CaseEstados { get; set; }
        public SelectList TiposServicio { get; set; }
        public SelectList Problemas { get; set; }
        public SelectList PrestacionEstados { get; set; }
        public SelectList PrestacionesRetrabajo { get; set; }

        public Case()
        {
            this.Observaciones = new List<Observacion>();
            this.Prestaciones = new List<Prestacion>();
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

            m.NombreLocalidadOrigen = e.NombreLocalidadOrigen;
            m.NombreLocalidadDestino = e.NombreLocalidadDestino;
            m.UbicacionOrigen = e.CalleOrigen + ", " + e.NombreLocalidadOrigen;
            m.UbicacionDestino = e.CalleDestino + ", " + e.NombreLocalidadDestino;
            m.Modelo = e.Modelo;
            m.Marca = e.Marca;

            if (e.Afiliado != null)
                m.Afiliado = AfiliadoModel.EntityToModel(e.Afiliado);

            foreach (Entities.InterAsisst.Observacion o in e.ObservacionesHistoricas)
            {
                m.Observaciones.Add(InterAssistMVC.Models.Observacion.EntityToModel(o));
            }

            foreach (Entities.InterAsisst.PrestadorCaso p in e.PrestadorCaso)
            {
                m.Prestaciones.Add(InterAssistMVC.Models.Prestacion.EntityToModel(p));
            }

            m.DatosPrestaciones = Newtonsoft.Json.JsonConvert.SerializeObject(m.Prestaciones);

            return m;

        }

        public Ticket ModelToEntity()
        {
            Ticket e;
            bool existPrest = false;

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

            if (Observacion != null && Observacion.Trim() != "")
            {
                e.Observacion = new Entities.InterAsisst.Observacion(this.IDOperador);
                e.Observacion.Descripcion = this.Observacion;
                e.Observacion.IdTicket = this.Id;
                e.Observacion.Fecha = System.DateTime.Today;
            }
            /*
            foreach (Prestacion p in this.Prestaciones)
            {
                existPrest = false;
                foreach(PrestadorCaso pc in e.PrestadorCaso)
                {
                    if(pc.ID == p.Id)
                    {
                        existPrest = true;
                        pc = p.ModelToEntity();
                    }
                }
                if (!existPrest)
                    e.PrestadorCaso.Add(p.ModelToEntity());
            }*/
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
