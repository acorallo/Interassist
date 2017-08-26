using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cognitas.Framework.Repository;
using Utils.InterAssist;

namespace DAL.InterAssist
{
    public class ColoresDS : Dataservices
    {
        #region Constantes


        private const string CONST_GET_BY_ID_PROCEDURE_NAME = "COLORES_PKG.GET_COLOR_BY_ID";
        private const string CONST_LIST_PROCEDURE_NAME = "COLORES_PKG.LIST_COLOR";

        public const string COLUMN_IDCOLOR = "IDCOLOR";
        public const string COLUMN_NOMBRE = "NOMBRE";

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros

        #endregion Miembros

        #region Propiedades

        public override System.Data.DataTable getMyTable()
        {
            return new Datasets.Colores.COLORESDataTable();
        }

        public override string GET_BY_ID_PROCEDURE_NAME
        {
            get { return CONST_GET_BY_ID_PROCEDURE_NAME; }
        }

        public override string GET_DELETE_PROCEDURE_NAME
        {
            get { throw new NotImplementedException(); }
        }

        #endregion Propiedades

        #region Metodos

        public override bool Update(System.Data.DataRow r)
        {
            throw new NotImplementedException();
        }

        public override int Create(System.Data.DataRow r)
        {
            throw new NotImplementedException();
        }

        public override System.Data.DataSet List(Filter f, out int RecordCount)
        {
            DataSet ds = new DataSet();

            try
            {
                FiltroColores filtro = (FiltroColores)f;

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                DBRepository repository = DBRepository.GetDbRepository();

                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, filtro.ID));


                bool result = repository.ExecuteListProcedure(CONST_LIST_PROCEDURE_NAME, paramList, f, ds, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        #endregion Metodos
    }
}
