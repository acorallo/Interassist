using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.InterAsisst;

namespace InterAssistMVC.Controllers
{
    public class CaseController : Controller
    {
        // GET: Case
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            //Ticket t = new Ticket();
            // esteban buscar el id operador logueado
            // llenar campos not null
            //t.Observacion = new Observacion(25);
            //t.Observacion.Descripcion = "Alta Ticket";
            //t.Persist();
            //ViewBag.IdTicket = t.ID;
            ViewBag.IdTicket = 12345;
            return View();
        }

    }
}