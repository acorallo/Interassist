using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.InterAsisst;


namespace UI.InterAssist.Usercontrols
{
    public partial class AfiliadoDetallo : System.Web.UI.UserControl
    {

        #region Constantes

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros

        private int _idAfiliado;


        #endregion Miembros

        #region Propiedades

        public int IdAfiliado
        {
            get { return _idAfiliado; }
            set { _idAfiliado = value; }
        }


        #endregion Propiedades

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.AssignTextToControls();
                this.IncializaControles();
            }
            
        }

        private void AssignTextToControls()
        {
            // Labels
            this.lblId.Text = Resource.LBL_AFILIADO_ID + Resource.LBL_SEPARADOR;
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
            this.lblFechaHasta.Text = Resource.LBL_AFILIADO_FECHA_HASTA + Resource.LBL_SEPARADOR;
            this.lblFechaDesde.Text = Resource.LBL_AFILIADO_FECHA_DESDE + Resource.LBL_SEPARADOR;
            this.lblDocumento.Text = Resource.LBL_AFILIADO_DOCUMENTO + Resource.LBL_SEPARADOR;
            this.lblCategoria.Text = Resource.LBL_AFILIADO_CATEGORIA + Resource.LBL_SEPARADOR;
            this.lblHogar.Text = Resource.LBL_AFILIADO_HOGAR + Resource.LBL_SEPARADOR;
            this.lblModelo.Text = Resource.LBL_AFILIADO_MODELO + Resource.LBL_SEPARADOR;

            // Secciones.
            this.lblDatosPersonales.Text = Resource.TXT_SECCION_PERSONAL;
            this.lblDatosPoliza.Text = Resource.TXT_SECCION_POLIZA;
            this.lblDatosVehiculo.Text = Resource.TXT_SESSION_VEHICULO;

            


        }

        private void IncializaControles()
        {
            Afiliado a = Afiliado.GetById(this.IdAfiliado);

            if(a!=null)
            {
               //this.
                this.lbltxtId.Text = a.ID.ToString();
                this.lblTxtDocumento.Text = a.Documento;
                this.lbltxtNombre.Text = a.Nombre;
                this.lbltxtApellido.Text = a.Apellido;
                this.lbltxtDireccion.Text = a.Direccion;
                this.lbltxtCodigoPostal.Text = a.CodigoPostal;
                this.lbltxtEmpresa.Text = a.NombreEmpresa;
                this.lbltxtCategoria.Text = a.NombreCategoria;
                this.lbltxtPoliza.Text = a.Poliza;
                this.lbltxtPatente.Text = a.Patente;
                this.lbltxtFechaDesde.Text = a.FechaDesde.ToShortDateString();
                this.lbltxtFechaHasta.Text = a.FechaHasta.ToShortDateString();
                this.lbltxtaño.Text = a.Año;
                this.lbltxtColor.Text = a.Color;
                this.lbltxtMarca.Text = a.Marca;
                this.lblTxtHogar.Text = a.Hogar ? "SI" : "NO";
                this.lblTxtModelo.Text = a.Modelo;

            }
        }

        #endregion Metodos


    }
}