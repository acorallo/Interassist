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
    public class PrestadorDS : Dataservices
    {

        #region Constantes



        private const string CONST_GET_BY_ID_PROCEDURE_NAME = "PRESTADOR_PKG.GET_PRESTADOR_BY_ID";
        private const string CONST_UPDATE_PROCEDURE_NAME = "PRESTADOR_PKG.MODIFY_PRESTADOR";
        private const string CONST_CREATE_PROCEDURE_NAME = "PRESTADOR_PKG.CREATE_PRESTADOR";
        private const string CONST_DELETE_PROCEDURE_NAME = "PRESTADOR_PKG.DELETE_PRESTADOR";
        private const string CONST_LIST_PROCEDURE_NAME = "PRESTADOR_PKG.LIST_PRESTADOR";

        // Campos
        public const string COL_ID_PRESTADOR = "IDPRESTADOR";
        public const string COL_NOMBRE = "NOMBRE";
        public const string COL_DESCRIPCION = "DESCRIPCION";
        public const string COL_ESTADO = "ESTADO";
        public const string COL_OBJECTHASH = "OBJECTHASH";
        public const string COL_TELEFONO1 = "TELEFONO1";
        public const string COL_TELEFONO2 = "TELEFONO2";
        public const string COL_CELULAR1 = "CELULAR1";
        public const string COL_CELULAR2 = "CELULAR2";
        public const string COL_NEXTEL = "NEXTEL";
        public const string COL_DOMICILIO = "DOMICILIO";
        public const string COL_ID_CIUDAD = "IDCIUDAD";
        public const string COL_NOMBRE_CIUDAD = "CIUDAD_NOMBRE";   
        public const string COL_PROVINCA_NOMBRE = "PROVINCA_NOMBRE";
        public const string COL_IDPROVINCIA = "IDPROVINCIA";
        public const string COL_IDPAIS = "IDPAIS";
        public const string COL_PAIS_NOMBRE = "PAIS_NOMBRE";
        public const string COL_IDLOCALIDAD = "IDLOCALIDAD";
        public const string COL_LOCALIDAD_NOMBRE = "LOCALIDAD_NOMBRE";
        public const string COL_EMAIL = "EMAIL";
        public const string COL_CUIT = "CUIT";
        public const string COL_IVA = "IVA";
        public const string COL_LIV_MOVIDA = "LIV_MOVIDA";
        public const string COL_LIV_KM = "LIV_KM";
        public const string COL_SP1_MOVIDA = "SP1_MOVIDA";
        public const string COL_SP1_KM = "SP1_KM";
        public const string COL_SP2_MOVIDA = "SP2_MOVIDA";
        public const string COL_SP2_KM = "SP2_KM";
        public const string COL_PS1_MOVIDA = "PS1_MOVIDA";
        public const string COL_PS1_KM = "PS1_KM";
        public const string COL_PS2_MOVIDA = "PS2_MOVIDA";
        public const string COL_PS2_KM = "PS2_KM";

        // Campos
        /*
        A.IDPRESTADOR,
        A.NOMBRE,
        A.DESCRIPCION,
        A.ESTADO,
        A.OBJECTHASH,
        A.TELEFONO1,
        A.TELEFONO2,
        A.CELULAR1,
        A.CELULAR2,
        A.NEXTEL,
        A.DOMICILIO,
        A.IDLOCALIDAD,
        D.NOMBRE LOCALIDAD_NOMBRE,
        C.PROVINCIA,
        C.PROVINCIA PROVINCA_NOMBRE,
        A.IDPROVINCIA,
        A.IDPAIS,
        B.PAIS PAIS_NOMBRE,
        A.EMAIL,
        A.CUIT,
        A.IVA,
        A.LIV_MOVIDA,
        A.LIV_KM,
        A.SP1_MOVIDA,
        A.SP1_KM,
        A.SP2_MOVIDA,
        A.SP2_KM,
        A.PS1_MOVIDA,
        A.PS1_KM,
        A.PS2_MOVIDA,
        A.PS2_KM
        */

        #endregion Constantes

        #region Metodos

        public override string GET_BY_ID_PROCEDURE_NAME
        {
            get { return CONST_GET_BY_ID_PROCEDURE_NAME; }
        }

        public override string GET_DELETE_PROCEDURE_NAME
        {
            get { return CONST_DELETE_PROCEDURE_NAME; }
        }

        public override System.Data.DataTable getMyTable()
        {
            DataTable dt = null;
            dt = new Datasets.Prestadores.PRESTADORESDataTable();
            return dt;
        }

        public override bool Update(System.Data.DataRow r)
        {
            bool result = false;
            
            try
            {


                DBRepository repository = DBRepository.GetDbRepository();


                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                Datasets.Prestadores.PRESTADORESDataTable dt = (Datasets.Prestadores.PRESTADORESDataTable)r.Table;

                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, Int32.Parse(r[dt.IDPRESTADORColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_NOMBRE", DbType.String, r[dt.NOMBREColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_DESCRIPCION", DbType.String, r[dt.DESCRIPCIONColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_ESTADO", DbType.Int32, Int32.Parse(r[dt.ESTADOColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_TELEFONO1", DbType.String, r[dt.TELEFONO1Column]));
                paramList.Add(repository.DbFactory.getDataParameter("P_TELEFONO2", DbType.String, r[dt.TELEFONO2Column]));
                paramList.Add(repository.DbFactory.getDataParameter("P_CELULAR1", DbType.String, r[dt.CELULAR1Column]));
                paramList.Add(repository.DbFactory.getDataParameter("P_CELULAR2", DbType.String, r[dt.CELULAR2Column]));
                paramList.Add(repository.DbFactory.getDataParameter("P_NEXTEL", DbType.String, r[dt.NEXTELColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_DOMICILIO", DbType.String, r[dt.DOMICILIOColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDCIUDAD", DbType.Int32, Int32.Parse(r[dt.IDCIUDADColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPROVINCIA", DbType.Int32, Int32.Parse(r[dt.IDPROVINCIAColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPAIS", DbType.Int32, Int32.Parse(r[dt.IDPAISColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("p_IDLOCALIDAD", DbType.Int32, Int32.Parse(r[dt.IDLOCALIDADColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_EMAIL", DbType.String, r[dt.EMAILColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_CUIT", DbType.String, r[dt.CUITColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_IVA", DbType.String, r[dt.IVAColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_LIV_MOVIDA", DbType.Decimal, r[dt.LIV_MOVIDAColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_LIV_KM", DbType.Decimal, r[dt.LIV_KMColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_SP1_MOVIDA", DbType.Decimal, r[dt.SP1_MOVIDAColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_SP1_KM", DbType.Decimal, r[dt.SP1_KMColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_SP2_MOVIDA", DbType.Decimal, r[dt.SP2_MOVIDAColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_SP2_KM", DbType.Decimal, r[dt.SP2_KMColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_PS1_MOVIDA", DbType.Decimal, r[dt.PS1_MOVIDAColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_PS1_KM", DbType.Decimal, r[dt.PS1_KMColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_PS2_MOVIDA", DbType.Decimal, r[dt.PS2_MOVIDAColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_PS2_KM", DbType.Decimal, r[dt.PS2_KMColumn]));

                result = repository.ExecuteUpdateProcedure(CONST_UPDATE_PROCEDURE_NAME, paramList, r[dt.OBJECTHASHColumn].ToString()) == 1;


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


                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                Datasets.Prestadores.PRESTADORESDataTable dt = (Datasets.Prestadores.PRESTADORESDataTable)r.Table;


                /*
                 *  P_ID OUT PRESTADORES.idPRESTADOR%TYPE,
                    P_NOMBRE IN PRESTADORES.nombre%TYPE,
                    P_DESCRIPCION IN PRESTADORES.descripcion%TYPE,
                    P_ESTADO IN PRESTADORES.estado%TYPE,
                    P_OBJECTHASH IN PRESTADORES.objecthash%TYPE,
                    P_TELEFONO1 IN PRESTADORES.TELEFONO1%TYPE,
                    P_TELEFONO2 IN PRESTADORES.TELEFONO2%TYPE,
                    P_CELULAR1 IN PRESTADORES.CELULAR1%TYPE,
                    P_CELULAR2 IN PRESTADORES.CELULAR2%TYPE,
                    P_NEXTEL IN PRESTADORES.NEXTEL%TYPE,
                    P_DOMICILIO IN PRESTADORES.DOMICILIO%TYPE,
                    P_IDCIUDAD IN PRESTADORES.IDCIUDAD%TYPE,
                    P_IDPROVINCIA IN PRESTADORES.IDPROVINCIA%TYPE,
                    P_IDPAIS IN PRESTADORES.IDPAIS%TYPE,
                    P_EMAIL IN PRESTADORES.EMAIL%TYPE,
                    P_CUIT IN PRESTADORES.CUIT%TYPE,
                    P_IVA IN PRESTADORES.IVA%TYPE,
                    P_LIV_MOVIDA IN PRESTADORES.LIV_MOVIDA%TYPE,
                    P_LIV_KM IN PRESTADORES.LIV_KM%TYPE,
                    P_SP1_MOVIDA IN PRESTADORES.SP1_MOVIDA%TYPE,
                    P_SP1_KM IN PRESTADORES.SP1_KM%TYPE,
                    P_SP2_MOVIDA IN PRESTADORES.SP2_MOVIDA%TYPE,
                    P_SP2_KM IN PRESTADORES.SP2_KM%TYPE,
                    P_PS1_MOVIDA IN PRESTADORES.PS1_MOVIDA%TYPE,
                    P_PS1_KM IN PRESTADORES.PS1_KM%TYPE,
                    P_PS2_MOVIDA IN PRESTADORES.PS2_MOVIDA%TYPE,
                    P_PS2_KM IN PRESTADORES.PS2_KM%TYPE
                 * 
                 * 
                 */

                paramList.Add(repository.DbFactory.getDataParameter("P_NOMBRE", DbType.String, r[dt.NOMBREColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_DESCRIPCION", DbType.String, r[dt.DESCRIPCIONColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_ESTADO", DbType.Int32, Int32.Parse(r[dt.ESTADOColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_TELEFONO1", DbType.String, r[dt.TELEFONO1Column]));
                paramList.Add(repository.DbFactory.getDataParameter("P_TELEFONO2", DbType.String, r[dt.TELEFONO2Column]));
                paramList.Add(repository.DbFactory.getDataParameter("P_CELULAR1", DbType.String, r[dt.CELULAR1Column]));
                paramList.Add(repository.DbFactory.getDataParameter("P_CELULAR2", DbType.String, r[dt.CELULAR2Column]));
                paramList.Add(repository.DbFactory.getDataParameter("P_NEXTEL", DbType.String, r[dt.NEXTELColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_DOMICILIO", DbType.String, r[dt.DOMICILIOColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDCIUDAD", DbType.Int32, Int32.Parse(r[dt.IDCIUDADColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPROVINCIA", DbType.Int32, Int32.Parse(r[dt.IDPROVINCIAColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPAIS", DbType.Int32, Int32.Parse(r[dt.IDPAISColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("p_IDLOCALIDAD", DbType.Int32, Int32.Parse(r[dt.IDLOCALIDADColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_EMAIL", DbType.String, r[dt.EMAILColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_CUIT", DbType.String, r[dt.CUITColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_IVA", DbType.String, r[dt.IVAColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_LIV_MOVIDA", DbType.Decimal, r[dt.LIV_MOVIDAColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_LIV_KM", DbType.Decimal, r[dt.LIV_KMColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_SP1_MOVIDA", DbType.Decimal, r[dt.SP1_MOVIDAColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_SP1_KM", DbType.Decimal, r[dt.SP1_KMColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_SP2_MOVIDA", DbType.Decimal, r[dt.SP2_MOVIDAColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_SP2_KM", DbType.Decimal, r[dt.SP2_KMColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_PS1_MOVIDA", DbType.Decimal, r[dt.PS1_MOVIDAColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_PS1_KM", DbType.Decimal, r[dt.PS1_KMColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_PS2_MOVIDA", DbType.Decimal, r[dt.PS2_MOVIDAColumn]));
                paramList.Add(repository.DbFactory.getDataParameter("P_PS2_KM", DbType.Decimal, r[dt.PS2_KMColumn]));



                result = repository.ExecuteCreateProcedure(CONST_CREATE_PROCEDURE_NAME, paramList, r[dt.OBJECTHASHColumn].ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public override DataSet List(Filter f, out int RecordCount)
        {
            DataSet ds = new DataSet();

            try
            {
                FiltroPrestador filtro = (FiltroPrestador)f;
                DBRepository repository = DBRepository.GetDbRepository();

                List<IDbDataParameter> paramlist = new List<IDbDataParameter>();

                paramlist.Add(repository.DbFactory.getDataParameter("P_ID_PRESTADOR", DbType.Int32, filtro.ID));
                paramlist.Add(repository.DbFactory.getDataParameter("P_NOMBRE", DbType.String, filtro.Nombre));
                paramlist.Add(repository.DbFactory.getDataParameter("P_DESCRIPCION", DbType.String, filtro.Descripcion));
                paramlist.Add(repository.DbFactory.getDataParameter("P_ESTADO", DbType.Int32, filtro.ESTADO));
                paramlist.Add(repository.DbFactory.getDataParameter("P_ID_PAIS", DbType.Int32, filtro.IdPais));
                paramlist.Add(repository.DbFactory.getDataParameter("P_ID_PROVINCA", DbType.Int32, filtro.IdProvincia));
                paramlist.Add(repository.DbFactory.getDataParameter("P_LOCALIDAD_NOMBRE", DbType.String, filtro.Localidad));
                paramlist.Add(repository.DbFactory.getDataParameter("P_SEARCH", DbType.String, filtro.Search));

                repository.ExecuteListProcedure(CONST_LIST_PROCEDURE_NAME, paramlist, f, ds, out RecordCount);


            }
            catch(Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        #endregion Metodos
    }
}
