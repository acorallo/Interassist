using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;
using Utils.InterAssist;
using System.Data;

namespace DAL.InterAssist
{
    public class UploaDS : Dataservices
    {

        #region Constantes

        private const string CONST_GET_BY_ID_PROCEDURE_NAME = "UPLOAD_UI_PKG.GET_UPLOAD_BY_ID";
        private const string CONST_LIST_PROCEDURE_NAME = "UPLOAD_UI_PKG.LIST_UPLOAD";
            
        // Columns 
        public static readonly string COLUMN_CANT_ERRORS = "CANT_ERRORS";
        public static readonly string COLUMN_IDUPLOAD = "IDUPLOAD";
        public static readonly string COLUMN_DATETIME = "DATETIME";
        public static readonly string COLUMN_FILENAME = "FILENAME";
        public static readonly string COLUMN_FILEHASH = "FILEHASH";
        public static readonly string COLUMN_ST_DATETIME = "ST_DATETIME";
        public static readonly string COLUMN_FN_DATETIME = "FN_DATETIME";
        public static readonly string COLUMN_TOTAL_LINES = "TOTAL_LINES";
        public static readonly string COLUMN_LINE_PROCESSES = "LINE_PROCESSES";
        public static readonly string COLUMN_LINE_ERRORS = "LINE_ERRORS";
        public static readonly string COLUMN_DESCRIPTION = "DESCRIPTION";
        public static readonly string COLUMN_IDFILETYPE = "IDFILETYPE";
        public static readonly string COLUMN_INSERTED_RCD = "INSERTED_RCD";
        public static readonly string COLUMN_UPDATED_RCD = "UPDATED_RCD";
        public static readonly string COLUMN_DELETED_RCD = "DELETED_RCD";
        public static readonly string COLUMN_IDEMPRESA = "IDEMPRESA";
        public static readonly string COLUMN_EMPRESA_NOMBRE = "EMPRESA_NOMBRE";
    
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
                FiltroUpload filtro = (FiltroUpload)f;

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                DBRepository repository = DBRepository.GetDbRepository();

                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, filtro.ID));
                paramList.Add(repository.DbFactory.getDataParameter("P_SEARCH", DbType.String, filtro.Search));


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
