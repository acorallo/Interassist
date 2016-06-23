using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Entities.InterAsisst;
using System.Data;


namespace UI.InterAssist
{
    public partial class Grid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.Cargar_CmbPaisFiltroPrestador();
                this.AssignTextToControls();

            }

            if (!this.IsPostBack)
            {
                
            }


        }

        private void AssignTextToControls()
        {
            this.QPrest_Detalles_Cuit.FieldLabel = Resource.LBL_PRESTADOR_CIUT;
            this.QPrest_Detalles_iva.FieldLabel = Resource.LBL_PRESTADOR_IVA;
            this.QPrest_Detalles_Id.FieldLabel = Resource.LBL_PRESTADOR_ID;
            this.QPrest_Detalles_Activo.FieldLabel = Resource.LBL_PRESTADOR_ESTADO;

        }

        private void Cargar_CmbPaisFiltroPrestador()
        {

            int DefaultPais = 1;

            var dataTablepaises = Pais.List();
            this.Pais_PrestadorBusquedaAvanzada.DataSource = dataTablepaises;
            this.Pais_PrestadorBusquedaAvanzada.DataBind();
            this.cmbPaisFiltroPrestador.SelectedItem.Value = DefaultPais.ToString();
            this.Cargar_cmbProvinciaFiltroPrestador(DefaultPais);
        }

        private void Cargar_cmbProvinciaFiltroPrestador(int id)
        {
            this.Provincia_PrestadorBusquedaAvanzada.DataSource = UI.InterAssist.Views.services.GetProvincias(id);
            this.Provincia_PrestadorBusquedaAvanzada.DataBind();
        }
        

        protected void BeforeExpand(object sender, DirectEventArgs e)
        {
            e.ExtraParamsResponse["content"] = string.Format("<span class=\"template\">Company: {0}, Row �: {1}, Server Date: {2}</span>", e.ExtraParams["company"], e.ExtraParams["index"], DateTime.Now.ToString());
        }

        protected void IniciarBusqueda_DirectClick(object sender, DirectEventArgs e)
        {
            string value = string.Empty;
            Utils.InterAssist.FiltroPrestador f = new Utils.InterAssist.FiltroPrestador();
            f.Search = value;

            BuscarPrestador(f);
        }

        protected void BusquedaSimplificada_DirectClick(object sender, DirectEventArgs e)
        {
            string value = txtBusquedaSimple.Text.Trim();

            Utils.InterAssist.FiltroPrestador f = new Utils.InterAssist.FiltroPrestador();
            f.Search = value;

            BuscarPrestador(f);
            
            
        }


        private void BuscarPrestador(Utils.InterAssist.FiltroPrestador f)
        {
            List<Modelviews.PrestadorModelView> listaPrestadores = Modelviews.PrestadorModelView.getPrestadorModelView(Entities.InterAsisst.Prestador.List(f));
            StorePrestadoresBusquedaAvanzada.DataSource = listaPrestadores;
            StorePrestadoresBusquedaAvanzada.DataBind();
        }
            
    }
}