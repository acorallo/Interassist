using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository.Interfaces;
using Cognitas.Framework.Repository;
using DAL.InterAssist.Datasets;
using DAL.InterAssist;
using System.Data;
using Utils.InterAssist;

namespace Entities.InterAsisst
{
    public class Problema : PersistEntity, IRepository
    {

        #region Constantes

        #endregion Constantes

        #region Enumeradores

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros de Clase

        private string _desripcion = string.Empty;

        public string Desripcion
        {
            get { return _desripcion; }
            set { _desripcion = value; }
        }
        private bool _estado = false;

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        

        #endregion Miembros de Clase

        #region Miembros

        public bool HasChange()
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            throw new NotImplementedException();

        }

        #endregion Miembros

        #region Propiedades

        #endregion Propiedades

        #region Metodos

        public override Dataservices getDataService()
        {
            return new ProblemaDS();
        }

        public override DataRow ObjectToRow()
        {
            Problemas.PROBLEMASRow dr = new Problemas.PROBLEMASDataTable().NewPROBLEMASRow();

            dr.IDPROBLEMA = this._id;
            dr.DESCRIPCION = this._desripcion;
            dr.ESTADO = this.Estado ? Dataservices.ACTIVO : Dataservices.NO_ACTIVO;
            dr.OBJECTHASH = this._UObjectID;

            return dr;
        }

        public static void ORM(Problema problema, DataRow dr)
        {
            problema._id = Int32.Parse(dr[ProblemaDS.COL_ID_PROBLEMA].ToString());
            problema.Desripcion = dr[ProblemaDS.COL_ID_DESCRIPCION].ToString();
            problema._estado = Int32.Parse(dr[ProblemaDS.COL_ID_ESTADADO].ToString())==ProblemaDS.ACTIVO;

        }

        public static List<Problema> ListAll()
        {
            FiltroProblema f = new FiltroProblema();
            
            f.OrderBY = " order by DESCRIPCION ";
            return List(f);
        }

        public static List<Problema> List(FiltroProblema f)
        {
            List<Problema> resulList = new List<Problema>();

            try
            {

                ProblemaDS dataservice = new ProblemaDS();
                DataSet listado = dataservice.List(f);

                if (listado.Tables.Count > 0)
                {
                    foreach (DataRow d in listado.Tables[0].Rows)
                    {
                        Problema p = new Problema();
                        ORM(p, d);
                        resulList.Add(p);
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resulList;
        }


        #endregion Metodos
    }
}
