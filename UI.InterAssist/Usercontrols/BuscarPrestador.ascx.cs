using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.InterAssist.Usercontrols
{
    public partial class BuscarPrestador : System.Web.UI.UserControl
    {

        


        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.AssignTextToControls();

            }
        }

        private void AssignTextToControls()
        {
            this.lblPresadorPais.Text = Resource.LBL_PRESTADOR_PAIS + Resource.LBL_SEPARADOR;
            this.lblPrestadorProvincia.Text = Resource.LBL_PRESTADOR_PROVINCIA + Resource.LBL_SEPARADOR;
            this.lblPrestadorCiudad.Text = Resource.LBL_PRESTADOR_CIUDAD + Resource.LBL_SEPARADOR;
            this.lblPrestadorNombre.Text = Resource.LBL_PRESTADOR_NOMBRE + Resource.LBL_SEPARADOR;
            this.lblNonResult.Text = Resource.TXT_NON_RESULTS;
        }

        #endregion Metodos

    }
}