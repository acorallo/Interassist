using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cognitas.Framework.UserInterface;
using Cognitas.Framework.Repository;
using UI.InterAssist.Classes;
using Utils.InterAssist;



namespace UI.InterAssist.Views
{
    public partial class Operadores : Classes.Views
    {

        #region Constantes

        private const string COMMNAD_MODIF_OPERADOR = "cmdModifOperador";
        
        #endregion Constantes

        #region Enumeradores



        public enum ColumnOperadores
        {
            ID=0,
            USUARIO, 
            APELLIDO,
            NOMBRE,
            EMAIL,
            ADMIN,
            ACTIVO,
            MODIFICAR,
        }
        

        #endregion Enumeradores

        #region Properties

        protected override bool ReqAdmin
        {
            get { return true; }
        }

        protected override bool ReqLogin
        {
            get { return true; }
        }

        public override string Seccion
        {
            get { return Resource.SECCION_ADM_OPERADORES; }
               
        }

        public override string ViewName
        {
            get { return Classes.Views.OPERADOR_VIEW; }
        }

        #endregion Propeties

        #region Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!this.IsPostBack)
            {
                this.InicializaControles();
                this.AssignTextToControls();
                this.CargarOperadores();
            }
        }

        private void InicializaControles()
        {
            
        }

        private void AssignTextToControls()
        {
            // Columnas de DatagridOperadores.
            this.gdwOperadores.Columns[(int)ColumnOperadores.ID].HeaderText = Resource.LBL_OPERADOR_ID;
            this.gdwOperadores.Columns[(int)ColumnOperadores.USUARIO].HeaderText = Resource.LBL_OPERADOR_USUARIO;
            this.gdwOperadores.Columns[(int)ColumnOperadores.NOMBRE].HeaderText = Resource.LBL_OPERADOR_NOMBRE;
            this.gdwOperadores.Columns[(int)ColumnOperadores.APELLIDO].HeaderText = Resource.LBL_OPERADOR_APELLIDO;
            this.gdwOperadores.Columns[(int)ColumnOperadores.EMAIL].HeaderText = Resource.LBL_OPERADOR_EMAIL;
            this.gdwOperadores.Columns[(int)ColumnOperadores.ADMIN].HeaderText = Resource.LBL_OPERADOR_ADMIN;
            this.gdwOperadores.Columns[(int)ColumnOperadores.ACTIVO].HeaderText = Resource.LBL_OPERADOR_ACTIVO;

            ((ButtonColumn)this.gdwOperadores.Columns[(int)ColumnOperadores.MODIFICAR]).Text = Resource.BTN_GRID_MODIFICAR;
            ((ButtonColumn)this.gdwOperadores.Columns[(int)ColumnOperadores.MODIFICAR]).CommandName = COMMNAD_MODIF_OPERADOR;
            
            
            
            
            // Botones
            this.btnBuscar.Text = Resource.BTN_BUSCAR;
            this.btnFreeSeacrh.Text = Resource.BTN_FREE_SEARCH;
            this.btnCrearNuevo.Text = Resource.BTN_CREAR_USUARIO;

            // Alineamiento de las columnas
            this.gdwOperadores.Columns[(int)ColumnOperadores.ID].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            this.gdwOperadores.Columns[(int)ColumnOperadores.MODIFICAR].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            this.gdwOperadores.Columns[(int)ColumnOperadores.ADMIN].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            this.gdwOperadores.Columns[(int)ColumnOperadores.ACTIVO].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        private void CargarOperadores()
        {
            FiltroOperador f = new FiltroOperador();
            this.CargarGrillaOperadores(f);

        }

        private void CargarGrillaOperadores(FiltroOperador f)
        {
            List<Entities.InterAsisst.Operador> operadores = Entities.InterAsisst.Operador.List(f);
            this.gdwOperadores.DataSource = operadores;
            this.gdwOperadores.DataBind();
        }

        private void ModificaOperador(string idOperador)
        {
            int id = Int32.Parse(idOperador);
            SessionHelper.ID_OPERADOR = id;
            this.goView(Classes.Views.OPERADOR_MODIF_VIEW);
        }

        

        #endregion Metodos

        #region Eventos



        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string txtSearch = this.txtSearch.Text;
            FiltroOperador f = new FiltroOperador();
            f.Search = txtSearch;

            this.CargarGrillaOperadores(f);
        }

        protected void btnFreeSeacrh_Click(object sender, EventArgs e)
        {
            this.txtSearch.Text = string.Empty;
            this.CargarGrillaOperadores(new FiltroOperador());
        }

        protected void btnCrearNuevo_Click(object sender, EventArgs e)
        {
            SessionHelper.ID_OPERADOR = SessionHelper.DEFAULT_ID;
            this.goView(Classes.Views.OPERADOR_MODIF_VIEW);
        }
        
        #endregion Eventos

        protected void gdwOperadores_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case COMMNAD_MODIF_OPERADOR:
                    this.ModificaOperador(e.CommandArgument.ToString());
                    break;
            }
        }

        protected void gdwOperadores_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entities.InterAsisst.Operador operador = (Entities.InterAsisst.Operador)e.Item.DataItem;

                e.Item.Cells[(int)ColumnOperadores.ID].Text = operador.ID.ToString();
                e.Item.Cells[(int)ColumnOperadores.USUARIO].Text = operador.Usuario;
                e.Item.Cells[(int)ColumnOperadores.NOMBRE].Text = operador.Nombre;
                e.Item.Cells[(int)ColumnOperadores.APELLIDO].Text = operador.Apellido;
                e.Item.Cells[(int)ColumnOperadores.EMAIL].Text = operador.Email;
                e.Item.Cells[(int)ColumnOperadores.ACTIVO].Text = operador.Activo ? Resource.TXT_BOOL_TRUE : Resource.TXT_BOOL_FALSE;
                e.Item.Cells[(int)ColumnOperadores.ADMIN].Text = operador.Admin ? Resource.TXT_BOOL_TRUE : Resource.TXT_BOOL_FALSE;
                ((LinkButton)e.Item.Cells[(int)ColumnOperadores.MODIFICAR].Controls[0]).CommandArgument = operador.ID.ToString();
            }
        }

        protected void gdwOperadores_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {

        }

        protected void gdwOperadores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}