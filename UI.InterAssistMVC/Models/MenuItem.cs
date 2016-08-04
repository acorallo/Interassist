using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.InterAssistMVC.Models
{
    public class MenuItem
    {
        public string Text { get; set; }
        public List<MenuItem> Item { get; set; }
        public string Action { get; set; }
        public string BootstrapIcon { get; set; }
    }
}