using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.InterAsisst;
using UI.InterAssist.Classes;

namespace UI.InterAssist.Usercontrols
{
    public partial class UbicacionPredictivo : System.Web.UI.UserControl
    {
        #region Constantes

        public const int NULL_ID = -1;
        
        private const string VW_VALIDATE_EMPTY = "wsValidateEmptyControl";
        private const string VW_VALIDATE_EMPTY_TEXT = "wsValidateEmptyText";
        
        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros

        #endregion Miembros

        #region Propiedades

        public bool IsEmptyValidate 
        {
            get
            {
                return this.cmvUbicacion.Enabled;
            }
            set
            {
                this.cmvUbicacion.Enabled = value;
            }

        }

        public string IsEmptyValidateText
        {
            get
            {
                if (this.ViewState[VW_VALIDATE_EMPTY_TEXT] == null)
                    this.ViewState[VW_VALIDATE_EMPTY_TEXT] = string.Empty;
                return this.ViewState[VW_VALIDATE_EMPTY_TEXT].ToString();
            }
            set
            {
                this.ViewState.Add(VW_VALIDATE_EMPTY_TEXT, value);
            }

        }

        public string NombreCompletoControlName
        {
            get
            {
                return this.nombreCompleto.Name;
            }

        }

        public string NombreCompletoControlID
        {
            get
            {
                return this.nombreCompleto.ClientID;
            }
        }

        public string UniqueUbicacionControlID
        {
            get
            {
                return this.uniqueUbicacion.ClientID.ToString();
            }
        }

        public string UniqueUbicacionContolName
        {
            get
            {
                return this.uniqueUbicacion.Name;
            }
        }

        public string UbicacionControlID
        {
            get
            {
                return this.ubicacion.ClientID.ToString();
            }
        }

        public int IdLocalidad
        {
            get
            {
                int resultValue = NULL_ID;

                if (this.uniqueUbicacion.Value != string.Empty)
                    resultValue = Int32.Parse(this.uniqueUbicacion.Value);

                return resultValue;
            }
            set
            {
                this.uniqueUbicacion.Value = value.ToString();
            }
        }

        #endregion Propiedades

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            
            string paramExpresion = "function () {InitUbicacion('" + this.UbicacionControlID + "','" + this.UniqueUbicacionControlID + "','" + this.NombreCompletoControlID + "');}";

            this.variables.Text = "SuscribirCarga("+paramExpresion+")";
            

            this.SincronizarControles();

            if (!this.IsPostBack)
            {
                this.InicializaControles();
                
            }
        }

        private void InicializaControles()
        {
            if (this.IdLocalidad != NULL_ID)
            {
                string whereClause = string.Format("IDLOCALIDAD = {0}", IdLocalidad);
                DataRow[] localidades = Localidades.GetLocalidades().Select(whereClause);

                if (localidades.Length > 0)
                {
                    this.ubicacion.Value = localidades[0]["NOMBRE_COMPLETO"].ToString();
                    this.nombreCompleto.Value = localidades[0]["NOMBRE_COMPLETO"].ToString();
                }
            }

            
            this.cmvUbicacion.ErrorMessage = this.IsEmptyValidateText;
        }

        public void SincronizarControles()
        {
            if (this.Request.Form[this.UniqueUbicacionContolName] != null && this.Request.Form[this.UniqueUbicacionContolName] != string.Empty)
            {
                this.uniqueUbicacion.Value = this.Request.Form[this.UniqueUbicacionContolName];
            }

            if (this.Request.Form[this.NombreCompletoControlName] != null)
            {
                this.nombreCompleto.Value = this.Request.Form[this.NombreCompletoControlName];
            }

        }

        public Classes.Ubicacion GetUbicacion()
        {
            Classes.Ubicacion result = new Classes.Ubicacion(); ;

            if (this.IdLocalidad != NULL_ID)
            {
                result = Localidades.GetUbicacionById(this.IdLocalidad);
            }

            return result;

        }

        #endregion Metodos

        #region Eventos

        protected void cmvUbicacion_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.IdLocalidad != NULL_ID;
        }

        #endregion Eventos

    }
}