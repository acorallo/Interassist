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