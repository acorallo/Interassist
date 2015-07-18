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
    public class Categoria : PersistEntity, IRepository
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

        private string _descripcion = string.Empty;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private bool _estado = true;

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private string _codigo = string.Empty;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        
        

        #endregion Miembros de Entidad

        #region Propiedades

        #endregion Propiedades

        #region Metodos

        public override Dataservices getDataService()
        {
            return new CategoriaDS();
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

        public static void ORM(Categoria categoria, DataRow r)
        {
            categoria._id = Int32.Parse(r[CategoriaDS.COLUMN_ID_EMPRESA].ToString());
            categoria._nombre = r[CategoriaDS.COLUMN_NOMBRE].ToString();
            categoria._descripcion = r[CategoriaDS.COLUMN_DESCRIPCION].ToString();
            categoria._codigo = r[CategoriaDS.COLUMN_CODIGO].ToString();
            categoria._estado = Int32.Parse(r[CategoriaDS.COLUMN_ESTADO].ToString()) == ACTIVO;
        }

        public static List<Categoria> List(FiltroCategorias f)
        {
            List<Categoria> resulList = new List<Categoria>();

            try
            {

                CategoriaDS dataservice = new CategoriaDS();
                DataSet listado = dataservice.List(f);

                if (listado.Tables.Count > 0)
                {
                    foreach (DataRow d in listado.Tables[0].Rows)
                    {
                        Categoria c = new Categoria();
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

        public static List<Categoria> ListAll()
        {
            FiltroCategorias f = new FiltroCategorias();
            return List(f);
        }

    }
        #endregion Metodos
    
}
