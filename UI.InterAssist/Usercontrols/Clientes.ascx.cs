using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils.InterAssist;
using Entities.InterAsisst;
using System.Data;

namespace UI.InterAssist.Usercontrols
{
    public partial class Clientes : System.Web.UI.UserControl
    {

        #region Delegates

        #endregion Delegates

        #region Constantes

        // Columnas 
        public static readonly string COL_ID = "ID";
        public static readonly string COL_NOMBRE = "NOMBRE";
        public static readonly string COL_APELLIDO = "APELLIDO";
        public static readonly string COL_PATENTE = "PANTENTE";
        public static readonly string COL_POLIZA = "POLIZA";

        // Botones
        public static readonly string BTN_BUSCAR = "Buscar";
        public static readonly string BTN_LIMPIAR = "Nueva Busqueda";
        public static readonly string BTN_SELECT = "Seleccionar";
        
        
        

        #endregion Constantes

        #region Enum 

        public enum ColumnasCliente
        {
            COL_SELECT = 0,
            COL_ID,
            COL_APELLIDO,
            COL_NOMBRE,
            COL_PATENTE,
            COL_POLIZA
        }

        #endregion 

        #region Miembros
        #endregion Miembros

        #region Propiedades
        #endregion Propiedades

        #region Metodos

        private void LimpiarControles()
        {
            this.txtPoliza.Text = String.Empty;
            this.txtNombre.Text = String.Empty;
            this.txtApellido.Text = String.Empty;
            this.txtPatente.Text = string.Empty;
            this.grwClientes.Visible = false;
        }

        private void AssigntTextToControls()
        {
            
            

            // Botones
            this.btnBuscar.Text = BTN_BUSCAR;
            this.btnNuevaBusqueda.Text = BTN_LIMPIAR;
            
            
            // Columnas de la grilla.
            this.grwClientes.Columns[(int)ColumnasCliente.COL_ID].HeaderText = COL_ID;
            this.grwClientes.Columns[(int)ColumnasCliente.COL_NOMBRE].HeaderText = COL_NOMBRE;
            this.grwClientes.Columns[(int)ColumnasCliente.COL_APELLIDO].HeaderText = COL_APELLIDO;
            this.grwClientes.Columns[(int)ColumnasCliente.COL_PATENTE].HeaderText = COL_PATENTE;
            this.grwClientes.Columns[(int)ColumnasCliente.COL_POLIZA].HeaderText = COL_POLIZA;

            ((ButtonField)this.grwClientes.Columns[(int)ColumnasCliente.COL_SELECT]).Text = BTN_SELECT;

            this.lblNombre.Text = COL_NOMBRE;
            this.lblApellido.Text = COL_APELLIDO;
            this.lblPoliza.Text = COL_POLIZA;
            this.lblPatente.Text = COL_PATENTE;

        }

        private void InicilizaControles()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.AssigntTextToControls();
                this.InicilizaControles();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BucarCliente();
        }

        protected void BucarCliente()
        {
            string nombre = this.txtNombre.Text.Trim();
            string apellido = this.txtApellido.Text.Trim();
            string patente = this.txtPatente.Text.Trim();
            string poliza = this.txtPoliza.Text.Trim();

            
            // Analizar los campos para filto.

            List<Campos> camposWhere = new List<Campos>();

            if (nombre != string.Empty)
                camposWhere.Add(new Campos("NOMBRE", nombre));

            if (apellido != string.Empty)
                camposWhere.Add(new Campos("APELLIDO", apellido));

            if (patente != string.Empty)
                camposWhere.Add(new Campos("PATENTE", patente));

            if (poliza != string.Empty)
                camposWhere.Add(new Campos("POLIZA", poliza));

            // Campos oreder.
            List<string> camposOrder = new List<string>();
            camposOrder.Add("APELLIDO");

            IDataReader read = Cliente.ListarClientes(camposWhere, camposOrder);

            grwClientes.DataSource = read;
            grwClientes.DataBind();

        }

        protected void btnNuevaBusqueda_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
        }

        protected void grwClientes_DataBinding(object sender, EventArgs e)
        {
            
        }

        protected void grwClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grwClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer)
            {
                System.Data.Common.DbDataRecord dbRecord = (System.Data.Common.DbDataRecord)e.Row.DataItem;

                
                e.Row.Cells[(int)ColumnasCliente.COL_ID].Text = dbRecord["IDCliente"].ToString();
                e.Row.Cells[(int)ColumnasCliente.COL_NOMBRE].Text = dbRecord["NOMBRE"].ToString();
                e.Row.Cells[(int)ColumnasCliente.COL_APELLIDO].Text = dbRecord["APELLIDO"].ToString();
                e.Row.Cells[(int)ColumnasCliente.COL_PATENTE].Text = dbRecord["PATENTE"].ToString();
                e.Row.Cells[(int)ColumnasCliente.COL_POLIZA].Text = dbRecord["POLIZA"].ToString();
                
            }
        }

        #endregion Metodos

    }
}