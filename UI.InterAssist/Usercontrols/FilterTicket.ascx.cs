using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.InterAssist.Usercontrols
{
    public partial class FilterTicket : System.Web.UI.UserControl
    {

        #region Metodos

        private void AssignTextToControls()
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                this.AssignTextToControls();
            }
        }

        #endregion Metodos
    }
}