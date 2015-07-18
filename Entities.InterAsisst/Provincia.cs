using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.InterAsisst
{
    public class Provincia
    {

        #region Constantes
        #endregion Constantes

        #region Enumeradores
        #endregion Enumeradores

        #region Constructores

        public Provincia()
        {
        }

        public Provincia(int id, int idPais, string nombre)
        {
            this._id = id;
            this._idPais = idPais;
            this._nombre = nombre;
        }

        #endregion Constructores

        #region Miembros

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
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
        
        #endregion Miembros

        #region Propiedades
        #endregion Propiedades

        #region Metodos

        public static List<Provincia > ListAll()
        {
            List<Provincia> provincias = new List<Provincia>();
            
            provincias.Add(new Provincia(1, 1, "BUENOS AIRES"));
            provincias.Add(new Provincia(2,	1,	"CATAMARCA"));
            provincias.Add(new Provincia(3,	1,	"CHACO"));
            provincias.Add(new Provincia(4,	1,	"CHUBUT"));
            provincias.Add(new Provincia(24, 1,	"CIUDAD AUTÓNOMA DE BUENOS AIRES"));
            provincias.Add(new Provincia(5,	1,	"CORDOBA"));
            provincias.Add(new Provincia(6,	1,	"CORRIENTES"));
            provincias.Add(new Provincia(7,	1,	"ENTRE RIOS"));
            provincias.Add(new Provincia(8,	1,	"FORMOSA"));
            provincias.Add(new Provincia(9,	1,	"JUJUY"));
            provincias.Add(new Provincia(10, 1,	"LA PAMPA"));
            provincias.Add(new Provincia(11, 1,	"LA RIOJA"));
            provincias.Add(new Provincia(12, 1,	"MENDOZA"));
            provincias.Add(new Provincia(13, 1,	"MISIONES"));
            provincias.Add(new Provincia(14, 1,	"NEUQUEN"));
            provincias.Add(new Provincia(15, 1,	"RIO NEGRO"));
            provincias.Add(new Provincia(16, 1,	"SALTA"));
            provincias.Add(new Provincia(17, 1,	"SAN JUAN"));
            provincias.Add(new Provincia(18, 1,	"SAN LUIS"));
            provincias.Add(new Provincia(19, 1,	"SANTA CRUZ"));
            provincias.Add(new Provincia(20, 1,	"SANTA FE"));
            provincias.Add(new Provincia(21, 1, "SANTIAGO DEL ESTERO"));
            provincias.Add(new Provincia(22, 1,	"TIERRA DEL FUEGO "));
            provincias.Add(new Provincia(23, 1, "TUCUMAN"));
            
            return provincias;
 
        }

        public static List<Provincia> List(int idPais)
        {
            List<Provincia> provincias = new List<Provincia>();

            provincias.Add(new Provincia(1, 1, "BUENOS AIRES"));
            provincias.Add(new Provincia(2, 1, "CATAMARCA"));
            provincias.Add(new Provincia(3, 1, "CHACO"));
            provincias.Add(new Provincia(4, 1, "CHUBUT"));
            provincias.Add(new Provincia(24, 1, "CIUDAD AUTÓNOMA DE BUENOS AIRES"));
            provincias.Add(new Provincia(5, 1, "CORDOBA"));
            provincias.Add(new Provincia(6, 1, "CORRIENTES"));
            provincias.Add(new Provincia(7, 1, "ENTRE RIOS"));
            provincias.Add(new Provincia(8, 1, "FORMOSA"));
            provincias.Add(new Provincia(9, 1, "JUJUY"));
            provincias.Add(new Provincia(10, 1, "LA PAMPA"));
            provincias.Add(new Provincia(11, 1, "LA RIOJA"));
            provincias.Add(new Provincia(12, 1, "MENDOZA"));
            provincias.Add(new Provincia(13, 1, "MISIONES"));
            provincias.Add(new Provincia(14, 1, "NEUQUEN"));
            provincias.Add(new Provincia(15, 1, "RIO NEGRO"));
            provincias.Add(new Provincia(16, 1, "SALTA"));
            provincias.Add(new Provincia(17, 1, "SAN JUAN"));
            provincias.Add(new Provincia(18, 1, "SAN LUIS"));
            provincias.Add(new Provincia(19, 1, "SANTA CRUZ"));
            provincias.Add(new Provincia(20, 1, "SANTA FE"));
            provincias.Add(new Provincia(21, 1, "SANTIAGO DEL ESTERO"));
            provincias.Add(new Provincia(22, 1, "TIERRA DEL FUEGO "));
            provincias.Add(new Provincia(23, 1, "TUCUMAN"));

            return provincias;
 
        }

        #endregion Metodos
    }
}
