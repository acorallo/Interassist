using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.InterAsisst
{
    public class Pais
    {

        #region Constantes

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores

        public Pais()
        {
        }

        public Pais(int id, string nombre)
        {
            this._idPais = id;
            this._nombre = nombre;

        }

        #endregion Constructores

        #region Miembros de Entidad

        private int _idPais;



        public int IdPais
        {
            get { return _idPais; }
            set { _idPais = value; }
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

        #endregion Propiedades

        #region Metodos

        public static List<Pais> List()
        {
            List<Pais> resultList = new List<Pais>();

            resultList.Add(new Pais(1, "Argentina"));
            //resultList.Add(new Pais(2, "Uruguay"));
            //resultList.Add(new Pais(3, "Chile"));
            return resultList;

        }

        #endregion Metodos
    }
}
