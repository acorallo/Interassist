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
using System.Globalization;

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
            : this(NULL_ID, "")
        {

        }

        public Ticket(int id, string objectHash)
        {
            this._id = id;
            this._UObjectID = objectHash;
            this.IdAfiliado = NULL_ID;
            this.IdCiudadDestino = NULL_ID;
            this.IdCiudadOrigen = NULL_ID;
            this.IdEstado = NULL_ID;
            this.IdLocalidadDestino = NULL_ID;
            this.IdLocalidadOrigen = NULL_ID;
            this.IDOperador = NULL_ID;
            this.IdPaisDestino = NULL_ID;
            this.IdPaisOrigen = NULL_ID;
            this.IdProvinciaDestino = NULL_ID;
            this.IdProvinciaOrigen = NULL_ID;
            this.CantTicketsAfil = NULL_ID;
            this.OkAfiliado = false;
            this.IdOperadorTrack = NULL_ID;
            this.IdColor = NULL_ID;
            this.IdProblema = NULL_ID;
        }

        #endregion Constructores

        #region Miembros de Entidad


        private bool _isPrestadorLoaded = false;

        public bool IsPrestadorLoaded
        {
            get { return _isPrestadorLoaded; }

        }

        private bool _isTrackingLoaded = false;

        public bool IsTrackingLoaded
        {
            get { return _isTrackingLoaded;  }
        }

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

        private string _calle_destino;

        public string CalleDestino
        {
            get { return _calle_destino; }
            set { _calle_destino = value; }
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

        private string _categoria;

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        private string _categoriaNombre;

        public string CategoriaNombre
        {
            get { return _categoriaNombre; }
            set { _categoriaNombre = value; }
        }

        private bool _okAfiliado;

        public bool OkAfiliado
        {
            get { return _okAfiliado; }
            set { _okAfiliado = value; }
        }

        private int _cantTicketsAfil;

        public int CantTicketsAfil
        {
            get { return _cantTicketsAfil; }
            set { _cantTicketsAfil = value; }
        }

        private int _idColor;

        public int IdColor
        {
            get { return _idColor; }
            set { _idColor = value; }
        }

        private int _idProblema;

        public int IdProblema
        {
            get { return _idProblema; }
            set { _idProblema = value; }
        }

        private string _ubicacionDescr;

        public string UbicacionDescr
        {
            get { return _ubicacionDescr; }
            set { this._ubicacionDescr = value; }
        }

        private string _demoraEst;

        public string DemoraEst
        {
            get { return _demoraEst; }
            set { this._demoraEst = value; }
        }


        private string _urlOrigen;

        public string UrlOrigen
        {
            get { return _urlOrigen; }
            set { this._urlOrigen= value; }
        }

        private string _urlDestino;

        public string UrlDestino
        {
            get { return _urlDestino; }
            set { this._urlDestino = value; }
        }


        private int _idOperadorTrack;

        public int IdOperadorTrack
        {
            get { return _idOperadorTrack; }
            set { _idOperadorTrack = value; }
        }

        private string _estado;

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
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

        private List<PrestadorCaso> _prestadorCaso = new List<PrestadorCaso>();

        public List<PrestadorCaso> PrestadorCaso
        {
            get
            {

                return _prestadorCaso;
            }
            set { _prestadorCaso = value; }
        }

        public Afiliado Afiliado { get; set; }

        private List<TicketTrack> _ticketTracking = new List<TicketTrack>();

        public List<TicketTrack> TicketTracking
        {
            get
            {

                return _ticketTracking;
            }
            set { _ticketTracking = value; }
        }
        #endregion Miembros de Entidad

        #region Miembros

        private Operador _operador = null;

        public Operador Operador
        {
            get
            {

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
                    ticketResult.LoadPrestadores();

                    if (ticketResult.IdAfiliado > 0)
                    {
                        ticketResult.Afiliado = Afiliado.GetById(ticketResult.IdAfiliado);
                    }
                    ticketResult.LoadTracking();
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
            resultRow.CALLE_DESTINO = this.CalleDestino;
            resultRow.OBJECTHASH = this.UObjectID;
            resultRow.TIPO_TICKET = this.TipoTicket;
            resultRow.OKAFILIADO = this.OkAfiliado ? "S" : "N";
            resultRow.CANT_TICKETS_AFIL = this.CantTicketsAfil;
            resultRow.IDCOLOR = this.IdColor;
            resultRow.IDPROBLEMA = this.IdProblema;
            resultRow.UBICACION_DESCR = this.UbicacionDescr;
            resultRow.DEMORA_EST = this.DemoraEst;
            resultRow.URL_ORIGEN = this.UrlOrigen;
            resultRow.URL_DESTINO = this.UrlDestino;

            return resultRow;
        }

        public static void ORM_PrestadorCaso(PrestadorCaso prestadorCaso, DataRow dr)
        {
            prestadorCaso.ID = Int32.Parse(dr["IDTICKETPRESTADOR"].ToString());
            prestadorCaso.IdPrestador = PersistEntity.NuleableInt(dr["IDPRESTADOR"].ToString());
            if (prestadorCaso.IdPrestador > 0)
                prestadorCaso.Prestador = Prestador.GetById(Int32.Parse(dr["IDPRESTADOR"].ToString()));

            decimal costo = 0;
            decimal kilometros = 0;

            prestadorCaso.IdTipoServicio = PersistEntity.NuleableInt(dr["IDTIPOSERVICIO"].ToString());

            if (prestadorCaso.IdTipoServicio > 0)
            {
                FiltroTipoServicio f = new FiltroTipoServicio();
                f.ID = Int32.Parse(dr["IDTIPOSERVICIO"].ToString());
                prestadorCaso.TipoServicio = TipoServicio.GetById(Int32.Parse(dr["IDTIPOSERVICIO"].ToString()));
            }

            prestadorCaso.Comentarios = dr["COMENTARIOS"].ToString();

            Decimal.TryParse(dr["COSTO"].ToString().Replace(",", "."), NumberStyles.Any, new CultureInfo("en-US"), out costo);
            Decimal.TryParse(dr["KILOMETROS"].ToString().Replace(",", "."), NumberStyles.Any, new CultureInfo("en-US"), out kilometros);

            prestadorCaso.Kilometros = kilometros;
            prestadorCaso.Costo = costo;

            prestadorCaso.IdPaisOrigen = PersistEntity.NuleableInt(dr["IDPAIS_ORIGEN"].ToString());
            prestadorCaso.IdPaisDestino = PersistEntity.NuleableInt(dr["IDPAIS_DESTINO"].ToString());
            prestadorCaso.IdProvinciaOrigen = PersistEntity.NuleableInt(dr["IDPROVINCIA_ORIGEN"].ToString());
            prestadorCaso.IdProvinciaDestino = PersistEntity.NuleableInt(dr["IDPROVINCIA_DESTINO"].ToString());
            prestadorCaso.IdCiudadOrigen = PersistEntity.NuleableInt(dr["IDCIUDAD_ORIGEN"].ToString());
            prestadorCaso.IdCiudadDestino = PersistEntity.NuleableInt(dr["IDCIUDAD_DESTINO"].ToString());
            prestadorCaso.CalleOrigen = dr["CALLE_ORIGEN"].ToString();
            prestadorCaso.IdLocalidadOrigen = PersistEntity.NuleableInt(dr["IDLOCALIDAD_ORIGEN"].ToString());
            prestadorCaso.IdLocalidadDestino = PersistEntity.NuleableInt(dr["IDLOCALIDAD_DESTINO"].ToString());
            prestadorCaso.CalleDestino = dr["CALLE_DESTINO"].ToString();
            prestadorCaso.IdEstado = PersistEntity.NuleableInt(dr["IDESTADO"].ToString());
            if (prestadorCaso.IdEstado > 0)
            {
                FiltroEstado f = new FiltroEstado("PRESTACION");
                f.ID = prestadorCaso.IdEstado;
                prestadorCaso.Estado = Entities.InterAsisst.Estado.List(f).FirstOrDefault().Descripcion;
            }
            prestadorCaso.IdTicketPrestadorRetrabajo = PersistEntity.NuleableInt(dr["IDTICKETPRESTADOR_RETRABAJO"].ToString());
            prestadorCaso.Patente = dr["PATENTE"].ToString();
            prestadorCaso.NombreChofer = dr["NOMBRE_CHOFER"].ToString();
            prestadorCaso.NombreLocalidadOrigen = dr["LOCALIDAD_ORIGEN_NOMBRE"].ToString();
            prestadorCaso.NombreLocalidadDestino = dr["LOCALIDAD_DESTINO_NOMBRE"].ToString();
            prestadorCaso.IdFinalizacion = PersistEntity.NuleableInt(dr["IDFINALIZACION"].ToString());
            prestadorCaso.DemoraEst = dr["DEMORA_EST"].ToString();
            prestadorCaso.DemoraReal = dr["DEMORA_REAL"].ToString();
            prestadorCaso.IdTipoPrestacion = PersistEntity.NuleableInt(dr["IDTIPOPRESTACION"].ToString());
            prestadorCaso.CodigoTipoPrestacion = dr["CODIGO_TIPOPRESTACION"].ToString();
        }

        public static void ORM(Ticket ticket, DataRow dr)
        {
            ticket._id = Int32.Parse(dr[TicketDS.COL_IDTICKET].ToString());
            ticket._idOperador = Int32.Parse(dr[TicketDS.COL_IDOPERADOR].ToString());
            ticket._idPaisOrigen = PersistEntity.NuleableInt(dr[TicketDS.COL_IDPAIS_ORIGEN].ToString());
            ticket._idAfiliado = PersistEntity.NuleableInt(dr[TicketDS.COL_IDAFILIADO].ToString());
            ticket._telefono = dr[TicketDS.COL_TELEFONO].ToString();
            ticket._idEstado = PersistEntity.NuleableInt(dr[TicketDS.COL_IDESTADO].ToString());
            ticket._idPaisDestino = PersistEntity.NuleableInt(dr[TicketDS.COL_IDPAIS_DESTINO].ToString());
            ticket._idProvinciaDestino = PersistEntity.NuleableInt(dr[TicketDS.COL_IDPROVINCIA_DESTINO].ToString());
            ticket._idProvinciaOrigen = PersistEntity.NuleableInt(dr[TicketDS.COL_IDPROVINCIA_ORIGEN].ToString());
            ticket._idCiudadOrigen = PersistEntity.NuleableInt(dr[TicketDS.COL_IDCIUDAD_ORIGEN].ToString());
            ticket._idCiudadDestino = PersistEntity.NuleableInt(dr[TicketDS.COL_IDCIUDAD_DESTINO].ToString());
            ticket._idLocalidadDestino = PersistEntity.NuleableInt(dr[TicketDS.COL_IDLOCALIDAD_DESTINO].ToString());
            ticket._idLocalidadOrigen = PersistEntity.NuleableInt(dr[TicketDS.COL_IDLOCALIDAD_ORIGEN].ToString());
            ticket._calle_origen = dr[TicketDS.COL_CALLE_ORIGEN].ToString();
            ticket._calle_destino = dr[TicketDS.COL_CALLE_DESTINO].ToString();
            ticket._fecha = (DateTime)dr[TicketDS.COL_FECHA];
            ticket._patente = dr[TicketDS.COL_PATENTE].ToString();
            ticket._poliza = dr[TicketDS.COL_POLIZA].ToString();
            ticket._nombreOperador = dr[TicketDS.COL_NOMBRE_OPERADOR].ToString();
            ticket._okAfiliado = dr[TicketDS.COL_OKAFILIADO].ToString() == "S" ? true : false;
            ticket._cantTicketsAfil = PersistEntity.NuleableInt(dr[TicketDS.COL_CANT_TICKETS_AFIL].ToString());
            ticket._estado = dr[TicketDS.COL_ESTADO].ToString();
            ticket._nombreEmpresa = dr[TicketDS.COL_NOMBRE_EMPRESA].ToString();
            ticket._nombreAfiliado = dr[TicketDS.COL_NOMBRE_AFILIADO].ToString();
            ticket._tipoTicket = dr[TicketDS.COL_TIPO_TICKET].ToString();
            ticket._categoria = dr[TicketDS.COL_CATEGORIA].ToString();
            ticket._categoriaNombre = dr[TicketDS.COL_CATEGORIA_NOMBRE].ToString();
            ticket._nombreLocalidadOrigen = dr[TicketDS.COL_LOCALIDAD_ORIGEN_NOMBRE].ToString();
            ticket._nombreLocalidadDestino = dr[TicketDS.COL_LOCALIDAD_DESTINO_NOMBRE].ToString();
            ticket._marca = dr[TicketDS.COL_MARCA].ToString();
            ticket._modelo = dr[TicketDS.COL_MODELO].ToString();
            ticket._idColor = PersistEntity.NuleableInt(dr[TicketDS.COL_IDCOLOR].ToString());
            ticket._idProblema = PersistEntity.NuleableInt(dr[TicketDS.COL_IDPROBLEMA].ToString());
            ticket._ubicacionDescr = dr[TicketDS.COL_UBICACION_DESCR].ToString();
            ticket._demoraEst = dr[TicketDS.COL_DEMORA_EST].ToString();
            ticket._urlOrigen = dr[TicketDS.COL_URL_ORIGEN].ToString();
            ticket._urlDestino = dr[TicketDS.COL_URL_DESTINO].ToString();
        }

        public override bool Persist()
        {
            bool result = false;

            try
            {

                TicketDS dataservice = new TicketDS();

                if (this.IsNew)
                {
                    this._id = dataservice.Create(this.ObjectToRow(), (this.Observacion != null ? this.Observacion.ObjectToRow() : null), this.GetPrestadoresTable(), this.IdOperadorTrack);
                    result = true;
                }
                else
                {
                    result = dataservice.Update(this.ObjectToRow(), (this.Observacion != null ? this.Observacion.ObjectToRow() : null), this.GetPrestadoresTable(), this.IdOperadorTrack);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private void LoadPrestadores()
        {

            if (this.ID != NULL_ID && !this.IsPrestadorLoaded)
            {
                TicketDS ticketDataService = new TicketDS();
                DataSet ds = ticketDataService.List_PrestadoresByTicket(this.ID);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        PrestadorCaso p = new PrestadorCaso();
                        ORM_PrestadorCaso(p, dr);
                        this._prestadorCaso.Add(p);
                    }
                }

                this._isPrestadorLoaded = true;

            }
        }

        private Ticket_Prestador.TICKET_PRESTADORESDataTable GetPrestadoresTable()
        {
            Ticket_Prestador.TICKET_PRESTADORESDataTable resulTable = new Ticket_Prestador.TICKET_PRESTADORESDataTable();

            foreach (PrestadorCaso c in this.PrestadorCaso)
            {
                Ticket_Prestador.TICKET_PRESTADORESRow r = resulTable.NewTICKET_PRESTADORESRow();
                c.ObjectToRow(r);
                r.IDTICKET = this.ID;
                resulTable.Rows.Add(r);
            }

            return resulTable;

        }


        private void LoadTracking()
        {
            if (this.ID != NULL_ID && !this.IsTrackingLoaded)
            {
                TicketDS ticketDataService = new TicketDS();
                DataSet ds = ticketDataService.List_Ticket_TrackByTicket(this.ID);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        TicketTrack t = new TicketTrack();
                        t.ID = Int32.Parse(dr["IDTICKET_TRACK"].ToString());
                        t.IdOperador = PersistEntity.NuleableInt(dr["IDOPERADOR"].ToString());
                        t.IdEstado = PersistEntity.NuleableInt(dr["IDESTADO"].ToString());
                        t.IdTicket = PersistEntity.NuleableInt(dr["IDTICKET"].ToString());
                        t.FechaHora = Convert.ToDateTime(dr["FECHA_HORA"]);
                        t.NombreOperador = dr["NOMBRE_OPERADOR"].ToString();
                        t.Estado = dr["ESTADO"].ToString();
                        this._ticketTracking.Add(t);
                    }
                }

                this._isTrackingLoaded = true;

            }
        }

        #endregion Metodos



    }
}
