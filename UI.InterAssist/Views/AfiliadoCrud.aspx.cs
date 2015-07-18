using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.InterAssist.Views
{
    public partial class AfiliadoCrud : Classes.Views
    {

        #region Constantes

        private const string SHOW_POP_MODIF = "SHOW_POP_MODIF";
        private const string SHOW_POP_ALTA = "SHOW_POP_ALTA";

        private const string SHOW_CONCUR_ERROR = "SHOW_CONCURR_ERROR";

       

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
            get { return Classes.Views.AFILIADO_MODIF_VIEW; }
        }

        private string SHOW_POPUP
        {
            get
            {
                if (this.AfiliadoCtrl1.IsNewEntity)
                {
                    return SHOW_POP_ALTA;
                }
                else
                {
                    return SHOW_POP_MODIF;
                }
            }
        }

        public override string Seccion
        {
            get
            {
                string result = Resource.SESSION_NUEVO_AFILIADO;
                if (Classes.SessionHelper.ID_AFILIADO != Classes.SessionHelper.DEFAULT_ID)
                    result = Resource.SESSION_MODIF_AFILIADO;

                

                return result;
            }
        }

        protected override bool ReqLogin
        {
            get { return true; }
        }

        protected override bool ReqAdmin
        {
            get { return true; }
        }

        public string ErrorText
        {
            get
            {
                return Resource.TXT_CONCURENCY_ERROR;
            }
        }

        public string SuccessModif
        {
            get
            {
                return Resource.TXT_SUCC_AFILIADO_MODIF;
            }
        }

        public string SuccessCreate
        {
            get
            {
                return Resource.TXT_SUCC_AFILIADO_CREATE;
            }
        }

        public string SeccionName
        {
            get
            {
                return Resource.SECCION_ADM_AFILIADOS;
            }
        }

        #endregion Propiedades

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            this.AssignTextToControls();
            this.InicalizaControles();
            
        }

        private void AssignTextToControls()
        {

        }

        private void InicalizaControles()
        {

            this.AfiliadoCtrl1.AceptarEvent += new Usercontrols.AfiliadoCtrl.AceptaButtonHandler(AfiliadoCtrl1_AceptarEvent);
            this.AfiliadoCtrl1.CancelarEvent += new Usercontrols.AfiliadoCtrl.CancelarButtonHandle(AfiliadoCtrl1_CancelarEvent);

            if (Classes.SessionHelper.ID_AFILIADO != Classes.SessionHelper.DEFAULT_ID)
            {
                this.AfiliadoCtrl1.EntityID =  Classes.SessionHelper.ID_AFILIADO;

            }


        }

        void AfiliadoCtrl1_CancelarEvent()
        {
            
            this.AfiliadoCtrl1.ResetValues();
            this.GoBackView();
        }

        void AfiliadoCtrl1_AceptarEvent(bool result)
        {
            if (result)
            {
                this.showpop.Value = this.SHOW_POPUP;
            }
            else
            {
                this.showpop.Value = SHOW_CONCUR_ERROR;
            }

            this.AfiliadoCtrl1.ResetValues();
        }


        #endregion Metodos

        #region Eventos

        #endregion Eventos


    }
}