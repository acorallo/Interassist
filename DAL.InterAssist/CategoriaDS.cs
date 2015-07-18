using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cognitas.Framework.Repository;
using Utils.InterAssist;

namespace DAL.InterAssist 
{
    public class CategoriaDS : Dataservices
    {

        #region Constantes


        private const string CONST_GET_BY_ID_PROCEDURE_NAME = "CATEGORIA_PKG.GET_CATEGORIA_BY_ID";
        private const string CONST_LIST_PROCEDURE_NAME = "CATEGORIA_PKG.LIST_CATEGORIA";

        public const string COLUMN_ID_EMPRESA = "IDCATEGORIA";
        public const string COLUMN_NOMBRE = "NOMBRE";
        public const string COLUMN_DESCRIPCION = "DESCRIPCION";
        public const string COLUMN_ESTADO = "ESTADO";
        public const string COLUMN_CODIGO = "CODIGO";
        

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
            return new Datasets.Categoria.CATAGORIASDataTable();
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
                FiltroCategorias filtro = (FiltroCategorias)f;

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
