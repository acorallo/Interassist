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

        // Nombre de los procediminentos
        private const string CONST_GET_BY_ID_PROCEDURE_NAME = "TICKET_PKG.GET_TICKET_BY_ID";
        private const string CONST_UPDATE_PROCEDURE_NAME = "TICKET_PKG.MODIFY_TICKET";
        private const string CONST_CREATE_PROCEDURE_NAME = "TICKET_PKG.CREATE_TICKET";
        private const string CONST_LIST_PROCEDURE_NAME = "TICKET_PKG.LIST_TICKET";

        private const string CONST_DELETE_TICKET_PRESTADOR_PROCEDURE_NAME = "TICKET_PKG.DELETE_TICKET_PRESTADOR";
        private const string CONST_DELETE_PRESTADOR_BY_TICKET_PROCEDURE_NAME = "TICKET_PKG.DELETE_PRESTADOR_BY_TICKET";
        private const string CONST_CREATE_TICKET_PRESTADOR_PROCEDURE_NAME = "TICKET_PKG.CREATE_TICKET_PRESTADOR";
        private const string CONST_UPDATTE_TICKET_PRESTADOR_PROCEDURE_NAME = "TICKET_PKG.MODIFY_TICKET_PRESTADOR";

        private const string CONST_LIST_PROSTADORES_PROCEDURE_NAME = "TICKET_PKG.LIST_PRESTADORES_BY_TICKET";

        private const string CONST_LIST_TICKET_TRACK_PROCEDURE_NAME = "TICKET_PKG.LIST_TICKET_TRACK_BY_TICKET";
        private const string CONST_CREATE_TICKET_TRACK_PROCEDURE_NAME = "TICKET_PKG.CREATE_TICKET_TRACK";



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
        public const string COL_CALLE_ORIGEN = "CALLE_ORIGEN";
        public const string COL_OBJECTHASH = "OBJECTHASH";
        public const string COL_ID_PROBLEMA = "IDPROBLEMA";
        public const string COL_TIPO_TICKET = "TIPO_TICKET";
        public const string COL_IDTIPOSERVICIO = "IDTIPOSERVICIO";
        public const string COL_LOCALIDAD_ORIGEN_NOMBRE = "LOCALIDAD_ORIGEN_NOMBRE";
        public const string COL_LOCALIDAD_DESTINO_NOMBRE = "LOCALIDAD_DESTINO_NOMBRE";
        public const string COL_MARCA = "MARCA";
        public const string COL_MODELO = "MODELO";
        public const string COL_KILOMETROS = "KILOMETROS";
        public const string COL_COSTO = "COSTO";

        public const string COL_IDTICKETPRESTADOR = "IDTICKETPRESTADOR";
        public const string COL_IDPROBLEMA = "IDPROBLEMA";
        public const string COL_IDTICKETPRESTADOR_RETRABAJO = "IDTICKETPRESTADOR_RETRABAJO";
        public const string COL_NOMBRE_CHOFER = "NOMBRE_CHOFER";
        public const string COL_OKAFILIADO = "OKAFILIADO";
        public const string COL_CANT_TICKETS_AFIL = "CANT_TICKETS_AFIL";
        public const string COL_ESTADO = "ESTADO";

        public const string COL_IDCOLOR = "IDCOLOR";
        public const string COL_UBICACION_DESCR = "UBICACION_DESCR";
        public const string COL_DEMORA_EST = "DEMORA_EST";

        public const string COL_DEMORA_REAL = "DEMORA_REAL";
        public const string COL_IDTIPOPRESTACION = "IDTIPOPRESTACION";

        public const string COL_CODIGO_TIPOPRESTACION = "CODIGO_TIPOPRESTACION";


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

       public int Create(DataRow r, DataRow observacion, Datasets.Ticket_Prestador.TICKET_PRESTADORESDataTable Prestadores, int idOperadorTrack)
        {
            int result = 0;

            DBRepository repository = DBRepository.GetDbRepository(true);

            repository.BeginTransaction();

            try
            {
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
                paramList.Add(repository.DbFactory.getDataParameter("P_TELEFONO", DbType.String, dr[dtable.TELEFONOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDESTADO", DbType.Int32, Int32.Parse(dr[dtable.IDESTADOColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_CALLE_ORIGEN", DbType.String, dr[dtable.CALLE_ORIGENColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_CALLE_DESTINO", DbType.String, dr[dtable.CALLE_DESTINOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDLOCALIDA_ORIGEN", DbType.Int32, Dataservices.IntNUlleable((Int32.Parse(dr[dtable.IDLOCALIDAD_ORIGENColumn].ToString())))));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDLOCALIDA_DESTINO", DbType.Int32, Dataservices.IntNUlleable((Int32.Parse(dr[dtable.IDLOCALIDAD_DESTINOColumn].ToString())))));
                paramList.Add(repository.DbFactory.getDataParameter("P_TIPO_TICKET", DbType.String, dr[dtable.TIPO_TICKETColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_OKAFILIADO", DbType.String, dr[dtable.OKAFILIADOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_CANT_TICKETS_AFIL", DbType.Int32, Dataservices.IntNUlleable((Int32.Parse(dr[dtable.CANT_TICKETS_AFILColumn].ToString())))));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDCOLOR", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDCOLORColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPROBLEMA", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDPROBLEMAColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_UBICACION_DESCR", DbType.String, dr[dtable.UBICACION_DESCRColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_DEMORA_EST", DbType.String, dr[dtable.DEMORA_ESTColumn].ToString()));

                result = repository.ExecuteCreateProcedure(CONST_CREATE_PROCEDURE_NAME, paramList, dr[dtable.OBJECTHASHColumn].ToString());
                
                if (observacion != null)
                {
                    DBRepository repositoryObservacion = DBRepository.GetDbRepository(repository);

                    ObservacionDS dsObservaciones = new ObservacionDS();
                    Datasets.Observaciones.OBSERVACIONESRow obs = (Datasets.Observaciones.OBSERVACIONESRow)observacion;
                    obs.IDTICKET = result;

                    dsObservaciones.Create(obs, repositoryObservacion);
                } 

                // Persiste los prestadores asociados.
                this.PersistPrestadores(result, Prestadores, repository);

                this.Insert_Ticket_Track(repository, result, idOperadorTrack, Int32.Parse(dr[dtable.IDESTADOColumn].ToString()));

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

        public bool Update(DataRow r, DataRow observacion, Datasets.Ticket_Prestador.TICKET_PRESTADORESDataTable Prestadores, int idOperadorTrack)
        {
            bool result = false;

            DBRepository repository = DBRepository.GetDbRepository(true);

            repository.BeginTransaction();

            try
            {

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();

                Datasets.Tickets.TICKETSDataTable dtable = (Datasets.Tickets.TICKETSDataTable)r.Table;
                Datasets.Tickets.TICKETSRow dr = (Datasets.Tickets.TICKETSRow)r;

                int idTicketToUpdate = Int32.Parse(dr[dtable.IDTICKETColumn].ToString());

                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, Int32.Parse(dr[dtable.IDTICKETColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDOPERADOR", DbType.Int32, Int32.Parse(dr[dtable.IDOPERADORColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDAFILIADO", DbType.Int32, Int32.Parse(dr[dtable.IDAFILIADOColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_PAIS_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDPAIS_ORIGENColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_PROV_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDPROVINCIA_ORIGENColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_CIUDAD_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDCIUDAD_ORIGENColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_PAIS_DEST", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDPAIS_DESTINOColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_PROV_DEST", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDPROVINCIA_DESTINOColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_CIUDAD_DEST", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDCIUDAD_DESTINOColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_TELEFONO", DbType.String, dr[dtable.TELEFONOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDESTADO", DbType.Int32, Int32.Parse(dr[dtable.IDESTADOColumn].ToString())));
                paramList.Add(repository.DbFactory.getDataParameter("P_CALLE_ORIGEN", DbType.String, dr[dtable.CALLE_ORIGENColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_CALLE_DESTINO", DbType.String, dr[dtable.CALLE_DESTINOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_LOCALIDAD_DESTINO", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDLOCALIDAD_DESTINOColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_ID_LOCALIDAD_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDLOCALIDAD_ORIGENColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_TIPO_TICKET", DbType.String, dr[dtable.TIPO_TICKETColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_OKAFILIADO", DbType.String, dr[dtable.OKAFILIADOColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_CANT_TICKETS_AFIL", DbType.Int32, Dataservices.IntNUlleable((Int32.Parse(dr[dtable.CANT_TICKETS_AFILColumn].ToString())))));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDCOLOR", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDCOLORColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPROBLEMA", DbType.Int32, Dataservices.IntNUlleable(Int32.Parse(dr[dtable.IDPROBLEMAColumn].ToString()))));
                paramList.Add(repository.DbFactory.getDataParameter("P_UBICACION_DESCR", DbType.String, dr[dtable.UBICACION_DESCRColumn].ToString()));
                paramList.Add(repository.DbFactory.getDataParameter("P_DEMORA_EST", DbType.String, dr[dtable.DEMORA_ESTColumn].ToString()));

                result = (repository.ExecuteUpdateProcedure(CONST_UPDATE_PROCEDURE_NAME, paramList, dr[dtable.OBJECTHASHColumn].ToString()) == 1);

                if (observacion != null)
                {
                    // Guardar Observaciones.
                    DBRepository repositoryObservacion = DBRepository.GetDbRepository(repository);
                    ObservacionDS dataserviceObservacion = new ObservacionDS();

                    Datasets.Observaciones.OBSERVACIONESRow obs = (Datasets.Observaciones.OBSERVACIONESRow)observacion;
                    obs.IDTICKET = Int32.Parse(dr[dtable.IDTICKETColumn].ToString());

                    dataserviceObservacion.Create(obs);
                } 

                this.PersistPrestadores(idTicketToUpdate, Prestadores, repository);

                this.Insert_Ticket_Track(repository, Int32.Parse(dr[dtable.IDTICKETColumn].ToString()), idOperadorTrack, Int32.Parse(dr[dtable.IDESTADOColumn].ToString()));

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
                repository.RollbackTransaction();
                throw ex;
            }


            return result;
        }

        private void PersistPrestadores(int idTicketAsociado, Datasets.Ticket_Prestador.TICKET_PRESTADORESDataTable Prestadores, DBRepository repository)
        {
            foreach (Datasets.Ticket_Prestador.TICKET_PRESTADORESRow r in Prestadores)
            {

                if (r.PERSISTOPERATION != (int)Utils.InterAssist.Constants.PersistOperationType.Void)
                {
                    // Si es distinto de void hace una actualización en la base de datos.
                    if (r.PERSISTOPERATION == (int)Utils.InterAssist.Constants.PersistOperationType.Persist)
                    {
                        if (r.IDTICKETPRESTADOR == NULL_INT)
                        {
                            Insert_Proveedor_Ticket(repository, idTicketAsociado, r, "ObjectHash");
                        }
                        else
                        {
                            Update_Proveedor_Ticket(repository, r, "ObjectHash");
                        }
                    }
                    else
                    {
                        if (r.PERSISTOPERATION == ((int)Utils.InterAssist.Constants.PersistOperationType.Delete))
                        {
                            Delete_Proveedor_Ticket(r.IDTICKETPRESTADOR, repository);
                        }
                    }

                }

            }
        }


        public DataSet List_PrestadoresByTicket(int idTicket)
        {
            DataSet resultSet = new DataSet();

            try
            {

                DBRepository repository = DBRepository.GetDbRepository();

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();

                paramList.Add(repository.DbFactory.getDataParameter("P_IDTICKET", DbType.Int32, idTicket));

                repository.ExecuteProcedure(CONST_LIST_PROSTADORES_PROCEDURE_NAME, paramList, resultSet);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultSet;
        }

        public bool Delete_Proveedores_By_Ticket(int idTicket)
        {
            bool result = false;

            try
            {
                DBRepository repository = DBRepository.GetDbRepository();
                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                paramList.Add(repository.DbFactory.getDataParameter("P_IDTICKET", DbType.Int32, idTicket));
                result = repository.ExecuteNonQueryProcedure(CONST_DELETE_PRESTADOR_BY_TICKET_PROCEDURE_NAME, paramList);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool Delete_Proveedor_Ticket(int idTicketProveedor, DBRepository repository)
        {
            bool result = false;

            try
            {

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, idTicketProveedor));
                result = repository.ExecuteNonQueryProcedure(CONST_DELETE_TICKET_PRESTADOR_PROCEDURE_NAME, paramList);

                result = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public bool Update_Proveedor_Ticket(DBRepository repository, Datasets.Ticket_Prestador.TICKET_PRESTADORESRow r, string ObjectHash)
        {
            bool result = false;

            try
            {
                List<IDbDataParameter> paramList = new List<IDbDataParameter>();

                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, Dataservices.IntNUlleable(r.IDTICKETPRESTADOR)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDTICKET", DbType.Int32, Dataservices.IntNUlleable(r.IDTICKET)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPRESTADOR", DbType.Int32, Dataservices.IntNUlleable(r.IDPRESTADOR)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDTIPOSERVICIO", DbType.Int32, Dataservices.IntNUlleable(r.IDTIPOSERVICIO)));
                paramList.Add(repository.DbFactory.getDataParameter("P_COMENTARIOS", DbType.String, r.COMENTARIOS));
                paramList.Add(repository.DbFactory.getDataParameter("P_KILOMETROS", DbType.Decimal, r.KILOMETROS));
                paramList.Add(repository.DbFactory.getDataParameter("P_COSTO", DbType.Decimal, r.COSTO));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPAIS_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(r.IDPAIS_ORIGEN)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPAIS_DESTINO", DbType.Int32, Dataservices.IntNUlleable(r.IDPAIS_DESTINO)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPROVINCIA_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(r.IDPROVINCIA_ORIGEN)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPROVINCIA_DESTINO", DbType.Int32, Dataservices.IntNUlleable(r.IDPROVINCIA_DESTINO)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDCIUDAD_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(r.IDCIUDAD_ORIGEN)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDCIUDAD_DESTINO", DbType.Int32, Dataservices.IntNUlleable(r.IDCIUDAD_DESTINO)));
                paramList.Add(repository.DbFactory.getDataParameter("P_CALLE_ORIGEN", DbType.String, r.CALLE_ORIGEN));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDLOCALIDAD_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(r.IDLOCALIDAD_ORIGEN)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDLOCALIDAD_DESTINO", DbType.Int32, Dataservices.IntNUlleable(r.IDLOCALIDAD_DESTINO)));
                paramList.Add(repository.DbFactory.getDataParameter("P_CALLE_DESTINO", DbType.String, r.CALLE_DESTINO));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDESTADO", DbType.Int32, Dataservices.IntNUlleable(r.IDESTADO)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDTICKETPRESTADOR_RETRABAJO", DbType.Int32, Dataservices.IntNUlleable(r.IDTICKETPRESTADOR_RETRABAJO)));
                paramList.Add(repository.DbFactory.getDataParameter("P_PATENTE", DbType.String, r.PATENTE));
                paramList.Add(repository.DbFactory.getDataParameter("P_NOMBRE_CHOFER", DbType.String, r.NOMBRE_CHOFER));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDFINALIZACION", DbType.Int32, Dataservices.IntNUlleable(r.IDFINALIZACION)));
                paramList.Add(repository.DbFactory.getDataParameter("P_DEMORA_EST", DbType.String, r.DEMORA_EST));
                paramList.Add(repository.DbFactory.getDataParameter("P_DEMORA_REAL", DbType.String, r.DEMORA_REAL));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDTIPOPRESTACION", DbType.Int32, Dataservices.IntNUlleable(r.IDTIPOPRESTACION)));

                repository.ExecuteUpdateProcedure(CONST_UPDATTE_TICKET_PRESTADOR_PROCEDURE_NAME, paramList, ObjectHash);

                result = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return result;
        }

        public int Insert_Proveedor_Ticket(DBRepository repository, Int32 idTicket, Datasets.Ticket_Prestador.TICKET_PRESTADORESRow r, string ObjectHash)
        {
            int resultID = -1;

            try
            {
                List<IDbDataParameter> paramList = new List<IDbDataParameter>();

                paramList.Add(repository.DbFactory.getDataParameter("P_IDTICKET", DbType.Int32, r.IDTICKET));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPRESTADOR", DbType.Int32, Dataservices.IntNUlleable(r.IDPRESTADOR)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDTIPOSERVICIO", DbType.Int32, Dataservices.IntNUlleable(r.IDTIPOSERVICIO)));
                paramList.Add(repository.DbFactory.getDataParameter("P_COMENTARIOS", DbType.String, r.COMENTARIOS));
                paramList.Add(repository.DbFactory.getDataParameter("P_KILOMETROS", DbType.Decimal, r.KILOMETROS));
                paramList.Add(repository.DbFactory.getDataParameter("P_COSTO", DbType.Decimal, r.COSTO));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPAIS_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(r.IDPAIS_ORIGEN)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPAIS_DESTINO", DbType.Int32, Dataservices.IntNUlleable(r.IDPAIS_DESTINO)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPROVINCIA_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(r.IDPROVINCIA_ORIGEN)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDPROVINCIA_DESTINO", DbType.Int32, Dataservices.IntNUlleable(r.IDPROVINCIA_DESTINO)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDCIUDAD_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(r.IDCIUDAD_ORIGEN)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDCIUDAD_DESTINO", DbType.Int32, Dataservices.IntNUlleable(r.IDCIUDAD_DESTINO)));
                paramList.Add(repository.DbFactory.getDataParameter("P_CALLE_ORIGEN", DbType.String, r.CALLE_ORIGEN));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDLOCALIDAD_ORIGEN", DbType.Int32, Dataservices.IntNUlleable(r.IDLOCALIDAD_ORIGEN)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDLOCALIDAD_DESTINO", DbType.Int32, Dataservices.IntNUlleable(r.IDLOCALIDAD_DESTINO)));
                paramList.Add(repository.DbFactory.getDataParameter("P_CALLE_DESTINO", DbType.String, r.CALLE_DESTINO));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDESTADO", DbType.Int32, Dataservices.IntNUlleable(r.IDESTADO)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDTICKETPRESTADOR_RETRABAJO", DbType.Int32, Dataservices.IntNUlleable(r.IDTICKETPRESTADOR_RETRABAJO)));
                paramList.Add(repository.DbFactory.getDataParameter("P_PATENTE", DbType.String, r.PATENTE));
                paramList.Add(repository.DbFactory.getDataParameter("P_NOMBRE_CHOFER", DbType.String, r.NOMBRE_CHOFER));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDFINALIZACION", DbType.Int32, Dataservices.IntNUlleable(r.IDFINALIZACION)));
                paramList.Add(repository.DbFactory.getDataParameter("P_DEMORA_EST", DbType.String, r.DEMORA_EST));
                paramList.Add(repository.DbFactory.getDataParameter("P_DEMORA_REAL", DbType.String, r.DEMORA_REAL));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDTIPOPRESTACION", DbType.Int32, Dataservices.IntNUlleable(r.IDTIPOPRESTACION)));

                resultID = repository.ExecuteCreateProcedure(CONST_CREATE_TICKET_PRESTADOR_PROCEDURE_NAME, paramList, ObjectHash);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultID;

        }


        public int Insert_Ticket_Track(DBRepository repository, int idTicket, int idOperadorTrack, int idEstado)
        {
            int resultID = -1;

            try
            {
                List<IDbDataParameter> paramList = new List<IDbDataParameter>();

                paramList.Add(repository.DbFactory.getDataParameter("P_IDTICKET", DbType.Int32, idTicket));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDOPERADOR", DbType.Int32, Dataservices.IntNUlleable(idOperadorTrack)));
                paramList.Add(repository.DbFactory.getDataParameter("P_IDESTADO", DbType.Int32, Dataservices.IntNUlleable(idEstado)));

                resultID = repository.ExecuteCreateProcedure(CONST_CREATE_TICKET_TRACK_PROCEDURE_NAME, paramList, " ");

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultID;
        }

        public DataSet List_Ticket_TrackByTicket(int idTicket)
        {
            DataSet resultSet = new DataSet();

            try
            {

                DBRepository repository = DBRepository.GetDbRepository();

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();

                paramList.Add(repository.DbFactory.getDataParameter("P_IDTICKET", DbType.Int32, idTicket));

                repository.ExecuteProcedure(CONST_LIST_TICKET_TRACK_PROCEDURE_NAME, paramList, resultSet);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultSet;
        }


        public DataTable ObtenercasosMensuales(int anno, int mes, string poliza)
        {
            DataTable resultSet = null;


            try
            {
                DBRepository repository = DBRepository.GetDbRepository();

                string sqlQuery = "select B.POLIZA, A.TIPO_TICKET, Count(1) Cantidad, sum(Count(1)) over() TOTAL from tickets A, afiliados B where A.IDAFILIADO = B.IDAFILIADO and to_char(FECHA, 'mm') = :mes and to_char(FECHA, 'yyyy') = :anno and B.POLIZA = :poliza group by B.POLIZA, A.TIPO_TICKET order by B.POLIZA, A.TIPO_TICKET";

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();

                paramList.Add(repository.DbFactory.getDataParameter("mes", DbType.Int32, mes));
                paramList.Add(repository.DbFactory.getDataParameter("anno", DbType.Int32, anno));
                paramList.Add(repository.DbFactory.getDataParameter("poliza", DbType.String, poliza));

                DataSet ds = new DataSet();

                repository.ExecuteQueryParam(ds, sqlQuery, paramList);

                if (ds.Tables.Count > 0)
                    resultSet = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultSet;
        }


        public int ObtenercasosMensuales(int idAfiliado, int idTicket)
        {

            try
            {
                DBRepository repository = DBRepository.GetDbRepository();

                string sqlQuery = "select Count(*) Cantidad from tickets A, tickets B where A.IDAFILIADO = :idAfiliado and B.IDTICKET = :idTicket and A.FECHA <= B.FECHA and to_char(A.FECHA,'MMYYYY') = to_char(B.FECHA,'MMYYYY') and A.TIPO_TICKET = B.TIPO_TICKET and A.IDTICKET <> B.IDTICKET";

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();

                paramList.Add(repository.DbFactory.getDataParameter("idAfiliado", DbType.Int32, idAfiliado));
                paramList.Add(repository.DbFactory.getDataParameter("idTicket", DbType.Int32, idTicket));

                DataSet ds = new DataSet();

                repository.ExecuteQueryParam(ds, sqlQuery, paramList);

                if (ds.Tables.Count > 0)
                    return Convert.ToInt32(ds.Tables[0].Rows[0][0]);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 0;
        }
        #endregion Dataservices Metodos
    }
}
