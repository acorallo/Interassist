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
    public partial class Prestadorctrl : System.Web.UI.UserControl
    {

        #region Constantes

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros

        private int _idPrestador = -1;


        #endregion Miembros

        #region Propiedades

        public int IdPrestador
        {
            get { return _idPrestador; }
            set { _idPrestador = value; }
        }

        #endregion Propiedades

        #region Metodos


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.AssignTextToControls();
                this.InicilalizaControles();
            }

                
        }

        public void Reiniciar()
        {
            this.lbltxtId.Text = string.Empty;
            this.LbTxtlNombre.Text = string.Empty;
            this.lbltxtDescripcion.Text = string.Empty;
            this.lblTxtEstador.Text = string.Empty;
            this.lbltxtTelefono1.Text = string.Empty;
            this.lbltxtTelefono2.Text = string.Empty;
            this.lblTxtCeluar1.Text = string.Empty;
            this.lblTxtCeluar2.Text = string.Empty;
            this.lblTxtNextel.Text = string.Empty;
            this.lbltxtDomicilio.Text = string.Empty;
            this.lblTxtCiudad.Text = string.Empty;
            this.lblTxtPais.Text = string.Empty;
            this.lbltxtProvincia.Text = string.Empty;
            this.lblTxtEmail.Text = string.Empty;
            this.lbltxtCuit.Text = string.Empty;
            this.lblLivMovida.Text = string.Empty;
            this.lblLivkm.Text = string.Empty;

            this.lblSp1Movida.Text = string.Empty;
            this.lblSp1Km.Text = string.Empty;

            this.lblSp2Movida.Text = string.Empty;
            this.lblSp2Km.Text = string.Empty;

            this.lblPs1Movida.Text = string.Empty;
            this.lblPs1km.Text = string.Empty;

            this.lblps2Movida.Text = string.Empty;
            this.lblps2Km.Text = string.Empty;


        }

        public void CargarPrestador(int idPrestador)
        {
            this.IdPrestador = idPrestador;

            if (this.IdPrestador != -1)
            {
                Prestador p = Prestador.GetById(this.IdPrestador);
                if (p != null)
                {
                    this.lbltxtId.Text = p.ID.ToString();
                    this.LbTxtlNombre.Text = p.Nombre;
                    this.lbltxtDescripcion.Text = p.Descripcion;
                    this.lblTxtEstador.Text = p.Activo.ToString();
                    this.lbltxtTelefono1.Text = p.Telefono1;
                    this.lbltxtTelefono2.Text = p.Telefono2;
                    this.lblTxtCeluar1.Text = p.Celular1;
                    this.lblTxtCeluar2.Text = p.Celular2;
                    this.lblTxtNextel.Text = p.Nextel;
                    this.lbltxtDomicilio.Text = p.Domicilio;
                    this.lblTxtCiudad.Text = p.NombreCiudad;
                    this.lblTxtPais.Text = p.NombrePais;
                    this.lbltxtProvincia.Text = p.ProvinciaNombre;
                    this.lblTxtEmail.Text = p.Email;
                    this.lbltxtCuit.Text = p.Cuit;
                    this.lbltxtLocalidad.Text = p.LocalidadNombre;

                    // Tarifas
                    this.lblLivMovida.Text = TarifaToText(p.LIV_MOVIDA);
                    this.lblLivkm.Text = TarifaToText(p.LIV_KM);

                    this.lblSp1Movida.Text = TarifaToText(p.SP1_MOVIDA);
                    this.lblSp1Km.Text = TarifaToText(p.SP1_KM);

                    this.lblSp2Movida.Text = TarifaToText(p.SP2_MOVIDA);
                    this.lblSp2Km.Text = TarifaToText(p.SP2_KM);

                    this.lblPs1Movida.Text = TarifaToText(p.PS1_MOVIDA);
                    this.lblPs1km.Text = TarifaToText(p.PS1_KM);

                    this.lblps2Movida.Text = TarifaToText(p.PS2_MOVIDA);
                    this.lblps2Km.Text = TarifaToText(p.PS2_KM);

                }
            }
        }

        private string TarifaToText(Nullable<float> t)
        {
            string result = Resource.TXT_VALOR_NO_DISPONIBLE;

            if(t!=null)
                result = t.ToString();

            return result;

        }

        private void InicilalizaControles()
        {
            this.CargarPrestador(this.IdPrestador);


        }

        private void AssignTextToControls()
        {

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
            this.lblCiudad.Text = Resource.LBL_PRESTADOR_CIUDAD + Resource.LBL_SEPARADOR;
            this.lblPais.Text = Resource.LBL_PRESTADOR_PAIS + Resource.LBL_SEPARADOR;
            this.lblProvincia.Text = Resource.LBL_PRESTADOR_PROVINCIA + Resource.LBL_SEPARADOR;
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
            this.lblLocalidad.Text = Resource.LBL_PRESTADOR_LOCALIDAD + Resource.LBL_SEPARADOR;
        }


        #endregion Metodos
    }
}