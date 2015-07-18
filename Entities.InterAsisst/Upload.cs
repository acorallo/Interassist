using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository.Interfaces;
using Cognitas.Framework.Repository;
using DAL.InterAssist.Datasets;
using DAL.InterAssist;
using System.Data;
using Utils.InterAssist;


namespace Entities.InterAsisst
{
    public class Upload
    {
        #region Members

        private List<UploadError> _errors = null;
        public int CantErrores { get; set; }
        public Int64 IDUpload { get; set; }
        public DateTime? Fecha { get; set; }
        public string FileName { get; set; }
        public string FileHash { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public int Total_Lines { get; set; }
        public int Line_Proceses { get; set; }
        public int Line_Errors { get; set; }
        public string Descripcion {get; set; }
        public int IDFileType { get; set; }
        public int Inserted_Rcd { get; set; }
        public int Updated_Rcd { get; set; }
        public int Deleted_Rcd { get; set; }
        public int? IDEmpresa { get; set; }
        public string Empresa_Nombre { get; set; }

        public List<UploadError> Errors
        {
            get
            {   
                if(this.IDUpload != -1)
                {
                    if(this._errors == null)
                    {
                        this._errors = UploadError.List(this.IDUpload);
                    }
                }
            
                return this._errors;
            }
        }

        #endregion Members

        #region Metodos

        public Upload()
        {
            this.IDUpload = -1;
        }

        public static void ORM(Upload o, DataRow r)
        {

            try
            {

                o.CantErrores = Int32.Parse((r[UploaDS.COLUMN_CANT_ERRORS].ToString()));
                o.IDUpload = Int64.Parse(r[UploaDS.COLUMN_IDUPLOAD].ToString());
                
                o.Fecha = null; 

                if (r[UploaDS.COLUMN_DATETIME] != DBNull.Value)
                    o.Fecha = (DateTime)r[UploaDS.COLUMN_DATETIME];
                
                o.FileName = r[UploaDS.COLUMN_FILENAME].ToString();
                o.FileHash = r[UploaDS.COLUMN_FILEHASH].ToString();

                o.Start_Date = null;

                if (r[UploaDS.COLUMN_ST_DATETIME] != DBNull.Value)
                    o.Start_Date = (DateTime)r[UploaDS.COLUMN_ST_DATETIME];

                o.End_Date = null;

                if (r[UploaDS.COLUMN_FN_DATETIME] != DBNull.Value)
                    o.End_Date = (DateTime)r[UploaDS.COLUMN_FN_DATETIME];

                
                
                o.Total_Lines = Int32.Parse((r[UploaDS.COLUMN_TOTAL_LINES].ToString()));
                o.Line_Proceses = Int32.Parse((r[UploaDS.COLUMN_LINE_PROCESSES].ToString()));
                o.Line_Errors = Int32.Parse((r[UploaDS.COLUMN_LINE_ERRORS].ToString()));
                o.Descripcion = r[UploaDS.COLUMN_DESCRIPTION].ToString();
                o.Inserted_Rcd = Int32.Parse((r[UploaDS.COLUMN_INSERTED_RCD].ToString()));
                o.Updated_Rcd = Int32.Parse((r[UploaDS.COLUMN_UPDATED_RCD].ToString()));
                o.Deleted_Rcd = Int32.Parse((r[UploaDS.COLUMN_DELETED_RCD].ToString()));
                
                o.IDEmpresa = null;
                
                if (r[UploaDS.COLUMN_IDEMPRESA] != DBNull.Value)
                    o.IDEmpresa = Int32.Parse((r[UploaDS.COLUMN_IDEMPRESA].ToString()));
                
                o.Empresa_Nombre = r[UploaDS.COLUMN_EMPRESA_NOMBRE].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static Upload GetById(int id)
        {
            Upload Result = null;

            try
            {
                UploaDS DS = new UploaDS();
                String objectHash = Guid.NewGuid().ToString();
                DataRow dr = DS.GetObjectById(id, objectHash);

                if (dr != null)
                {
                    Result = new Upload();
                    ORM(Result, dr);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }


        public static List<Upload> List(FiltroUpload f, out int RecordCount)
        {
            List<Upload> resultList = new List<Upload>();

            try
            {
                UploaDS dataservice = new UploaDS();
                DataSet ds = dataservice.List(f, out RecordCount);

                if (ds.Tables.Count > 0)
                
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Upload a = new Upload();
                        ORM(a, r);
                        resultList.Add(a);
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultList;
        }

        #endregion Metodos


    }
}
