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
    public class Empresa : PersistEntity, IRepository
    {

        #region Constantes

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros

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
        bool estado = false;

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        #endregion Miembros

        #region Propiedades

        #endregion Propiedades

        #region Metodos

        public static List<Empresa> List(FiltroEmpresa f)
        {
            List<Empresa> resulList = new List<Empresa>();

            try
            {

                EmpresaDS dataservice = new EmpresaDS();
                DataSet listado = dataservice.List(f);

                if (listado.Tables.Count > 0)
                {
                    foreach (DataRow d in listado.Tables[0].Rows)
                    {
                        Empresa e = new Empresa();
                        ORM(e, d);
                        resulList.Add(e);
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resulList;
        }

        public static List<Empresa> ListAll()
        {
            FiltroEmpresa f = new FiltroEmpresa();
            return List(f);
        }

        public override Dataservices getDataService()
        {
            return new EmpresaDS();
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

        public static void ORM(Empresa empresa, DataRow r)
        {
            empresa._id = Int32.Parse(r[EmpresaDS.COLUMN_ID_EMPRESA].ToString());
            empresa._nombre = r[EmpresaDS.COLUMN_NOMBRE].ToString();
            empresa._descripcion = r[EmpresaDS.COLUMN_DESCRIPCION].ToString();
            empresa.estado = Int32.Parse(r[EmpresaDS.COLUMN_ESTADO].ToString()) == ACTIVO;

        }

        #endregion Metodos
    }

}
