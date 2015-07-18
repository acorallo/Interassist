using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entities.InterAsisst;



namespace UI.InterAssist.Views
{
    public class AjaxResponseCiudaes
    {
        public string value;
        public string label;
        public int id;

        public AjaxResponseCiudaes(string value, string label, int id)
        {
            this.value = value;
            this.label = label;
            this.id = id;
        }

        public static DataTable _ubicaciones;

    }

    public partial class test : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.UbicacionPredictivo1.IsEmptyValidate = true;
                this.UbicacionPredictivo2.IsEmptyValidate = false;
                this.InicializaControles();
            }
        }

        public void InicializaControles()
        {
            this.UbicacionPredictivo1.IdLocalidad = 111;
        }

        public static string getWhereLogic(string value)
        {
            string result = string.Empty;

            string[] parse = value.Split(',');

            if (parse.Length == 1)
            {
                // con un solo parametro
                result = String.Format("LOCALIDAD LIKE '%{0}%' or CIUDAD LIKE '%{0}%' or PROVINCIA LIKE '%{0}%'", parse[0].Trim());
            }
            else if (parse.Length == 2)
            {
                // con dos parametros
                result = String.Format("(LOCALIDAD LIKE '%{0}%' and CIUDAD LIKE '%{1}%') or (CIUDAD LIKE '%{0}%' and PROVINCIA LIKE '%{1}%') or (LOCALIDAD LIKE '%{0}%' and  PROVINCIA LIKE '%{1}%')", parse[0].Trim(), parse[1].Trim());

            }else
            {
                // con tres parametros.
                result = String.Format("LOCALIDAD LIKE '%{0}%' and CIUDAD LIKE '%{1}%' and PROVINCIA LIKE '%{2}%'", parse[0].Trim(), parse[1].Trim(), parse[2].Trim());
            }


            return result;
        }


        [System.Web.Services.WebMethod]
        public static AjaxResponseCiudaes[] ObtenerUbicacion(string valor)
        {

            List<AjaxResponseCiudaes> listResult = new List<AjaxResponseCiudaes>();

            try
            {

                string selecExpr = getWhereLogic(valor);

                string orderExpr = "Provincia asc, Ciudad asc, Localidad asc";

                foreach (DataRow dr in Classes.Localidades.GetLocalidades().Select(selecExpr, orderExpr))
                {
                    listResult.Add(new AjaxResponseCiudaes(dr["NOMBRE_COMPLETO"].ToString(), dr["NOMBRE_COMPLETO"].ToString(), Int32.Parse(dr["IDCIUDAD"].ToString())));
                }
            }
            catch
            { 
            }

            return listResult.ToArray();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            int a = 10;
        }

    }
}