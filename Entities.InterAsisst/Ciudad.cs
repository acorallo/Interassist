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
    public class Ciudad : PersistEntity, IRepository
    {

        #region Constantes

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros de Entidad

        private int _idPais;

        public int IdPais
        {
            get { return _idPais; }
            set { _idPais = value; }
        }
        private int _idProvincia;

        public int IdProvincia
        {
            get { return _idProvincia; }
            set { _idProvincia = value; }
        }
        private string _nombre;

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
            return new CiudadDS();
        }

        #endregion Propiedades

        #region Metodos


        public static List<Ciudad> List(int idPais, int idProvincia)
        {
            FiltroCiudad f = new FiltroCiudad();
            f.IDPais = idPais;
            f.IDProvinca = idProvincia;
            f.OrderBY = " order by nombre";

            return List(f);
            
        }

        public static List<Ciudad> List(FiltroCiudad f)
        {
            List<Ciudad> resulList = new List<Ciudad>();

            try
            {

                CiudadDS dataservice = new CiudadDS();
                DataSet listado = dataservice.List(f);

                if (listado.Tables.Count > 0)
                {
                    foreach (DataRow d in listado.Tables[0].Rows)
                    {
                        Ciudad c = new Ciudad();
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

        public static List<Ciudad> ListAll()
        {
            FiltroCiudad f = new FiltroCiudad();
            return List(f);
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

        public static void ORM(Ciudad ciudad, DataRow r)
        {
            ciudad._id = Int32.Parse(r[CiudadDS.COLUMN_ID_CIUDAD].ToString());
            ciudad._nombre = r[CiudadDS.COLUMN_NOMBRE].ToString();
            ciudad.IdPais = Int32.Parse(r[CiudadDS.COLUMN_ID_PAIS].ToString());
            ciudad.IdProvincia = Int32.Parse(r[CiudadDS.COLUMN_ID_PROVINCIA].ToString());

        }

        #endregion Metodos
    }
}
