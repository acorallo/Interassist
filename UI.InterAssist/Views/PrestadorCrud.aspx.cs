using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cognitas.Framework.UserInterface;
using Cognitas.Framework.Repository;
using UI.InterAssist.Classes;
using Utils.InterAssist;
namespace UI.InterAssist.Views
{
    public partial class ProveedorCrud : Classes.Views, ICrmPage
    {
        #region Constantes

        private const string SHOW_POP_MODIF = "SHOW_POP_MODIF";
        private const string SHOW_POP_ALTA = "SHOW_POP_ALTA";
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

        public override string ViewName
        {
            get { return Classes.Views.PRESTADOR_MODIF_VIEW; }
        }

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
            get { return Resource.SECCION_ADM_PRESTADORES; }
        }

        public string SuccessModif
        {
            get
            {
                return Resource.TXT_SUCC_PRESTADOR_MODIF;
            }
        }

        public string SuccessCreate
        {
            get
            {
                return Resource.TXT_SUCC_PRESTADOR_CREATE;
            }
        }

        public string SeccionName
        {
            get
            {
                return Resource.SECCION_ADM_PRESTADORES;
            }
        }

        public string ErrorText
        {
            get
            {
                return Resource.TXT_CONCURENCY_ERROR;
            }
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

        private string SHOW_POPUP
        {
            get
            {
                if (this.PrestadoresEdit1.IsNewEntity)
                {
                    return SHOW_POP_ALTA;
                }
                else
                {
                    return SHOW_POP_MODIF;
                }
            }
        }

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
            this.AssisgnTextToControls();
            this.InicalizaControles();
            
        }

        private void AssisgnTextToControls()
        {
            
        }

        private void InicalizaControles()
        {

            
            this.PrestadoresEdit1.AceptarEvent +=new Usercontrols.PrestadoresEdit.AceptaButtonHandler(PrestadoresEdit1_AceptarEvent);
            this.PrestadoresEdit1.CancelarEvent += new Usercontrols.PrestadoresEdit.CancelarButtonHandle(PrestadoresEdit1_CancelarEvent);

            if (Classes.SessionHelper.ID_PRESTADOR != Classes.SessionHelper.DEFAULT_ID)
            {
                this.PrestadoresEdit1.EntityID = Classes.SessionHelper.ID_PRESTADOR;
                

            }


        }

        void PrestadoresEdit1_CancelarEvent()
        {
            this.PrestadoresEdit1.ResetValues();
            this.goView(Classes.Views.PRESTADOR_VIEW);
        }

        void PrestadoresEdit1_AceptarEvent(bool result, int id)
        {
            if (result)
            {
                this.SendSuccMsg(id.ToString());
            }
            else
            {
                this.SendErrorMsg();
            }

            this.PrestadoresEdit1.ResetValues();
            
        }

        private void SendSuccMsg(string idPrestador)
        {
            this.PopUp = POP_CREATE_MSG;
            this.SendInputHidden(this.litSuccMsg, "txtCasoModal", string.Format(Resource.TXT_PRESTADOR_SUCCESS, idPrestador));

        }

        private void SendErrorMsg()
        {
            this.PopUp = POP_ERROR_MSG;
            this.SendInputHidden(this.litSuccMsg, "txtCasoModal", Resource.TXT_PRESTADOR_ERROR);
        }

        #endregion Metodos

        #region WebMethods

        public static string getWhereLogic(string value)
        {
            string result = string.Empty;

            string[] parse = value.Split(',');

            if (parse.Length == 1)
            {
                // con un solo parametro
                result = String.Format("LOCALIDAD LIKE '%{0}%' or CIUDAD LIKE '%{0}%' or PROVINCIA LIKE '%{0}%'", parse[0].Trim());
            }
            else if (parse.Length == 2)
            {
                // con dos parametros
                result = String.Format("(LOCALIDAD LIKE '%{0}%' and CIUDAD LIKE '%{1}%') or (CIUDAD LIKE '%{0}%' and PROVINCIA LIKE '%{1}%') or (LOCALIDAD LIKE '%{0}%' and  PROVINCIA LIKE '%{1}%')", parse[0].Trim(), parse[1].Trim());

            }
            else
            {
                // con tres parametros.
                result = String.Format("LOCALIDAD LIKE '%{0}%' and CIUDAD LIKE '%{1}%' and PROVINCIA LIKE '%{2}%'", parse[0].Trim(), parse[1].Trim(), parse[2].Trim());
            }


            return result;
        }


        [System.Web.Services.WebMethod]
        public static AjaxResponseCiudaes[] ObtenerUbicacion(string valor)
        {

            List<AjaxResponseCiudaes> listResult = new List<AjaxResponseCiudaes>();

            try
            {

                string selecExpr = getWhereLogic(valor);

                string orderExpr = "Provincia asc, Ciudad asc, Localidad asc";

                foreach (DataRow dr in Classes.Localidades.GetLocalidades().Select(selecExpr, orderExpr))
                {
                    listResult.Add(new AjaxResponseCiudaes(dr["NOMBRE_COMPLETO"].ToString(), dr["NOMBRE_COMPLETO"].ToString(), Int32.Parse(dr["IDLOCALIDAD"].ToString())));
                }
            }
            catch
            {
            }

            return listResult.ToArray();
        }


        #endregion WebMethods
    }
}