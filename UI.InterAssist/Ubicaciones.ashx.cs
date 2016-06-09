using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Ext.Net;

namespace UI.InterAssist
{
    /// <summary>
    /// Summary description for Ubicaciones
    /// </summary>
    public class Ubicaciones : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";

            int start = 0;
            int limit = 10;
            string sort = string.Empty;
            string dir = string.Empty;
            string query = string.Empty;

            int idPais = -1;
            int idProvincia = -1;

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

            if (!string.IsNullOrEmpty(context.Request["paramIdProvincia"]))
            {
                idProvincia = Int32.Parse(context.Request["paramIdProvincia"]);
            }


            if (!string.IsNullOrEmpty(context.Request["paramIdPais"]))
            {
                idPais = Int32.Parse(context.Request["paramIdPais"]);
            }



            var ubicaciones = Classes.Localidades.getUbicaciones();
           
            
            var selectUbicacion = from item in ubicaciones where string.Concat(item.Ciudad, item.Localidad).ToUpper().IndexOf(query.ToUpper())>=0 select item;

            if (idPais != -1)
                selectUbicacion = from item in selectUbicacion where item.IDPais == idPais select item;

            if (idProvincia != -1)
                selectUbicacion = from item in selectUbicacion where item.IDProvincia == idProvincia select item;
            
            context.Response.Write(string.Format("{{total:{1},'Ubicaciones':{0}}}", JSON.Serialize(selectUbicacion), selectUbicacion.Count()));

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