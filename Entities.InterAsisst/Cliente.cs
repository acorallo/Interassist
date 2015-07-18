using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL.InterAssist;
using Utils.InterAssist;

namespace Entities.InterAsisst
{
    public class Cliente : Entity
    {
        #region Constantes

       

        #endregion Constantes

        #region Miembros

        private string _nombre;
        private string _apellido;
        private string _poliza;
        private string _patente;
        private string _color;
        private string _ano;
        private string _marca;



        #endregion Miembros

        #region Propiedades

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }


        public string Poliza
        {
            get { return _poliza; }
            set { _poliza = value; }
        }


        public string Patente
        {
            get { return _patente; }
            set { _patente = value; }
        }


        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }


        public string Ano
        {
            get { return _ano; }
            set { _ano = value; }
        }


        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        #endregion Propiedades

        #region Metodos

        public static IDataReader ListarClientes(List<Campos>camposWhere, List<string> camposOrder)
        {
            IDataReader result = null;

            try
            {

                ClienteDS cDal = new ClienteDS();
                result = cDal.ListClientes(camposWhere, camposOrder);
                
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
