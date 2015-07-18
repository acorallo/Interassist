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
    public class TipoServicio : PersistEntity, IRepository
    {
        #region Constantes

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros de Clase

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private bool _activo = true;

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        #endregion Mimbros de Clase

        #region Miembros

        #endregion Miembros

  
        #region Propiedades

        #endregion Propiedades

        #region Metodos

        public static void ORM(TipoServicio tipoServico, DataRow r)
        {
            tipoServico._id = Int32.Parse(r[TipoServicioDS.COLUMN_ID_TIPOSEVICIO].ToString());
            tipoServico._descripcion = r[TipoServicioDS.COLUMN_DESCRIPCION].ToString();
            tipoServico._activo = Int32.Parse(r[TipoServicioDS.COLUMN_ESTADO].ToString()) == ACTIVO;

        }

        public static List<TipoServicio> List(FiltroTipoServicio f)
        {
            List<TipoServicio> resulList = new List<TipoServicio>();

            try
            {

                TipoServicioDS dataservice = new TipoServicioDS();
                DataSet listado = dataservice.List(f);

                if (listado.Tables.Count > 0)
                {
                    foreach (DataRow d in listado.Tables[0].Rows)
                    {
                        TipoServicio t = new TipoServicio();
                        ORM(t, d);
                        resulList.Add(t);
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resulList;
        }


        public override Dataservices getDataService()
        {
            return new TipoServicioDS();
        }

        public override DataRow ObjectToRow()
        {
            throw new NotImplementedException();
        }

        public bool HasChange()
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }

        #endregion Metodos
    }
}
