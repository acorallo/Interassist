using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterAssistMVC;
using InterAssistMVC.Utils;
using InterAssistMVC.Models;
using Entities.InterAsisst;
using Utils.InterAssist;
using Ext.Net.MVC;
using Ext.Net;


namespace InterAssistMVC.Controllers
{
    public class ProviderController : IAController
    {
        // GET: Provider
        public ActionResult Index()
        {
           
            if (!UISecurityManager.HasAccessTo(UISecurityManager.PROVIDER_LIST_KEY))
                return View(IAController.ACCESS_DENY_VIEW);

            this.SetRights();
            this.SetText();

            return View();
           

        }

        private void SetRights()
        {
            ViewBag.CanCreateProviders = UISecurityManager.HasAccessTo(UISecurityManager.PROVIDER_CREATE_KEY);
            
        }
            
        private void SetText()
        {
            ViewBag.Title = Resource.SECCION_ADM_PRESTADORES;
            ViewBag.TableTitle = Resource.TXT_PRESTADORES_TABLE_TITLE;
            ViewBag.NoRecords = Resource.TXT_NON_RESULTS;
        }

        public ActionResult ListProviders(StoreRequestParameters parameters)
        {
            FiltroPrestador f = new FiltroPrestador();
            int totalRegistros;


            if (PARAM_WIDE_SEARCH!= null && PARAM_WIDE_SEARCH != string.Empty)
                f.Search = PARAM_WIDE_SEARCH;

            f.IsPaged = true;
            f.PageSize = parameters.Limit;
            


            f.StartRow = ((parameters.Page- 1) * parameters.Limit) + 1;

            List<Provider> list = Provider.EntityToModel(Prestador.List(f, out totalRegistros));

            Paging<Provider> paging = new Paging<Provider>(list, totalRegistros);


            return this.Store(paging);
        }

        
       
    }
}