using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;
using System.Data;
using Utils.InterAssist;

namespace DAL.InterAssist
{
    public class ProblemaDS : Dataservices
    {

        #region Constantes

        private const string CONST_GET_BY_ID_PROCEDURE_NAME = "PROBLEMA_PKG.GET_TICKET_BY_ID";
        private const string CONST_LIST_PROCEDURE_NAME = "PROBLEMA_PKG.LIST_PROBLEMA";

        // Columnas
        public const string COL_ID_PROBLEMA =  "IDPROBLEMA"; 
        public const string COL_ID_DESCRIPCION =  "DESCRIPCION";
        public const string COL_ID_ESTADADO = "ESTADO";
        public const string COL_OBJECTHASH = "OBJECTHASH";

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
            get { return CONST_GET_BY_ID_PROCEDURE_NAME; }
        }

        public override string GET_DELETE_PROCEDURE_NAME
        {
            get { throw new NotImplementedException(); }
        }

        #endregion Propiedades

        #region Metodos

        public override int Create(DataRow r)
        {
            throw new NotImplementedException();
        }

        public override DataTable getMyTable()
        {
            return new Datasets.Problemas.PROBLEMASDataTable();
        }

        public override bool Update(DataRow r)
        {
            throw new NotImplementedException();
        }


        public override DataSet List(Filter f, out int RecordCount)
        {
            DataSet resultSet = new DataSet();

            try
            {
                FiltroProblema filtro = (FiltroProblema)f;
                DBRepository repository = DBRepository.GetDbRepository();

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();

                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, filtro.ID));

                repository.ExecuteListProcedure(CONST_LIST_PROCEDURE_NAME, paramList, f, resultSet, out RecordCount);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultSet;
        }

        #endregion Metodos
    }
}
