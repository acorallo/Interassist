using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Entities.InterAsisst;
using Cognitas.Framework.UserInterface;
using Cognitas.Framework.Repository;

namespace UI.InterAssist.Usercontrols
{
    public partial class Operador : System.Web.UI.UserControl
    {

        #region Delegados

        public delegate void CancelarDel();

        #endregion Delegados

        CancelarDel _cancelar;
        
        #region Constantes

        public const string VW_OPERADOR = "VW_OPEADORE_KEY";
        private const string SHOW_POP_MODIF = "SHOW_POP_MODIF";
        private const string SHOW_POP_ALTA = "SHOW_POP_ALTA";
        private const string SHOW_POP_RESET = "SHOW_RESET_PASSWORD";

        private const string SHOW_CONCUR_ERROR = "SHOW_CONCURR_ERROR";
        #endregion Constantes

        #region Propiedades

        private string _succesReset = string.Empty;

        public string SuccesReset
        {
            get { return _succesReset; }
            set { _succesReset = value; }
        }

        private string SHOW_POPUP
        {
            get
            {
                if (this.CMPage.IsNew)
                {
                    return SHOW_POP_ALTA;
                }
                else
                {
                    return SHOW_POP_MODIF;
                }
            }
        }

        public CancelarDel CancelarMethod
        {
            get
            {
                return this._cancelar;
            }
            set
            {
                _cancelar = value;
            }
        }

        public string GetExistUserError
        {
            get
            {
                return String.Format(Resource.ERR_USUARIO_EXISTENTE, Resource.LBL_OPERADOR_USUARIO);
            }
        }

        public string SuccessText
        {
            get
            {
                if (this.CMPage.IsNew)
                    return Resource.TXT_SUCC_OPERADOR_CREATE;
                else
                    return Resource.TXT_SUCC_OPERADOR_MODIF;
            }
        }

        

        public string ErrorText
        {
            get
            {
                return Resource.TXT_CONCURENCY_ERROR;
            }
        }

        public string SeccionName
        {
            get
            {
                return Resource.SECCION_ADM_OPERADORES;
            }
        }

        private ICrmPage CMPage
        {
            get
            {
                return (ICrmPage)this.Page;
            }
        }
        
        #endregion Propiedades

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {
                // Se carga la pagina inicialmente.
                this.AssigntTextToControls();
                this.InitControls();

                
            }
        }

        private void AssigntTextToControls()
        {
            // Carga el control
            this.lblNombre.Text = Resource.LBL_OPERADOR_NOMBRE + Resource.LBL_SEPARADOR;
            this.lblApellido.Text = Resource.LBL_OPERADOR_APELLIDO + Resource.LBL_SEPARADOR;
            this.lblUsuario.Text = Resource.LBL_OPERADOR_USUARIO + Resource.LBL_SEPARADOR;
            this.lblPassword.Text = Resource.LBL_OPERADOR_CLAVE + Resource.LBL_SEPARADOR;
            this.lblRepassword.Text = Resource.LBL_OPERADOR_RE_CLAVE + Resource.LBL_SEPARADOR;
            this.lblEmail.Text = Resource.LBL_OPERADOR_EMAIL + Resource.LBL_SEPARADOR;
            
            // Botones
            this.chkAdmin.Text = Resource.CHK_ADMIN;
            this.chkEstado.Text = Resource.CHK_ESTADO;
            this.btnAceptar.Text = Resource.BTN_ACEPTAR;
            this.btnCancelar.Text = Resource.BTN_CANCELAR;
            this.btnResetPassword.Text = Resource.BTN_REINICIAR_PASSWORD;

            // Validadores
            this.rfvNombre.ErrorMessage = string.Format(Resource.ERR_REQUEST_FIELD, Resource.LBL_OPERADOR_NOMBRE);
            this.rfvApellido.ErrorMessage = string.Format(Resource.ERR_REQUEST_FIELD, Resource.LBL_OPERADOR_APELLIDO);
            this.rfvUsuario.ErrorMessage = string.Format(Resource.ERR_REQUEST_FIELD, Resource.LBL_OPERADOR_USUARIO);
            this.rfvPassword.ErrorMessage = string.Format(Resource.ERR_REQUEST_FIELD, Resource.LBL_OPERADOR_CLAVE);
            this.rfvRePassword.ErrorMessage = string.Format(Resource.ERR_REQUEST_FIELD, Resource.LBL_OPERADOR_RE_CLAVE);
            this.cmvPassword.ErrorMessage = string.Format(Resource.ERR_PASSWORD_COMPARE, Resource.LBL_OPERADOR_CLAVE, Resource.LBL_OPERADOR_RE_CLAVE);
            this.cmvExisteUsuario.ErrorMessage = string.Format(Resource.ERR_USUARIO_EXISTENTE, Resource.LBL_OPERADOR_USUARIO);
            this.cmvLongUsuario.ErrorMessage = string.Format(Resource.ERR_LONG_USUARIO, Resource.LBL_OPERADOR_USUARIO, Entities.InterAsisst.Operador.MIN_LONG_USUARIO.ToString(), Entities.InterAsisst.Operador.MAX_LONG_USUARIO.ToString());
            this.cmvPasswordLong.ErrorMessage = string.Format(Resource.ERR_LONG_PASSWORD, Resource.LBL_OPERADOR_CLAVE, Entities.InterAsisst.Operador.MIN_PASSWORD);


        }

        private void InitControls()
        {
            //this.chkEstado.Checked = true;

            if (!this.CMPage.IsNew)
            {
                this.SetModificacion();
                this.CargarOperador(this.CMPage.EntityID);
            }
            else
            {
                this.SetAlta();
            }

        }

        private void CargarOperador(int id)
        {
            Entities.InterAsisst.Operador Operador = Entities.InterAsisst.Operador.GetById(id);
            if (Operador != null)
            {
                this.SetObjectToContror(Operador);
            }
        }

        private void SetAlta()
        {
            this.chkEstado.Checked = true;
            this.btnResetPassword.Visible = false;
        }

        private void SetModificacion()
        {
            this.txtUsuario.Enabled = false;
            this.txtPassword.Enabled = false;
            this.txtRePassword.Enabled = false;
            this.cmvExisteUsuario.Enabled = false;
            this.cmvLongUsuario.Enabled = false;
            this.cmvPasswordLong.Enabled = false;
            this.cmvPassword.Enabled = false;
            this.rfvPassword.Enabled = false;
            this.rfvUsuario.Enabled = false;
            this.rfvRePassword.Enabled = false;
            this.btnResetPassword.Visible = true;

        }
       
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if(this.Page.IsValid)
            {
                Entities.InterAsisst.Operador operador = this.getOperadorFromControl();
                if (operador.Persist())
                {
                    this.showpop.Value = this.SHOW_POPUP;
                    Classes.SessionHelper.ID_OPERADOR = Classes.SessionHelper.DEFAULT_ID;
                }
                else
                {
                    this.showpop.Value = SHOW_CONCUR_ERROR;
                    Classes.SessionHelper.ID_OPERADOR = Classes.SessionHelper.DEFAULT_ID;
                }
            }
        }

        private void SetObjectToContror(Entities.InterAsisst.Operador operador)
        {

            
            this.CMPage.ObjectHash = operador.UObjectID;
            this.txtApellido.Text = operador.Apellido;
            this.txtNombre.Text = operador.Nombre;
            this.txtUsuario.Text = operador.Usuario;
            this.txtEmail.Text = operador.Email;
            this.chkAdmin.Checked = operador.Admin;
            this.chkEstado.Checked = operador.Activo;
        }

        private Entities.InterAsisst.Operador getOperadorFromControl()
        {

            Entities.InterAsisst.Operador operador = null;

            if (this.CMPage.IsNew)
                operador = new Entities.InterAsisst.Operador();
            else
                operador = new Entities.InterAsisst.Operador(this.CMPage.EntityID, this.CMPage.ObjectHash);


            operador.Nombre = this.txtNombre.Text.Trim();
            operador.Apellido = this.txtApellido.Text.Trim();
            operador.Usuario = this.txtUsuario.Text.Trim();
            operador.SetClave(this.txtPassword.Text.Trim());
            operador.Email = this.txtEmail.Text.Trim();
            operador.Activo = this.chkEstado.Checked;
            operador.Admin = this.chkAdmin.Checked;

            

            return operador;
        }

        public static bool ValidarUsuario(string usuario)
        {
            bool result = false;

            Entities.InterAsisst.Operador operador = Entities.InterAsisst.Operador.GetByUsuario(usuario);

            result = operador == null;

            return result;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.CancelarMethod.Invoke();
        }

        #endregion Metodos

        #region Validadores

        protected void cmvPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.txtPassword.Text.Trim() == this.txtRePassword.Text.Trim();
        }

        protected void cmvExisteUsuario_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Operador.ValidarUsuario(args.Value.Trim());
        }

        protected void cmvLongUsuario_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool result = false;

            string usuario = args.Value.Trim();

            result = usuario.Length >= Entities.InterAsisst.Operador.MIN_LONG_USUARIO && usuario.Length <= Entities.InterAsisst.Operador.MAX_LONG_USUARIO;

            args.IsValid = result;
        }

        protected void cmvPasswordLong_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool result = false;

            string password = args.Value.Trim();
            result = password.Length >= Entities.InterAsisst.Operador.MIN_PASSWORD;

            args.IsValid = result;
        }

        
        #endregion Validadores

        #region Eventos

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            Entities.InterAsisst.Operador operador = this.getOperadorFromControl();
            string nuevaClave = operador.ResetPassword();
            this.SuccesReset = String.Format(Resource.MSG_RESET_PASSWORD, nuevaClave);
            this.showpop.Value = SHOW_POP_RESET;

        }

        #endregion Eventos

    }   
}