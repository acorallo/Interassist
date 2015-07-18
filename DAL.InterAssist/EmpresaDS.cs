using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cognitas.Framework.Repository;
using Utils.InterAssist;

namespace DAL.InterAssist
{
    public class EmpresaDS : Dataservices
    {

        #region Constantes

        private const string CONST_GET_BY_ID_PROCEDURE_NAME = "OPERADOR_PKG.GET_OPERADOR_BY_ID";
        private const string CONST_UPDATE_PROCEDURE_NAME = "OPERADOR_PKG.MODIFY_OPERADOR";
        private const string CONST_CREATE_PROCEDURE_NAME = "OPERADOR_PKG.CREATE_OPERADOR";
        private const string CONST_DELETE_PROCEDURE_NAME = "OPERADOR_PKG.DELETE_PRESTADOR";
        private const string CONST_LIST_PROCEDURE_NAME = "EMPRESAS_PKG.LIST_EMPRESA";


        // Columnas de la tabla.
        /*
         *  IDCATEGORIA,
                 NOMBRE,
                 DESCRIPCION,
                 ESTADO,
                 OBJECTHASH,
                 CODIGO
         */

        public const string COLUMN_ID_EMPRESA = "IDEMPRESA";
        public const string COLUMN_NOMBRE = "NOMBRE";
        public const string COLUMN_DESCRIPCION = "DESCRIPCION";
        public const string COLUMN_ESTADO = "ESTADO";
        
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

        public override DataTable getMyTable()
        {
            return new Datasets.Empresas.EMPRESASDataTable();
        }

        public override System.Data.DataSet List(Filter f, out int RecordCount)
        {
            DataSet ds = new DataSet();

            try
            {
                FiltroEmpresa filtro = (FiltroEmpresa)f;

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

        public override bool Update(DataRow r)
        {
            throw new NotImplementedException();
        }

        public override int Create(DataRow r)
        {
            throw new NotImplementedException();
        }
    
        #endregion Metodos

    }
}
