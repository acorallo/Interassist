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
    // EGV 25May2017 Inicio
    //public class Estado
    public class Estado : PersistEntity, IRepository
    // EGV 25May2017 Fin
    {
        // EGV 25May2017 Inicio
        public string Descripcion { get; set; }
        public string Grupo { get; set; }

        // EGV 25May2017 Inicio
        public enum Prestacion { Borrador = 8, PendientePrestador = 9, PendienteAsistencia = 10, PendienteCierre = 11, Cerrado = 12 }
        public enum Caso { Borrador = 4, Abierto = 5, PendienteCierre = 6, Cerrado = 7 }
        public enum FinalPrestacion { CancelaAfiliado = 13, CancelaPrestador = 14, AsistenciaOk = 15 }
        // EGV 25May2017 Fin

        public static void ORM(Estado estado, DataRow r)
        {
            estado._id = Int32.Parse(r[EstadoDS.COLUMN_IDESTADO].ToString());
            estado.Descripcion = r[EstadoDS.COLUMN_DESCRIPCION].ToString();
            estado.Grupo = r[EstadoDS.COLUMN_GRUPO] != System.DBNull.Value ? r[EstadoDS.COLUMN_GRUPO].ToString() : "";
        }

        public static Estado GetById(int idEstado)
        {
            Estado e = null;

            FiltroEstado filtro = new FiltroEstado();
            filtro.ID = idEstado;

            var list = Estado.List(filtro);

            if (list.Count > 0)
                e = list[0];


            return e;
        }

        public static List<Estado> List(FiltroEstado f)
        {
            List<Estado> resulList = new List<Estado>();

            try
            {

                EstadoDS dataservice = new EstadoDS();
                DataSet listado = dataservice.List(f);

                if (listado.Tables.Count > 0)
                {
                    foreach (DataRow d in listado.Tables[0].Rows)
                    {
                        Estado t = new Estado();
                        ORM(t, d);
                        resulList.Add(t);
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resulList;
        }

        public override Dataservices getDataService()
        {
            return new TipoServicioDS();
        }

        public override DataRow ObjectToRow()
        {
            throw new NotImplementedException();
        }

        public bool HasChange()
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }


        // EGV 25May2017 Fin
    }
}
