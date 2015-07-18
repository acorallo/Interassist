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
    public partial class Uploads : Classes.Views
    {

        #region Constantes 

        private const string COMMNAD_VIEW_DETALLES = "cmdDetalles";

        #endregion Constantes

        #region Enumeradores

        private enum ColumnasListado
        {
            ID = 0,
            Estado,
            Cant_Errores,
            Empresa,
            Fecha,
            NombreArchivo,
            Registos,
            ST_Fecha,
            FN_Fecha

            
        }

        #endregion Enumeradores

        #region Propiedades

        public override string ViewName
        {
            get { return Classes.Views.UPLOAD_VIEW; }
        }

        protected override bool ReqAdmin
        {
            get { return true; }
        }

        protected override bool ReqLogin
        {
            get { return true; }
        }

        public override string Seccion
        {
            get { return Resource.SECTION_ADM_UPLOADS; }
        }

        public FiltroUpload Filtro
        {
            get
            {
                if (this.ViewState[VIEW_STATE_FILTRO] == null)
                    this.ViewState.Add(VIEW_STATE_FILTRO, new FiltroUpload());
                return (FiltroUpload)this.ViewState[VIEW_STATE_FILTRO];

            }
            set
            {
                this.ViewState.Add(VIEW_STATE_FILTRO, value);
            }
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

        private void AssigntTextToControles()
        {


            // Columnas del listado
            this.dtgUploads.Columns[(int)ColumnasListado.ID].HeaderText = Resource.LBL_UPLOAD_ID;
            this.dtgUploads.Columns[(int)ColumnasListado.Estado].HeaderText = Resource.LBL_UPLOAD_ESTADO;
            this.dtgUploads.Columns[(int)ColumnasListado.Cant_Errores].HeaderText = Resource.LBL_UPLOAD_CANT_ERRORES;
            this.dtgUploads.Columns[(int)ColumnasListado.Empresa].HeaderText = Resource.LBL_UPLOAD_EMPRESA;
            this.dtgUploads.Columns[(int)ColumnasListado.Fecha].HeaderText = Resource.LBL_UPLOAD_FECHA;
            this.dtgUploads.Columns[(int)ColumnasListado.NombreArchivo].HeaderText = Resource.LBL_UPLOAD_NOMBRE_ARCHIVO;
            this.dtgUploads.Columns[(int)ColumnasListado.Registos].HeaderText = Resource.LBL_UPLOAD_REGISTROS;
            this.dtgUploads.Columns[(int)ColumnasListado.ST_Fecha].HeaderText = Resource.LBL_UPLOAD_ST_FECHA;
            this.dtgUploads.Columns[(int)ColumnasListado.FN_Fecha].HeaderText = Resource.LBL_UPLOAD_FN_FECHA;

            // Botones de la página.
            this.btnBuscar.Text = Resource.BTN_BUSCAR;
            this.btnFreeSeacrh.Text = Resource.BTN_FREE_SEARCH;


            this.lblNonResults.Text = Resource.TXT_NON_RESULTS;

            this.lblCantRegistros.Text = Resource.TXT_RECORD_COUNT + Resource.LBL_SEPARADOR;


            // Alineamiento de las columnas
            this.dtgUploads.Columns[(int)ColumnasListado.ID].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            this.dtgUploads.Columns[(int)ColumnasListado.Estado].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            this.dtgUploads.Columns[(int)ColumnasListado.Cant_Errores].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            this.dtgUploads.Columns[(int)ColumnasListado.Empresa].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            this.dtgUploads.Columns[(int)ColumnasListado.Fecha].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            this.dtgUploads.Columns[(int)ColumnasListado.NombreArchivo].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            this.dtgUploads.Columns[(int)ColumnasListado.Registos].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            this.dtgUploads.Columns[(int)ColumnasListado.ST_Fecha].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            this.dtgUploads.Columns[(int)ColumnasListado.FN_Fecha].ItemStyle.HorizontalAlign = HorizontalAlign.Center;


            ((ButtonColumn)this.dtgUploads.Columns[(int)ColumnasListado.Estado]).CommandName = COMMNAD_VIEW_DETALLES;

            this.lnkHuerfanos.Text = Resource.TXT_VER_HUERFANOS;

        }

        private void InicializaControles()
        {
            
            this.dtgUploads.PageSize = PAGE_SIZE;
            this.CargarListado(this.Filtro, 1);
             

        }

        public void CargarListado(FiltroUpload filtro, int pageNumber)
        {
            
            int totalRegistros;

            filtro.PageSize = PAGE_SIZE;
            filtro.IsPaged = true;
            filtro.StartRow = ((pageNumber - 1) * PAGE_SIZE) + 1;

            List<Entities.InterAsisst.Upload> listaAfiliados = Upload.List(filtro, out totalRegistros);

            this.Filtro.FiltredRowsQtty = totalRegistros;

            this.ShowList(totalRegistros > 0);
            this.lbltxtCantidadRegistros.Text = totalRegistros.ToString();

            this.dtgUploads.CurrentPageIndex = pageNumber - 1;
            this.dtgUploads.VirtualItemCount = totalRegistros;
            this.dtgUploads.DataSource = listaAfiliados;
            this.dtgUploads.DataBind();

            this.lnkHuerfanos.NavigateUrl = Classes.Views.AFILIADOS_UNSYNC;
           
            
        }

        private void ShowList(bool value)
        {
            this.divNonResult.Visible = !value;
            this.divGrid.Visible = value;
            this.divCantregistros.Visible = value;
        }

        #endregion Metodos

        #region Eventos

        protected void dtgUploads_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entities.InterAsisst.Upload upload = (Entities.InterAsisst.Upload)e.Item.DataItem;

 
                e.Item.Cells[(int)ColumnasListado.ID].Text = upload.IDUpload.ToString();
                //e.Item.Cells[(int)ColumnasListado.Estado].Text = upload.E;
                e.Item.Cells[(int)ColumnasListado.Cant_Errores].Text = upload.CantErrores.ToString();
                e.Item.Cells[(int)ColumnasListado.Empresa].Text = upload.Empresa_Nombre;
                e.Item.Cells[(int)ColumnasListado.Fecha].Text = upload.Fecha.HasValue ? upload.Fecha.Value.ToShortDateString() : string.Empty;
                e.Item.Cells[(int)ColumnasListado.NombreArchivo].Text = upload.FileName;
                e.Item.Cells[(int)ColumnasListado.Registos].Text = upload.Total_Lines.ToString();
                e.Item.Cells[(int)ColumnasListado.ST_Fecha].Text = upload.Start_Date.ToString();
                e.Item.Cells[(int)ColumnasListado.FN_Fecha].Text = upload.End_Date.ToString();


                LinkButton lnk_estado = (LinkButton)e.Item.Cells[(int)ColumnasListado.Estado].Controls[0];
                lnk_estado.CommandArgument = upload.IDUpload.ToString();

                // Asigna el estados
                if (upload.CantErrores > 0)
                {
                    // Fail
                    lnk_estado.Text = Resource.LBL_UPLOAD_FAIL;
                    lnk_estado.CssClass = "UpdateFailLink";
                    e.Item.CssClass = "UpdateFailBg";
                }
                else
                {
                    // Hit
                    lnk_estado.Text = Resource.LBL_UPLOAD_HIT;
                    lnk_estado.CssClass = "UpdateHitLink";
                    e.Item.CssClass = "UpdateHitBg";
                }
           

            }
        }

        protected void dtgUploads_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            int a = e.NewPageIndex;
            this.CargarListado(this.Filtro, a + 1);
        }

        protected void dtgUploads_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {   
            this.Filtro.Search = this.txtSearch.Text.Trim();
            this.CargarListado(this.Filtro, 1);
        }

        protected void btnFreeSeacrh_Click(object sender, EventArgs e)
        {
            this.txtSearch.Text = string.Empty;
            this.Filtro.Reset();
            this.CargarListado(this.Filtro, 1);
        }

        private void VerDetalles(string id)
        {
            Classes.SessionHelper.ID_UPLOAD = Int32.Parse(id);
            this.goView(Classes.Views.UPLOAD_ERRORS_VIEW);
        }

        protected void dtgUploads_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == COMMNAD_VIEW_DETALLES)
            {
                this.VerDetalles(e.CommandArgument.ToString());
            }
        }


        #endregion Eventos
    }
}