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
            if (!InterAssistMVC.Utils.UISecurityManager.HasAccessTo(InterAssistMVC.Utils.UISecurityManager.CASE_MODIFY_KEY))
            {
                throw new Exception("No tiene acceso a Crear Casos");
            }
            Ticket t = new Ticket();
            t.IDOperador = Utils.UISecurityManager.GetOperador();
            t.IdOperadorTrack = t.IDOperador;
            t.Fecha = System.DateTime.Today;
            t.IdEstado = 4;
            t.TipoTicket = "Vehículo";
            t.DemoraEst = "02:00";
            t.Persist();

            return RedirectToAction("Edit", "Case", new { Id = t.ID });
        }

        public ActionResult Edit(int Id, int NumTab = 0)
        {
            Ticket e = Ticket.GetById(Id);

            Case m = Case.EntityToModel(e);

            FillCombos(m);

            m.NumTabActive = NumTab;

            return View(m);
        }

        [HttpPost]
        public ActionResult Edit(Case m)
        {
            int tabActive = m.NumTabActive;

            if (!InterAssistMVC.Utils.UISecurityManager.HasAccessTo(InterAssistMVC.Utils.UISecurityManager.CASE_MODIFY_KEY))
            {
                throw new Exception("No tiene acceso a Modificar Casos");
            }
            if (ModelState.IsValid)
            {
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
                    e.IdOperadorTrack = Utils.UISecurityManager.GetOperador();
                    
                    e.Persist();

                    if (m.ModoGraba == Common.ModoGrabacion.GrabarYSalir)
                        return RedirectToAction("Index", "Case", null);
                    
                    return RedirectToAction("Edit", "Case", new { Id = e.ID , NumTab = tabActive});
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

        public ActionResult TraePrestadores(string query)
        {
            FiltroPrestador f = new FiltroPrestador();
            int totalRegistros;

            f.Search = query;

            f.IsPaged = false;
            f.OrderBY = " ORDER BY NOMBRE";
            
            List<Provider> list = Provider.EntityToModel(Prestador.List(f, out totalRegistros));

            Paging<Provider> paging = new Paging<Provider>(list, totalRegistros);

            return this.Store(paging.Data, paging.TotalRecords);
        }

        [HttpGet]
        [Route("Case/TraeDatosPrestador")]
        public string TraeDatosPrestador(int id)
        {
            FiltroPrestador f = new FiltroPrestador();
            int totalRegistros;

            f.ID = id;

            f.IsPaged = false;

            List<Provider> list = Provider.EntityToModel(Prestador.List(f, out totalRegistros));

            if (list.Count > 0)
            {
                Provider p = list[0];
                return p.DatosPrestador;
            }
            return "";
        }

        [HttpGet]
        [Route("Case/TraeCosto")]
        public decimal TraeCosto(int id, string codigo, decimal km)
        {
            if (id <= 0)
                return 0;

            if (codigo == null || codigo == "")
                return 0;

            FiltroPrestador f = new FiltroPrestador();
            int totalRegistros;

            f.ID = id;

            f.IsPaged = false;

            List<Provider> list = Provider.EntityToModel(Prestador.List(f, out totalRegistros));

            if (list.Count > 0)
            {
                Provider p = list[0];
                float kmf = (float)km;
                switch (codigo)
                {
                    case "LIV":
                        return Convert.ToDecimal((p.LivMovida ?? 0) + ((p.LivKm ?? 0) * kmf));
                    case "SP1":
                        return Convert.ToDecimal((p.Sp1Movida ?? 0) + ((p.Sp1Km ?? 0) * kmf));
                    case "SP2":
                        return Convert.ToDecimal((p.Sp2Movida ?? 0) + ((p.Sp2Km ?? 0) * kmf));
                    case "PS1":
                        return Convert.ToDecimal((p.Ps1Movida ?? 0) + ((p.Ps1Km ?? 0) * kmf));
                    case "PS2":
                        return Convert.ToDecimal((p.Ps2Movida ?? 0) + ((p.Ps2Km ?? 0) * kmf));
                    default:
                        return 0;
                }
            }
            return 0;
        }

        public ActionResult TraeUbicaciones(string query)
        {
            FiltroUbicacion f = new FiltroUbicacion();
            //int totalRegistros, indexOfComma;
            int totalRegistros;
            
            /*indexOfComma = query.IndexOf(',');

            if (indexOfComma < 0)
            {
                return this.Store(new object(),0);
            }

            string calle = query.Substring(0,indexOfComma);
            string q = query.Substring(indexOfComma + 1, query.Length - (indexOfComma + 1)).Trim();
            */
            //f.Search = q;
            f.Search = query;

            f.IsPaged = false;
            f.OrderBY = " ORDER BY ORDEN, NOMBRE";

            List<UbicacionModel> list = UbicacionModel.EntityToModel(Ubicacion.List(f, out totalRegistros));
            if (list.Count > 300)
            {
                list.RemoveRange(300, list.Count - 300);
                UbicacionModel u = new UbicacionModel();
                u.Nombre = "... acote su búsqueda ...";
                list.Add(u);
            }

            //list.ForEach(l => { l.CalleUbicacion = Common.Ubicacion(calle, l.Nombre); l.Calle = calle; l.DatosUbicacion = l.DatosUbicacion = Newtonsoft.Json.JsonConvert.SerializeObject(new { IdLocalidad = l.IdLocalidad, IdCiudad = l.IdCiudad, IdProvincia = l.IdProvincia, IdPais = l.IdPais, Calle = l.Calle, CalleUbicacion = calle + ", " + l.Nombre }); });
            list.ForEach(l => { l.DatosUbicacion = Newtonsoft.Json.JsonConvert.SerializeObject(new { IdLocalidad = l.IdLocalidad, IdCiudad = l.IdCiudad, IdProvincia = l.IdProvincia, IdPais = l.IdPais, Nombre = l.Nombre }); });

            Paging<UbicacionModel> paging = new Paging<UbicacionModel>(list, totalRegistros);

            return this.Store(paging.Data, paging.TotalRecords);
        }

        [HttpGet]
        [Route("Case/TraeCantidadCasosPorMes")]
        public int TraeCantidadCasosPorMes(int idAfiliado, int idTicket)
        {
            return ContadorCasos.GetCantidadCasos(idAfiliado, idTicket);
        }

        private void FillCombos(Case m)
        {
            m.CaseEstados = new SelectList(Estado.List(new FiltroEstado("CASO")), "ID", "Descripcion", m.IdEstado);
            m.TiposServicio = new SelectList(TipoServicio.List(new FiltroTipoServicio()), "ID", "Descripcion");
            //m.Problemas = new SelectList(Problema.List(new FiltroProblema()), "ID", "Desripcion");

            List<Problema> ip = Problema.List(new FiltroProblema());
            Problema prob = new Problema();
            prob.Desripcion = "-- Problema --";
            ip.Add(prob);
            m.Problemas = new SelectList(ip, "ID", "Desripcion");

            m.PrestacionEstados = new SelectList(Estado.List(new FiltroEstado("PRESTACION")), "ID", "Descripcion");
            m.PrestacionesRetrabajo = new SelectList(m.Prestaciones, "Id", "NombrePrestacion");
            m.FinalizacionesPretaciones = new SelectList(Estado.List(new FiltroEstado("FINAL_PREST")), "ID", "Descripcion");

            List<Colores> it = Colores.List(new FiltroColores());
            Colores col = new Colores();
            col.Nombre = "-- Color --";
            it.Add(col);
            m.Colores = new SelectList(it, "ID", "Nombre");

            m.TipoPrestaciones = new SelectList(TipoPrestaciones.List(new FiltroTipoPrestacion()), "ID", "Codigo");
        }

        private void Validate(Case m)
        {

            if (!ValidaDemora(m.DemoraEst))
                ModelState.AddModelError("demoraEst" + m.Id.ToString(), "Demora Estimada inválida. Ingrese HH:MM.");

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
                            if (!Regex.IsMatch(p.Patente.Substring(0, 3), @"^[a-zA-Z]+$") || !Regex.IsMatch(p.Patente.Substring(3, 3), @"^[0-9]+$"))
                                ModelState.AddModelError("prestPatente" + p.Id.ToString(), "Patente de la Prestación inválida.");
                        }
                        else
                        {
                            if (!Regex.IsMatch(p.Patente.Substring(0, 2), @"^[a-zA-Z]+$") || !Regex.IsMatch(p.Patente.Substring(2, 3), @"^[0-9]+$") || !Regex.IsMatch(p.Patente.Substring(5, 2), @"^[a-zA-Z]+$"))
                                ModelState.AddModelError("prestPatente" + p.Id.ToString(), "Patente de la Prestación inválida.");
                        }
                    }
                }

                if (!ValidaDemora(p.DemoraEst))
                    ModelState.AddModelError("prestDemoraEst" + p.Id.ToString(), "Demora Estimada inválida. Ingrese HH:MM.");

                if (!ValidaDemora(p.DemoraReal))
                    ModelState.AddModelError("prestDemoraReal" + p.Id.ToString(), "Demora Real inválida. Ingrese HH:MM.");

                Provider pr = new Provider();
                
                p.Costo = TraeCosto(p.IdPrestador, p.CodigoTipoPrestacion, p.Kilometros);
            }

            if (!ModelState.IsValid)
                return;

            // Flujo de Estados
            Ticket t = Ticket.GetById(m.Id);
            m.IDOperador = t.IDOperador;
            m.Fecha = t.Fecha;
            m.TipoTicket = t.TipoTicket;
            if (t.IdAfiliado == m.IdAfiliado)
            {
                m.OkAfiliado = t.OkAfiliado;
                m.CantTicketsAfil = t.CantTicketsAfil;
            }
            else
            {
                if (m.CantTicketsAfil != ContadorCasos.GetCantidadCasos(m.IdAfiliado, m.Id))
                {
                    ModelState.AddModelError("casoCantAfil", "Inconsistencia en la Cantidad de Casos.");
                    return;
                }
            }

            // Estados de la Prestacion
            ConfiguraEstadoPrestacion(m, t);

            // Estados del Caso
            if (ModelState.IsValid)
            {
                ConfiguraEstadoCaso(m, t);
            }

            if (!ModelState.IsValid)
            {
                m.IdEstado = t.IdEstado;
                foreach(Prestacion p in m.Prestaciones)
                {
                    if (p.Id > 0)
                        p.IdEstado = t.PrestadorCaso.Find(x => x.ID == p.Id).IdEstado;
                }
            }

        }

        private bool ValidaDemora(string demora)
        {
            if (demora != null && demora != "")
            {
                if (demora.Length != 5)
                    return false;
                else
                {
                    if (!Regex.IsMatch(demora, @"[0-9][0-9]:[0-5][0-9]"))
                        return false;
                }
            }
            return true;
        }

        private bool CambioEnPrestacion(Prestacion m,PrestadorCaso e)
        {
            if (m.IdPrestador != e.IdPrestador ||
                m.IdTipoServicio != e.IdTipoServicio ||
                (m.Comentarios ?? "") != (e.Comentarios ?? "") ||
                m.Kilometros != e.Kilometros ||
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
                (m.Patente ?? "") != (e.Patente ?? "") ||
                (m.NombreChofer ?? "") != (e.NombreChofer ?? "") ||
                m.IdFinalizacion != e.IdFinalizacion ||
                (m.DemoraEst ?? "") != (e.DemoraEst ?? "") ||
                (m.DemoraReal ?? "") != (e.DemoraReal ?? "") ||
                m.IdTipoPrestacion != e.IdTipoPrestacion)

                return true;

            return false;

        }

        private Prestacion CopiaPrestacion(Prestacion p)
        {
            Prestacion pc = new Prestacion();

            pc.Id = -1;
            pc.IdFinalizacion = -1;
            pc.IdPrestador = -1;

            pc.IdTipoServicio = p.IdTipoServicio;
            pc.Comentarios = p.Comentarios;
            pc.Kilometros = p.Kilometros;
            pc.IdPaisOrigen = p.IdPaisOrigen;
            pc.IdPaisDestino = p.IdPaisDestino;
            pc.IdProvinciaOrigen = p.IdProvinciaOrigen;
            pc.IdProvinciaDestino = p.IdProvinciaDestino;
            pc.IdCiudadOrigen = p.IdCiudadOrigen;
            pc.IdCiudadDestino = p.IdCiudadDestino;
            pc.CalleOrigen = p.CalleOrigen;
            pc.IdLocalidadOrigen = p.IdLocalidadOrigen;
            pc.IdLocalidadDestino = p.IdLocalidadDestino;
            pc.CalleDestino = p.CalleDestino;
            pc.IdTicketPrestadorRetrabajo = p.IdTicketPrestadorRetrabajo;
            pc.IdEstado = (int) Estado.Prestacion.PendientePrestador;
            pc.Patente = "";
            pc.NombreChofer = "";
            pc.DemoraEst = p.DemoraEst;
            pc.DemoraReal = p.DemoraReal;
            pc.IdTipoPrestacion = p.IdTipoPrestacion;

            return pc;
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
            List<Prestacion> prestacionesAgregar = new List<Prestacion>();

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
                            {
                                p.IdEstado = (int)Estado.Prestacion.PendienteCierre;
                                if (p.IdFinalizacion == (int) Estado.FinalPrestacion.CancelaPrestador)
                                    prestacionesAgregar.Add(CopiaPrestacion(p));
                            }
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

            foreach(Prestacion p in prestacionesAgregar)
            {
                m.Prestaciones.Add(p);
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
                            if (CasoTieneUbicaciones(m) && m.IdProblema > 0)
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
                m.CantTicketsAfil != t.CantTicketsAfil ||
                m.IdProblema != t.IdProblema ||
                m.IdColor != t.IdColor ||
                (m.UbicacionDescr ?? "") != (t.UbicacionDescr ?? "") ||
                (m.DemoraEst ?? "") != (t.DemoraEst ?? "") ||
                (m.UrlOrigen ?? "") != (t.UrlOrigen ?? "") ||
                (m.UrlDestino ?? "") != (t.UrlDestino ?? ""))
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