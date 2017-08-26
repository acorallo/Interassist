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
    public class Colores : PersistEntity, IRepository
    {
        #region Constantes

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros de Entidad

        private string _nombre = string.Empty;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        #endregion Miembros de Entidad

        #region Propiedades

        #endregion Propiedades

        #region Metodos

        public override Dataservices getDataService()
        {
            return new ColoresDS();
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

        public static void ORM(Colores color, DataRow r)
        {
            color._id = Int32.Parse(r[ColoresDS.COLUMN_IDCOLOR].ToString());
            color._nombre = r[ColoresDS.COLUMN_NOMBRE].ToString();
        }

        public static List<Colores> List(FiltroColores f)
        {
            List<Colores> resulList = new List<Colores>();

            try
            {

                ColoresDS dataservice = new ColoresDS();
                DataSet listado = dataservice.List(f);

                if (listado.Tables.Count > 0)
                {
                    foreach (DataRow d in listado.Tables[0].Rows)
                    {
                        Colores c = new Colores();
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

        public static List<Colores> ListAll()
        {
            FiltroColores f = new FiltroColores();
            return List(f);
        }
        #endregion Metodos
    }
}
