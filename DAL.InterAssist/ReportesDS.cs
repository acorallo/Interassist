using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;
using System.Data;
using Utils.InterAssist;

namespace DAL.InterAssist
{
    public class ReportesDS : Dataservices
    {
        #region Implementación de Interfaces

        public override string GET_BY_ID_PROCEDURE_NAME
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string GET_DELETE_PROCEDURE_NAME
        {
            get { throw new System.NotImplementedException(); }
        }

        public override DataTable getMyTable()
        {
            throw new System.NotImplementedException();
        }

        public override bool Update(DataRow r)
        {
            throw new System.NotImplementedException();
        }

        public override int Create(DataRow r)
        {
            throw new System.NotImplementedException();
        }

        public override DataSet List(Filter f, out int RecordCount)
        {
            throw new System.NotImplementedException();
        }

        #endregion Implementación de Interfaces

        #region Constantes

        private const string CONST_REPORTE_CASOS = "reports_pkg.REPORTE_CASOS";

        #endregion constantes

        #region Metodos

        public DataTable GetReporteCasos(DateTime fechaDesde, DateTime fechaHasta)
        {
            DataTable dt = null;

            try
            {
                DBRepository repository = DBRepository.GetDbRepository();

                List<IDbDataParameter> Paramlist = new List<IDbDataParameter>();

                DataSet ds = new DataSet();

                Paramlist.Add(repository.DbFactory.getDataParameter("P_FECHA_DESDE", DbType.Date, fechaDesde));
                Paramlist.Add(repository.DbFactory.getDataParameter("P_FECHA_HASTA", DbType.Date, fechaHasta));

                repository.ExecuteProcedure(CONST_REPORTE_CASOS, Paramlist, ds);

                if(ds.Tables.Count>0)
                {
                    dt = ds.Tables[0];
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        #endregion Metodos

    }
}
