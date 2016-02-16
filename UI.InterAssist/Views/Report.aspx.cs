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
using System.Configuration;

namespace UI.InterAssist.Views
{
    public partial class Report : Classes.Views
    {

        #region Constantes

        private const string ERR_CMV_REPORTE = "Error desconocido al intentar generar el reporte";
        private const string FileName = "ReporteCasos";
        private const string FileExtension = "csv";


        private const string MSG_NON_RECORDS = "No hay resgistros para mostrar";

        #endregion Constantes

        #region Propiedades

        protected override bool ReqLogin
        {
            get { return true; }
        }

        protected override bool ReqAdmin
        {
            get { return true; }
        }

        public override string ViewName
        {
            get {return Classes.Views.REPORTES_VIEW ; }
        }

        public override string Seccion
        {
            get { return Resource.SECCION_REPORTES; }
        }

        #endregion Propiedades

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
               if(!this.IsPostBack)
               {
                   this.AssignTextControles();
                   this.InitControls();
               }
        }


        private void AssignTextControles()
        {

            // Labels

            string txtFechaDesde = "Fecha Desde";
            string txtFechaHasta = "Fecha Hasta";
            string txtDelimidador = "Delimitador";

            string txtDelimiter_coma = "Coma Simple (,)";
            string txtDelimiter_punto_y_Coma = "Punto y Coma (;)";

            this.lblFechaDesde.Text = txtFechaDesde + Resource.LBL_SEPARADOR;
            this.lblFechaHasta.Text = txtFechaHasta + Resource.LBL_SEPARADOR;
            this.lblDelimitador.Text = txtDelimidador + Resource.LBL_SEPARADOR;

            this.RdbComa.Text = txtDelimiter_coma;
            this.rdbPuntaComa.Text = txtDelimiter_punto_y_Coma;
            
            // Botones
            this.btnGenerarReporte.Text = "Generar Reporte";

            // validadores
            this.rfvFechaDesde.ErrorMessage = string.Format(Resource.ERR_REQUEST_FIELD, txtFechaDesde);
            this.rfvFechaHasta.ErrorMessage = string.Format(Resource.ERR_REQUEST_FIELD, txtFechaHasta);
            this.cmvFechaDesde.ErrorMessage = string.Format(Resource.ERR_GENERIC_CMB, txtFechaDesde);
            this.cmvFechaHasta.ErrorMessage = string.Format(Resource.ERR_GENERIC_CMB, txtFechaHasta);
            this.cmvRerport.ErrorMessage = ERR_CMV_REPORTE;

            this.lblOutMsg.Text = string.Empty;

        }

        private void InitControls()
        {
            this.txtFechaDesde.Text = string.Empty;

        }



        #endregion Metods

        #region Eventos

        protected void cmvFechaDesde_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.ValidateDate(args.Value);
        }

        protected void cmvFechaHasta_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.ValidateDate(args.Value);
        }

        private bool ValidateDate(string date)
        {
            bool result = false;
            DateTime tparse;

            result = DateTime.TryParse(date, out tparse);

            return result;
        }

        private void ClearControls()
        {
            this.txtFechaDesde.Text = String.Empty;
            this.txtFechaHasta.Text = string.Empty;
        }


        private string SubZero(int valor)
        {
            string result = valor.ToString();
            if (valor < 10)
                result = "0" + result;            

            return result;
            
    
        }

        private string DateAsInteger(DateTime date)
        {
            string result = string.Empty;

            result = date.Year.ToString() + SubZero(date.Month) + SubZero(date.Day);

            return result;
        }

        public string GetFileName(DateTime dtStart, DateTime dtEnd)
        {
            string result = string.Empty;

            result = FileName + "_" + DateAsInteger(dtStart) + "_" + DateAsInteger(dtEnd) + "." + FileExtension;
 
            return result;
        }

        
        public string getDelimiter()
        {
            string result = ";";

            if (this.RdbComa.Checked)
                result = ",";

            return result;
                
        }

        #endregion Eventos

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {

                try
                {
                    DateTime fechaDesde = DateTime.MinValue;
                    DateTime fechaHasta = DateTime.MaxValue;


                    if(this.txtFechaDesde.Text.Trim()!=string.Empty)
                        DateTime.TryParse(this.txtFechaDesde.Text.Trim(), out fechaDesde);

                    if(this.txtFechaHasta.Text.Trim()!=string.Empty)
                        DateTime.TryParse(this.txtFechaHasta.Text.Trim(), out fechaHasta);


                    DataTable dtReporte = ReporteCasos.GetReporteCasos(fechaDesde, fechaHasta);

                    if (dtReporte.Rows.Count > 0)
                    {
                        this.ClearControls();
                        HtmlStreamAdapter h = new HtmlStreamAdapter(GetFileName(fechaDesde, fechaHasta), this.Response);
                        ReporteCasos.ExportToCsv(dtReporte, this.getDelimiter(), true, h);
                        Response.End();
                    }else
                    {
                        this.lblOutMsg.Text = MSG_NON_RECORDS;
                    }
                
                }
                catch (System.Exception ex)
                {   
                    this.cmvRerport.IsValid = false;
                }
            }
        }

    }
}