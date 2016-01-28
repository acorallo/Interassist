using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL.InterAssist;


namespace Entities.InterAsisst
{

    public class CasosMesurables
    {
        public string TipoCaso;
        public int Cantidad;
    }
    
    public class ContadorCasos
    {

        #region Constants

        public static readonly string COL_TIPO_TICKET = "TIPO_TICKET";
        public static readonly string COL_CANTIIDAD = "CANTIDAD";
        public static readonly string COL_POLIZA = "POLIZA";
        public static readonly string COL_TOTAL = "TOTAL";

        #endregion Constans

        #region Constructores


        private ContadorCasos()
        {

        }
        
        public static ContadorCasos getContadorCasos(int mes, int anno, string poliza)
        {
            ContadorCasos rContador = new ContadorCasos();

            rContador._cantidad = 0;

            TicketDS ds = new TicketDS();
            DataTable dt = ds.ObtenercasosMensuales(anno, mes, poliza);


            if(dt!=null && dt.Rows.Count>0)
            {
                rContador._cantidad = Int32.Parse(dt.Rows[0][COL_TOTAL].ToString());
                foreach(DataRow r in dt.Rows)
                {
                    CasosMesurables caso = new CasosMesurables();
                    caso.TipoCaso = r[COL_TIPO_TICKET].ToString();
                    caso.Cantidad = Int32.Parse(r[COL_CANTIIDAD].ToString());
                    rContador._casos.Add(caso);
                }
            }

            return rContador;
        }

        #endregion Constructores

        #region Miembros

        private int _cantidad;
        private List<CasosMesurables> _casos = new List<CasosMesurables>();

        #endregion Miembros

        #region Propiedades

        public int Cantidad
        {
            get
            {
                return _cantidad;
            }
        }
        public List<CasosMesurables> Casos
        {
            get
            {
                return this._casos;
            }
        }
        

        #endregion Propiedades

    }
}
