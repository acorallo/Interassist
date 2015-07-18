using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.InterAssist;
using System.Data;
using Utils.InterAssist;

namespace DAL.InterAssist
{
    public class ClienteDS : Dals
    {
                
        #region Constantes

        public const string CONST_TABLE_NAME = "CLIENTES";
        private static readonly string CAMPOS = "IDCLIENTE, NOMBRE, APELLIDO, POLIZA, MARCA, PATENTE, ANO,COLOR";
        
        #endregion Constantes

        #region Miembros

        #endregion Miembros

        #region Propiedades

        public override string TABLE_NAME
        {
            get { return CONST_TABLE_NAME; }
        }

        #endregion Propiedades

        #region Metodos
        
        public IDataReader ListClientes(List<Campos> camposWhere, List<string> camposOrder)
        {
            IDataReader result = null;


            try
            {

                /*result = this.getList(TBL_NAME, CAMPOS, camposWhere, camposOrder);*/
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
