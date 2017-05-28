using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cognitas.Framework.Repository;
using Utils.InterAssist;

/**** EGV 25May2017 Creacion de Archivo ****/

namespace DAL.InterAssist
{
    public class EstadoDS : Dataservices
    {
        private const string CONST_LIST_PROCEDURE_NAME = "ESTADO_PKG.LIST_ESTADOS";

        public const string COLUMN_IDESTADO = "IDESTADO";
        public const string COLUMN_DESCRIPCION = "DESCRIPCION";
        public const string COLUMN_GRUPO = "GRUPO";


        public override string GET_BY_ID_PROCEDURE_NAME
        {
            get { throw new NotImplementedException(); }
        }

        public override string GET_DELETE_PROCEDURE_NAME
        {
            get { throw new NotImplementedException(); }
        }

        public override DataSet List(Filter f, out int RecordCount)
        {
            DataSet ds = new DataSet();

            try
            {
                FiltroEstado filtro = (FiltroEstado)f;

                List<IDbDataParameter> paramList = new List<IDbDataParameter>();
                DBRepository repository = DBRepository.GetDbRepository();

                paramList.Add(repository.DbFactory.getDataParameter("P_ID", DbType.Int32, filtro.ID));
                paramList.Add(repository.DbFactory.getDataParameter("P_GRUPO", DbType.String, filtro.Grupo));

                bool result = repository.ExecuteListProcedure(CONST_LIST_PROCEDURE_NAME, paramList, f, ds, out RecordCount);

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return ds;
        }

        public override DataTable getMyTable()
        {
            throw new NotImplementedException();
        }

        public override int Create(DataRow r)
        {
            throw new NotImplementedException();
        }

        public override bool Update(DataRow r)
        {
            throw new NotImplementedException();
        }

    }
}
