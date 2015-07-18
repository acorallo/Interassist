using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.InterAssist.Views
{
    public partial class Exception : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Exception ex = Server.GetLastError();

            this.lblError.Text = ex.Source;
            this.lblDescripcion.Text = ex.Message;

            this.lblInnerException.Text = "N/A";

            if (ex.InnerException != null)
            {
                string result = "Source: " + ex.InnerException.Source + " Error:" + ex.InnerException.Message;
                this.lblInnerException.Text = result;

            }


        }
    }
}