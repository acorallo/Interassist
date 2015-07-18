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
    public partial class UpLoadErrors : Classes.Views
    {

        #region Enum

        private enum ColumnasListado
        {
            ID_ERROR_TYPE,
            FILELINE,
            INFORMATION,
            ERROR_DESCRIPCTION
        }

        #endregion Enum

        #region Properties

        public override string ViewName
        {
            get { return Classes.Views.UPLOAD_ERRORS_VIEW; }
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
            get { return Resource.SECTION_DETALLES_UPLOADS; }
        }

        public FiltroUploadError Filtro
        {
            get
            {
                if (this.ViewState[VIEW_STATE_FILTRO] == null)
                    this.ViewState.Add(VIEW_STATE_FILTRO, new FiltroUploadError());
                return (FiltroUploadError)this.ViewState[VIEW_STATE_FILTRO];

            }
            set
            {
                this.ViewState.Add(VIEW_STATE_FILTRO, value);
            }
        }


        #endregion Properties

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

        public void AssigntTextToControles()
        {
            // Columns 
            this.dtgUploads.Columns[(int)ColumnasListado.ID_ERROR_TYPE].HeaderText = Resource.LBL_UPDATE_ERROR_DESCRIPCION;
            this.dtgUploads.Columns[(int)ColumnasListado.FILELINE].HeaderText = Resource.LBL_UPDATE_ERROR_FILELINE;
            this.dtgUploads.Columns[(int)ColumnasListado.INFORMATION].HeaderText = Resource.LBL_UPDATE_ERROR_INFORMACION;
            this.dtgUploads.Columns[(int)ColumnasListado.ERROR_DESCRIPCTION].HeaderText = Resource.LBL_UPDATE_ERROR_DESCRIPCION;

            // Labers.
            this.lblNombreArhivo.Text = Resource.LBL_UPLOAD_NOMBRE_ARCHIVO + Resource.LBL_SEPARADOR;
            this.lblFileLines.Text = Resource.LBL_UDDATE_REG_TOTAL + Resource.LBL_SEPARADOR;
            this.lblFNFecha.Text = Resource.LBL_UPLOAD_FN_FECHA + Resource.LBL_SEPARADOR;
            this.lblSTFecha.Text = Resource.LBL_UPLOAD_ST_FECHA + Resource.LBL_SEPARADOR;

            this.lblInsetedLine.Text = Resource.LBL_UPDATE_INSERTED + Resource.LBL_SEPARADOR;
            this.lblUpdateLine.Text = Resource.LBL_UPDATE_UPDATED + Resource.LBL_SEPARADOR;
            this.lblDeletedLine.Text = Resource.LBL_UPDATE_DELETED + Resource.LBL_SEPARADOR;
            this.lblLineErrors.Text = Resource.LBL_UPDATE_REC_ERR + Resource.LBL_SEPARADOR;
            this.lblLinesProc.Text = Resource.LBL_UPDATE_PROCESSED + Resource.LBL_SEPARADOR;

            this.lblDetalles.Text = Resource.LBL_UPDATE_DETALLES;
            this.lblErrors.Text = Resource.LBL_UPDATE_ERRORES;

            this.bt_volverUp.Text = Resource.BTN_VOLVER;
            this.bt_volverDown.Text = Resource.BTN_VOLVER;

   
        }

        public void InicializaControles()
        {
            Upload upLoad = Upload.GetById(Classes.SessionHelper.ID_UPLOAD);
            this.SetUpdateInControls(upLoad);

            if (upLoad.CantErrores > 0)
            {
                this.txtEstados.CssClass = "UpdateFailLink";
                
                this.dtgUploads.DataSource = upLoad.Errors;
                this.dtgUploads.DataBind();
                this.txtTotalErrores.Text = String.Format(Resource.LBL_TOTAL_ERRORS, upLoad.Errors.Count.ToString());
                this.txtTotalErrores.Visible = true;

            }else
            {
                this.txtEstados.CssClass = "UpdateHitLink";
                this.txtTotalErrores.Visible = false;
            }

           
        }

        public void SetUpdateInControls(Upload upLoad)
        {
            this.txtEmpresa.Text = upLoad.Empresa_Nombre;
            this.txtFecha.Text = upLoad.Fecha != null ? upLoad.Fecha.Value.ToShortDateString() : string.Empty;
            this.txtEstados.Text = upLoad.CantErrores == 0 ? Resource.LBL_UPLOAD_HIT : Resource.LBL_UPLOAD_FAIL;

            this.txtFileLines.Text = upLoad.Total_Lines.ToString();
            this.txtLineErrors.Text = upLoad.Line_Errors.ToString();
            this.txtLineProc.Text = upLoad.Line_Proceses.ToString();
            this.txtSTFecha.Text = upLoad.Start_Date.ToString();
            this.txtFNFecha.Text = upLoad.End_Date.ToString();

            this.txtUpdateLine.Text = upLoad.Updated_Rcd.ToString();
            this.txtInsetedLine.Text = upLoad.Inserted_Rcd.ToString();
            this.txtDeletedLine.Text = upLoad.Deleted_Rcd.ToString();
            this.txtNombreArchivo.Text = upLoad.FileName;

            // Alineamiento de las columnas
            this.dtgUploads.Columns[(int)ColumnasListado.ID_ERROR_TYPE].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            this.dtgUploads.Columns[(int)ColumnasListado.FILELINE].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            this.dtgUploads.Columns[(int)ColumnasListado.INFORMATION].ItemStyle.HorizontalAlign = HorizontalAlign.Left;
            this.dtgUploads.Columns[(int)ColumnasListado.ERROR_DESCRIPCTION].ItemStyle.HorizontalAlign = HorizontalAlign.Left;


        }



        private void ShowList(bool value)
        {
            this.divNonResult.Visible = !value;
            this.divGrid.Visible = value;
            this.divCantregistros.Visible = value;
        }

        #endregion Metodos

        #region Events

        protected void dtgUploads_ItemCommand(object source, DataGridCommandEventArgs e)
        {

        }

        protected void dtgUploads_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entities.InterAsisst.UploadError uploadError = (Entities.InterAsisst.UploadError)e.Item.DataItem;

                e.Item.Cells[(int)ColumnasListado.ID_ERROR_TYPE].Text = uploadError.IDErrorType.ToString();
                e.Item.Cells[(int)ColumnasListado.FILELINE].Text = uploadError.LineaArchivo.ToString();
                e.Item.Cells[(int)ColumnasListado.INFORMATION].Text = uploadError.Informacion.ToString();
                e.Item.Cells[(int)ColumnasListado.ERROR_DESCRIPCTION].Text = uploadError.ErrorDescrition.ToString();
            }
        }

        protected void dtgUploads_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {

        }

        protected void dtgUploads_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void bt_volverUp_Click(object sender, EventArgs e)
        {
            this.GoBackView();
        }

        #endregion Events

    }
}