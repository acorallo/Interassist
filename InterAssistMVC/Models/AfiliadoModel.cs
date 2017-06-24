/* EGV 25May2017
 Creación de Clase AfiliadoModel
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.InterAsisst;
using System.Web.Mvc;
using Utils.InterAssist;


namespace InterAssistMVC.Models
{
    public class AfiliadoModel
    {
        public virtual int Id { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Poliza { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string CodigoPostal { get; set; }
        public virtual DateTime FechaDesde { get; set; }
        public virtual DateTime FechaHasta { get; set; }
        public virtual string Documento { get; set; }
        public virtual string Marca { get; set; }
        public virtual string Patente { get; set; }
        public virtual string Color { get; set; }
        public virtual string Anio { get; set; }
        public virtual int IdEmpresa { get; set; }
        public virtual string Categoria { get; set; }
        public virtual string NombreCategoria { get; set; }
        public virtual bool Hogar { get; set; }
        public virtual string Modelo { get; set; }
        public virtual bool Estado { get; set; }
        public virtual string NombreEmpresa { get; set; }
        public virtual string ApellidoYNombre { get; set; }
        public virtual string PatenteApeYNom { get; set; }
        public virtual string DatosAfiliado { get; set; }

        public virtual string FechaDesdeDisplay { get; set; }
        public virtual string FechaHastaDisplay { get; set; }

        public static AfiliadoModel EntityToModel(Afiliado e)
        {
            AfiliadoModel m = new AfiliadoModel();

            m.Id = e.ID;
            m.Apellido = e.Apellido;
            m.Nombre = e.Nombre;
            m.Poliza = e.Poliza;
            m.Direccion = e.Direccion;
            m.CodigoPostal = e.CodigoPostal;
            m.FechaDesde = e.FechaDesde;
            m.FechaHasta = e.FechaHasta;
            m.Documento = e.Documento;
            m.Marca = e.Marca;
            m.Patente = e.Patente;
            m.Color = e.Color;
            m.Anio = e.Año;
            m.IdEmpresa = e.IDEmpresa;
            m.Categoria = e.Categoria;
            m.NombreCategoria = e.NombreCategoria;
            m.Hogar = e.Hogar;
            m.Modelo = e.Modelo;
            m.Estado = e.Estado;
            m.NombreEmpresa = e.NombreEmpresa;

            m.ApellidoYNombre = Common.ApeYNom(e.Nombre, e.Apellido);
            m.PatenteApeYNom = e.Patente + " - " + m.ApellidoYNombre;

            m.FechaDesdeDisplay = m.FechaDesde.ToString("dd/MM/yyyy");
            m.FechaHastaDisplay = m.FechaHasta.ToString("dd/MM/yyyy");

            m.DatosAfiliado = Newtonsoft.Json.JsonConvert.SerializeObject(new { Id = m.Id, ApyNom = m.ApellidoYNombre, Doc = m.Documento, Dir = m.Direccion, cp = m.CodigoPostal, pol = m.Poliza, cia = m.NombreEmpresa, fd = m.FechaDesdeDisplay, fh = m.FechaHastaDisplay, tp = " ", sp = " ", pat = m.Patente, marca = m.Marca, mod = m.Modelo, col = m.Color, anio = m.Anio });

            return m;

        }

        public Afiliado ModelToEntity()
        {
            Afiliado e;

            if (this.Id > 0)
            {
                e = Afiliado.GetById(this.Id);
            }
            else
            {
                e = new Afiliado();
            }

            e.Apellido = this.Apellido;
            e.Nombre = this.Nombre;
            e.Poliza = this.Poliza;
            e.Direccion = this.Direccion;
            e.CodigoPostal = this.CodigoPostal;
            e.FechaDesde = this.FechaDesde;
            e.FechaHasta = this.FechaHasta;
            e.Documento = this.Documento;
            e.Marca = this.Marca;
            e.Patente = this.Patente;
            e.Color = this.Color;
            e.Año = this.Anio;
            e.IDEmpresa = this.IdEmpresa;
            e.Categoria = this.Categoria;
            e.NombreCategoria = this.NombreCategoria;
            e.Hogar = this.Hogar;
            e.Modelo = this.Modelo;
            e.Estado = this.Estado;

            return e;

        }

        public static List<AfiliadoModel> EntityToModel(List<Afiliado> le)
        {
            List<AfiliadoModel> resultList = new List<AfiliadoModel>();

            foreach (Afiliado e in le)
            {
                resultList.Add(EntityToModel(e));
            }

            return resultList;
        }
    }
}