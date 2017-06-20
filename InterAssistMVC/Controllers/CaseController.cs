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

            // Flujo de Estados
            Ticket t = Ticket.GetById(m.Id);
            m.IDOperador = t.IDOperador;
            m.Fecha = t.Fecha;
            if (t.IdAfiliado == m.IdAfiliado)
            {
                m.OkAfiliado = t.OkAfiliado;
                m.CantTicketsAfil = t.CantTicketsAfil;
            }

            // Estados de la Prestacion
            ConfiguraEstadoPrestacion(m, t);

            // Estados del Caso
            if (ModelState.IsValid)
            {
                ConfiguraEstadoCaso(m, t);
            }


        }

        private bool CambioEnPrestacion(Prestacion m,PrestadorCaso e)
        {
            if (m.IdPrestador != e.IdPrestador ||
                m.IdTipoServicio != e.IdTipoServicio ||
                (m.Comentarios ?? "") != (e.Comentarios ?? "") ||
                m.Kilometros != e.Kilometros ||
                m.IdProblema != e.IdProblema ||
                m.IdPaisOrigen != e.IdPaisOrigen ||
                m.IdPaisDestino != e.IdPaisDestino ||
                m.IdProvinciaOrigen != e.IdProvinciaOrigen ||
                m.IdProvinciaDestino != e.IdProvinciaDestino ||
                m.IdCiudadOrigen != e.IdCiudadOrigen ||
                m.IdCiudadDestino != e.IdCiudadDestino ||
                (m.CalleOrigen ?? "") != (e.CalleOrigen ?? "") ||
                m.IdLocalidadOrigen != e.IdLocalidadOrigen ||
                m.IdLocalidadDestino != e.IdLocalidadDestino ||
                (m.CalleDestino ?? "") != (e.CalleDestino ?? "") ||
                m.IdTicketPrestadorRetrabajo != e.IdTicketPrestadorRetrabajo ||
                (m.Demora ?? "") != (e.Demora ?? "") ||
                (m.Patente ?? "") != (e.Patente ?? "") ||
                (m.NombreChofer ?? "") != (e.NombreChofer ?? "") ||
                m.IdFinalizacion != e.IdFinalizacion)

                return true;

            return false;

        }

        private bool PrestacionTieneUbicaciones(Prestacion p)
        {
            if (p.CalleOrigen != "" && 
                p.IdLocalidadOrigen > 0 &&
                p.IdCiudadOrigen > 0 &&
                p.IdProvinciaOrigen > 0 &&
                p.IdPaisOrigen > 0 &&
                p.CalleDestino != "" && 
                p.IdLocalidadDestino > 0 &&
                p.IdCiudadDestino > 0 &&
                p.IdProvinciaDestino > 0 &&
                p.IdPaisDestino > 0)
                return true;
            return false;
        }

        private void ConfiguraEstadoPrestacion(Case m, Ticket t)
        {
            foreach (Prestacion p in m.Prestaciones)
            {
                if (p.Id > 0)
                {
                    PrestadorCaso pe = t.PrestadorCaso.Find(x => x.ID == p.Id);

                    if (Utils.UISecurityManager.HasAccessTo(Utils.UISecurityManager.CASE_CHANGE_STATUS_KEY) && p.IdEstado != pe.IdEstado)
                        continue;

                    switch (pe.IdEstado)
                    {
                        case (int)Estado.Prestacion.Cerrado:
                        case (int)Estado.Prestacion.PendienteCierre:
                            if (CambioEnPrestacion(p, pe))
                            {
                                ModelState.AddModelError("prestEstado" + p.Id.ToString(), "La Prestacion está cerrada, no se le pueden realizar cambios.");
                                return;
                            }
                            p.IdEstado = pe.IdEstado;
                            break;
                        case (int)Estado.Prestacion.Borrador:
                            if (!ConfiguraEstadoPrestacionAbierta(p))
                            {
                                ModelState.AddModelError("prestEstado" + p.Id.ToString(), "No se puede Finalizar la prestación.");
                                return;
                            }
                            break;
                        case (int)Estado.Prestacion.PendientePrestador:
                            if (!ConfiguraEstadoPrestacionAbierta(p))
                            {
                                ModelState.AddModelError("prestEstado" + p.Id.ToString(), "No se puede Finalizar la prestación.");
                                return;
                            }
                            break;
                        case (int)Estado.Prestacion.PendienteAsistencia:
                            if (p.IdFinalizacion > 0)
                                p.IdEstado = (int)Estado.Prestacion.PendienteCierre;
                            else
                                p.IdEstado = (int)Estado.Prestacion.PendienteAsistencia;
                            break;
                        default:
                            p.IdEstado = pe.IdEstado;
                            break;
                    }
                }
                else
                {
                    if (!Utils.UISecurityManager.HasAccessTo(Utils.UISecurityManager.CASE_CHANGE_STATUS_KEY) || p.IdEstado <= 0 || p.IdEstado == (int)Estado.Prestacion.Borrador)
                    {
                        if (!ConfiguraEstadoPrestacionAbierta(p))
                        {
                            ModelState.AddModelError("prestEstado" + p.Id.ToString(), "No se puede Finalizar la prestación.");
                            return;
                        }
                    }
                }
            }
        }


        private bool ConfiguraEstadoPrestacionAbierta(Prestacion p)
        {
            if (p.IdFinalizacion > 0)
            {
                if (p.IdFinalizacion != (int)Estado.FinalPrestacion.CancelaAfiliado)
                    return false;
                p.IdEstado = (int)Estado.Prestacion.PendienteCierre;
                return true;
            }
            else
            {
                if (PrestacionTieneUbicaciones(p))
                {
                    if (p.IdPrestador > 0)
                        p.IdEstado = (int)Estado.Prestacion.PendienteAsistencia;
                    else
                        p.IdEstado = (int)Estado.Prestacion.PendientePrestador;
                    return true;
                }
            }
            p.IdEstado = (int)Estado.Prestacion.Borrador;
            return true;
        }

        private void ConfiguraEstadoCaso(Case m, Ticket t)
        {
            if (Utils.UISecurityManager.HasAccessTo(Utils.UISecurityManager.CASE_CHANGE_STATUS_KEY) && m.IdEstado != t.IdEstado)
                return;

            switch (t.IdEstado)
            {
                case (int) Estado.Caso.PendienteCierre:
                case (int)Estado.Caso.Cerrado:
                    if (CambioCaso(m, t))
                    {
                        ModelState.AddModelError("caseEstado" + m.Id.ToString(), "El Caso está cerrado, no se le pueden realizar cambios.");
                        return;
                    }
                    m.IdEstado = t.IdEstado;
                    break;
                case (int) Estado.Caso.Abierto:
                    if (CambioCaso(m,t))
                    {
                        ModelState.AddModelError("caseEstado" + m.Id.ToString(), "El Caso está abierto, no se le pueden realizar cambios.");
                        return;
                    }
                    if (m.Prestaciones.Count > 0 && m.Prestaciones.Count == m.Prestaciones.Count(x => x.IdEstado == (int)Estado.Prestacion.PendienteCierre || x.IdEstado == (int)Estado.Prestacion.Cerrado))
                    {
                        m.IdEstado = (int)Estado.Caso.PendienteCierre;
                        break;
                    }
                    m.IdEstado = t.IdEstado;
                    break;
                case (int)Estado.Caso.Borrador:
                    if (m.IdAfiliado > 0)
                    {
                        if (m.CantTicketsAfil > 0 && !m.OkAfiliado)
                            m.IdEstado = (int)Estado.Caso.PendienteCierre;
                        else
                        {
                            if (CasoTieneUbicaciones(m))
                                m.IdEstado = (int)Estado.Caso.Abierto;
                            else
                                m.IdEstado = (int)Estado.Caso.Borrador;
                        }
                        break;
                    }
                    m.IdEstado = t.IdEstado;
                    break;
                default:
                    m.IdEstado = t.IdEstado;
                    break;
            }
        }

        private bool CambioCaso(Case m, Ticket t)
        {
            if (m.IdPaisOrigen != t.IdPaisOrigen ||
                m.IdAfiliado != t.IdAfiliado ||
                (m.Telefono ?? "") != (t.Telefono ?? "") ||
                m.IdProvinciaOrigen != t.IdProvinciaOrigen ||
                m.IdCiudadOrigen != t.IdCiudadOrigen ||
                m.IdLocalidadOrigen != t.IdLocalidadOrigen ||
                m.IdPaisDestino != t.IdPaisDestino ||
                m.IdProvinciaDestino != t.IdProvinciaDestino ||
                m.IdCiudadDestino != t.IdCiudadDestino ||
                m.IdLocalidadDestino != t.IdLocalidadDestino ||
                (m.CalleOrigen ?? "") != (t.CalleOrigen ?? "") ||
                (m.CalleDestino ?? "") != (t.CalleDestino ?? "") ||
                (m.TipoTicket ?? "") != (t.TipoTicket ?? "") ||
                m.OkAfiliado != t.OkAfiliado ||
                m.CantTicketsAfil != t.CantTicketsAfil)
                return true;

            return false;
        }

        private bool CasoTieneUbicaciones(Case m)
        {
            if (m.IdLocalidadOrigen > 0 &&
                m.IdCiudadOrigen > 0 &&
                m.IdProvinciaOrigen > 0 &&
                m.IdPaisOrigen > 0 &&
                m.IdLocalidadDestino > 0 &&
                m.IdCiudadDestino > 0 &&
                m.IdProvinciaDestino > 0 &&
                m.IdPaisDestino > 0)
                return true;

            return false;
        }

    }
}