using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cognitas.Framework.Repository;
using Utils.InterAssist;

namespace DAL.InterAssist
{
    public class LocalidadDS : Dataservices
    {

        #region Constantes


        private const string CONST_LIST_PROCEDURE_NAME = "LOCALIDAD_PKG.LIST_LOCALIDAD";
        private const string CONST_LIST_UBICACIONES_NAME = "LOCALIDAD_PKG.LIST_UBICACIONES";


        public const string COLUMN_ID_LOCALIDAD = "IDLOCALIDAD";        
        public const string COLUMN_ID_IDCIUDAD = "IDCIUDAD";
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


        public DataSet ListUbicaciones(Filter f, out int RecordCount)
        {
            DataSet ds = new DataSet();

            try
            {
                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                DBRepository repository = DBRepository.GetDbRepository();

                bool result = repository.ExecuteListProcedure(CONST_LIST_UBICACIONES_NAME, paramList, f, ds, out RecordCount);
    
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        public override DataSet List(Filter f, out int RecordCount)
        {
            DataSet ds = new DataSet();

            try
            {
                FiltroLocalidad filtro = (FiltroLocalidad)f;

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                DBRepository repository = DBRepository.GetDbRepository();

                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, filtro.ID));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDCIUDAD", DbType.Int32, filtro.IDCiudad));
                


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
