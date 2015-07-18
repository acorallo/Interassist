using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.InterAsisst 
{
    public class TipoIva : Entity
    {

        #region Constantes

        

        #endregion Constantes

        #region Enumeradores

        
        
        #endregion Enumeradores

        #region Constructores

        public TipoIva(int id, string descripcion)
        {
            this._id = id;
            this._descripction = descripcion;
        }

        #endregion Constructores

        #region Miembros

        private string _descripction = string.Empty;

        public string Descripction
        {
            get { return _descripction; }
            set { _descripction = value; }
        }

        #endregion Miembros

        #region Propiedades

        

        #endregion Propiedades

        #region Metodos

        public static List<TipoIva> GetList()
        {
            List<TipoIva> resultList = new List<TipoIva>();
            
            resultList.Add(new TipoIva(1, "RESPONSABLE INSCRIPTO"));
            resultList.Add(new TipoIva(2, "MONOTRISBUTISTA"));
            resultList.Add(new TipoIva(3, "Otros"));

            return resultList;

        }

        #endregion Metodos
    }
}
