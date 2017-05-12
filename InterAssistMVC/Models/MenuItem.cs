using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterAssistMVC.Models
{
    public class MenuItem
    {

        public MenuItem()
        {
            this.Text = string.Empty;
            this.Action = string.Empty;
            this.BootstrapIcon = string.Empty;
        }


        public string Text { get; set; } 
        public List<MenuItem> Item { get; set; }
        public string Action { get; set; }
        public string BootstrapIcon { get; set; }
    }



}