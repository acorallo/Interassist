using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.InterAsisst;

namespace UI.InterAssist.Usercontrols
{
    public partial class Ubicacion : System.Web.UI.UserControl
    {

        #region Constantes

        private const int DEFAUL_ID_CONTROL=-1;

        private const string VW_REQUERIDO = "vw_requerido";

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros

        private string _seccion;

        private int _idPais = DEFAUL_ID_CONTROL;

        public int IdPais
        {
            get { return _idPais; }
            set { _idPais = value; }
        }
        
        private int _idLocalidad = DEFAUL_ID_CONTROL;


        private bool _isNew = true;

      
        #endregion Miembros

        #region Propiedades

        

        public int IDLocalidad
        {
            get
            {
                return this._idLocalidad;
            }
            set
            {
                this._idLocalidad = value;
            }
        }

       
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }

        public string Seccion
        {
            get { return _seccion; }
            set { _seccion = value; }
        }

        public string Dirección
        {
            get
            {
                return this.txtDireccion.Text;
            }
            set
            {
                this.txtDireccion.Text = value;
            }
        }


        public bool Requerido
        {
            get
            {
               if(this.ViewState[VW_REQUERIDO]==null)
                   this.ViewState.Add(VW_REQUERIDO, true);
               return (bool)this.ViewState[VW_REQUERIDO];
            }
            set
            {
                this.SetValidadores(value);
                this.ViewState.Add(VW_REQUERIDO, value);
            }
        }



        public Classes.Ubicacion GetUbicacion
        {
            get
            {
                return this.ubicacionPredict.GetUbicacion();
            }
        }

        #endregion Propiedades

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                
                this.InicializaControles();
                this.AssignTextToControls();
            }

        }

        private void InicializaComboPais()
        {
            Classes.Views.AgergarElijaOpcion(this.ddlPais);
            List<Pais> Paises = Pais.List();

            foreach (Pais p in Paises)
            {
                this.ddlPais.Items.Add(new ListItem(p.Nombre, p.IdPais.ToString()));
            }

            this.ddlPais.SelectedValue = "1";
            

        }

        private void InicializaControles()
        {

            if(this._isNew)
            {
                this.InicializaComboPais();
            }else
            {
                this.InicializaComboPais();
                if(this.IdPais!=-1)
                    this.ddlPais.SelectedValue = this.IdPais.ToString();

                this.ubicacionPredict.IdLocalidad = this._idLocalidad;
            }

            this.SetValidadores(this.Requerido);
            
        }

        private void SetValidadores(bool valor)
        {
            
            this.cmvPais.Enabled = valor;
            this.rfvDireccion.Enabled = valor;
            this.ubicacionPredict.IsEmptyValidate = valor;
        }

        private void AssignTextToControls()
        {
            // Labes
            this.lblPais.Text = Resource.LBL_UBICACION_PAIS + Resource.LBL_SEPARADOR;
            this.lblDireccion.Text = Resource.LBL_UBICACION_DIRECCION + Resource.LBL_SEPARADOR;
            this.lblUbicacion.Text = Resource.LBL_UBICACION_UBICACION + Resource.LBL_SEPARADOR;

            //Validadores
            this.cmvPais.ErrorMessage = String.Format(Resource.ERR_REQUEST_COMBO, this.Seccion + "/" + Resource.LBL_UBICACION_PAIS);
            this.rfvDireccion.ErrorMessage = string.Format(Resource.ERR_REQUEST_FIELD, this.Seccion + "/" + Resource.LBL_UBICACION_DIRECCION);
            this.ubicacionPredict.IsEmptyValidateText = String.Format(Resource.ERR_REQUEST_COMBO, this.Seccion + "/" + Resource.LBL_UBICACION_UBICACION);
            
        }
        
        #endregion Metodos

        #region Eventos

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        } 
        

        #endregion Eventos
    }
}