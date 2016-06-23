using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.InterAsisst;
namespace UI.InterAssist.Usercontrols
{
    public partial class VerifcacionCasos : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                this.InitControls();
                this.AssignTextToControls();
            }
        }


        private void InitControls()
        {

        }

        private void AssignTextToControls()
        {
            this.lblSinCasos.Text = Resource.TXT_SIN_CASOS;
        }

        public bool LoadAfiliado(int idAfiliado)
        {

            bool result = false;

            Entities.InterAsisst.Afiliado a = Entities.InterAsisst.Afiliado.GetById(idAfiliado);

            if (a != null)
            {
                this.setAfiliadosInControls(a);
                result = true;
            }
            else
                result = false;

            return result;

        }

        private void setAfiliadosInControls(Entities.InterAsisst.Afiliado afiliado)
        {
            int mesCorriente = System.DateTime.Now.Month;
            int annoCorriente = System.DateTime.Now.Year;

            ContadorCasos c = ContadorCasos.getContadorCasos(mesCorriente, annoCorriente, afiliado.Poliza);



            if(c.Casos.Count>0)
            {
                this.lblSinCasos.Hidden = true;
                this.GdPCasosAsignados.Hidden = false;
                this.lblCantidadCasos.Hidden = false;
                this.lblCantidadCasos.Text = c.Cantidad.ToString();
                this.Store1.DataSource = c.Casos;
                this.Store1.DataBind();
                
            }
            else
            {
                this.lblCantidadCasos.Hidden = true;
                this.GdPCasosAsignados.Hidden = true;
                this.lblSinCasos.Hidden = false;
            }

            this.lblMesCorriente.Text = System.DateTime.Now.ToString("MMMM").ToUpper() + " " + annoCorriente.ToString();

            this.lblPatente.Text = afiliado.Patente;
            this.lblMarca.Text = afiliado.Marca;
            this.lblPoliza.Text = afiliado.Poliza;
            this.lblCompania.Text = afiliado.NombreEmpresa;
            this.lblTipo.Text = afiliado.NombreCategoria;


        }

    }
}