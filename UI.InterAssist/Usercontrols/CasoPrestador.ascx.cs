using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities.InterAsisst;
using Utils.InterAssist;

namespace UI.InterAssist.Usercontrols
{
    public partial class CasoPrestador : System.Web.UI.UserControl
    {

        #region Propiedades


        public string InternalID
        {
            get
            {
                if (this.Request.Form["BuscarPrestador_internalID"] != null)
                {
                    return this.Request.Form["BuscarPrestador_internalID"];
                }
                else
                    return string.Empty;
            }
        }

        public int IdPrestador
        {
            get
            {
                if (this.Request.Form["CasoPrestador_Info_ID"] != null)
                {
                    return Int32.Parse(this.Request.Form["CasoPrestador_Info_ID"]);
                }
                else
                    return -1;
            }
        }

        public int IdTipoAsistencia
        {
            get
            {
                if (this.Request.Form["CasoPrestador_Info_TipoAsistencia"] != null)
                {
                    return Int32.Parse(this.Request.Form["CasoPrestador_Info_TipoAsistencia"]);
                }
                else
                    return -1;
            }
        }

        public string Comentarios
        {
            get
            {
                return this.Request.Form["CasoPrestador_Info_Descripcion"];
            }
        }


        #endregion Propiedades

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
               if(!this.IsPostBack)
               {
                   this.InicializaControles();
                   this.AssignTextToControls();
               }
        }

        private void AssignTextToControls()
        {
            this.lblCasoPrestador_descripcion.Text = "Comentarios:";
            this.lblCasoPrestador_prestador.Text = "Prestador:";
            this.lblCasoPrestador_TipoAsisitencia.Text = Resource.LBL_TICKET_TIPO_ASISTENCIA + Resource.LBL_SEPARADOR;
        }
            
        private void InicializaControles()
        {
            Classes.Views.AgergarElijaOpcion(this.ddlCasoPrestador_TipoAsistencia);
            FiltroTipoServicio f = new FiltroTipoServicio();
            f.OrderBY = " order by descripcion asc";

            List<TipoServicio> TiposServicios = TipoServicio.List(f);

            foreach (TipoServicio t in TiposServicios)
            {
                this.ddlCasoPrestador_TipoAsistencia.Items.Add(new ListItem(t.Descripcion, t.ID.ToString()));
            }
        }

        #endregion Metodos

        
    }
}