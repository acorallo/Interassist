using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cognitas.Framework.UserInterface;
using Entities.InterAsisst;
using UI.InterAssist.Classes;

namespace UI.InterAssist.Usercontrols
{
    public partial class AfiliadoCtrl : CruEntityUserControl
    {

        #region Delegados

        public delegate void AceptaButtonHandler(bool result);
        public delegate void CancelarButtonHandle();

        #endregion Delatados

        #region Constantes

        private const string ID_FECHA_DESDE = "ctrlIdFechaHasta";
        private const string ID_FECHA_HASTA = "ctrlIdFechaDesde";

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros

        public event AceptaButtonHandler AceptarEvent;
        public event CancelarButtonHandle CancelarEvent;

        #endregion Miembros

        #region Propiedades

        private Classes.Views MyPage
        {
            get
            {
                return (Classes.Views)this.Page;
            }
        }

        #endregion Propiedades

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.AssignTextToControls();
                this.InicalizaControles();
            }

        }

        private void InicalizaControles()
        {
            this.InicalizaComboEmpresas();
            this.InicializaComboCategorias();
            this.tableId.Visible = !this.IsNewEntity;
            Classes.Views.SendInputTypeHidden(this.ltrIdFechaDesde, ID_FECHA_DESDE, this.txtFechaDesde.ClientID.ToString());
            Classes.Views.SendInputTypeHidden(this.ltrIdFechaHasta, ID_FECHA_HASTA, this.txtFechaHasta.ClientID.ToString());
            this.InicializaEntidad();
           
        }

        private void InicializaEntidad()
        {
            if (this.EntityID != Classes.SessionHelper.DEFAULT_ID)
            {
                Entities.InterAsisst.Afiliado afiliado = Entities.InterAsisst.Afiliado.GetById(this.EntityID);
                this.SetAfiliadoToControls(afiliado);
            }
        }

        private void InicializaComboCategorias()
        {
            Classes.Views.AgergarElijaOpcion(this.ddlCategoria);
            List<Categoria> listCategoria = Categoria.ListAll();
            foreach (Categoria c in listCategoria)
            {
                this.ddlCategoria.Items.Add(new ListItem(c.Nombre, c.Codigo));
                
            }
        }

        private void InicalizaComboEmpresas()
        {
            Classes.Views.AgergarElijaOpcion(this.ddlEmpresa);
            List<Empresa> listaEmpresas = Empresa.ListAll();
            foreach (Empresa e in listaEmpresas)
            {
                this.ddlEmpresa.Items.Add(new ListItem(e.Nombre, e.ID.ToString()));
            }
        }

        private Afiliado GetAfiliadoFromControls()
        {
            Afiliado resultAfiliado = new Afiliado(this.EntityID, this.ObjectHash);
            resultAfiliado.Nombre = txtNombre.Text.Trim();
            resultAfiliado.Apellido = txtApellido.Text.Trim();
            resultAfiliado.Direccion = txtDireccion.Text.Trim();
            resultAfiliado.CodigoPostal = txtCodigoPostal.Text.Trim();
            resultAfiliado.IDEmpresa = Int32.Parse(this.ddlEmpresa.SelectedValue.ToString());
            resultAfiliado.Poliza = this.txtPoliza.Text.Trim();
            resultAfiliado.Patente = this.txtPatente.Text.Trim();
            resultAfiliado.Año = this.txtAno.Text.Trim();
            resultAfiliado.Marca = this.txtMarca.Text.Trim();
            resultAfiliado.Color = this.txtColor.Text.Trim();
            resultAfiliado.FechaDesde = this.GetDateFromControl(this.txtFechaDesde.Text.Trim());
            resultAfiliado.FechaHasta = this.GetDateFromControl(this.txtFechaHasta.Text.Trim());
            resultAfiliado.Documento = this.txtDocumento.Text.Trim();
            resultAfiliado.Categoria = this.ddlCategoria.SelectedValue;
            resultAfiliado.Hogar = this.chkHogar.Checked;
            resultAfiliado.Modelo = this.txtModelo.Text.Trim();
            resultAfiliado.Estado = this.chkEstado.Checked;

            return resultAfiliado;
        }

        private string GetDateText(DateTime date)
        {
            string result = string.Empty;

            if (date != DateTime.MinValue)
            {

                string dia = date.Day.ToString().Length == 1 ? "0" + date.Day.ToString() : date.Day.ToString();
                string mes = date.Month.ToString().Length == 1 ? "0" + date.Month.ToString() : date.Month.ToString();
                string ano = date.Year.ToString();

                result = dia + "/" + mes + "/" + ano;
            }

            return result;
        }

        private DateTime GetDateFromControl(string valor)
        {

            DateTime result = DateTime.MinValue;

            if (valor != string.Empty)
            {

                int day = Int32.Parse(valor.Substring(0, 2));
                int month = Int32.Parse(valor.Substring(3, 2));
                int year = Int32.Parse(valor.Substring(6, 4));
                result = new DateTime(year, month, day);

            }
            
            return result;
        }

        private void SetAfiliadoToControls(Afiliado afiliado)
        {
            this.EntityID = afiliado.ID;
            this.ObjectHash = afiliado.UObjectID;
            this.lbltxtID.Text = afiliado.ID.ToString();
            this.txtNombre.Text = afiliado.Nombre;
            this.txtApellido.Text = afiliado.Apellido;
            this.txtDocumento.Text = afiliado.Documento;
            this.txtDireccion.Text = afiliado.Direccion;
            this.txtCodigoPostal.Text = afiliado.CodigoPostal;
            this.ddlEmpresa.SelectedValue = afiliado.IDEmpresa.ToString();
            this.txtPoliza.Text = afiliado.Poliza;
            this.txtPatente.Text = afiliado.Patente;
            this.txtAno.Text = afiliado.Año;
            this.txtMarca.Text = afiliado.Marca;
            this.txtColor.Text = afiliado.Color;
            this.txtFechaDesde.Text = this.GetDateText(afiliado.FechaDesde);
            this.txtFechaHasta.Text = this.GetDateText(afiliado.FechaHasta);
            this.ddlCategoria.SelectedValue = afiliado.Categoria;
            this.chkHogar.Checked = afiliado.Hogar;
            this.txtModelo.Text = afiliado.Modelo;
            this.chkEstado.Checked = afiliado.Estado;

        }

        private void ResetControl()
        {

        }

        private void AssignTextToControls()
        {
            
            // Labels
            this.lblID.Text = Resource.LBL_AFILIADO_ID + Resource.LBL_SEPARADOR;
            this.lblNombre.Text = Resource.LBL_AFILIADO_NOMBRE + Resource.LBL_SEPARADOR;
            this.lblApellido.Text = Resource.LBL_AFILIADO_APELLIDO + Resource.LBL_SEPARADOR;
            this.lblDireccion.Text = Resource.LBL_AFILIADO_DIRECCION + Resource.LBL_SEPARADOR;
            this.lblEmpresa.Text = Resource.LBL_AFIILIADO_EMPRESA + Resource.LBL_SEPARADOR;
            this.lblCodigoPostal.Text = Resource.LBL_AFILIADO_CODIGO_POSTAL + Resource.LBL_SEPARADOR;
            this.lblColor.Text = Resource.LBL_AFILIADO_COLOR + Resource.LBL_SEPARADOR;
            this.lblPatente.Text = Resource.LBL_AFILIAFO_PATENTE + Resource.LBL_SEPARADOR;
            this.lblAño.Text = Resource.LBL_AFILIADO_ANO + Resource.LBL_SEPARADOR;
            this.lblMarca.Text = Resource.LBL_AFILIADO_MARCA + Resource.LBL_SEPARADOR;
            this.lblPoliza.Text = Resource.LBL_AFILIADO_POLIZA + Resource.LBL_SEPARADOR;
            this.lblFechaaHasta.Text = Resource.LBL_AFILIADO_FECHA_HASTA + Resource.LBL_SEPARADOR;
            this.lblFechaDesde.Text = Resource.LBL_AFILIADO_FECHA_DESDE + Resource.LBL_SEPARADOR;
            this.lblDocumento.Text = Resource.LBL_AFILIADO_DOCUMENTO + Resource.LBL_SEPARADOR;
            this.lblCategoria.Text = Resource.LBL_AFILIADO_CATEGORIA + Resource.LBL_SEPARADOR;
            this.lblModelo.Text = Resource.LBL_AFILIADO_MODELO + Resource.LBL_SEPARADOR;
            this.chkHogar.Text = Resource.LBL_AFILIADO_HOGAR;

            // Botones.
            this.btnAceptar.Text = Resource.BTN_ACEPTAR;
            this.btnCancelar.Text = Resource.BTN_CANCELAR;

            // Secciones
            this.lblSeccionPersonal.Text = Resource.TXT_SECCION_PERSONAL;
            this.lblSeccionPoliza.Text = Resource.TXT_SECCION_POLIZA;
            this.lblSeccionVehiculo.Text = Resource.TXT_SESSION_VEHICULO;

            // Validadoes
            this.rfvNombre.ErrorMessage = String.Format(Resource.ERR_REQUEST_FIELD, Resource.LBL_AFILIADO_NOMBRE);
            this.rfvApellido.ErrorMessage = String.Format(Resource.ERR_REQUEST_FIELD, Resource.LBL_AFILIADO_APELLIDO);
            this.rfvPatente.ErrorMessage = String.Format(Resource.ERR_REQUEST_FIELD, Resource.LBL_AFILIAFO_PATENTE);
            this.cmvEmpresa.ErrorMessage = String.Format(Resource.ERR_REQUEST_COMBO, Resource.LBL_AFIILIADO_EMPRESA);
            this.revAño.ErrorMessage = String.Format(Resource.ERR_FORMATO_AÑO, Resource.LBL_AFILIADO_ANO);
            this.cmvCategorias.ErrorMessage = String.Format(Resource.ERR_REQUEST_COMBO, Resource.LBL_AFILIADO_CATEGORIA);
            this.cmvPolizaExiste.ErrorMessage = Resource.ERR_POLIZA_EXISTENTE;

        }

        #endregion Metodos

        #region Eventos

        protected void btnAceptar_Click(object sender, EventArgs e)
        {


            if (this.MyPage.IsGroupValid("vgAfiliadoCtrl"))
            {

                Afiliado afiliado = this.GetAfiliadoFromControls();
                if (afiliado.Persist())
                {
                    this.AceptarEvent.Invoke(true);
                }
                else
                {
                    this.AceptarEvent.Invoke(false);
                }

                this.ResetControl();
            }
            

            
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
         
            this.ResetControl();
            this.CancelarEvent.Invoke();

        }

        protected void cmvEmpresa_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value != Classes.Views.COMBO_ELIJA_OPCION;
        }

        protected void cmvCategorias_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = args.Value != Classes.Views.COMBO_ELIJA_OPCION;
        }

        #endregion Eventos

        protected void cmvPolizaExiste_Unload(object sender, EventArgs e)
        {
                
        }

        protected void cmvPolizaExiste_ServerValidate(object source, ServerValidateEventArgs args)
        {
            String poliza = args.Value;
            Afiliado afiliado = Afiliado.GetAfiliadoByPoliza(poliza);
            args.IsValid = afiliado == null || (!this.IsNewEntity && afiliado.ID == this.EntityID);

        }


    }
}
