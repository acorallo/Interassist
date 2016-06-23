using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.InterAssist.Usercontrols
{
    public partial class PrestadorView : System.Web.UI.UserControl
    {
        Entities.InterAsisst.Prestador p = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                this.InicializaComponentes();
                this.AssignTextToControls();
                
            }
        }

    

        private void InicializaComponentes()
        {
            
        }

        private void AssignTextToControls()
        {
            this.Separador_Direccion.Text = " - ";

            this.TxtEmailPrestador.FieldLabel = Resource.LBL_PRESTADOR_EMAIL;
            this.TxtNextelPrestador.FieldLabel = Resource.LBL_PRESTADOR_NEXT_TEX;
            this.TxtTelefonoPrestador.FieldLabel = Resource.LBL_PRESTADOR_TELEFONO1;
            this.TxtTelefono2Prestador.FieldLabel = Resource.LBL_PRESTADOR_TELEFONO2;
            this.TxtCelularPrestador.FieldLabel = Resource.LBL_PRESTADOR_CELULAR;
            this.TxtCelular2Prestador.FieldLabel = Resource.LBL_PRESTADOR_CELULAR2;
        }

        public bool LoadPrestador(int idPrestador)
        {

            bool result = false;
        
            p = Entities.InterAsisst.Prestador.GetById(idPrestador);
            {
                if (p != null)
                {
                    SetPrestadorIncontrols(p);
                    result = true;
                }
                else
                    result = false;
            }
           

            return result;
        }

        private void SetPrestadorIncontrols(Entities.InterAsisst.Prestador p)
        {
            this.lblNombreProveedor.Text = p.Nombre.ToUpper();
            this.lblDireccion.Text = p.Domicilio;
            this.lblLocalidad_Prestadores.Text = p.LocalidadNombre;


            if (p.Domicilio.Trim() != string.Empty)
                this.lblDireccion.Text = p.Domicilio;
            else
                this.lblDireccion.Text = Resource.TXT_SIN_DIRECCION;


            this.lblProvincia_Prestador.Text = "Provincia de " + p.ProvinciaNombre;
            this.lblPais_Prestador.Text = p.NombrePais;
            this.lblCiudad_Prestador.Text = p.NombreCiudad;
            this.TxtDetallePrestador.Text = p.Descripcion;
            
            this.TxtEmailPrestador.Text = p.Email;
            this.TxtNextelPrestador.Text = p.Nextel;
            this.TxtTelefonoPrestador.Text = p.Telefono1;
            this.TxtTelefono2Prestador.Text = p.Telefono2;
            this.TxtCelularPrestador.Text = p.Celular1;
            this.TxtCelular2Prestador.Text = p.Celular2;
           
            this.txtLivMovida.Text = p.LIV_MOVIDA.ToString();
            this.txtLivKm.Text = p.LIV_KM.ToString();

            this.txtSp1Movida.Text = p.SP1_MOVIDA.ToString();
            this.txtSp1Km.Text = p.SP1_KM.ToString();

            this.txtSp2Movida.Text = p.SP2_MOVIDA.ToString();
            this.txtSp2Km.Text = p.SP2_KM.ToString();

            this.txtPs1Movida.Text = p.PS1_MOVIDA.ToString();
            this.txtPs1Km.Text = p.PS1_KM.ToString();

            this.txtPs2Movida.Text = p.PS1_MOVIDA.ToString();
            this.txtPs2Km.Text = p.PS2_KM.ToString();

            this.lblMovida.Text = Resource.LBL_PRESTADOR_MOVIDA;
            this.lblkm.Text = Resource.LBL_PRESTADOR_KM;
            this.lblLiv.Text = Resource.LBL_PRESTADOR_LIV;
            this.lblSp1.Text = Resource.LBL_PRESTADOR_SP1;
            this.lblSp2.Text = Resource.LBL_PRESTADOR_SP2;
            this.lblps1.Text = Resource.LBL_PRESTADOR_PS1;
            this.lblPs2.Text = Resource.LBL_PRESTADOR_PS2;
           
        }

        public void ClearPrestador()
        {

        }

    }
}