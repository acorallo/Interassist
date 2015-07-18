using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace UI.InterAssist
{
    public partial class InterAssist : System.Web.UI.MasterPage
    {

        #region Metodos

        private Classes.Views MyPage
        {
            get
            {
                return (Classes.Views)this.Page;
            }
        }

        private void AssignTextToContros()
        {
            this.lblVersion.Text = ConfigurationSettings.AppSettings["ApplicationVersion"];
            this.lnkLogOut.Text = Resource.BTN_LOGOUT;

            // Menu.

            this.lnkOperadores.Text = Resource.BTN_MENU_OPERADORES;
            this.lnkPrestadores.Text = Resource.BTN_MENU_PRESTADORES;
            this.lnkAfiliados.Text = Resource.BTN_MENU_AFILIADOS;
            this.lnkCasos.Text = Resource.BTN_MENU_CASOS;
            this.lnkDatos.Text = Resource.BTN_MENU_UPLODAS;


        }

        protected void Page_Load(object sender, EventArgs e)
        {


            this.InicializaMenu();

            if (!this.IsPostBack)
            {
                this.AssignTextToContros();
                this.InitControls();
                
            }
        }

        public void ShowAsLogin()
        {
            this.lnkLogOut.Visible = true;
        }

        public void InicializaMenu()
        {

            this.lnkOperadores.Enabled = false;
            this.lnkOperadores.Visible = false;

            this.divBotones.Visible = this.MyPage.IsLoginUser;

            if (this.MyPage.IsLoginUser)
            {
                this.lnkOperadores.Enabled = this.MyPage.SessionOperador.Admin;
                this.lnkOperadores.Visible = this.MyPage.SessionOperador.Admin;

            }

        }

        private void InitControls()
        {
            this.lblSeccion.Text = this.MyPage.Seccion;
            this.lnkLogOut.Visible = false;

            if (this.MyPage.SessionOperador != null)
            {

                this.lnkUsuario.Text = this.MyPage.SessionOperador.Apellido + ", " + this.MyPage.SessionOperador.Nombre;
                this.ShowAsLogin();
            }
            else
            {

            }
        }

        #endregion Metodos

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            this.MyPage.SessionOperador = null;
            MyPage.goView(Classes.Views.LOGIN_VIEW);
        }

        protected void lnkOperadores_Click(object sender, EventArgs e)
        {
            MyPage.goView(Classes.Views.OPERADOR_VIEW);
        }

        protected void lnkAfiliados_Click(object sender, EventArgs e)
        {
            MyPage.goView(Classes.Views.AFILIADO_VIEW);
        }

        protected void lnkPrestadores_Click(object sender, EventArgs e)
        {
            MyPage.goView(Classes.Views.PRESTADOR_VIEW);
        }

        protected void lnkCasos_Click(object sender, EventArgs e)
        {
            MyPage.goView(Classes.Views.CASO_VIEW);
        }

        protected void lnkUsuario_Click(object sender, EventArgs e)
        {
            MyPage.goView(Classes.Views.USER_VIEW);
        }

        protected void lnkDatos_Click(object sender, EventArgs e)
        {
            MyPage.goView(Classes.Views.UPLOAD_VIEW);
        }
    }
}