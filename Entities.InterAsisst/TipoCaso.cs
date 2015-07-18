using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.InterAsisst
{
    public class TipoCaso
    {

        #region Constantes

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores

        public TipoCaso(string tipoCaso)
        {
            this._descripcion = tipoCaso;
        }

        #endregion Constructores

        #region Miembros

        private string _descripcion = string.Empty;

        public string Descripcion
        {
          get { return _descripcion; }
          set { _descripcion = value; }
        }


        #endregion Miembros

        #region Propiedades

        public static List<TipoCaso> List()
        {
            List<TipoCaso> resultList = new List<TipoCaso>();

            resultList.Add(new TipoCaso("Asesoramiento"));
            resultList.Add(new TipoCaso("Asistencia"));
            resultList.Add(new TipoCaso("Traslado"));
            
            return resultList;
        }

        #endregion Propiedades

        #region Metodos

        #endregion Metodos
    }
}
