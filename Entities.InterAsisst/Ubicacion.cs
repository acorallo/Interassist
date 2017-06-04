using DAL.InterAssist;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Utils.InterAssist;

namespace Entities.InterAsisst
{
    public class Ubicacion
    {
        public int idPais { get; set; }
        public int idProvincia { get; set; }
        public int idLocalidad { get; set; }
        public int idCiudad { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Localidad { get; set; }
        public string Nombre { get; set; }      // EGV 03Jun2017

        public List<Ubicacion> getUbicaciones()
        {
            List<Ubicacion> resultList = new List<Ubicacion>();

            return resultList;
        }

        // EGV 03Jun2017 Inicio
        public static List<Ubicacion> List(FiltroUbicacion f, out int RecordCount)
        {
            List<Ubicacion> resulList = new List<Ubicacion>();

            try
            {

                UbicacionDS dataservice = new UbicacionDS();
                DataSet listado = dataservice.List(f, out  RecordCount);

                if (listado.Tables.Count > 0)
                {
                    foreach (DataRow d in listado.Tables[0].Rows)
                    {
                        Ubicacion t = new Ubicacion();
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

        public static void ORM(Ubicacion u, DataRow r)
        {
            u.idLocalidad = Int32.Parse(r[UbicacionDS.COLUMN_IDLOCALIDAD].ToString());
            u.idCiudad = Int32.Parse(r[UbicacionDS.COLUMN_IDCIUDAD].ToString());
            u.idProvincia = Int32.Parse(r[UbicacionDS.COLUMN_IDPROVINCIA].ToString());
            u.idPais = Int32.Parse(r[UbicacionDS.COLUMN_IDPAIS].ToString());
            u.Localidad = r[UbicacionDS.COLUMN_LOCALIDAD].ToString();
            u.Ciudad = r[UbicacionDS.COLUMN_CIUDAD].ToString();
            u.Provincia = r[UbicacionDS.COLUMN_PROVINCIA].ToString();
            u.Pais = r[UbicacionDS.COLUMN_PAIS].ToString();
            u.Nombre = r[UbicacionDS.COLUMN_NOMBRE].ToString();

        }

        // EGV 03Jun2017 Fin

    }
}
