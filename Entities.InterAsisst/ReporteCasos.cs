using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using DAL.InterAssist;
using Excel = Microsoft.Office.Interop.Excel;
using System.Configuration;

namespace Entities.InterAsisst
{
    public class ReporteCasos : IAReports
    {


        #region Properties

        public static string Random_Key()
        {
            return Path.GetRandomFileName().Replace(".", "");
        }
        
        

        private static Excel.Application _excel;

        public static Excel.Application oExcel
        {
            get
            {
                if (_excel == null)
                    _excel = new Excel.Application();
                return _excel;
            }
        }

        #endregion Properties

        #region Constants

        // Columnas del listado
        public static readonly string COL_CARDINAL = "CARDINAL";
        public static readonly string COL_IDTICKET = "IDTICKET";
        public static readonly string COL_FECHA = "FECHA";
        public static readonly string COL_HORA = "HORA";
        public static readonly string COL_EMPRESA = "EMPRESA";
        public static readonly string COL_CATEGORIA = "CATEGORIA";
        public static readonly string COL_POLIZA = "POLIZA";
        public static readonly string COL_NOMBRE_AFILIADO = "NOMBRE_AFILIADO";
        public static readonly string COL_MARCA_MODELO = "MARCA_MODELO";
        public static readonly string COL_PATENTE = "PATENTE";
        public static readonly string COL_ANO = "ANO";
        public static readonly string COL_PAIS_ORIGEN = "PAIS_ORIGEN";
        public static readonly string COL_PROVINCIA_ORIGEN = "PROVINCIA_ORIGEN";
        public static readonly string COL_CIUDAD_ORIGEN = "CIUDAD_ORIGEN";
        public static readonly string COL_LOCALIDAD_ORIGEN = "LOCALIDAD_ORIGEN";
        public static readonly string COL_CALLE_ORIGEN = "CALLE_ORIGEN";
        public static readonly string COL_PAIS_DESTINO = "PAIS_DESTINO";
        public static readonly string COL_PROVINCIA_DESTINO = "PROVINCIA_DESTINO";
        public static readonly string COL_CIUDAD_DESTINO = "CIUDAD_DESTINO";
        public static readonly string COL_LOCALIDAD_DESTINO = "LOCALIDAD_DESTINO";
        public static readonly string COL_CALLE_DESTINO = "CALLE_DESTINO";
        public static readonly string COL_PROBLEMA = "PROBLEMA";
        public static readonly string COL_TIPO_CASO = "TIPO_CASO";
        public static readonly string COL_KILOMETROS = "KILOMETROS";
        public static readonly string COL_IDPRESTADOR = "IDPRESTADOR";
        public static readonly string COL_NOMBRE_PRESTADOR = "NOMBRE_PRESTADOR";
        public static readonly string COL_TIPO_SERVICIO = "TIPO_SERVICIO";
        public static readonly string COL_OPERADOR = "OPERADOR";

        #endregion Constants


        #region Metodos

        public static DataTable GetReporteCasos(DateTime fechaDesde, DateTime fechaHasta)
        {
            ReportesDS ds = new ReportesDS();
            return ds.GetReporteCasos(fechaDesde, fechaHasta);
        }


        public static void ExportToCsv(DataTable dtReport, string delimiter, bool hearder, HtmlStreamAdapter streamAdp)
        {
           
            if (hearder)
            {
                StringBuilder stHeader = new StringBuilder();
                foreach (DataColumn col in dtReport.Columns)
                {

                    string columnName = col.ToString();
                    stHeader.Append(delimiter);
                    stHeader.Append(columnName);
                    
                }

                string headerLine = stHeader.ToString().Substring(1);
                streamAdp.WriteLine(headerLine);
            }

           
            foreach (DataRow r in dtReport.Rows)
            {

                StringBuilder stRow = new StringBuilder();
                foreach (DataColumn col in dtReport.Columns)
                {
                    //appExcel.Cells[i, j] = r[j - 1].ToString();
                    stRow.Append(delimiter);
                    stRow.Append(r[col.ColumnName].ToString().Replace(delimiter, " ").Replace("\n", " "));
                }

                string strRow = stRow.ToString().Substring(1);
                streamAdp.WriteLine(strRow);
                
            }
        }
        /*
        public static void ExportToExcel(DataTable dtReport)
        {
            try
            {
                Excel.Application appExcel = oExcel;
                appExcel.Workbooks.Add();
              

                // Construye los headers.
                
                int i = 1;
                foreach(DataColumn col in dtReport.Columns)
                {
                    string columnName = col.ToString();
                    appExcel.Cells[1, i] = columnName;
                    i++;
                    
                }


                i = 2;
                foreach (DataRow r in dtReport.Rows)
                {
                    int j = 1;
                    foreach (DataColumn col in dtReport.Columns)
                    {
                        j++;
                    }

                    i++;
                }

                Excel._Worksheet workSheet = appExcel.ActiveSheet;
                string excelFile = ConfigurationSettings.AppSettings["Report_Path"] + Random_Key() + ".xlsx";
                workSheet.Name = "Casos";
                workSheet.SaveAs(excelFile);
                oExcel.Quit();
                
                
                
            }
            catch (Exception ex)
            {
            
                throw ex;
            
        }
        */
        #endregion Metodos


    }
}
