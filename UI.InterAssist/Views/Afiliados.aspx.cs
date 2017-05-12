using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Utils.InterAssist;
using Entities.InterAsisst;
using UI.InterAssist.Interfaces;
using Cognitas.Framework.Repository;
using System.Web.Services;


namespace UI.InterAssist.Views
{
    public partial class Afiliados : Classes.Views
    {

        #region Constantes

        private const string COMMNAD_MODIF_AFILIADO = "cmdModifAfiliado";
        private const string COMMAND_NUEVO_CASO = "cmdNuevoCaso";

        #endregion Constantes

        #region Enumeradores

        private enum ColumnasListado
        {
            ID = 0,
            Nombre,
            Apellido,
            Documento,
            Empresa,
            Poliza,
            Categoria,
            Patente,
            Marca,
            Modificar,
            NuevoCaso,
            Prueba_Casos
        }



        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros

        #endregion Miembros

        #region Propiedades

        protected override bool ReqAdmin
        {
            get { return false; }
        }

        protected override bool ReqLogin
        {
            get { return true; }
        }

        public override string Seccion
        {
            get { return Resource.SECCION_ADM_AFILIADOS; }
        }

        public FiltroAfiliado Filtro
        {
            get
            {
                if (this.ViewState[VIEW_STATE_FILTRO] == null)
                    this.ViewState.Add(VIEW_STATE_FILTRO, new FiltroAfiliado());
                return (FiltroAfiliado)this.ViewState[VIEW_STATE_FILTRO];

            }
            set
            {
                this.ViewState.Add(VIEW_STATE_FILTRO, value);
            }
        }

        public override string ViewName
        {
            get { return Classes.Views.AFILIADO_VIEW; }
        }
   
        #endregion Propiedades

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!this.IsPostBack)
            {
                this.AssigntTextToControles();
                this.InicializaControles();
            }
        }

        private void InicializaControles()
        {
            this.dtgAfiliados.PageSize = PAGE_SIZE;
            this.CargarListado(this.Filtro, 1);
        }

        List<Entities.InterAsisst.Afiliado> getListado(FiltroAfiliado filtro, out int totalRegistros)
        {
            List<Entities.InterAsisst.Afiliado> listaAfiliados = null;

            if (this.rdbFindPatente.Checked)
            {
                filtro.Patente = filtro.Search;
                listaAfiliados = Afiliado.ListByPatente(filtro, out totalRegistros);
            }
            else
                listaAfiliados = Afiliado.List(filtro, out totalRegistros);

            return listaAfiliados;
        }

        public void CargarListado(FiltroAfiliado filtro, int pageNumber)
        {
            int totalRegistros;

            filtro.PageSize = PAGE_SIZE;
            filtro.IsPaged = true;
            filtro.StartRow = ((pageNumber - 1) * PAGE_SIZE) + 1;

            List<Entities.InterAsisst.Afiliado> listaAfiliados = getListado((FiltroAfiliado)filtro, out totalRegistros);

            this.Filtro.FiltredRowsQtty = totalRegistros;

            this.ShowList(totalRegistros > 0);
            this.lbltxtCantidadRegistros.Text = totalRegistros.ToString();

            this.dtgAfiliados.CurrentPageIndex = pageNumber - 1;
            this.dtgAfiliados.VirtualItemCount = totalRegistros;
            this.dtgAfiliados.DataSource = listaAfiliados;
            this.dtgAfiliados.DataBind();


        }

        private void AssigntTextToControles()
        {
            this.divListado.Visible = false;
            // Columnas del listado
            this.dtgAfiliados.Columns[(int)ColumnasListado.ID].HeaderText = Resource.LBL_AFILIADO_ID;
            this.dtgAfiliados.Columns[(int)ColumnasListado.Nombre].HeaderText = Resource.LBL_AFILIADO_NOMBRE;
            this.dtgAfiliados.Columns[(int)ColumnasListado.Apellido].HeaderText = Resource.LBL_AFILIADO_APELLIDO;
            this.dtgAfiliados.Columns[(int)ColumnasListado.Documento].HeaderText = Resource.LBL_AFILIADO_DOCUMENTO;
            this.dtgAfiliados.Columns[(int)ColumnasListado.Empresa].HeaderText = Resource.LBL_AFIILIADO_EMPRESA;
            this.dtgAfiliados.Columns[(int)ColumnasListado.Poliza].HeaderText = Resource.LBL_AFILIADO_POLIZA;
            this.dtgAfiliados.Columns[(int)ColumnasListado.Patente].HeaderText = Resource.LBL_AFILIAFO_PATENTE;
            this.dtgAfiliados.Columns[(int)ColumnasListado.Marca].HeaderText = Resource.LBL_AFILIADO_MARCA;
            this.dtgAfiliados.Columns[(int)ColumnasListado.Categoria].HeaderText = Resource.LBL_AFILIADO_CATEGORIA;
            ((ButtonColumn)this.dtgAfiliados.Columns[(int)ColumnasListado.Modificar]).Text = Resource.BTN_GRID_MODIFICAR;
            ((ButtonColumn)this.dtgAfiliados.Columns[(int)ColumnasListado.Modificar]).CommandName = COMMNAD_MODIF_AFILIADO;
            ((ButtonColumn)this.dtgAfiliados.Columns[(int)ColumnasListado.NuevoCaso]).Text = Resource.LBL_AFILIADO_NUEVO_CASO;
            ((ButtonColumn)this.dtgAfiliados.Columns[(int)ColumnasListado.NuevoCaso]).CommandName = COMMAND_NUEVO_CASO;



            // Botones de la página.
            this.btnCrearNUevo.Text = Resource.BTN_CREAR_AFILIADO;
            this.btnBuscar.Text = Resource.BTN_BUSCAR;
            this.btnFreeSeacrh.Text = Resource.BTN_FREE_SEARCH;


            this.lblNonResults.Text = Resource.TXT_NON_RESULTS;

            this.lblCantRegistros.Text = Resource.TXT_RECORD_COUNT + Resource.LBL_SEPARADOR;
            
            // Validaciones de seguridad
            this.dtgAfiliados.Columns[(int)ColumnasListado.Modificar].Visible = this.SessionOperador.Admin;

            // Alineamiento de las columnas
            this.dtgAfiliados.Columns[(int)ColumnasListado.ID].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            this.dtgAfiliados.Columns[(int)ColumnasListado.Documento].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            this.dtgAfiliados.Columns[(int)ColumnasListado.Modificar].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            this.dtgAfiliados.Columns[(int)ColumnasListado.NuevoCaso].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            this.dtgAfiliados.Columns[(int)ColumnasListado.Patente].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            this.dtgAfiliados.Columns[(int)ColumnasListado.NuevoCaso].ItemStyle.Wrap = false;
            this.dtgAfiliados.Columns[(int)ColumnasListado.Modificar].ItemStyle.Wrap = false;


            this.WdoInformacionCasos.Title = Resource.TXT_INFORMACION_CASOS;
            this.btnContinuarCaso.Text = Resource.LBL_AFILIADO_NUEVO_CASO;
            this.chkAceptarInfoCasos.BoxLabel = Resource.TXT_INFO_CASOS_DISCLAMER;
        }

        private void ShowList(bool value)
        {
            this.divNonResult.Visible = !value;
            this.divGrid.Visible = value;
            this.divCantregistros.Visible = value;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
           
            this.Filtro.Search = this.txtSearch.Text.Trim();
            this.CargarListado(this.Filtro, 1);
            this.divListado.Visible = true;
        }

        protected void btnFreeSeacrh_Click(object sender, EventArgs e)
        {
            this.txtSearch.Text = string.Empty;
            this.Filtro.Reset();
            this.CargarListado(this.Filtro, 1);
            this.divListado.Visible = false;
        }

        private void ModificarAfiliado(string id)
        {
            Classes.SessionHelper.ID_AFILIADO = Int32.Parse(id);
            this.goView(Classes.Views.AFILIADO_MODIF_VIEW);
        }

        private void NuevoCaso(string id)
        {
            Classes.SessionHelper.ID_CASO_AFILIADO = Int32.Parse(id);
            Classes.SessionHelper.ID_CASO = Classes.SessionHelper.DEFAULT_ID;


            //this.goView(Classes.Views.CASO_MODIF);
        }

        protected void gdvAfiliados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case COMMNAD_MODIF_AFILIADO:
                    this.ModificarAfiliado(e.CommandArgument.ToString());
                    break;

            }
        }  
        
        #endregion Metodos

        #region Eventos

        protected void btnCrearNUevo_Click(object sender, EventArgs e)
        {
            Classes.SessionHelper.ID_AFILIADO = Classes.SessionHelper.DEFAULT_ID;
            this.goView(Classes.Views.AFILIADO_MODIF_VIEW);
        }

        protected void dtgAfiliados_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case COMMNAD_MODIF_AFILIADO:
                    this.ModificarAfiliado(e.CommandArgument.ToString());
                    break;
                case COMMAND_NUEVO_CASO:
                    this.NuevoCaso(e.CommandArgument.ToString());
                    break;

            }
        }

        protected void dtgAfiliados_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entities.InterAsisst.Afiliado afiliado = (Entities.InterAsisst.Afiliado)e.Item.DataItem;

                e.Item.Cells[(int)ColumnasListado.ID].Text = afiliado.ID.ToString();
                e.Item.Cells[(int)ColumnasListado.Nombre].Text = afiliado.Nombre;
                e.Item.Cells[(int)ColumnasListado.Apellido].Text = afiliado.Apellido;
                e.Item.Cells[(int)ColumnasListado.Documento].Text = afiliado.Documento;
                e.Item.Cells[(int)ColumnasListado.Empresa].Text = afiliado.NombreEmpresa;
                e.Item.Cells[(int)ColumnasListado.Poliza].Text = afiliado.Poliza;
                //e.Item.Cells[(int)ColumnasListado.Poliza].Attributes.Add("onClick", "javascript:contarCasos(event,'" + afiliado.Poliza + "');");
                //e.Item.Cells[(int)ColumnasListado.Poliza].Attributes.Add("onMouseout", "javascript:OcultarContador();");
                //e.Item.Cells[(int)ColumnasListado.Poliza].Attributes.Add("class", "style_Count");
                e.Item.Cells[(int)ColumnasListado.Patente].Text = afiliado.Patente;
                e.Item.Cells[(int)ColumnasListado.Marca].Text = afiliado.Marca;
                e.Item.Cells[(int)ColumnasListado.Categoria].Text = afiliado.NombreCategoria;
                ((LinkButton)e.Item.Cells[(int)ColumnasListado.Modificar].Controls[0]).CommandArgument = afiliado.ID.ToString();
                ((LinkButton)e.Item.Cells[(int)ColumnasListado.NuevoCaso].Controls[0]).CommandArgument = afiliado.ID.ToString();
                ((LinkButton)e.Item.Cells[(int)ColumnasListado.NuevoCaso].Controls[0]).Enabled = afiliado.Estado;
                
                if (afiliado.Estado)
                    ((LinkButton)e.Item.Cells[(int)ColumnasListado.NuevoCaso].Controls[0]).Attributes.Add("OnClick", "verificarCaso('" + afiliado.Poliza.ToString() + "','" + afiliado.ID.ToString() + "')");
                
                // Si el afiliado esta activo se permite el crear un nuevo caso.
                if (!afiliado.Estado)
                {
                    e.Item.Cells[(int)ColumnasListado.NuevoCaso].ToolTip = Resource.TXT_TOOL_TIP_AFILIADO_NO_ACTIVO;
                }
                
            }
        }
        
        protected void dtgAfiliados_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void dtgAfiliados_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            int a = e.NewPageIndex;
            this.CargarListado(this.Filtro, a+1);
        }

        [WebMethod]
        public static ContadorCasos getCasos(string Poliza)
        {

            int mesCorriente = System.DateTime.Now.Month;
            int annoCorriente = System.DateTime.Now.Year;

            ContadorCasos c = ContadorCasos.getContadorCasos(mesCorriente, annoCorriente, Poliza);


            return c;
        }

        [Ext.Net.DirectMethod]
        public void VerificarCasos(string Poliza, string idAfiliado)
        {
            this.ResetVerificarCasos();
            this.WdoInformacionCasos.Hidden = false;
            this.WdoInformacionCasos.ShowModal();
            this.VerifcacionCasos.LoadAfiliado(Int32.Parse(idAfiliado));
        }


        public void ResetVerificarCasos()
        {
            this.chkAceptarInfoCasos.Checked = false;
            this.btnContinuarCaso.Disabled = true;
        }

        protected void ContinuarCaso(object sender, Ext.Net.DirectEventArgs e)
        {
            this.goView(Classes.Views.CASO_MODIF);
        }

        #endregion Eventos
    }
}