using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cognitas.Framework.Repository.Interfaces;


namespace Cognitas.Framework.Repository
{
    public abstract class Dataservices
    {

        #region Constantes

        public const string PARAM_OBJECT_HASH = "P_OBJECTHASH";
        public const string PARAM_AFFECTED_ROW = "P_AFFECTED_ROWS";
        public const string PARAM_ID = "P_ID";
        public const int NULL_INT = -1;


        public const int ACTIVO = 1;
        public const int NO_ACTIVO = 0;

        #endregion Constantes

        #region Properties

        public abstract string GET_BY_ID_PROCEDURE_NAME {get;}
        public abstract string GET_DELETE_PROCEDURE_NAME { get; }

        #endregion Properties

        #region Methods

        public abstract DataTable getMyTable();
        public abstract bool Update(DataRow r);
        public abstract int Create(DataRow r);
        public abstract DataSet List(Filter f, out int RecordCount);

        public static Nullable<Int32> IntNUlleable(int value)
        {
            Nullable<Int32> result = null;

            if (value != NULL_INT)
                result = value;

            return result;
        }
        
        public System.Data.DataSet List(Filter f)
        {
            int RecordCount;
            return List(f, out RecordCount);
        }


        public bool Delete(int id)
        {
            bool result = false;

            try
            {
                DBRepository repository = DBRepository.GetDbRepository();
                repository.DBCommand.CommandType = CommandType.StoredProcedure;
                repository.DBCommand.Connection = repository.DBConnection;


                List<IDbDataParameter> paramList = new List<IDbDataParameter>();

                paramList.Add(repository.DbFactory.getDataParameter(PARAM_ID, DbType.Int32, id)); 
                paramList.Add(repository.DbFactory.getDataParameter(PARAM_AFFECTED_ROW, DbType.Int32, 0, ParameterDirection.Output));

                repository.ConnectionOpen();
                repository.ExecuteNonQueryProcedure(this.GET_DELETE_PROCEDURE_NAME, paramList);

                int affected = Int32.Parse(((IDbDataParameter)repository.DBCommand.Parameters[Dataservices.PARAM_AFFECTED_ROW]).Value.ToString());

                result = true;
            }
            
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public DataRow GetObjectById(int id, string objectHash)
        {

            DataRow dr = null;

            if (id <= 0)
                throw new Exceptions.IdNotNullException();

            try
            {

                DBRepository db = DBRepository.GetDbRepository();
                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                DataSet ds = new DataSet();

                

                paramList.Add(db.DbFactory.getDataParameter(PARAM_ID, DbType.Int32, id));
                paramList.Add(db.DbFactory.getDataParameter(PARAM_OBJECT_HASH, DbType.String, objectHash));

                db.ExecuteProcedure(GET_BY_ID_PROCEDURE_NAME, paramList, ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dr = ds.Tables[0].Rows[0];
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }


            return dr;
            

        }

       
        #endregion Methods.

    }
}
