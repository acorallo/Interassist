using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository.Interfaces;
using Cognitas.Framework.Repository;
using DAL.InterAssist.Datasets;
using DAL.InterAssist;
using System.Data;
using Utils.InterAssist;

namespace Entities.InterAsisst
{
    public class Ticket : PersistEntity, IRepository
    {

        #region Constantes

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores

        public Ticket()
        {

        }

        public Ticket(int id, string objectHash)
        {
            this._id = id;
            this._UObjectID = objectHash;
        }

        #endregion Constructores

        #region Miembros de Entidad

        private int _idOperador;

        public int IDOperador
        {
          get { return _idOperador; }
          set
          { _idOperador = value; }
        }
        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private int _idPaisOrigen;

        public int IdPaisOrigen
        {
            get { return _idPaisOrigen; }
            set { _idPaisOrigen = value; }
        }
        private int _idAfiliado;

        public int IdAfiliado
        {
            get { return _idAfiliado; }
            set { _idAfiliado = value; }
        }
        private int _idPrestador;

        public int IdPrestador
        {
            get { return _idPrestador; }
            set { _idPrestador = value; }
        }
        private string _telefono;

        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        private int _idEstado;

        public int IdEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }

        private int _idProvinciaOrigen;

        public int IdProvinciaOrigen
        {
            get { return _idProvinciaOrigen; }
            set { _idProvinciaOrigen = value; }
        }
        private int _idCiudadOrigen;

        public int IdCiudadOrigen
        {
            get { return _idCiudadOrigen; }
            set { _idCiudadOrigen = value; }
        }
        private int _idLocalidadOrigen;

        public int IdLocalidadOrigen
        {
            get { return _idLocalidadOrigen; }
            set { _idLocalidadOrigen = value; }
        }
        private int _idPaisDestino;

        public int IdPaisDestino
        {
            get { return _idPaisDestino; }
            set { _idPaisDestino = value; }
        }
        private int _idProvinciaDestino;

        public int IdProvinciaDestino
        {
            get { return _idProvinciaDestino; }
            set { _idProvinciaDestino = value; }
        }
        private int _idCiudadDestino;

        public int IdCiudadDestino
        {
            get { return _idCiudadDestino; }
            set { _idCiudadDestino = value; }
        }
        private int _idLocalidadDestino;

        public int IdLocalidadDestino
        {
            get { return _idLocalidadDestino; }
            set { _idLocalidadDestino = value; }
        }

        private string _calle_origen;

        public string CalleOrigen
        {
            get { return _calle_origen; }
            set { _calle_origen = value; }
        }

        private string _altura_origen;

        public string AlturaOrigen
        {
            get { return _altura_origen; }
            set { _altura_origen = value; }
        }

        private string _calle_destino;

        public string CalleDestino
        {
            get { return _calle_destino; }
            set { _calle_destino = value; }
        }

        private string _altura_destino;

        public string AlturaDestino
        {
            get { return _altura_destino; }
            set { _altura_destino = value; }
        }

        private int _idProblema;

        public int IdProblema
        {
            get { return _idProblema; }
            set { _idProblema = value; }
        }

        private Observacion _observacion;

        public Observacion Observacion
        {
            get { return _observacion; }
            set { _observacion = value; }
        }

        private string _poliza;

        public string Poliza
        {
            get { return _poliza; }
            set { _poliza = value; }
        }

        private string _nombrePrestador;

        public string NombrePrestador
        {
            get { return _nombrePrestador; }
            set { _nombrePrestador = value; }
        }

        private string _patente;

        public string Patente
        {
            get { return _patente; }
            set { _patente = value; }
        }

        private string _nombreOperador;

        public string NombreOperador
        {
            get { return _nombreOperador; }
            set { _nombreOperador = value; }
        }

        private string _problema;

        public string Problema
        {
            get { return _problema; }
            set { _problema = value; }
        }

        private string _nombreEmpresa;

        public string NombreEmpresa
        {
            get { return _nombreEmpresa; }
            set { _nombreEmpresa = value; }
        }

        private string _nombreAfiliado;

        public string NombreAfiliado
        {
            get { return _nombreAfiliado; }
            set { _nombreAfiliado = value; }
        }

        private string _tipoTicket = string.Empty;

        public string TipoTicket
        {
            get { return _tipoTicket; }
            set { _tipoTicket = value; }
        }

        private int _idTipoServicio;

        public int IdTipoServicio
        {
            get { return _idTipoServicio; }
            set { _idTipoServicio = value; }
        }

        private string _nombreLocalidadOrigen;

        public string NombreLocalidadOrigen
        {
            get { return _nombreLocalidadOrigen; }
            set { _nombreLocalidadOrigen = value; }
        }
        private string _nombreLocalidadDestino;

        public string NombreLocalidadDestino
        {
            get { return _nombreLocalidadDestino; }
            set { _nombreLocalidadDestino = value; }
        }
        private string _modelo;

        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }
        private string _marca;

        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }
        

        private List<Observacion> _observacionesHistorica = new List<Observacion>();

        public List<Observacion> ObservacionesHistoricas
        {
            get
            {
                return this._observacionesHistorica;
            }
            set
            {
                this._observacionesHistorica = value;
            }
        }
        

        #endregion Miembros de Entidad

        #region Miembros

        private Operador _operador = null;

        public Operador Operador
        {
            get {

                if (this._operador == null && this.IDOperador > 0)
                {
                    this._operador = Operador.GetById(this.IDOperador);
                }

                return _operador; 
            }
            
        }

        #endregion Miembros

        #region Propiedades

        #endregion Propiedades

        #region Metodos

        public static List<Ticket> List(FiltroTicket f)
        {
            int r;
            return List(f, out r);
        }

        public static List<Ticket> List(FiltroTicket f, out int RecordCount)
        {
            List<Ticket> resultList = new List<Ticket>();

            try
            {
                TicketDS dataservice = new TicketDS();
                DataSet ds = dataservice.List(f, out RecordCount);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Ticket t = new Ticket();
                        ORM(t, r);
                        resultList.Add(t);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultList;
        }
        
        public static Ticket GetById(int id)
        {
         
            Ticket ticketResult = null;

            try
            {
                TicketDS ticketDS = new TicketDS();
                String objectHash = Guid.NewGuid().ToString();
                DataRow dr = ticketDS.GetObjectById(id, objectHash);

                if (dr != null)
                {
                    ticketResult = new Ticket();
                    ticketResult._UObjectID = objectHash;
                    ORM(ticketResult, dr);

                    ticketResult.ObservacionesHistoricas = Observacion.ListByTicket(ticketResult.ID);
                    

                }

                

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ticketResult;
         
        }

        public bool HasChange()
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            throw new NotImplementedException();

        }

        public override Dataservices getDataService()
        {
            return new TicketDS();
        }

        public override DataRow ObjectToRow()
        {
            
            Tickets.TICKETSRow resultRow = new Tickets.TICKETSDataTable().NewTICKETSRow();


            resultRow.IDTICKET = this.ID;
            resultRow.IDOPERADOR = this.IDOperador;
            resultRow.IDPAIS_ORIGEN = this.IdPaisOrigen;
            resultRow.IDAFILIADO = this.IdAfiliado;
            resultRow.IDPRESTADOR = this.IdPrestador;
            resultRow.TELEFONO = this.Telefono;
            resultRow.IDESTADO = this.IdEstado;
            resultRow.IDPAIS_DESTINO = this.IdPaisDestino;
            resultRow.IDPROVINCIA_ORIGEN = this.IdProvinciaOrigen;
            resultRow.IDPROVINCIA_DESTINO = this.IdProvinciaDestino;
            resultRow.IDCIUDAD_ORIGEN = this.IdCiudadOrigen;
            resultRow.IDCIUDAD_DESTINO = this.IdCiudadDestino;
            resultRow.IDLOCALIDAD_DESTINO = this.IdLocalidadDestino;
            resultRow.IDLOCALIDAD_ORIGEN = this.IdLocalidadOrigen;
            resultRow.CALLE_ORIGEN = this.CalleOrigen;
            resultRow.ALTURA_ORIGEN = this.AlturaOrigen;
            resultRow.CALLE_DESTINO = this.CalleDestino;
            resultRow.ALTURA_DESTINO = this.AlturaDestino;
            resultRow.OBJECTHASH = this.UObjectID;
            resultRow.IDPROBLEMA = this.IdProblema;
            resultRow.TIPO_TICKET = this.TipoTicket;
            resultRow.IDTIPOSERVICIO = this.IdTipoServicio;

            return resultRow;
        }

        public static void ORM(Ticket ticket, DataRow dr)
        {
            ticket._id = Int32.Parse(dr[TicketDS.COL_IDTICKET].ToString());
            ticket._idOperador = Int32.Parse(dr[TicketDS.COL_IDOPERADOR].ToString());
            ticket._idPaisOrigen = PersistEntity.NuleableInt(dr[TicketDS.COL_IDPAIS_ORIGEN].ToString());
            ticket._idAfiliado = Int32.Parse(dr[TicketDS.COL_IDAFILIADO].ToString());
            ticket._idPrestador = PersistEntity.NuleableInt(dr[TicketDS.COL_IDPRESTADOR].ToString());
            ticket._telefono = dr[TicketDS.COL_TELEFONO].ToString();
            ticket._idEstado = Int32.Parse(dr[TicketDS.COL_IDESTADO].ToString());
            ticket._idPaisDestino = PersistEntity.NuleableInt(dr[TicketDS.COL_IDPAIS_DESTINO].ToString());
            ticket._idProvinciaDestino = PersistEntity.NuleableInt(dr[TicketDS.COL_IDPROVINCIA_DESTINO].ToString());
            ticket._idProvinciaOrigen = PersistEntity.NuleableInt(dr[TicketDS.COL_IDPROVINCIA_ORIGEN].ToString());
            ticket._idCiudadOrigen = PersistEntity.NuleableInt(dr[TicketDS.COL_IDCIUDAD_ORIGEN].ToString());
            ticket._idCiudadDestino = PersistEntity.NuleableInt(dr[TicketDS.COL_IDCIUDAD_DESTINO].ToString());
            ticket._idLocalidadDestino = PersistEntity.NuleableInt(dr[TicketDS.COL_IDLOCALIDAD_DESTINO].ToString());
            ticket._idLocalidadOrigen = PersistEntity.NuleableInt(dr[TicketDS.COL_IDLOCALIDAD_ORIGEN].ToString());
            ticket._calle_origen = dr[TicketDS.COL_CALLE_ORIGEN].ToString();
            ticket._altura_origen = dr[TicketDS.COL_ALTURA_ORIGEN].ToString();
            ticket._calle_destino = dr[TicketDS.COL_CALLE_DESTINO].ToString();
            ticket._altura_destino = dr[TicketDS.COL_ALTURA_DESTINO].ToString();
            ticket._fecha = (DateTime)dr[TicketDS.COL_FECHA];
            ticket._idProblema = Int32.Parse(dr[TicketDS.COL_ID_PROBLEMA].ToString());
            ticket._idTipoServicio = Int32.Parse(dr[TicketDS.COL_IDTIPOSERVICIO].ToString());
            // Columnas para el listado.
            ticket._patente = dr[TicketDS.COL_PATENTE].ToString();
            ticket._poliza = dr[TicketDS.COL_POLIZA].ToString();
            ticket._nombrePrestador = dr[TicketDS.COL_NOMBRE_PRESTADOR].ToString();
            ticket._nombreOperador = dr[TicketDS.COL_NOMBRE_OPERADOR].ToString();
            ticket._problema = dr[TicketDS.COL_PROBLEMA].ToString();
            ticket._nombreEmpresa = dr[TicketDS.COL_NOMBRE_EMPRESA].ToString();
            ticket._nombreAfiliado = dr[TicketDS.COL_NOMBRE_AFILIADO].ToString();
            ticket._tipoTicket = dr[TicketDS.COL_TIPO_TICKET].ToString();
            ticket._nombreLocalidadOrigen = dr[TicketDS.COL_LOCALIDAD_ORIGEN_NOMBRE].ToString();
            ticket._nombreLocalidadDestino = dr[TicketDS.COL_LOCALIDAD_DESTINO_NOMBRE].ToString();
            ticket._marca = dr[TicketDS.COL_MARCA].ToString();
            ticket._modelo = dr[TicketDS.COL_MODELO].ToString();
            

        }

        public override bool Persist()
        {
            bool result = false;

            try
            {

                TicketDS dataservice = new TicketDS();

                if (this.Observacion == null)
                    throw new Exception("El objeto ticket debe tener una observación");

                if (this.IsNew)
                {


                    this._id = dataservice.Create(this.ObjectToRow(), this.Observacion.ObjectToRow());
                    result = true;
                }
                else
                {
                    result = dataservice.Update(this.ObjectToRow(), this.Observacion.ObjectToRow());
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        #endregion Metodos

    }
}
