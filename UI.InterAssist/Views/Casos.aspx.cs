using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Utils.InterAssist;
using Entities.InterAsisst;
using UI.InterAssist.Interfaces;
using Cognitas.Framework.Repository;

namespace UI.InterAssist.Views
{
    public partial class Casos : Classes.Views
    {


        #region Constantes

        public const string COMMNAD_VER_TICKET = "cmdverTicket";

        #endregion Constantes

        #region Enumeradores

        public enum Columnas
        {
            IdTicket=0,
            Tipo,
            MarcaModelo,
            Patente,
            LocalidadOrigen,
            LocalidadDestino,
            Empresa,
            Fecha,
            Operador
        }

        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros

        #endregion Miembros

        public override string ViewName
        {
            get { return Classes.Views.CASO_VIEW; }
        }

        #region Propiedades

        protected override bool ReqAdmin
        {
            get { return false; }
        }

        protected override bool ReqLogin
        {
            get { return true; }
        }

        public override string Seccion
        {
            get { return Resource.SECCION_ADM_CASOS; }
        }

        public FiltroTicket Filtro
        {
            get
            {
                if (this.ViewState[VIEW_STATE_FILTRO] == null)
                    this.ViewState.Add(VIEW_STATE_FILTRO, new FiltroTicket());
                return (FiltroTicket)this.ViewState[VIEW_STATE_FILTRO];

            }
            set
            {
                this.ViewState.Add(VIEW_STATE_FILTRO, value);
            }
        }

        #endregion Propiedades

        #region Metodos
        
        protected void Page_Load(object sender, EventArgs e)
        {

            base.Page_Load(sender, e);
            if (!this.IsPostBack)
            {
                this.AssignTextToControls();
                this.InicializaControles();
            }

        }



        private void ShowList(bool value)
        {
            this.divNonResult.Visible = !value;
            this.divGrid.Visible = value;
            this.divCantregistros.Visible = value;
        }

        public void CargarListadoID(FiltroTicket filtro, int pageNumber)
        {

            int idSearch;
            List<Entities.InterAsisst.Ticket> listaAfiliados = new List<Ticket>();
            int totalRegistros = 0;

            if (Int32.TryParse(filtro.Search, out idSearch))
            {
                Ticket t = Ticket.GetById(idSearch);
                if (t != null)
                {
                    listaAfiliados.Add(t);
                    totalRegistros = 1;
                }


            }
            

            this.ShowList(totalRegistros > 0);
            this.lbltxtCantidadRegistros.Text = totalRegistros.ToString();

            this.dtgTickets.CurrentPageIndex = pageNumber - 1;
            this.dtgTickets.VirtualItemCount = totalRegistros;
            this.dtgTickets.DataSource = listaAfiliados;
            this.dtgTickets.DataBind();

        }

        public void CargarListado(FiltroTicket filtro, int pageNumber)
        {
            int totalRegistros;

            filtro.PageSize = PAGE_SIZE;
            filtro.IsPaged = true;
            filtro.StartRow = ((pageNumber - 1) * PAGE_SIZE) + 1;

            filtro.OrderBY = " order by fecha desc";

            List<Entities.InterAsisst.Ticket> listaAfiliados = Entities.InterAsisst.Ticket.List((FiltroTicket)filtro, out totalRegistros);

            this.Filtro.FiltredRowsQtty = totalRegistros;
            

            this.ShowList(totalRegistros > 0);
            this.lbltxtCantidadRegistros.Text = totalRegistros.ToString();

            this.dtgTickets.CurrentPageIndex = pageNumber - 1;
            this.dtgTickets.VirtualItemCount = totalRegistros;
            this.dtgTickets.DataSource = listaAfiliados;
            this.dtgTickets.DataBind();


        }

        protected void AssignTextToControls()
        {
            
            // Labels
            this.lblNonResults.Text = Resource.TXT_NON_RESULTS;
            this.lblCantRegistros.Text = Resource.TXT_RECORD_COUNT + Resource.LBL_SEPARADOR;

            
            // Columnas
            this.dtgTickets.Columns[(int)Columnas.IdTicket].HeaderText = Resource.LBL_TICKET_LISTADO_ID;
            this.dtgTickets.Columns[(int)Columnas.Tipo].HeaderText = Resource.LBL_TICKET_TIPO;
            this.dtgTickets.Columns[(int)Columnas.MarcaModelo].HeaderText = Resource.LBL_TICKET_LISTADO_MARCA;
            this.dtgTickets.Columns[(int)Columnas.Patente].HeaderText = Resource.LBL_TICKET_LISTADO_PATENTE;
            this.dtgTickets.Columns[(int)Columnas.LocalidadOrigen].HeaderText = Resource.LBL_TICKET_LISTADO_LOCALIDAD_ORIGEN;
            this.dtgTickets.Columns[(int)Columnas.LocalidadDestino].HeaderText = Resource.LBL_TICKET_LISTADO_LOCALIDAD_DESTINO;
            this.dtgTickets.Columns[(int)Columnas.Fecha].HeaderText = Resource.LBL_TICKET_LISTADO_FECHA;
            this.dtgTickets.Columns[(int)Columnas.Fecha].ItemStyle.Wrap = false;
            this.dtgTickets.Columns[(int)Columnas.Operador].HeaderText = Resource.LBL_TICKET_LISTADO_OPERADOR;
            this.dtgTickets.Columns[(int)Columnas.Empresa].HeaderText = Resource.LBL_TICKET_LISTADO_EMPRESA;
            this.dtgTickets.Columns[(int)Columnas.Fecha].HeaderText = Resource.LBL_TICKET_LISTADO_FECHA;
            this.dtgTickets.Columns[(int)Columnas.Operador].HeaderText = Resource.LBL_TICKET_LISTADO_OPERADOR;
            
            ((ButtonColumn)this.dtgTickets.Columns[(int)Columnas.IdTicket]).CommandName = COMMNAD_VER_TICKET;
            


            // Botones
            this.btnBuscar.Text = Resource.BTN_BUSCAR;
            this.btnFreeSeacrh.Text = Resource.BTN_FREE_SEARCH;
            this.rdbAvanzada.Text = Resource.TXT_BUSQUEDA_AVANZADA;
            this.rdbID.Text = Resource.TXT_BUSQUEDA_ID;

            // Alineamientos de columnas.
            this.dtgTickets.Columns[(int)Columnas.IdTicket].ItemStyle.HorizontalAlign = HorizontalAlign.Right;
            this.dtgTickets.Columns[(int)Columnas.Patente].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            this.dtgTickets.Columns[(int)Columnas.Fecha].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            
            



        }

        private void MostrarTicket(string idTicket)
        {
            Classes.SessionHelper.ID_CASO = Int32.Parse(idTicket);
            this.goView(Classes.Views.CASO_MODIF);
        }

        protected void InicializaControles()
        {
            this.CargarListado(this.Filtro, 1);
        }

        #endregion Metodos

        #region Eventos

        protected void dtgAfiliados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dtgAfiliados_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            int a = e.NewPageIndex;
            this.CargarListado(this.Filtro, a + 1);
        }

        private string ResultMarcaModelo(string marca, string modelo)
        {
            string result = string.Empty;
            string separador = string.Empty;

            if (marca.Trim() != string.Empty && modelo.Trim() != string.Empty)
                separador = "/";

            result = marca + separador + modelo;

            return result;
        }

        protected void dtgAfiliados_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entities.InterAsisst.Ticket t = (Entities.InterAsisst.Ticket)e.Item.DataItem;

                ((LinkButton)e.Item.Cells[(int)Columnas.IdTicket].Controls[0]).CommandArgument = t.ID.ToString();
                ((LinkButton)e.Item.Cells[(int)Columnas.IdTicket].Controls[0]).Text = t.ID.ToString();
                ((LinkButton)e.Item.Cells[(int)Columnas.IdTicket].Controls[0]).ToolTip = String.Format(Resource.TOOL_TIP_ID_CASO, t.ID.ToString());
                e.Item.Cells[(int)Columnas.Tipo].Text = t.TipoTicket;
                e.Item.Cells[(int)Columnas.MarcaModelo].Text = ResultMarcaModelo(t.Marca, t.Modelo);
                e.Item.Cells[(int)Columnas.Patente].Text = t.Patente;
                e.Item.Cells[(int)Columnas.LocalidadOrigen].Text = t.NombreLocalidadOrigen;
                e.Item.Cells[(int)Columnas.LocalidadDestino].Text = t.NombreLocalidadDestino;
                e.Item.Cells[(int)Columnas.Empresa].Text = t.NombreEmpresa;
                e.Item.Cells[(int)Columnas.Fecha].Text = t.Fecha.ToString();
                e.Item.Cells[(int)Columnas.Operador].Text = t.NombreOperador;
            
            }
        }

        

        protected void dtgAfiliados_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case COMMNAD_VER_TICKET:
                    this.MostrarTicket(e.CommandArgument.ToString());
                    break;

            }
        }

        
        protected void btnFreeSeacrh_Click(object sender, EventArgs e)
        {
            this.txtSearch.Text = string.Empty;
            this.rdbID.Checked = true;
            this.Filtro.Reset();
            this.CargarListado(this.Filtro, 1);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Filtro.Search = this.txtSearch.Text.Trim();
            if (this.rdbID.Checked)
            {
                this.CargarListadoID(this.Filtro, 1);
            }
            else
            {
                this.CargarListado(this.Filtro, 1);
            }
        }

        #endregion Eventos
    }
}