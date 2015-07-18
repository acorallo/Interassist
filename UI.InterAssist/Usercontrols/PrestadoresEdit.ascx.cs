using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.InterAsisst;
using Cognitas.Framework.UserInterface;

namespace UI.InterAssist.Usercontrols
{
    public partial class PrestadoresEdit : CruEntityUserControl
    {

        #region Delegados

        public delegate void AceptaButtonHandler(bool result, int IdPrestador);
        public delegate void CancelarButtonHandle();

        #endregion Delatados

        #region Constantes

        private const int DEFAUL_ID_CONTROL = -1;


        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros

        private int _idPais = DEFAUL_ID_CONTROL;
        private int _idProvincia = DEFAUL_ID_CONTROL;
        private int _idLocalidad = DEFAUL_ID_CONTROL;
        private int _idCiudad = DEFAUL_ID_CONTROL;

        public event AceptaButtonHandler AceptarEvent;
        public event CancelarButtonHandle CancelarEvent;

        #endregion Miembros

        #region Propiedades

        public int IDPais
        {
            get
            {
                return Int32.Parse(this.ddlPais.SelectedValue);
            }
            set
            {
                this._idPais = value;
            }

        }

        #endregion Propiedades

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {
                this.AssignTextToControls();
                this.InicializaControles();
            }
        }

        private void AssignTextToControls()
        {

            // Labels
            this.lblId.Text = Resource.LBL_PRESTADOR_ID + Resource.LBL_SEPARADOR;
            this.lblNombre.Text = Resource.LBL_PRESTADOR_NOMBRE + Resource.LBL_SEPARADOR;
            this.lblDescripcion.Text = Resource.LBL_PRESTADOR_DESCRIPCION + Resource.LBL_SEPARADOR;
            this.lblEstado.Text = Resource.LBL_PRESTADOR_ESTADO + Resource.LBL_SEPARADOR;
            this.lblTelefono1.Text = Resource.LBL_PRESTADOR_TELEFONO1 + Resource.LBL_SEPARADOR;
            this.lblTelefono2.Text = Resource.LBL_PRESTADOR_TELEFONO2 + Resource.LBL_SEPARADOR;
            this.lblCelular1.Text = Resource.LBL_PRESTADOR_CELULAR + Resource.LBL_SEPARADOR;
            this.lblCelular2.Text = Resource.LBL_PRESTADOR_CELULAR2 + Resource.LBL_SEPARADOR;
            this.lblNextel.Text = Resource.LBL_PRESTADOR_NEXT_TEX + Resource.LBL_SEPARADOR;
            this.lblDomicilio.Text = Resource.LBL_PRESTADOR_DOMICILIO + Resource.LBL_SEPARADOR;
            this.lblPais.Text = Resource.LBL_PRESTADOR_PAIS + Resource.LBL_SEPARADOR;
            this.lblEmail.Text = Resource.LBL_PRESTADOR_EMAIL + Resource.LBL_SEPARADOR;
            this.lblCuit.Text = Resource.LBL_PRESTADOR_CIUT + Resource.LBL_SEPARADOR;
            this.lblMovida.Text = Resource.LBL_PRESTADOR_MOVIDA;
            this.lblkm.Text = Resource.LBL_PRESTADOR_KM;
            this.lblLiv.Text = Resource.LBL_PRESTADOR_LIV;
            this.lblSp1.Text = Resource.LBL_PRESTADOR_SP1;
            this.lblSp2.Text = Resource.LBL_PRESTADOR_SP2;
            this.lblps1.Text = Resource.LBL_PRESTADOR_PS1;
            this.lblPs2.Text = Resource.LBL_PRESTADOR_PS2;
            this.lblTarifas.Text = Resource.LBL_PRESTADOR_TARIFAS + Resource.LBL_SEPARADOR;
            this.lblIva.Text = Resource.LBL_PRESTADOR_IVA + Resource.LBL_SEPARADOR;
            this.lblUbicacion.Text = Resource.LBL_PRESTADOR_UBICACION + Resource.LBL_SEPARADOR;


            // Controles
            this.chkActivo.Text = Resource.LBL_PRESTADOR_ACTIVO;

            // Validadores 
            this.rfvNombre.ErrorMessage = string.Format(Resource.ERR_REQUEST_FIELD, Resource.LBL_OPERADOR_NOMBRE);
            this.cmvPais.ErrorMessage = string.Format(Resource.ERR_REQUEST_COMBO, Resource.LBL_PRESTADOR_PAIS);
            this.cmvIva.ErrorMessage = string.Format(Resource.ERR_REQUEST_COMBO, Resource.LBL_PRESTADOR_IVA);
            this.revEmail.ErrorMessage = string.Format(Resource.ERR_FIELD_EMAIL, Resource.LBL_PRESTADOR_EMAIL);
            this.UbicacionPredictivo1.IsEmptyValidateText = string.Format(Resource.ERR_REQUEST_FIELD, Resource.LBL_PRESTADOR_UBICACION);

            // Botones
            this.btnAceptar.Text = Resource.BTN_ACEPTAR;
            this.btnCancelar.Text = Resource.BTN_CANCELAR;

        }

        private void InicializaComboIva()
        {
            List<TipoIva> TList = TipoIva.GetList();
            Classes.Views.AgergarElijaOpcion(this.ddlIva);
            
            foreach (TipoIva t in TList)
            {
                this.ddlIva.Items.Add(new ListItem(t.Descripction, t.Descripction));       
            }
        }

        private void InicializaControles()
        {
            this.InicializaComboIva();
            this.UbicacionPredictivo1.IsEmptyValidate = true;
            
            if (this.IsNewEntity)
            {

                this.InicializaComboPais();
                
                

            }
            else
            {

                int idPrestador = Classes.SessionHelper.ID_PRESTADOR;

                Prestador p = Prestador.GetById(idPrestador);
                this.SetPresatador(p);

                this.InicializaComboPais();
                this.ddlPais.SelectedValue = this._idPais.ToString();
               
                 
                
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

        



        private Prestador GetPrestadorFromControl()
        {
            Prestador p = new Prestador(this.EntityID, this.ObjectHash);
            
            // Datos obligatorios.
            p.Nombre = this.txtNombre.Text;
            p.Activo = this.chkActivo.Checked;
            p.Cuit = this.txtCuit.Text;
            p.Email = this.txtEmail.Text;
            p.Domicilio = this.txtDomicio.Text;
            p.Nextel = this.txtNextel.Text;
            p.Telefono1 = this.txtTelefono1.Text;
            p.Telefono2 = this.txtTelefono2.Text;
            p.Celular1 = this.txtCelular1.Text;
            p.Celular2 = this.txtCelular2.Text;
            p.Descripcion = this.txtDescripcion.Text;
            p.Iva = this.ddlIva.SelectedValue;
            
            // Combos
            p.IdPais = Int32.Parse(this.ddlPais.SelectedValue);
        
            Classes.Ubicacion u = this.UbicacionPredictivo1.GetUbicacion();
            
            if (u != null)
            {
                p.IdPais = u.IDPais;
                p.IdProvincia = u.IDProvincia;
                p.IdCiudad = u.IDCiudad;
                p.IdLocalidad = u.IDLocalidad;
            }

            // Valores de tarifas
            p.LIV_MOVIDA = this.decLivMovida.Value;
            p.LIV_KM = this.decLivKm.Value;
            
            p.SP1_MOVIDA = this.decSp1Movida.Value;
            p.SP1_KM = this.decSp1Km.Value;

            p.SP2_MOVIDA = this.decSp2Movida.Value;
            p.SP2_KM = this.decSp2Km.Value;

            p.PS1_MOVIDA = this.decPs1Movida.Value;
            p.PS1_KM = this.decPs1Km.Value;

            p.PS2_MOVIDA = this.decPs2Movida.Value;
            p.PS2_KM = this.decPs2Km.Value;
            
            return p;
            
        }

        private void ResetControl()
        {
        }

        private void SetPresatador(Prestador p)
        {
            this.EntityID = p.ID;
            this.ObjectHash = p.UObjectID;

            // Valores generales.

            if (!this.IsNewEntity)
                this.lbltxtId.Text = p.ID.ToString();

            this.txtNombre.Text = p.Nombre;
            this.chkActivo.Checked = p.Activo;
            this.txtCuit.Text = p.Cuit;
            this.txtEmail.Text = p.Email;
            this.txtDomicio.Text = p.Domicilio;
            this.txtNextel.Text = p.Nextel;
            this.txtTelefono1.Text = p.Telefono1;
            this.txtTelefono2.Text = p.Telefono2;
            this.txtCelular1.Text = p.Celular1;
            this.txtCelular2.Text = p.Celular2;
            this.txtDescripcion.Text = p.Descripcion;

            // Combos
            this.IDPais = p.IdPais;
            
            this.UbicacionPredictivo1.IdLocalidad = p.IdLocalidad;

            // Valores de tarifas
            this.decLivMovida.Value = p.LIV_MOVIDA;
            this.decLivKm.Value = p.LIV_KM;

            this.decSp1Movida.Value = p.SP1_MOVIDA;
            this.decSp1Km.Value = p.SP1_KM;

            this.decSp2Movida.Value = p.SP2_MOVIDA;
            this.decSp2Km.Value = p.SP2_KM;

            this.decPs1Movida.Value = p.PS1_MOVIDA;
            this.decPs1Km.Value = p.PS1_KM;

            this.decPs2Movida.Value = p.PS2_MOVIDA;
            this.decPs2Km.Value = p.PS2_KM;

            this.ddlIva.SelectedValue = p.Iva;

            this.UbicacionPredictivo1.IdLocalidad = p.IdLocalidad;

        }

        
        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {

                Prestador p = this.GetPrestadorFromControl();

                if(p.Persist())
                {
                     this.AceptarEvent.Invoke(true, p.ID);
                }
                else
                {
                     this.AceptarEvent.Invoke(false, p.ID);
                }

                this.ResetControl();

            }
     

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ResetControl();
            this.CancelarEvent.Invoke();
        }

        #endregion Metodos              
    }
}