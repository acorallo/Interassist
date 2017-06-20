using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.InterAsisst;
using Utils.InterAssist;
using Ext.Net.MVC;
using Ext.Net;
using InterAssistMVC.Models;
using System.Text.RegularExpressions;

/*** EGV 25May2017 Archivo creado ***/

namespace InterAssistMVC.Controllers
{
    public class CaseController : IAController
    {
        // GET: Case
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            Ticket t = new Ticket();
            t.IDOperador = Utils.UISecurityManager.GetOperador();
            t.Fecha = System.DateTime.Today;
            t.IdEstado = 4;
            t.Persist();

            return RedirectToAction("Edit", "Case", new { Id = t.ID });
        }

        public ActionResult Edit(int Id)
        {
            Ticket e = Ticket.GetById(Id);

            Case m = Case.EntityToModel(e);

            FillCombos(m);

            return View(m);
        }

        [HttpPost]
        public ActionResult Edit(Case m)
        {
            if (ModelState.IsValid)
            {
                //m.Observacion = "Probando la Edición";
                m.Prestaciones.Clear();
                m.Prestaciones = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Prestacion>>(m.DatosPrestaciones);
                foreach (Prestacion p in m.Prestaciones)
                {
                    if (!TryValidateModel(p))
                    {
                        FillCombos(m);
                        return View(m);
                    }
                }
                Validate(m);
                if (ModelState.IsValid)
                {
                    Ticket e = m.ModelToEntity();
                    e.Persist();
                    return RedirectToAction("Edit", "Case", new { Id = e.ID });
                }
            }
            FillCombos(m);
            return View(m);
        }


        public ActionResult ListCases(StoreRequestParameters parameters)
        {
            FiltroTicket f = new FiltroTicket();
            int totalRegistros;

            if (PARAM_WIDE_SEARCH != null && PARAM_WIDE_SEARCH != string.Empty)
                f.Search = PARAM_WIDE_SEARCH;

            f.IsPaged = true;
            f.PageSize = parameters.Limit;
            f.OrderBY = " ORDER BY IDTICKET DESC";


            f.StartRow = ((parameters.Page - 1) * parameters.Limit) + 1;

            List<Case> list = Case.EntityToModel(Ticket.List(f, out totalRegistros));

            Paging<Case> paging = new Paging<Case>(list, totalRegistros);

            return this.Store(paging);
        }

        public ActionResult TraeAfiliados(int start, int limit, int page, string query)
        {
            FiltroAfiliado f = new FiltroAfiliado();
            int totalRegistros;

            f.Search = query.Replace(',',' ').Replace('-',' ').Replace(' ','%');

            f.IsPaged = true;
            f.PageSize = limit;
            f.OrderBY = " ORDER BY PATENTE";
            f.Vigente = true;


            f.StartRow = ((page - 1) * limit) + 1;

            List<AfiliadoModel> list = AfiliadoModel.EntityToModel(Afiliado.List(f, out totalRegistros));

            Paging<AfiliadoModel> paging = new Paging<AfiliadoModel>(list, totalRegistros);

            return this.Store(paging.Data, paging.TotalRecords);

        }

        //public ActionResult TraePrestadores(int start, int limit, int page, string query)
        public ActionResult TraePrestadores(string query)
        {
            FiltroPrestador f = new FiltroPrestador();
            int totalRegistros;

            f.Search = query;

            f.IsPaged = false;
            //f.PageSize = limit;
            f.OrderBY = " ORDER BY NOMBRE";


            //f.StartRow = ((page - 1) * limit) + 1;
            
            List<Provider> list = Provider.EntityToModel(Prestador.List(f, out totalRegistros));

            Paging<Provider> paging = new Paging<Provider>(list, totalRegistros);

            return this.Store(paging.Data, paging.TotalRecords);
        }

        //public ActionResult TraeUbicaciones(int start, int limit, int page, string query)
        public ActionResult TraeUbicaciones(string query)
        {
             FiltroUbicacion f = new FiltroUbicacion();
            int totalRegistros, indexOfComma;

            indexOfComma = query.IndexOf(',');

            if (indexOfComma < 0)
            {
                return this.Store(new object(),0);
            }

            string calle = query.Substring(0,indexOfComma);
            string q = query.Substring(indexOfComma + 1, query.Length - (indexOfComma + 1)).Trim();

            f.Search = q;

            //f.IsPaged = true;
            f.IsPaged = false;
            //f.PageSize = limit;
            f.OrderBY = " ORDER BY ORDEN, NOMBRE";

            //f.StartRow = ((page - 1) * limit) + 1;

            List<UbicacionModel> list = UbicacionModel.EntityToModel(Ubicacion.List(f, out totalRegistros));

            list.ForEach(l => { l.CalleUbicacion = Common.Ubicacion(calle, l.Nombre); l.Calle = calle; l.DatosUbicacion = l.DatosUbicacion = Newtonsoft.Json.JsonConvert.SerializeObject(new { IdLocalidad = l.IdLocalidad, IdCiudad = l.IdCiudad, IdProvincia = l.IdProvincia, IdPais = l.IdPais, Calle = l.Calle, CalleUbicacion = calle + ", " + l.Nombre }); });

            Paging<UbicacionModel> paging = new Paging<UbicacionModel>(list, totalRegistros);

            return this.Store(paging.Data, paging.TotalRecords);
        }

        private void FillCombos(Case m)
        {
            m.CaseEstados = new SelectList(Estado.List(new FiltroEstado("CASO")), "ID", "Descripcion", m.IdEstado);
            m.TiposServicio = new SelectList(TipoServicio.List(new FiltroTipoServicio()), "ID", "Descripcion");
            m.Problemas = new SelectList(Problema.List(new FiltroProblema()), "ID", "Desripcion");
            m.PrestacionEstados = new SelectList(Estado.List(new FiltroEstado("PRESTACION")), "ID", "Descripcion");
            m.PrestacionesRetrabajo = new SelectList(m.Prestaciones, "Id", "DescripcionServicio");
            m.FinalizacionesPretaciones = new SelectList(Estado.List(new FiltroEstado("FINAL_PREST")), "ID", "Descripcion");
        }

        private void Validate(Case m)
        {

            Estado.Prestacion EstadoPrestacionOriginal = Estado.Prestacion.Borrador;
            Estado.Caso EstadoCasoOriginal = Estado.Caso.Borrador;

            if (m.OkAfiliado == null || m.OkAfiliado != "S")
                m.OkAfiliado = "N";
 
            foreach (Prestacion p in m.Prestaciones)
            {
                // Validación de Patente
                if (p.Patente != null && p.Patente != "")
                {
                    if (p.Patente.Length != 6 && p.Patente.Length != 7)
                        ModelState.AddModelError("prestPatente" + p.Id.ToString(), "Patente de la Prestación inválida.");
                    else
                    {
                        if (p.Patente.Length == 6)
                        {
                            if (!Regex.IsMatch(p.Patente.Substring(0, 3), @"^[a-zA-Z]+$") || !Regex.IsMatch(p.Patente.Substring(0, 3), @"^[0-9]+$"))
                                ModelState.AddModelError("prestPatente" + p.Id.ToString(), "Patente de la Prestación inválida.");
                        }
                        else
                        {
                            if (!Regex.IsMatch(p.Patente.Substring(0, 2), @"^[a-zA-Z]+$") || !Regex.IsMatch(p.Patente.Substring(2, 3), @"^[0-9]+$") || !Regex.IsMatch(p.Patente.Substring(5, 2), @"^[a-zA-Z]+$"))
                                ModelState.AddModelError("prestPatente" + p.Id.ToString(), "Patente de la Prestación inválida.");
                        }
                    }
                }

                // Validacion Demora
                if (p.Demora != null && p.Demora != "")
                {
                    if (p.Demora.Length != 5)
                        ModelState.AddModelError("prestDemora" + p.Id.ToString(), "Demora inválida. Ingrese HH:MM.");
                    else 
                    { 
                        if (!Regex.IsMatch(p.Demora,@"[0-9][0-9]:[0-5][0-9]"))
                            ModelState.AddModelError("prestDemora" + p.Id.ToString(), "Demora inválida. Ingrese HH:MM.");
                    }
                }
            }


        }

    }
}