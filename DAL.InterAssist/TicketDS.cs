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
    public class TicketDS : Dataservices
    {

        #region Constantes

        private const string CONST_GET_BY_ID_PROCEDURE_NAME = "TICKET_PKG.GET_TICKET_BY_ID";
        private const string CONST_UPDATE_PROCEDURE_NAME = "TICKET_PKG.MODIFY_TICKET";
        private const string CONST_CREATE_PROCEDURE_NAME = "TICKET_PKG.CREATE_TICKET";
        private const string CONST_LIST_PROCEDURE_NAME = "TICKET_PKG.LIST_TICKET";

        // Columnas de la tabla.
        public const string COL_IDTICKET = "IDTICKET";
        public const string COL_IDOPERADOR = "IDOPERADOR";
        public const string COL_FECHA = "FECHA";
        public const string COL_IDPAIS_ORIGEN = "IDPAIS_ORIGEN";
        public const string COL_IDAFILIADO = "IDAFILIADO";
        public const string COL_IDPRESTADOR = "IDPRESTADOR";
        public const string COL_TELEFONO = "TELEFONO";
        public const string COL_IDESTADO = "IDESTADO";
        public const string COL_IDPAIS_DESTINO = "IDPAIS_DESTINO";
        public const string COL_IDPROVINCIA_ORIGEN = "IDPROVINCIA_ORIGEN";
        public const string COL_IDPROVINCIA_DESTINO = "IDPROVINCIA_DESTINO";
        public const string COL_IDCIUDAD_ORIGEN = "IDCIUDAD_ORIGEN";
        public const string COL_IDCIUDAD_DESTINO = "IDCIUDAD_DESTINO";
        public const string COL_IDLOCALIDAD_ORIGEN = "IDLOCALIDAD_ORIGEN";
        public const string COL_IDLOCALIDAD_DESTINO = "IDLOCALIDAD_DESTINO";
        public const string COL_CALLE_DESTINO = "CALLE_DESTINO";
        public const string COL_ALTURA_DESTINO = "ALTURA_DESTINO";
        public const string COL_CALLE_ORIGEN = "CALLE_ORIGEN";
        public const string COL_ALTURA_ORIGEN = "ALTURA_ORIGEN";
        public const string COL_OBJECTHASH = "OBJECTHASH";
        public const string COL_ID_PROBLEMA = "IDPROBLEMA";
        public const string COL_TIPO_TICKET = "TIPO_TICKET";
        public const string COL_IDTIPOSERVICIO = "IDTIPOSERVICIO";
        public const string COL_LOCALIDAD_ORIGEN_NOMBRE = "LOCALIDAD_ORIGEN_NOMBRE";
        public const string COL_LOCALIDAD_DESTINO_NOMBRE = "LOCALIDAD_DESTINO_NOMBRE";
        public const string COL_MARCA = "MARCA";
        public const string COL_MODELO = "MODELO";


        // Otras Columnas
        public const string COL_POLIZA = "POLIZA";
        public const string COL_NOMBRE_PRESTADOR = "NOMBRE_PRESTADOR";
        public const string COL_NOMBRE_OPERADOR = "NOMBRE_OPERADOR";
        public const string COL_PROBLEMA = "PROBLEMA";
        public const string COL_PATENTE = "PATENTE";
        public const string COL_NOMBRE_EMPRESA = "NOMBRE_EMPRESA";
        public const string COL_NOMBRE_AFILIADO = "NOMBRE_AFILIADO";
    
        


        #endregion Constantes

        #region Dataservices Metodos

        public override string GET_BY_ID_PROCEDURE_NAME
        {
            get { return CONST_GET_BY_ID_PROCEDURE_NAME; }

        }

        public override string GET_DELETE_PROCEDURE_NAME
        {
            get { throw new NotImplementedException(); }
        }

        public override DataTable getMyTable()
        {
            return new Datasets.Tickets.TICKETSDataTable();
        }

        public override DataSet List(Filter f, out int RecordCount)
        {
            DataSet resultSet = new DataSet();

            try
            {
                FiltroTicket filtro = (FiltroTicket)f;
                DBRepository repository = DBRepository.GetDbRepository();

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();

                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, filtro.ID));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDOPERADOR", DbType.Int32, filtro.IDOperador));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDAFILIADO", DbType.Int32, filtro.IDAfiliado));
                paramList.Add(repository.DbFactory.getDataParameter("P_CIUDAD_ORIGEN", DbType.Int32, filtro.IDCiudadOrigen));
                paramList.Add(repository.DbFactory.getDataParameter("P_CIUDAD_DESTINO", DbType.Int32, filtro.IDCiudadDestino));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPRESTADOR", DbType.Int32, filtro.IDPrestador));
                paramList.Add(repository.DbFactory.getDataParameter("P_SEARCH", DbType.String, filtro.Search));
                

                repository.ExecuteListProcedure(CONST_LIST_PROCEDURE_NAME, paramList, f, resultSet, out RecordCount);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultSet;
        }

        public override int Create(DataRow r)
        {
            throw new NotImplementedException();
        }

        public int Create(DataRow r, DataRow observacion)
        {
            int result = 0;

            DBRepository repository = DBRepository.GetDbRepository(true);

            try
            {
                

                // Primero guarda el ticket
                repository.BeginTransaction();

                

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();

                Datasets.Tickets.TICKETSDataTable dtable = (Datasets.Tickets.TICKETSDataTable)r.Table;
                Datasets.Tickets.TICKETSRow dr = (Datasets.Tickets.TICKETSRow)r;

                paramList.Add(repository.DbFactory.getDataParameter("P_IDAFILIADO", DbType.Int32, Int32.Parse(dr[dtable.IDAFILIADOColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDOPERADOR", DbType.Int32, Int32.Parse(dr[dtable.IDOPERADORColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_PAIS_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDPAIS_ORIGENColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_PROV_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDPROVINCIA_ORIGENColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_CIUDAD_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDCIUDAD_ORIGENColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_PAIS_DESTINO", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDPAIS_DESTINOColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_PROV_DEST", DbType.Int32, Dataservices.IntNUlleable((Int32.Parse(dr[dtable.IDPROVINCIA_DESTINOColumn].ToString())))));
                paramList.Add(repository.DbFactory.getDataParameter("P_CIUDAD_DEST", DbType.Int32, Dataservices.IntNUlleable((Int32.Parse(dr[dtable.IDCIUDAD_DESTINOColumn].ToString())))));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPRESTADOR", DbType.Int32, Dataservices.IntNUlleable((Int32.Parse(dr[dtable.IDPRESTADORColumn].ToString())))));
                paramList.Add(repository.DbFactory.getDataParameter("P_TELEFONO", DbType.String, dr[dtable.TELEFONOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDESTADO", DbType.Int32, Int32.Parse(dr[dtable.IDESTADOColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_CALLE_ORIGEN", DbType.String, dr[dtable.CALLE_ORIGENColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_ALTURA_ORIGEN", DbType.String, dr[dtable.ALTURA_ORIGENColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_CALLE_DESTINO", DbType.String, dr[dtable.CALLE_DESTINOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_ALTURA_DESTINO", DbType.String, dr[dtable.ALTURA_DESTINOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDLOCALIDA_ORIGEN", DbType.Int32, Dataservices.IntNUlleable((Int32.Parse(dr[dtable.IDLOCALIDAD_ORIGENColumn].ToString())))));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDLOCALIDA_DESTINO", DbType.Int32, Dataservices.IntNUlleable((Int32.Parse(dr[dtable.IDLOCALIDAD_DESTINOColumn].ToString())))));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPROBLEMA", DbType.Int32, Int32.Parse(dr[dtable.IDPROBLEMAColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDTIPOSERVICIO", DbType.Int32, Int32.Parse(dr[dtable.IDTIPOSERVICIOColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_TIPO_TICKET", DbType.String, dr[dtable.TIPO_TICKETColumn].ToString()));

                result = repository.ExecuteCreateProcedure(CONST_CREATE_PROCEDURE_NAME, paramList, dr[dtable.OBJECTHASHColumn].ToString());


                DBRepository repositoryObservacion = DBRepository.GetDbRepository(repository);
                

                ObservacionDS dsObservaciones = new ObservacionDS();
                Datasets.Observaciones.OBSERVACIONESRow obs = (Datasets.Observaciones.OBSERVACIONESRow)observacion;
                obs.IDTICKET = result;
                    
                dsObservaciones.Create(obs, repositoryObservacion);

                repository.CommitTransaction();
                
         
            }
            catch (Exception ex)
            {
                repository.RollbackTransaction();
                throw ex;
            }

            return result;
        }

        public override bool Update(DataRow r)
        {
            throw new NotImplementedException();
        }

        public bool Update(DataRow r, DataRow observacion)
        {
            bool result = false;

            DBRepository repository = DBRepository.GetDbRepository(true);

            try
            {

                repository.BeginTransaction();

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();

                Datasets.Tickets.TICKETSDataTable dtable = (Datasets.Tickets.TICKETSDataTable)r.Table;
                Datasets.Tickets.TICKETSRow dr = (Datasets.Tickets.TICKETSRow)r;


                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, Int32.Parse(dr[dtable.IDTICKETColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDOPERADOR", DbType.Int32, Int32.Parse(dr[dtable.IDOPERADORColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDAFILIADO", DbType.Int32, Int32.Parse(dr[dtable.IDAFILIADOColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_PAIS_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDPAIS_ORIGENColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_PROV_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDPROVINCIA_ORIGENColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_CIUDAD_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDCIUDAD_ORIGENColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_PAIS_DEST", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDPAIS_DESTINOColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_PROV_DEST", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDPROVINCIA_DESTINOColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_CIUDAD_DEST", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDCIUDAD_DESTINOColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPRESTADOR", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDPRESTADORColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_TELEFONO", DbType.String, dr[dtable.TELEFONOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDESTADO", DbType.Int32, Int32.Parse(dr[dtable.IDESTADOColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_CALLE_ORIGEN", DbType.String, dr[dtable.CALLE_ORIGENColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_ALTURA_ORIGEN", DbType.String, dr[dtable.ALTURA_ORIGENColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_CALLE_DESTINO", DbType.String, dr[dtable.CALLE_DESTINOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_ALTURA_DESTINO", DbType.String, dr[dtable.ALTURA_DESTINOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_LOCALIDAD_DESTINO", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDLOCALIDAD_DESTINOColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_LOCALIDAD_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDLOCALIDAD_ORIGENColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPROBLEMA", DbType.Int32, Int32.Parse(dr[dtable.IDPROBLEMAColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDTIPOSERVICIO", DbType.Int32, Int32.Parse(dr[dtable.IDTIPOSERVICIOColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_TIPO_TICKET", DbType.String, dr[dtable.TIPO_TICKETColumn].ToString()));

                result = (repository.ExecuteUpdateProcedure(CONST_UPDATE_PROCEDURE_NAME, paramList, dr[dtable.OBJECTHASHColumn].ToString()) == 1);


                // Guardar Observaciones.
                DBRepository repositoryObservacion = DBRepository.GetDbRepository(repository);
                ObservacionDS dataserviceObservacion = new ObservacionDS();

                Datasets.Observaciones.OBSERVACIONESRow obs = (Datasets.Observaciones.OBSERVACIONESRow)observacion;
                obs.IDTICKET = Int32.Parse(dr[dtable.IDTICKETColumn].ToString());
                
                
                dataserviceObservacion.Create(obs);
                

                if (result)
                {
                    repository.CommitTransaction();
                }
                else
                {
                    repository.RollbackTransaction();
                }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        #endregion Dataservices Metodos
    }
}
