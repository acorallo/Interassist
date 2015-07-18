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

namespace UI.InterAssist.Views
{
    public partial class Prestador : Classes.Views
    {
        #region Constantes

        private const string COMMAND_MODIFICAR_PRESTADOR = "cmd_modificar_prestador";


        #endregion Constantes

        #region Enumeradores

        private enum ColumnasPrestador
        {
            Id = 0,
            Nombre,
            Pais,
            Provincia,
            Ciudad,
            Localidad,
            Domicilio,
            Telefono1,
            Modificar

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
            get { return Resource.SECCION_ADM_PRESTADORES; }
        }


        public override string ViewName
        {
            get { return Classes.Views.PRESTADOR_VIEW; }
        }

        public FiltroPrestador Filtro
        {
            get
            {
                if (this.ViewState[VIEW_STATE_FILTRO] == null)
                    this.ViewState.Add(VIEW_STATE_FILTRO, new FiltroPrestador());
                return (FiltroPrestador)this.ViewState[VIEW_STATE_FILTRO];

            }
            set
            {
                this.ViewState.Add(VIEW_STATE_FILTRO, value);
            }
        }

        private void ModificarPrestador(string idPrestador)
        {
            Classes.SessionHelper.ID_PRESTADOR = Int32.Parse(idPrestador);
            this.goView(Classes.Views.PRESTADOR_MODIF_VIEW);
        }


        #endregion Propiedades

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!this.IsPostBack)
            {
                this.AssigTextToControl();
                this.InicializaControladores();
            }
        }

        private void AssigTextToControl()
        {

            // Columnas del listado
            // Columnas del listado del Prestadore
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Id].HeaderText = Resource.LBL_PRESTADOR_ID;
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Nombre].HeaderText = Resource.LBL_PRESTADOR_NOMBRE;
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Pais].HeaderText = Resource.LBL_PRESTADOR_PAIS;
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Provincia].HeaderText = Resource.LBL_PRESTADOR_PROVINCIA;
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Ciudad].HeaderText = Resource.LBL_PRESTADOR_CIUDAD;
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Localidad].HeaderText = Resource.LBL_PRESTADOR_LOCALIDAD;
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Domicilio].HeaderText = Resource.LBL_PRESTADOR_DOMICILIO;
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Telefono1].HeaderText = Resource.LBL_PRESTADOR_TELEFONO1;
            ((ButtonColumn)this.dtgPrestador.Columns[(int)ColumnasPrestador.Modificar]).Text = Resource.BTN_GRID_MODIFICAR;
            ((ButtonColumn)this.dtgPrestador.Columns[(int)ColumnasPrestador.Modificar]).CommandName = COMMAND_MODIFICAR_PRESTADOR;
            

            // Botones de la página.
            this.btnCrearNUevo.Text = Resource.BTN_CREAR_NUEVO_PRESTADOR;
            this.btnBuscar.Text = Resource.BTN_BUSCAR;
            this.btnFreeSeacrh.Text = Resource.BTN_FREE_SEARCH;


            this.lblNonResults.Text = Resource.TXT_NON_RESULTS;

            this.lblCantRegistros.Text = Resource.TXT_RECORD_COUNT + Resource.LBL_SEPARADOR;

            // Alineamiento de las columnas
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Id].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Modificar].ItemStyle.HorizontalAlign = HorizontalAlign.Center;


        }

        private void InicializaControladores()
        {
            this.dtgPrestador.PageSize = PAGE_SIZE;
            this.CargarListado(this.Filtro, 1);
        }

        public void CargarListado(FiltroPrestador filtro, int pageNumber)
        {
            int totalRegistros;

            filtro.PageSize = PAGE_SIZE;
            filtro.IsPaged = true;
            filtro.StartRow = ((pageNumber - 1) * PAGE_SIZE) + 1;

            List<Entities.InterAsisst.Prestador> listaAfiliados = Entities.InterAsisst.Prestador.List((FiltroPrestador)filtro, out totalRegistros);

            this.Filtro.FiltredRowsQtty = totalRegistros;

            this.ShowList(totalRegistros > 0);
            this.lbltxtCantidadRegistros.Text = totalRegistros.ToString();

            this.dtgPrestador.CurrentPageIndex = pageNumber - 1;
            this.dtgPrestador.VirtualItemCount = totalRegistros;
            this.dtgPrestador.DataSource = listaAfiliados;
            this.dtgPrestador.DataBind();
        }

        private void ShowList(bool value)
        {
            this.divNonResult.Visible = !value;
            this.divGrid.Visible = value;
            this.divCantregistros.Visible = value;
        }

        #endregion Metodos

        #region Eventos

        protected void btnFreeSeacrh_Click(object sender, EventArgs e)
        {

            this.txtSearch.Text = string.Empty;
            this.Filtro.Reset();
            this.CargarListado(this.Filtro, 1);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Filtro.Search = this.txtSearch.Text.Trim();
            this.CargarListado(this.Filtro, 1);
        }

        protected void btnCrearNUevo_Click(object sender, EventArgs e)
        {
            Classes.SessionHelper.ID_PRESTADOR = Classes.SessionHelper.DEFAULT_ID;
            this.goView(Classes.Views.PRESTADOR_MODIF_VIEW);
        }

        

        protected void dtgPrestador_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entities.InterAsisst.Prestador p = (Entities.InterAsisst.Prestador)e.Item.DataItem;

                e.Item.Cells[(int)ColumnasPrestador.Id].Text = p.ID.ToString();
                e.Item.Cells[(int)ColumnasPrestador.Pais].Text = p.NombrePais;
                e.Item.Cells[(int)ColumnasPrestador.Provincia].Text = p.ProvinciaNombre;
                e.Item.Cells[(int)ColumnasPrestador.Ciudad].Text = p.NombreCiudad;
                e.Item.Cells[(int)ColumnasPrestador.Localidad].Text = p.LocalidadNombre;
                e.Item.Cells[(int)ColumnasPrestador.Nombre].Text = p.Nombre;
                e.Item.Cells[(int)ColumnasPrestador.Domicilio].Text = p.Domicilio;
                e.Item.Cells[(int)ColumnasPrestador.Telefono1].Text = p.Telefono1;
                ((LinkButton)e.Item.Cells[(int)ColumnasPrestador.Modificar].Controls[0]).CommandArgument = p.ID.ToString();
                


            }
        }

        protected void dtgPrestador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dtgPrestador_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            int a = e.NewPageIndex;
            this.CargarListado(this.Filtro, a + 1);
        }

        protected void dtgPrestador_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case COMMAND_MODIFICAR_PRESTADOR:
                    this.ModificarPrestador(e.CommandArgument.ToString());
                    break;

            }
        }

        #endregion Eventos

    }
}