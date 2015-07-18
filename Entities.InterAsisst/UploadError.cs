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
    public class UploadError
    {
        #region Propiedades

        public int IDUploadError { get; set; }
        public int IDUpload { get; set; }
        public int IDErrorType { get; set; }
        public int? LineaArchivo { get; set; }
        public string Informacion { get; set; }
        public string ErrorDescrition { get; set; }

        public static void ORM(UploadError o, DataRow r)
        {
            try
            {
                o.IDUploadError = Int32.Parse(r[UploadErrorDS.COLUMN_IDUPLOADERROR].ToString());
                o.IDUpload = Int32.Parse(r[UploadErrorDS.COLUMN_IDUPLOADERROR].ToString());
                o.IDErrorType = Int32.Parse(r[UploadErrorDS.COLUMN_IDERRORTYPE].ToString());

                o.LineaArchivo = null;
                if(r[UploadErrorDS.COLUMN_FILELINE] != DBNull.Value)
                    o.LineaArchivo = Int32.Parse(r[UploadErrorDS.COLUMN_FILELINE].ToString());

                o.Informacion = r[UploadErrorDS.COLUMN_INFORMATION].ToString();
                o.ErrorDescrition = r[UploadErrorDS.COLUMN_ERROR_DESCRIPTION].ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static UploadError GetById(int id)
        {
            UploadError Result = null;

            try
            {
                UploadErrorDS DS = new UploadErrorDS();
                String objectHash = Guid.NewGuid().ToString();
                DataRow dr = DS.GetObjectById(id, objectHash);

                if (dr != null)
                {
                    Result = new UploadError();
                    ORM(Result, dr);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }


        public static List<UploadError> List(Int64 idUpload)
        {
            List<UploadError> resultList = new List<UploadError>();
            
            int rCount = 0;
            FiltroUploadError f = new FiltroUploadError();
            f.ID_UPLOAD = idUpload;
            try
            {
                UploadErrorDS dataservice = new UploadErrorDS();
                DataSet ds = dataservice.List(f, out rCount);

                if (ds.Tables.Count > 0)

                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        UploadError a = new UploadError();
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
           

        public static List<UploadError> List(FiltroUpload f, out int RecordCount)
        {
            List<UploadError> resultList = new List<UploadError>();

            try
            {
                UploadErrorDS dataservice = new UploadErrorDS();
                DataSet ds = dataservice.List(f, out RecordCount);

                if (ds.Tables.Count > 0)

                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        UploadError a = new UploadError();
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

        #endregion Propiedades
    }
}
