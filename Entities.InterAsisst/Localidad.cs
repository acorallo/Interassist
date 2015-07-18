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
    public class Localidad : PersistEntity, IRepository
    {

        #region Constantes

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores
        
        #region Miembros de Entidad

        private int _idCiudad;

        public int IdCiudad
        {
            get { return _idCiudad; }
            set { _idCiudad = value; }
        }

        private string _nombre = string.Empty;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        #endregion Miembros de Entidad

        #region Miembros

        #endregion Miembros

        #region Propiedades

        public override Dataservices getDataService()
        {
            return new LocalidadDS();
        }

        #endregion Propiedades

        #region Metodos

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

        public static List<Localidad> ListAll()
        {
            return List(new FiltroLocalidad());
        }

        public static List<Localidad> List(int idCiudad)
        {
            FiltroLocalidad f = new FiltroLocalidad();
            f.IDCiudad = idCiudad;
            f.OrderBY = " order by Nombre";

            return List(f);
        }
        
        public static DataTable ObtenerLocalidades()
        {
            DataTable dt = null;

            FiltroLocalidad f = new FiltroLocalidad();
            f.IsPaged = false;
            int rCount;
            
            LocalidadDS dataServices = new LocalidadDS();
            DataSet ds = dataServices.ListUbicaciones(f, out rCount);

            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                dt.TableName = "UBICACIONES";
            }

            return dt;
        }
        
        public static List<Localidad> List(FiltroLocalidad f)
        {
            List<Localidad> resulList = new List<Localidad>();

            try
            {

                LocalidadDS dataservice = new LocalidadDS();
                DataSet listado = dataservice.List(f);

                if (listado.Tables.Count > 0)
                {
                    foreach (DataRow d in listado.Tables[0].Rows)
                    {
                        Localidad l = new Localidad();
                        ORM(l, d);
                        resulList.Add(l);
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resulList;
        }

        public static void ORM(Localidad localidad, DataRow r)
        {
            localidad._id = Int32.Parse(r[LocalidadDS.COLUMN_ID_LOCALIDAD].ToString());
            localidad._idCiudad = Int32.Parse(r[LocalidadDS.COLUMN_ID_IDCIUDAD].ToString());
            localidad._nombre = r[LocalidadDS.COLUMN_NOMBRE].ToString();
            
        }

        

        #endregion Metodos
    }
}
