using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cognitas.Framework.Repository;
using Cognitas.Framework.Repository.Interfaces;
using Utils.InterAssist;

namespace DAL.InterAssist
{
    public class ObservacionDS : Dataservices
    {

        #region Constantes

        private const string CONST_GET_BY_ID_PROCEDURE_NAME = "OBSERVACION_PKG.GET_OBSERVACION_BY_ID";
        private const string CONST_CREATE_PROCEDURE_NAME = "OBSERVACION_PKG.CREATE_OBSERVACION";
        private const string CONST_LIST_PROCEDURE_NAME = "OBSERVACION_PKG.LIST_OBSERVACION";

        /*
         * IDOBSERVACION,
            IDOPERADOR,
            DESCRIPCION,
            FECHA,
            IDTICKET,
            ESTADO,
            OBJECTHASH
         */

        public const string COL_ID_OBSERVACION = "IDOBSERVACION";
        public const string COL_ID_OPERADOR = "IDOPERADOR";
        public const string COL_DESCRIPCION = "DESCRIPCION";
        public const string COL_FECHA = "FECHA";
        public const string COL_ID_TICKET = "IDTICKET";
        public const string COL_ESTADO = "ESTADO";
        public const string COL_OBJECTHASH = "OBJECTHASH";
        public const string COL_OPERADOR_NOMBRE = "NOMBRE_OPERADOR";
        public const string COL_OPERADOR_APELLIDO = "APELLIDO_OPERADOR";
        


        #endregion Constantes

        #region Dataservices Implementacion

        public override string GET_BY_ID_PROCEDURE_NAME
        {
            get { return CONST_GET_BY_ID_PROCEDURE_NAME; }
        }

        public override string GET_DELETE_PROCEDURE_NAME
        {
            get { throw new NotImplementedException(); }
        }

        public override bool Update(System.Data.DataRow r)
        {
            throw new NotImplementedException();
        }

        public int Create(System.Data.DataRow r, DBRepository repository)
        {
            int result = 0;

            try
            {
                Datasets.Observaciones.OBSERVACIONESRow dr = (Datasets.Observaciones.OBSERVACIONESRow)r;


                List<IDbDataParameter> Paramlist = new List<IDbDataParameter>();

                Paramlist.Add(repository.DbFactory.getDataParameter("P_IDOPERADOR", DbType.Int32, dr.IDOPERADOR));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_DESCRIPCION", DbType.String, dr.DESCRIPCION));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_IDTICKET", DbType.Int32, dr.IDTICKET));


                result = repository.ExecuteCreateProcedure(CONST_CREATE_PROCEDURE_NAME, Paramlist, dr.OBJECTHASH.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public override int Create(System.Data.DataRow r)
        {
            int result = 0;

            try
            {
                DBRepository repository = DBRepository.GetDbRepository();
                result = Create(r, repository);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
                

            return result;
        }

        public override DataTable getMyTable()
        {
            throw new NotImplementedException();
        }

        public override DataSet List(Filter f, out int RecordCount)
        {
            DataSet ds = new DataSet();

            try
            {
                FiltroOberservaciones filtro = (FiltroOberservaciones)f;

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                DBRepository repository = DBRepository.GetDbRepository();

                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, filtro.ID));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDOPERADOR", DbType.Int32, filtro.IDOperador));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDTICKET", DbType.Int32, filtro.IDTicket));

                bool result = repository.ExecuteListProcedure(CONST_LIST_PROCEDURE_NAME, paramList, f, ds, out RecordCount);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;

        }
        
        #endregion Dataservices Implementacion
    }
}
