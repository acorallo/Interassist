using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterAssist.Interface.Models
{
    public class SendAssistanceResponseAPI : ResponseApi
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}