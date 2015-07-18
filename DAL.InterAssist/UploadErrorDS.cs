using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;
using Utils.InterAssist;
using System.Data;

namespace DAL.InterAssist
{
    public class UploadErrorDS : Dataservices
    {

        #region Contantes

        private const string CONST_GET_BY_ID_PROCEDURE_NAME = "UPLOAD_UI_PKG.GET_UPLOAD_ERROR_BY_ID";
        private const string CONST_LIST_PROCEDURE_NAME = "UPLOAD_UI_PKG.LIST_UPLOAD_ERROR";

        public static readonly string COLUMN_IDUPLOADERROR = "IDUPLOADERROR";       
        public static readonly string COLUMN_IDUPLOAD = "IDUPLOAD";              
        public static readonly string COLUMN_IDERRORTYPE = "IDERRORTYPE";                 
        public static readonly string COLUMN_FILELINE = "FILELINE";                
        public static readonly string COLUMN_INFORMATION = "INFORMATION";
        public static readonly string COLUMN_ERROR_DESCRIPTION = "ERROR_DESCRIPTION";

        #endregion Constantes

        #region Properties

        public override string GET_BY_ID_PROCEDURE_NAME
        {
            get { return CONST_GET_BY_ID_PROCEDURE_NAME; }
        }

        public override string GET_DELETE_PROCEDURE_NAME
        {
            get { throw new NotImplementedException(); }
        }



        #endregion Properties

        #region Metodos

        public override DataSet List(Filter f, out int RecordCount)
        {
            DataSet ds = new DataSet();

            try
            {
                FiltroUploadError filtro = (FiltroUploadError)f;

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                DBRepository repository = DBRepository.GetDbRepository();

                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, filtro.ID));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_UPLOAD", DbType.String, filtro.ID_UPLOAD));


                bool result = repository.ExecuteListProcedure(CONST_LIST_PROCEDURE_NAME, paramList, f, ds, out RecordCount);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        public override DataTable getMyTable()
        {
            throw new NotImplementedException();
        }

        public override int Create(DataRow r)
        {
            throw new NotImplementedException();
        }

        public override bool Update(DataRow r)
        {
            throw new NotImplementedException();
        }

        #endregion Metodos

    }

}
