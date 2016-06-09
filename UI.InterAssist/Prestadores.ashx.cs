using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.InterAsisst;
using System.Web.SessionState;
using Utils.InterAssist;
using Entities.InterAsisst;
using Ext.Net;


namespace UI.InterAssist
{
    /// <summary>
    /// Summary description for Prestadores
    /// </summary>
    public class Prestadores : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            
            int start = 0;
            int limit = 10;
            string sort = string.Empty;
            string dir = string.Empty;
            string query = string.Empty;

            if (!string.IsNullOrEmpty(context.Request["start"]))
            {
                start = int.Parse(context.Request["start"]);
            }

            if (!string.IsNullOrEmpty(context.Request["limit"]))
            {
                limit = int.Parse(context.Request["limit"]);
            }

            if (!string.IsNullOrEmpty(context.Request["sort"]))
            {
                sort = context.Request["sort"];
            }

            if (!string.IsNullOrEmpty(context.Request["dir"]))
            {
                dir = context.Request["dir"];
            }

            if (!string.IsNullOrEmpty(context.Request["query"]))
            {
                query = context.Request["query"];
            }


            List<Modelviews.PrestadorModelView> listPrestadores = new List<Modelviews.PrestadorModelView>();

            /*
            listPrestadores.Add(new Modelviews.PrestadorModelView() { Id=111, Nombre = "Andes Remolque", Localidad = "Mendoza", Pais ="Argentina" });
            listPrestadores.Add(new Modelviews.PrestadorModelView() { Id=112, Nombre = "Belen Remolque", Localidad = "Rosario", Pais = "Argentina" });
            listPrestadores.Add(new Modelviews.PrestadorModelView() { Id=113, Nombre = "Caja Remolque", Localidad = "Buenos Aires", Pais = "Argentina" });
            listPrestadores.Add(new Modelviews.PrestadorModelView() { Id=115, Nombre = "Mecánica Remolque", Localidad = "Nequen", Pais = "Argentina" });
             */

            FiltroPrestador f = new FiltroPrestador();
            f.Nombre = query;
            f.OrderBY = " order by Nombre ";
            List<Prestador> prestadores = Prestador.List(f);


            foreach(Prestador p in prestadores)
            {
                Modelviews.PrestadorModelView pmv = new Modelviews.PrestadorModelView();
                pmv.Id = p.ID;
                pmv.Nombre = p.Nombre;
                pmv.Pais = p.NombrePais;
                pmv.Provincia = p.ProvinciaNombre;
                pmv.Ciudad = p.NombreCiudad;
                pmv.Localidad = p.LocalidadNombre;
                listPrestadores.Add(pmv);
            }


            context.Response.Write(string.Format("{{total:{1},'Prestadores':{0}}}", JSON.Serialize(listPrestadores), listPrestadores.Count));

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}