using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;
using System.Data;
using Utils.InterAssist;


namespace DAL.InterAssist
{
    public class AfiliadoDS : Dataservices
    {
        
        #region Constantes


        private const string CONST_GET_BY_ID_PROCEDURE_NAME = "AFILIADO_PKG.GET_AFILIADO_BY_ID";
        private const string CONST_UPDATE_PROCEDURE_NAME = "AFILIADO_PKG.MODIFY_AFILIADO";
        private const string CONST_CREATE_PROCEDURE_NAME = "AFILIADO_PKG.CREATE_AFILIADO";
        private const string CONST_DELETE_PROCEDURE_NAME = "AFILIADO_PKG.DELETE_AFILIADO";
        private const string CONST_LIST_PROCEDURE_NAME = "AFILIADO_PKG.LIST_AFILIADO";
        private const string CONST_LIST_HUERFANOS_NAME = "AFILIADO_PKG.LIST_AFILIADO_HUEARFANO";
        private const string CONST_LIST_BY_PATENTE = "AFILIADO_PKG.LIST_AFILIADO_BY_PATENTE";


        // Columnas
        public const string COLUMN_ID_AFILIADO =  "IDAFILIADO";
        public const string COLUMN_APELLIDO = "APELLIDO";
        public const string COLUMN_NOMBRE = "NOMBRE";
        public const string COLUMN_POLIZA = "POLIZA";
        public const string COLUMN_DIRECCION = "DIRECCION";
        public const string COLUMN_COD_POSTAL = "CODPOSTAL";
        public const string COLUMN_FECHADESDE =  "FECHADESDE";
        public const string COLUMN_FECHAHASTA =  "FECHAHASTA";
        public const string COLUMN_DOCUMENTO = "IDDOCUMENTO";
        public const string COLUMN_MARCA = "MARCA";
        public const string COLUMN_PATENTE = "PATENTE";
        public const string COLUMN_COLOR = "COLOR";
        public const string COLUMN_AÑO = "ANO";
        public const string COLUMN_OBJECTHASH = "OBJECTHASH";
        public const string COLUMN_IDEMPRESA = "IDEMPRESA";
        public const string COLUMN_NOMBRE_EMPRESA = "NOMBRE_EMPRESA";
        public const string COLUMN_CATEGORIA = "CATEGORIA";
        public const string COLUMN_CATEGORIA_NOMBRE = "CATAGORIA_NOMBRE";
        public const string COLUMN_HOGAR = "HOGAR";
        public const string COLUMN_MODELO = "MODELO";
        public const string COLUMN_ESTADO = "ESTADO";

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Miembros

        #endregion Miembros

        #region Propiedades

        public override string GET_BY_ID_PROCEDURE_NAME
        {
            get { return CONST_GET_BY_ID_PROCEDURE_NAME; }
        }

        public override string GET_DELETE_PROCEDURE_NAME
        {
            get { return GET_DELETE_PROCEDURE_NAME; }
        }

        #endregion Propiedades

        #region Metodos

        public override System.Data.DataTable getMyTable()
        {
            return new Datasets.Afiliados.AFILIADOSDataTable();
        }

        public override int Create(System.Data.DataRow r)
        {
            int result = 0;

            try
            {
                DBRepository repository = DBRepository.GetDbRepository();
                Datasets.Afiliados.AFILIADOSRow dr = (Datasets.Afiliados.AFILIADOSRow)r;
                Datasets.Afiliados.AFILIADOSDataTable dtable = (Datasets.Afiliados.AFILIADOSDataTable)dr.Table;

                List<IDbDataParameter> Paramlist = new List<IDbDataParameter>();

                Paramlist.Add(repository.DbFactory.getDataParameter("P_APELLIDO", DbType.String, r[dtable.APELLIDOColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_NOMBRE", DbType.String, r[dtable.NOMBREColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_POLIZA", DbType.String, r[dtable.POLIZAColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_DIRECCION", DbType.String, r[dtable.DIRECCIONColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_CODPOSTAL", DbType.String, r[dtable.CODPOSTALColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_FECHADESDE", DbType.Date, r[dtable.FECHADESDEColumn]));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_FECHAHASTA", DbType.Date, r[dtable.FECHAHASTAColumn]));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_IDDOCUMENTO", DbType.String, r[dtable.IDDOCUMENTOColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_MARCA", DbType.String, r[dtable.MARCAColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_PATENTE", DbType.String, r[dtable.PATENTEColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_ID_EMPRESA", DbType.Int32, Int32.Parse(r[dtable.IDEMPRESAColumn].ToString())));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_COLOR", DbType.String, r[dtable.COLORColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_ANO", DbType.String, r[dtable.ANOColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_CATEGORIA", DbType.String, r[dtable.CATEGORIAColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_HOGAR", DbType.Int32, Int32.Parse(r[dtable.HOGARColumn].ToString())));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_MODELO", DbType.String, r[dtable.MODELOColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_ESTADO", DbType.Int32, Int32.Parse(r[dtable.ESTADOColumn].ToString())));


                result = repository.ExecuteCreateProcedure(CONST_CREATE_PROCEDURE_NAME, Paramlist, r[dtable.OBJECTHASHColumn].ToString());
                


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public override bool Update(System.Data.DataRow r)
        {
            bool result = false;

            try
            {
                DBRepository repository = DBRepository.GetDbRepository();
                Datasets.Afiliados.AFILIADOSRow dr = (Datasets.Afiliados.AFILIADOSRow)r;
                Datasets.Afiliados.AFILIADOSDataTable dtable = (Datasets.Afiliados.AFILIADOSDataTable)dr.Table;

                List<IDbDataParameter> Paramlist = new List<IDbDataParameter>();


                Paramlist.Add(repository.DbFactory.getDataParameter("P_ID", DbType.String, r[dtable.IDAFILIADOColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_APELLIDO", DbType.String, r[dtable.APELLIDOColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_NOMBRE", DbType.String, r[dtable.NOMBREColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_POLIZA", DbType.String, r[dtable.POLIZAColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_DIRECCION", DbType.String, r[dtable.DIRECCIONColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_CODPOSTAL", DbType.String, r[dtable.CODPOSTALColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_FECHADESDE", DbType.Date, r[dtable.FECHADESDEColumn]));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_FECHAHASTA", DbType.Date, r[dtable.FECHAHASTAColumn]));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_IDDOCUMENTO", DbType.String, r[dtable.IDDOCUMENTOColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_MARCA", DbType.String, r[dtable.MARCAColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_PATENTE", DbType.String, r[dtable.PATENTEColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_COLOR", DbType.String, r[dtable.COLORColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_ANO", DbType.String, r[dtable.ANOColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_ID_EMPRESA", DbType.Int32, Int32.Parse(r[dtable.IDEMPRESAColumn].ToString())));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_CATEGORIA", DbType.String, r[dtable.CATEGORIAColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_HOGAR", DbType.Int32, Int32.Parse(r[dtable.HOGARColumn].ToString())));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_MODELO", DbType.String, r[dtable.MODELOColumn].ToString()));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_ESTADO", DbType.Int32, Int32.Parse(r[dtable.ESTADOColumn].ToString())));

                result = repository.ExecuteUpdateProcedure(CONST_UPDATE_PROCEDURE_NAME, Paramlist, r[dtable.OBJECTHASHColumn].ToString()) == 1;
               

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
                FiltroAfiliado filtro = (FiltroAfiliado)f;

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                DBRepository repository = DBRepository.GetDbRepository();

                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, filtro.ID));
                paramList.Add(repository.DbFactory.getDataParameter("P_APELLIDO", DbType.String, filtro.Apellido));
                paramList.Add(repository.DbFactory.getDataParameter("P_NOMBRE", DbType.String, filtro.Nombre));
                paramList.Add(repository.DbFactory.getDataParameter("P_POLIZA", DbType.String, filtro.Poliza));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDDOCUMENTO", DbType.String, filtro.Documento));
                paramList.Add(repository.DbFactory.getDataParameter("P_PATENTE", DbType.String, filtro.Patente));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_EMPRESA", DbType.Int32, filtro.IDEmpresa));
                paramList.Add(repository.DbFactory.getDataParameter("P_SEARCH", DbType.String, filtro.Search));
                paramList.Add(repository.DbFactory.getDataParameter("P_VIGENTE", DbType.Int32, Convert.ToInt32(filtro.Vigente)));      // EGV 10Jun2017

                bool result = repository.ExecuteListProcedure(CONST_LIST_PROCEDURE_NAME, paramList, f, ds, out RecordCount);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;

        }

        public System.Data.DataSet ListHuerfanos(Filter f, out int RecordCount)
        {

            DataSet ds = new DataSet();

            try
            {
                FiltroAfiliado filtro = (FiltroAfiliado)f;

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                DBRepository repository = DBRepository.GetDbRepository();

                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, filtro.ID));
                paramList.Add(repository.DbFactory.getDataParameter("P_APELLIDO", DbType.String, filtro.Apellido));
                paramList.Add(repository.DbFactory.getDataParameter("P_NOMBRE", DbType.String, filtro.Nombre));
                paramList.Add(repository.DbFactory.getDataParameter("P_POLIZA", DbType.String, filtro.Poliza));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDDOCUMENTO", DbType.String, filtro.Documento));
                paramList.Add(repository.DbFactory.getDataParameter("P_PATENTE", DbType.String, filtro.Patente));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_EMPRESA", DbType.Int32, filtro.IDEmpresa));
                paramList.Add(repository.DbFactory.getDataParameter("P_SEARCH", DbType.String, filtro.Search));

                bool result = repository.ExecuteListProcedure(CONST_LIST_HUERFANOS_NAME, paramList, f, ds, out RecordCount);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;

        }

        public System.Data.DataSet ListByPatente(Filter f, out int RecordCount)
        {
            DataSet ds = new DataSet();

            try
            {
                FiltroAfiliado filtro = (FiltroAfiliado)f;

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                DBRepository repository = DBRepository.GetDbRepository();

                paramList.Add(repository.DbFactory.getDataParameter("P_PATENTE", DbType.String, filtro.Patente));

                bool result = repository.ExecuteListProcedure(CONST_LIST_BY_PATENTE, paramList, f, ds, out RecordCount);

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
