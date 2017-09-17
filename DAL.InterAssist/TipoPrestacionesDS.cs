using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cognitas.Framework.Repository;
using Utils.InterAssist;

namespace DAL.InterAssist
{
    public class TipoPrestacionesDS : Dataservices
    {
        #region Constantes


        private const string CONST_GET_BY_ID_PROCEDURE_NAME = "TIPOPRESTACIONES_PKG.GET_TIPOPRESTACION_BY_ID";
        private const string CONST_LIST_PROCEDURE_NAME = "TIPOPRESTACIONES_PKG.LIST_TIPOPRESTACION";

        public const string COLUMN_IDTIPOPRESTACION = "IDTIPOPRESTACION";
        public const string COLUMN_CODIGO = "CODIGO";
        public const string COLUMN_DESCRIPCION = "DESCRIPCION";

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
            return new Datasets.TipoPrestaciones.TIPOPRESTACIONESDataTable();
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
                FiltroTipoPrestacion filtro = (FiltroTipoPrestacion)f;

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
