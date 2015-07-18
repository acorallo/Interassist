using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cognitas.Framework.Repository;
using Utils.InterAssist;

namespace DAL.InterAssist
{
    public class CiudadDS : Dataservices
    {

        #region Constantes

        private const string CONST_LIST_PROCEDURE_NAME = "CIUDAD_PKG.LIST_CIUDAD";

        public const string COLUMN_ID_CIUDAD = "IDCIUDAD";
        public const string COLUMN_ID_PAIS = "IDPAIS";
        public const string COLUMN_ID_PROVINCIA = "IDPROVINCIA";
        public const string COLUMN_NOMBRE = "NOMBRE";
        

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros

        #endregion Miembros

        #region Propiedades

        

        public override string GET_BY_ID_PROCEDURE_NAME
        {
            get { throw new NotImplementedException(); }
        }

        public override string GET_DELETE_PROCEDURE_NAME
        {
            get { throw new NotImplementedException(); }
        }

        #endregion Propiedades

        #region Metodos

        public override DataSet List(Filter f, out int RecordCount)
        {
            DataSet ds = new DataSet();

            try
            {
                FiltroCiudad filtro = (FiltroCiudad)f;

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                DBRepository repository = DBRepository.GetDbRepository();

                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, filtro.ID));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPAIS", DbType.Int32, filtro.IDPais));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPROVINCIA", DbType.Int32, filtro.IDProvinca));

                
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
