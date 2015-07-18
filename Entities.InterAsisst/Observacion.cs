using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL.InterAssist;
using DAL.InterAssist.Datasets;
using System.Security.Cryptography;
using Cognitas.Framework.Repository;
using Cognitas.Framework.Repository.Interfaces;
using Utils.InterAssist;

namespace Entities.InterAsisst
{
    public class Observacion : PersistEntity, IRepository
    {
        #region Constantes
        
        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores

        public Observacion(int idOperador)
        {
            this.IdOperador = idOperador;
        }

        #endregion Constructores

        #region Miembros de la entidad

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private bool _estado = true;

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        private string _descripcion = string.Empty;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private int _idOperador = -1;

        public int IdOperador
        {
            get { return _idOperador; }
            set { _idOperador = value; }
        }
        
        private int _idTicket = -1;

        public int IdTicket
        {
            get { return _idTicket; }
            set { _idTicket = value; }
        }

        private string _nombreOperador;

        public string NombreOperador
        {
            get { return _nombreOperador; }
            set { _nombreOperador = value; }
        }

        private string _apellidoOperador;

        public string ApellidoOperador
        {
            get { return _apellidoOperador; }
            set { _apellidoOperador = value; }
        }



        #endregion Miembros de la entidad

        #region Miembros

        public override Dataservices getDataService()
        {
            return new ObservacionDS();
        }

        #endregion Miembros

        #region Propiedades

        #endregion Propiedades

        #region Metodos

        public bool HasChange()
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }

        public override DataRow ObjectToRow()
        {
            Observaciones.OBSERVACIONESRow resultRow = (new Observaciones.OBSERVACIONESDataTable()).NewOBSERVACIONESRow();

            resultRow.IDOBSERVACION = this.ID;
            resultRow.IDOPERADOR = this.IdOperador;
            resultRow.IDTICKET = this.IdTicket;
            resultRow.DESCRIPCION = this.Descripcion;
            resultRow.OBJECTHASH = this._UObjectID;
   
            return resultRow;
        }

        public static void ORM(Observacion observacion, DataRow dr)
        {
            observacion._id = Int32.Parse(dr[ObservacionDS.COL_ID_OBSERVACION].ToString());
            observacion._idTicket = Int32.Parse(dr[ObservacionDS.COL_ID_TICKET].ToString());
            observacion.IdOperador = Int32.Parse(dr[ObservacionDS.COL_ID_OPERADOR].ToString());
            observacion.Fecha = (DateTime)dr[ObservacionDS.COL_FECHA];
            observacion.Descripcion = dr[ObservacionDS.COL_DESCRIPCION].ToString();
            observacion.Estado = Int32.Parse(dr[ObservacionDS.COL_ESTADO].ToString()) == ObservacionDS.ACTIVO;
            observacion.NombreOperador = dr[ObservacionDS.COL_OPERADOR_NOMBRE].ToString();
            observacion.ApellidoOperador = dr[ObservacionDS.COL_OPERADOR_APELLIDO].ToString();
        }

        public static List<Observacion> List(FiltroOberservaciones f)
        {
            List<Observacion> resulList = new List<Observacion>();

            try
            {

                ObservacionDS dataservice = new ObservacionDS();
                DataSet listado = dataservice.List(f);

                if (listado.Tables.Count > 0)
                {
                    foreach (DataRow d in listado.Tables[0].Rows)
                    {
                        Observacion o = new Observacion(-1);
                        ORM(o, d);
                        resulList.Add(o);
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resulList;
        }

        public static List<Observacion> ListByTicket(int idTicket)
        {
            FiltroOberservaciones f = new FiltroOberservaciones();
            f.IDTicket = idTicket;
            f.OrderBY = " order by fecha desc";
            return List(f);
        }

        

        #endregion Metodos
    }
}
