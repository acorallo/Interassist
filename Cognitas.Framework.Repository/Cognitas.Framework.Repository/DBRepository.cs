using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cognitas.Framework.Repository.Oracle;
using Cognitas.Framework.Repository.MSSqlserver;
using Cognitas.Framework.Repository.Exceptions;
using System.Configuration;
using System.Web;

namespace Cognitas.Framework.Repository
{
    public abstract class DBRepository : Repository, IDisposable
    {
        #region Constants

        private const string DEFAULT_CONNECTION_NAME = "DEFAULT";

        private const int PAGED_TRUE = 1;
        private const int PAGED_FALSE = 0;

        /*
        P_ORDER_BY IN varchar2,
        P_IS_PAGED IN boolean,
        P_PAGE_START IN number,
        P_PAGE_SIZE IN number,
        R_CURSOR OUT tyRefCursor
        */
        // FILTER

        private const string P_PAGE_START_PARAM = "P_PAGE_START";
        private const string P_PAGE_SIZE_PARAM = "P_PAGE_SIZE";
        private const string P_IS_PAGED_PARAM = "P_IS_PAGED";
        private const string P_ORDER_BY_PARAM = "P_ORDER_BY";


        private const string PARAM_ID = "P_ID";
        private const string COLUMN_TOTAL_ROW_NAME = "TOTAL_ROWS";

        #endregion Constants

        #region Constantes

        #endregion Constantes

        #region Members

        
        private IDbTransaction _dbTransaction = null;
        private IDbConnection _dbConnection = null;
        private IDbCommand _dbCommand = null;
        private IDataAdapter _dataAdapter = null;

        private string _connectionName = string.Empty;
        private DBFactory _dbFactory;
        private static ConnectionPool _connectionPool;
        private bool _transactionAble = false;

        #endregion Members

        #region Properties

        protected bool TransactionAble
        {
            get { return _transactionAble; }
        }

        private static ConnectionPool connectionPool
        {

            get
            {
                if (_connectionPool == null)
                {
                    if(HttpContext.Current!=null)
                        _connectionPool = new WebConnectionPool();
                    else
                        _connectionPool = new HostConnectionPool();
                }
                return _connectionPool;
            }

        }
   
        private string ConnectionName
        {
            get { return _connectionName; }

        }

        public IDbConnection DBConnection
        {
            get
            {
                return this._dbConnection;
            }
            set
            {
                this._dbConnection = value;
            }
        }

        public IDbCommand DBCommand
        {
            get
            {
                return this._dbCommand;
            }
            set
            {
                this._dbCommand = value;
            }
        }

        public IDbTransaction DbTransaction
        {
            get { return _dbTransaction; }

        }

        public IDataAdapter DBDataAdapter
        {
            get
            {
                return this._dataAdapter;
            }
            set
            {
                this._dataAdapter = value;
            }
        }

        

        #endregion Properties

        #region Methods

        #region Static Methods

        public static DBRepository GetDbRepository(DBRepository DBRepository)
        {
            DBRepository result = DBRepository.GetDbRepository(false);
            result._dbConnection = DBRepository._dbConnection;
            result._dbTransaction = DBRepository._dbTransaction;

            return result;
            
        }

        public static DBRepository GetDbRepository(string connectionName, bool TransactionAble)
        {
            DBRepository result = null;
            
            

            ConnectionStringSettings c = ConfigurationManager.ConnectionStrings[connectionName];
            if (c != null)
            {
                DBFactory dbFactory = DBFactory.GetInstance(c.ProviderName);
                
                result = dbFactory.getRepository();
                // Verify wether the repository support Transaction 
                if (TransactionAble && !result.SupportTransaction)
                    throw new RepositoryDoNotSupportTransacctionException(c.ProviderName);

                result._transactionAble = TransactionAble;
                result.DBCommand = dbFactory.getDBCommand();
                result.DBConnection = connectionPool.GetConnection(c.ConnectionString, c.Name, dbFactory);
                result.ConnectionOpen();
                result.DBDataAdapter = dbFactory.getDataAdapter(result.DBCommand);

                if (TransactionAble)
                {
                    
                }


                result.DbFactory = dbFactory;
                
            }
            else
            {
                throw new ConnectionNameNotFoundException(connectionName);
            }
            
            return result;
             
        }

        public static DBRepository GetDbRepository()
        {
            DBRepository result = null;
            result = DBRepository.GetDbRepository(false);
            return result;
        }

        public static DBRepository GetDbRepository(string connectionName)
        {
            DBRepository result = null;
            result = DBRepository.GetDbRepository(DEFAULT_CONNECTION_NAME, false);
            return result;
        }

        public static DBRepository GetDbRepository(bool TransactionAble)
        {
            DBRepository result = null;
            result = DBRepository.GetDbRepository(DEFAULT_CONNECTION_NAME, TransactionAble);
            return result;
        }
            
        public DBFactory DbFactory
        {
            get { return _dbFactory; }
            set { _dbFactory = value; }
        }

        #endregion Static Methods

        #region abstract Methods

        public abstract bool SupportProcedures { get; }
        public abstract bool SupportTransaction { get; }
        

        #endregion abstrac Methos

        #region Database Methods

        public virtual IDataReader ExecuteDataReader(string sql)
        {
            IDataReader resulReader = null;

            try
            {

                this.DBCommand.CommandText = sql;
                this.DBCommand.Connection = this.DBConnection;
                resulReader = this.DBCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resulReader;
        }

        public virtual IDataReader ExecuteDataReader()
        {
            IDataReader resulReader = null;

            try
            {
                resulReader = this.DBCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resulReader;
        }

        public virtual bool ExecuteQuery(DataSet ds, string sql)
        {
            bool result = false;

            try
            {
                this.DBCommand.CommandText = sql;
                IDataAdapter dataAdapter = DbFactory.getDataAdapter(this.DBCommand);
                dataAdapter.Fill(ds);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public virtual int ExecuteUpdateProcedure(string ProcedureName, List<IDbDataParameter> parameters, string objectHash)
        {
            int result = 0;
            
            try
            {
                
                parameters.Add(this.DbFactory.getDataParameter(Dataservices.PARAM_OBJECT_HASH, DbType.String, objectHash));
                parameters.Add(this.DbFactory.getDataParameter(Dataservices.PARAM_AFFECTED_ROW, DbType.Int32, null, ParameterDirection.Output));
                this.ExecuteNonQueryProcedure(ProcedureName, parameters);

                result = Int32.Parse(((IDbDataParameter)this.DBCommand.Parameters[Dataservices.PARAM_AFFECTED_ROW]).Value.ToString());

                if (result > 1)
                {
                    throw new IntegrityUpdateException(ProcedureName);
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            return result;
        }

        public virtual int ExecuteCreateProcedure(string ProcedureName, List<IDbDataParameter> parameters, string objectHash)
        {
            int result = 0;
            
            try
            {
                parameters.Add(this.DbFactory.getDataParameter(Dataservices.PARAM_ID, DbType.Int32, 0, ParameterDirection.Output));
                parameters.Add(this.DbFactory.getDataParameter(Dataservices.PARAM_OBJECT_HASH, DbType.String, objectHash));
             

                this.ConnectionOpen();
                
                this.ExecuteNonQueryProcedure(ProcedureName, parameters);

                result = Int32.Parse((((IDbDataParameter)this.DBCommand.Parameters[PARAM_ID]).Value.ToString()));


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public virtual bool ExecuteListProcedure(string ProcedureName, List<IDbDataParameter> parameters, Filter f, DataSet dsResult)
        {
            int Rowcount;
            return ExecuteListProcedure(ProcedureName, parameters, f, dsResult, out Rowcount);
        }

        public virtual bool ExecuteListProcedure(string ProcedureName, List<IDbDataParameter> parameters, Filter f, DataSet dsResult, out int RecordCount)
        {

            bool result = false;
            RecordCount = 0;
            try
            {
                this.AddFilterToCommand(parameters, f);
                this.ExecuteProcedure(ProcedureName, parameters, dsResult);
                
                if (f.IsPaged)
                {
                    if ((dsResult.Tables.Count > 0) && (dsResult.Tables[0].Rows.Count>0)){
                        RecordCount = Int32.Parse(dsResult.Tables[0].Rows[0][COLUMN_TOTAL_ROW_NAME].ToString());
                    }
                   
                }
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public virtual bool ExecuteNonQueryProcedure(string ProcedureName, List<IDbDataParameter> parameters)
        {
            bool result = false;

            try
            {
                this.DBCommand.CommandType = CommandType.StoredProcedure;
                this.DBCommand.CommandText = ProcedureName;
                this.DBCommand.Connection = this.DBConnection;

                foreach (IDbDataParameter p in parameters)
                {
                    this.DBCommand.Parameters.Add(p);
                }

                this.DBCommand.ExecuteNonQuery();
                result = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public virtual bool ExecuteProcedure(string ProcedureName, List<IDbDataParameter> parameters, DataSet ds)
        {
            bool result = false;

            try
            {
                this.DBCommand.CommandType = CommandType.StoredProcedure;
                this.DBCommand.CommandText = ProcedureName;

                foreach (IDataParameter p in parameters)
                {
                    this.DBCommand.Parameters.Add(p);
                }

                this.DBDataAdapter = DbFactory.getDataAdapter(this.DBCommand);

                this.DBDataAdapter.Fill(ds);

                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private void ConnectionClose()
        {
            if (this.DBConnection.State==ConnectionState.Open)
                this.DBConnection.Close();
        }

        public void ConnectionOpen()
        {
            if (this.DBConnection.State != ConnectionState.Open)
            {
                this.DBConnection.Open();
                
            }
        }

        public void AddFilterToCommand(List<IDbDataParameter> parameters, Filter filter)
        {
            // Get parameters.
            IDbDataParameter paramStartRow = this.DbFactory.getDataParameter(P_PAGE_START_PARAM, DbType.Int32, filter.StartRow);
            IDbDataParameter paramRowQtty = this.DbFactory.getDataParameter(P_PAGE_SIZE_PARAM, DbType.Int32, filter.PageSize);
            IDbDataParameter paramCouterFiltred = this.DbFactory.getDataParameter(P_IS_PAGED_PARAM, DbType.Int32, filter.IsPaged?PAGED_TRUE:PAGED_FALSE);
            IDbDataParameter paramOrderby = this.DbFactory.getDataParameter(P_ORDER_BY_PARAM, DbType.String, filter.OrderBY);

            parameters.Add(paramStartRow);
            parameters.Add(paramRowQtty);
            parameters.Add(paramCouterFiltred);
            parameters.Add(paramOrderby);
           
        }

        public void CommitTransaction()
        {
            if (this.TransactionAble)
            {
                if (this._dbTransaction != null)
                {
                    this._dbTransaction.Commit();
                }
                else
                {
                    throw new RepositoryDonotBeginTransactionException(this.ToString());
                }
            }
            else
            {
                throw new RespositoryNotasTransException(this.ToString());
            }
        }

        public void BeginTransaction()
        {
            if (this.TransactionAble)
            {
                this._dbTransaction = this.DBConnection.BeginTransaction();
            }
            else
            {

            }
        }

        public void RollbackTransaction()
        {
            if (this.TransactionAble)
            {
                if (this._dbTransaction != null)
                {
                    this._dbTransaction.Rollback();
                }
                else
                {
                    throw new RepositoryDonotBeginTransactionException(this.ToString());
                }
            }
            else
            {
                throw new RespositoryNotasTransException(this.ToString());
            }
        }
 
        #endregion Database Methods

        #endregion Methos

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            this.ConnectionClose();
            this.DBConnection.Dispose();
        }

        #endregion
    }
}
