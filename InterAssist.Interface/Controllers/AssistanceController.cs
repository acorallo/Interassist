using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterAssist.Interface.Controllers
{
    public class AssistanceController : Controller
    {
        // GET: Assistance
        public string SendAssistance(string hash, string poliza, string gps)
        {
            string result;

            Models.SendAssistanceResponseAPI api = new Models.SendAssistanceResponseAPI();
            api.ID = 78763;
            api.Description = "Transaccion Correcta";

            result = api.toJson();


            return result;
        }
    }
}