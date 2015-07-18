using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.InterAssist.Views
{
    public partial class Usuario : Classes.Views
    {


        #region Constantes

        private const string SHOW_POP_MODIF = "SHOW_POP_MODIF";
        private const string SHOW_CONCUR_ERROR = "SHOW_CONCURR_ERROR";
        private const string VS_ID_POP_UP = "vs_popup";
        private const string POP_ERROR_MSG = "dialog-message_error";
        private const string POP_CREATE_MSG = "dialog-message_create";

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros

        #endregion Miembros

        #region Propiedades

        protected override bool ReqAdmin
        {
            get { return false; }
        }

        protected override bool ReqLogin
        {
            get { return true; }
        }

        public override string ViewName
        {
            get { return Classes.Views.USER_VIEW; }
        }

        public override string Seccion
        {
            get { return Resource.SECCION_MI_USUARIO; }
        }

        private string PopUp
        {
            get
            {
                if (this.ViewState[VS_ID_POP_UP] == null)
                    this.ViewState.Add(VS_ID_POP_UP, string.Empty);
                return this.ViewState[VS_ID_POP_UP].ToString();

            }
            set
            {
                this.ViewState.Add(VS_ID_POP_UP, value);
            }
        }


        #endregion Propiedades

        #region Metodos

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.SincronizaPopModal();
        }

        private void SincronizaPopModal()
        {
            this.litPopUp.Text = string.Format(@"<input name=""popModal"" id=""popModal"" type=""hidden"" value=""{0}""/>", this.PopUp);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!this.IsPostBack)
            {
                this.AssignTextToControls();
                this.InicializaControles();
            }
        }

        private void AssignTextToControls()
        {
            // Labels
            this.lblUsuario.Text = Resource.LBL_OPERADOR_USUARIO + Resource.LBL_SEPARADOR;
            this.lblPassword.Text = Resource.LBL_OPERADORE_NUEVA_CLAVE + Resource.LBL_SEPARADOR;
            this.lblRePassword.Text = Resource.LBL_OPERADOR_RE_CLAVE + Resource.LBL_SEPARADOR;
            this.lblAnterior.Text = Resource.LBL_OPERADOR_CLAVE_ANTERIOR + Resource.LBL_SEPARADOR;
            this.lblSeccionPassword.Text = Resource.LBL_SECCION_CAMBIO_CLAVE;

            // Botones 
            this.btnCambiar.Text = Resource.BTN_CAMBIAR_CLAVE;
            this.btnVolver.Text = Resource.BTN_VOLVER;
            


            // Validadores
            this.rfvAnterior.ErrorMessage = String.Format(Resource.ERR_REQUEST_FIELD, Resource.LBL_OPERADOR_CLAVE_ANTERIOR);
            this.rfvPassword.ErrorMessage = String.Format(Resource.ERR_REQUEST_FIELD, Resource.LBL_OPERADOR_CLAVE);
            this.rfvRepassword.ErrorMessage = String.Format(Resource.ERR_REQUEST_FIELD, Resource.LBL_OPERADOR_RE_CLAVE);
            this.cmvAnterior.ErrorMessage = Resource.ERR_CLAVE_ANTERIOR;
            this.cmvLongPassword.ErrorMessage = string.Format(Resource.ERR_LONG_PASSWORD, Resource.LBL_OPERADOR_CLAVE, Entities.InterAsisst.Operador.MIN_PASSWORD);
            this.cmvRePassword.ErrorMessage = string.Format(Resource.ERR_PASSWORD_COMPARE, Resource.LBL_OPERADOR_CLAVE, Resource.LBL_OPERADOR_RE_CLAVE);

        }

        private void InicializaControles()
        {
            this.lblTxtUsuario.Text = this.SessionOperador.Usuario;
            this.lblApellidoNombre.Text = this.SessionOperador.Apellido + ", " + this.SessionOperador.Nombre;
        }

        private void SendSuccMsg()
        {
            this.PopUp = POP_CREATE_MSG;
            this.SendInputHidden(this.litSuccMsg, "txtCasoModal", Resource.TXT_SUCC_CAMBIO_CLAVE);

        }

        private void SendErrorMsg()
        {
            this.PopUp = POP_ERROR_MSG;
            this.SendInputHidden(this.litSuccMsg, "txtCasoModal", Resource.TEXT_ERR_CAMBIO_CLAVE);
        }


        #endregion Metodos

        #region Eventos

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                if (this.SessionOperador.CambiarClave(this.txtPassword.Text))
                {
                    this.SendSuccMsg();
                }
                else
                {
                    SendErrorMsg();
                }
                
                this.SessionOperador = null;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            this.GoBackView();
        }

        protected void cmvAnterior_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = SessionOperador.VerficarClave(args.Value.Trim());
        }

        protected void cmvLongPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool result = false;

            string password = args.Value.Trim();
            result = password.Length >= Entities.InterAsisst.Operador.MIN_PASSWORD;

            args.IsValid = result;
        } 
        
        #endregion Eventos

        protected void cmvRePassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.txtPassword.Text.Trim() == this.txtRePassword.Text.Trim();
        }
    }
}