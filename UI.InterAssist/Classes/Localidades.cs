using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Entities.InterAsisst;

namespace UI.InterAssist.Classes
{
    public class Localidades
    {
        private static DataTable dtLocalidades = null;
        private static DateTime lastUpdate;

        public static Ubicacion GetUbicacionById(int idLocalidad)
        {
            Ubicacion resultUbicacion = null;

            DataTable dt = GetLocalidades();
            string selectClause = string.Format("IDLOCALIDAD = {0}", idLocalidad);

            DataRow[] rows = GetLocalidades().Select(selectClause);

            if (rows.Length > 0)
            {
                DataRow dr = rows[0];
                resultUbicacion = new Ubicacion();

                resultUbicacion.IDLocalidad = idLocalidad;
                resultUbicacion.IDCiudad = Int32.Parse(dr["IDCIUDAD"].ToString());
                resultUbicacion.IDProvincia = Int32.Parse(dr["IDPROVINCIA"].ToString());
                resultUbicacion.IDPais = Int32.Parse(dr["IDPAIS"].ToString());


            }

            return resultUbicacion;

        }

        public static DataTable GetLocalidades()
        {
            if (dtLocalidades == null || !InCache())
                CargarLocalidades();
            return dtLocalidades;
                
        }

        public static List<Ubicacion> getUbicaciones()
        {
            List<Ubicacion> result = new List<Ubicacion>();

            DataTable dt = GetLocalidades();
            foreach(DataRow rw in dt.Rows)
            {
                Ubicacion ubicacion = new Ubicacion();

                ubicacion.IDPais = Int32.Parse(rw["IDPAIS"].ToString());
                ubicacion.IDProvincia = Int32.Parse(rw["IDPROVINCIA"].ToString());
                ubicacion.IDCiudad = Int32.Parse(rw["IDCIUDAD"].ToString());
                ubicacion.IDLocalidad = Int32.Parse(rw["IDLOCALIDAD"].ToString());
                ubicacion.Pais = rw["PAIS"].ToString();
                ubicacion.Provincia = rw["PROVINCIA"].ToString();
                ubicacion.Localidad = rw["LOCALIDAD"].ToString();
                ubicacion.Ciudad = rw["CIUDAD"].ToString();
                
                result.Add(ubicacion);
            }

            return result;
        }
        
        private static bool InCache()
        {
            bool result = false;

            result = lastUpdate != null && DateTime.Now.AddMinutes(-Views.CACHE_OBJECTS) <= lastUpdate;

            return result;
        }

        private static void CargarLocalidades()
        {
            try
            {
                dtLocalidades = Entities.InterAsisst.Localidad.ObtenerLocalidades();
                lastUpdate = DateTime.Now;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

    }
}