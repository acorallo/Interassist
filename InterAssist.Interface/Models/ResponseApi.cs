using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace InterAssist.Interface.Models
{
    public class ResponseApi
    {
        public string toJson()
        {
            var json = new JavaScriptSerializer().Serialize(this);
            return json;
        }
    }
}