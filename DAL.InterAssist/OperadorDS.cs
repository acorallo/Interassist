using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cognitas.Framework.Repository;
using Utils.InterAssist;




namespace DAL.InterAssist
{
    public class OperadorDS : Dataservices
    {

        #region Constantes


        private const string CONST_GET_BY_ID_PROCEDURE_NAME = "OPERADOR_PKG.GET_OPERADOR_BY_ID";
        private const string CONST_UPDATE_PROCEDURE_NAME = "OPERADOR_PKG.MODIFY_OPERADOR";
        private const string CONST_CREATE_PROCEDURE_NAME = "OPERADOR_PKG.CREATE_OPERADOR";
        private const string CONST_DELETE_PROCEDURE_NAME = "OPERADOR_PKG.DELETE_PRESTADOR";
        private const string CONST_LIST_PROCEDURE_NAME = "OPERADOR_PKG.LIST_OPERADOR";
        private const string CONST_MODIFCAR_CLAVE_PROCEDURE_NAME = "OPERADOR_PKG.MODIFY_OPERADOR_CLAVE";

        // Columnas
        public const string COLUMN_ID_OPERADOR = "IDOPERADOR";
        public const string COLUMN_USUARIO = "USUARIO";
        public const string COLUMN_NOMBRE = "NOMBRE";
        public const string COLUMN_APELLIDO = "APELLIDO";
        public const string COLUMN_CLAVE = "CLAVE";
        public const string COLUMN_ACTIVO = "ACTIVO";
        public const string COLUMN_ADMIN = "ADMIN";
        public const string COLUMN_OBJECT_HASH = "OBJECTHASH";
        public const string COLUMN_EMAIL = "EMAIL";
        

        #endregion Constantes

        #region Propiedes

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

        public override System.Data.DataTable getMyTable()
        {
            return new Datasets.Operadores.OPERADORESDataTable();
        }

        public override bool Update(System.Data.DataRow r)
        {
            bool result = false;


            try
            {

                DBRepository repository = DBRepository.GetDbRepository();
                Datasets.Operadores.OPERADORESDataTable dt = (Datasets.Operadores.OPERADORESDataTable)r.Table;

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();

                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, Int32.Parse((r[dt.IDOPERADORColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_USUARIO", DbType.String, r[dt.USUARIOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_NOMBRE", DbType.String, r[dt.NOMBREColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_APELLIDO", DbType.String, r[dt.APELLIDOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_EMAIL", DbType.String, r[dt.EMAILColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_ACTIVO", DbType.Int32, Int32.Parse(r[dt.ACTIVOColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_ADMIN", DbType.Int32, Int32.Parse(r[dt.ADMINColumn].ToString())));

                result = (repository.ExecuteUpdateProcedure(CONST_UPDATE_PROCEDURE_NAME, paramList, r[dt.OBJECTHASHColumn].ToString())) == 1;

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
                Datasets.Operadores.OPERADORESDataTable dt = (Datasets.Operadores.OPERADORESDataTable)r.Table;

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();

                
                paramList.Add(repository.DbFactory.getDataParameter("P_USUARIO", DbType.String, r[dt.USUARIOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_NOMBRE", DbType.String, r[dt.NOMBREColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_CLAVE", DbType.String, r[dt.CLAVEColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_APELLIDO", DbType.String, r[dt.APELLIDOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_EMAIL", DbType.String, r[dt.EMAILColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_ACTIVO", DbType.Int32, Int32.Parse(r[dt.ACTIVOColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_ADMIN", DbType.Int32, Int32.Parse(r[dt.ADMINColumn].ToString())));

                result = repository.ExecuteCreateProcedure(CONST_CREATE_PROCEDURE_NAME, paramList, r[dt.OBJECTHASHColumn].ToString());

                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool ModificarClave(int idOperador, string nuevaClave)
        {
            bool result = false;

            try
            {
                DBRepository repository = DBRepository.GetDbRepository();

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, idOperador));
                paramList.Add(repository.DbFactory.getDataParameter("P_CLAVE", DbType.String, nuevaClave));
                paramList.Add(repository.DbFactory.getDataParameter(Dataservices.PARAM_AFFECTED_ROW, DbType.Int32, null, ParameterDirection.Output));

                repository.ExecuteNonQueryProcedure(CONST_MODIFCAR_CLAVE_PROCEDURE_NAME, paramList);
                
                result = Int32.Parse(((IDbDataParameter)repository.DBCommand.Parameters[Dataservices.PARAM_AFFECTED_ROW]).Value.ToString()) == 1;


            }
            catch (Exception ex)
            {
                throw ex;
            }



            return result;
        }

        public override System.Data.DataSet List(Filter f, out int RecordCount)
        {
            DataSet ds = new DataSet();

            try
            {
                FiltroOperador filtro = (FiltroOperador)f;

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                DBRepository repository = DBRepository.GetDbRepository();


                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, filtro.ID));
                paramList.Add(repository.DbFactory.getDataParameter("P_USUARIO", DbType.String, filtro.Usuario));
                paramList.Add(repository.DbFactory.getDataParameter("P_NOMBRE", DbType.String, filtro.Nombre));
                paramList.Add(repository.DbFactory.getDataParameter("P_CLAVE", DbType.String, filtro.Clave));
                paramList.Add(repository.DbFactory.getDataParameter("P_APELLIDO", DbType.String, filtro.Apellido));
                paramList.Add(repository.DbFactory.getDataParameter("P_SEARCH", DbType.String, filtro.Search));
                paramList.Add(repository.DbFactory.getDataParameter("P_ACTIVO", DbType.Int32, filtro.Estado));

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
