using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cognitas.Framework.UserInterface;
using Cognitas.Framework.Repository;
using UI.InterAssist.Classes;
using Utils.InterAssist;


namespace UI.InterAssist.Views
{
    public partial class OperadorCrud : Classes.Views, ICrmPage
    {
        #region Propiedades

        protected override bool ReqAdmin
        {
            get { return true; }
        }

        protected override bool ReqLogin
        {
            get { return true; }
        }

        public override string Seccion
        {
            get {
                if (SessionHelper.ID_OPERADOR != SessionHelper.DEFAULT_ID)
                {
                    return Resource.SECCION_MODIFICACION_OPERADOR;
                }
                else
                {
                    return Resource.SECCION_NUEVO_OPERADOR;
                }
            }
        }

        public override string ViewName
        {
            get { return Classes.Views.OPERADOR_MODIF_VIEW; }
        }

        

        #endregion Propidades

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            this.InicializaControles();
            

        }

        protected void InicializaControles()
        {

            this.Operador1.CancelarMethod = new Usercontrols.Operador.CancelarDel(controlCancelar);

            if (SessionHelper.ID_OPERADOR != SessionHelper.DEFAULT_ID)
            {
                this.EntityID = SessionHelper.ID_OPERADOR;

            }
            
        }


        private void controlCancelar()
        {
            SessionHelper.ID_OPERADOR = SessionHelper.DEFAULT_ID;
            this.goView(Classes.Views.OPERADOR_VIEW);
        }

        #region WebMethods

        [System.Web.Services.WebMethod]
        public static AjaxResponseValidarUsuario ValidarUsuario(string usuario)
        {
            AjaxResponseValidarUsuario result = new AjaxResponseValidarUsuario();
            result.Error = String.Format(Resource.ERR_USUARIO_EXISTENTE, Resource.LBL_OPERADOR_USUARIO);
            result.Result = UI.InterAssist.Usercontrols.Operador.ValidarUsuario(usuario);
            
            return result;
        }

        

        #endregion WebMethods

        
    }

    public class AjaxResponseValidarUsuario
    {
        public string Error;
        public bool Result;
    }
}