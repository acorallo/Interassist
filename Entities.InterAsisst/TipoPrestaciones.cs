using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL.InterAssist;
using System.Security.Cryptography;
using Cognitas.Framework.Repository;
using Cognitas.Framework.Repository.Interfaces;
using Utils.InterAssist;

namespace Entities.InterAsisst
{
    public class TipoPrestaciones : PersistEntity, IRepository
    {
        #region Constantes

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros de Entidad

        private string _codigo = string.Empty;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _descripcion = string.Empty;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        #endregion Miembros de Entidad

        #region Propiedades

        #endregion Propiedades

        #region Metodos

        public override Dataservices getDataService()
        {
            return new TipoPrestacionesDS();
        }

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
            throw new NotImplementedException();
        }

        public static void ORM(TipoPrestaciones t, DataRow r)
        {
            t._id = Int32.Parse(r[TipoPrestacionesDS.COLUMN_IDTIPOPRESTACION].ToString());
            t._codigo = r[TipoPrestacionesDS.COLUMN_CODIGO].ToString();
            t._descripcion = r[TipoPrestacionesDS.COLUMN_DESCRIPCION].ToString();
        }

        public static List<TipoPrestaciones> List(FiltroTipoPrestacion f)
        {
            List<TipoPrestaciones> resulList = new List<TipoPrestaciones>();

            try
            {

                TipoPrestacionesDS dataservice = new TipoPrestacionesDS();
                DataSet listado = dataservice.List(f);

                if (listado.Tables.Count > 0)
                {
                    foreach (DataRow d in listado.Tables[0].Rows)
                    {
                        TipoPrestaciones c = new TipoPrestaciones();
                        ORM(c, d);
                        resulList.Add(c);
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resulList;
        }

        public static List<TipoPrestaciones> ListAll()
        {
            FiltroTipoPrestacion f = new FiltroTipoPrestacion();
            return List(f);
        }
        #endregion Metodos

    }
}
