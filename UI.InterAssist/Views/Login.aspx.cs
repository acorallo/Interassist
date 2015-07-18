using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.InterAssist.Views
{
    public partial class Login : Classes.Views
    {


        #region Properties

        protected override bool ReqAdmin
        {
	        get { return false; }
        }

        protected override bool ReqLogin
        {
	        get { return false; }
        }

        public override string  Seccion
        {
            get { return Resource.SECCION_LOGIN; }
        }

        #endregion Properties

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            this.AssitgtTextToControls();
        }

        private void AssitgtTextToControls()
        {
            // Labels.
            this.lblPassword.Text = Resource.LBL_OPERADOR_CLAVE + Resource.LBL_SEPARADOR;
            this.lblUser.Text = Resource.LBL_OPERADOR_USUARIO + Resource.LBL_SEPARADOR;

            // Botones.
            this.btnAceptar.Text = Resource.BTN_INICIAR_SESION;
            this.btnCancelar.Text = Resource.BTN_CANCELAR;

            // Validadores.
            this.rfvPassword.ErrorMessage = string.Format(Resource.ERR_LOGIN_EMPTY_PASSWORD, Resource.LBL_OPERADOR_CLAVE);
            this.rfvUsername.ErrorMessage = string.Format(Resource.ERR_LOGIN_EMPTY_USER, Resource.LBL_OPERADOR_USUARIO);
           
        }

        public override string ViewName
        {
            get { return Classes.Views.LOGIN_VIEW; }
        }

        private void DoLogin()
        {
            string username = this.txtUsuario.Text.Trim();
            string password = this.txtPassword.Text.Trim();
            Entities.InterAsisst.Operador oPerador = Entities.InterAsisst.Operador.GetByCredeciales(username, password);

            if (oPerador != null)
            {
                if (oPerador.Activo)
                {
                    this.SessionOperador = oPerador;
                    Classes.SessionHelper.CURRENT_VIEW = Classes.Views.LOGIN_VIEW;
                    this.goView(Classes.Views.AFILIADO_VIEW);
                }
                else
                {
                    // Tratar error de usuario no activo;
                    this.lblLoginError.Text = String.Format(Resource.ERR_LOGIN_NOT_ACTIVE, Resource.LBL_OPERADOR_USUARIO);
                }
            }
            else
            {
                // Tratar error de usuario y contraseña.
                this.lblLoginError.Text = String.Format(Resource.ERR_LOGIN_FAIL, Resource.LBL_OPERADOR_USUARIO, Resource.LBL_OPERADOR_CLAVE);
            }
        }

        #endregion Metodos

        #region Eventos


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DoLogin();   
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }

        #endregion Eventos

    }
}