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
using Cognitas.Framework.UserInterface;

namespace UI.InterAssist.Views
{
    public partial class CasoCrud1 : Classes.Views, ICrmPage
    {
        #region Constantes

        private const string VS_ID_PRESTADOR = "vs_prestador";
        private const string VS_ID_POP_UP = "vs_popup";
        private const string POP_UP_PRESTAODRES = "BusquedaPrestados";

        private const string COMMNAD_ASIGNAR_PRESTADOR = "cmdAsignarPrestador";
        private const string COMMNAD_INFO_PRESTADOR = "cmdMasInfoPrestador";

        private const string POP_ERROR_MSG = "dialog-message_error";
        private const string POP_CREATE_MSG = "dialog-message_create";
        private const string POP_CREATE_MSG_SALIR = "dialog-message_create_salir";

        private const string TIPO_ASISTENCIA = "Asistencia";
        private const string TIPO_TRASLADO = "Traslado";
        private const string TIPO_ASESORAMIENTO = "Asesoramiento";

        private const string TIPO_TICKET = "Tipo de Caso: {0}<br>";

        private const string OPERADOR_TEXT = "{0} - {1}, {2}";

        #endregion Constantes

        #region Enumeradores

        private enum ColumnasPrestador
        {
            Id=0,
            Nombre, 
            Pais,
            Provincia,
            Localidad,
            Domicilio,
            Telefono1,
            MasInfo,
            Asignar,

        }
        
        #endregion Enumeradores

        #region Constructores
        #endregion Constructores

        #region Miembros

        #endregion Miembros

        #region Propiedades

        private string PopUp
        {
            get
            {
                if (this.ViewState[VS_ID_POP_UP] == null)
                    this.ViewState.Add(VS_ID_POP_UP, string.Empty);
                return this.ViewState[VS_ID_POP_UP].ToString();

            }
            set
            {
                this.ViewState.Add(VS_ID_POP_UP, value);
            }
        }

        protected override bool ReqAdmin
        {
            get { return false; }
        }

        protected override bool ReqLogin
        {
            get { return true; }
        }

        public override string ViewName
        {
            get { return Classes.Views.CASO_MODIF; }
        }

        public override string Seccion
        {
            get
            {
                return Resource.SECCION_ADM_CASOS;
            }
        }

        public FiltroPrestador FiltroPrestador
        {
            get
            {
                if (this.ViewState[VIEW_STATE_FILTRO] == null)
                    this.ViewState.Add(VIEW_STATE_FILTRO, new FiltroPrestador());
                return (FiltroPrestador)this.ViewState[VIEW_STATE_FILTRO];

            }
            set
            {
                this.ViewState.Add(VIEW_STATE_FILTRO, value);
            }
        }

        public int IdPrestador
        {
            get
            {
                if (this.ViewState[VS_ID_PRESTADOR] == null)
                    this.ViewState.Add(VS_ID_PRESTADOR, DEFAULT_ID);
                return Int32.Parse(this.ViewState[VS_ID_PRESTADOR].ToString());

            }
            set
            {
                this.ViewState.Add(VS_ID_PRESTADOR, value);
            }
        }

        public bool TienePrestadorAsignado
        {
            get
            {
                return this.IdPrestador != DEFAULT_ID;
            }
        
        }

        #endregion Propiedades

        #region Metodos

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.SincronizaPopModal();
        }

        private void ShowAsPrestador()
        {

            this.divDatosPrestador.Visible = true && this.IdPrestador != -1;
            this.DivBusquedaPrestador.Visible = false;
        }

        private void ShowAsBuscador()
        {
            this.divDatosPrestador.Visible = false;
            this.DivBusquedaPrestador.Visible = true;
            this.ShowList(false);
        }

        private void SetTicketInCotrols(Entities.InterAsisst.Ticket t)
        {
            this.ObjectHash = t.UObjectID;
            this.lbltxtCaso.Text = t.ID.ToString();
            this.lblTextOperador.Text = string.Format(OPERADOR_TEXT, t.Operador.ID.ToString(), t.Operador.Apellido, t.Operador.Nombre);
            this.lblTextFecha.Text = t.Fecha.ToString();

            this.ddlEstado.SelectedValue = t.IdEstado.ToString();

            this.ddlProblema.SelectedValue = t.IdProblema.ToString();
            this.txtTelefono.Text = t.Telefono;

            this.UbicacionDestino.IsNew = false;
            this.UbicacionOrigen.IsNew = false;

            // Datos Origen
            this.UbicacionOrigen.Dirección = t.CalleOrigen;
            this.UbicacionOrigen.IdPais = t.IdPaisOrigen;
            this.UbicacionOrigen.IDLocalidad = t.IdLocalidadOrigen;
            

            // Datos Destino
            this.UbicacionDestino.Dirección = t.CalleDestino;
            this.UbicacionOrigen.IdPais = t.IdPaisOrigen;
            this.UbicacionDestino.IDLocalidad = t.IdLocalidadDestino;

            // Prestador
            this.IdPrestador = t.IdPrestador;
            this.Prestadorctrl.CargarPrestador(t.IdPrestador);

            // Observaciones
            this.ddlProblema.SelectedValue = t.IdProblema.ToString();
            if (t.ObservacionesHistoricas.Count > 0)
            {
                this.ShowObservaciones(true);
                this.rptObservaciones.DataSource = t.ObservacionesHistoricas;
                this.rptObservaciones.DataBind();
            }

            this.divDatosPrestador.Visible = t.IdPrestador != -1;
            this.ddlTipoCaso.SelectedValue = t.TipoTicket;
            this.ddlTipoServicio.SelectedValue = t.IdTipoServicio.ToString();

            


        }

        private Entities.InterAsisst.Ticket GetTicketFromControl()
        {
            Entities.InterAsisst.Ticket t = new Entities.InterAsisst.Ticket(this.EntityID, this.ObjectHash);

            t.IdAfiliado = Classes.SessionHelper.ID_CASO_AFILIADO;
            t.IdEstado = Int32.Parse(this.ddlEstado.SelectedValue);
            t.Telefono = this.txtTelefono.Text.Trim();
            t.IDOperador = this.SessionOperador.ID;
            t.TipoTicket = this.ddlTipoCaso.SelectedValue;


            // Datos Origen.
            Classes.Ubicacion uOrigen = this.UbicacionOrigen.GetUbicacion;
            
            t.IdPaisOrigen = uOrigen.IDPais;
            t.IdProvinciaOrigen = uOrigen.IDProvincia;
            t.IdCiudadOrigen = uOrigen.IDCiudad;
            t.IdLocalidadOrigen = uOrigen.IDLocalidad;
            

            t.CalleOrigen = this.UbicacionOrigen.Dirección;

            // Datos Destino.
            Classes.Ubicacion uDestino = this.UbicacionDestino.GetUbicacion;

            t.IdPaisDestino = uDestino.IDPais;
            t.IdProvinciaDestino = uDestino.IDProvincia;
            t.IdCiudadDestino = uDestino.IDCiudad;
            t.IdLocalidadDestino = uDestino.IDLocalidad;
            
            t.CalleDestino = this.UbicacionDestino.Dirección;

            t.IdPrestador = this.IdPrestador;
            t.IdProblema = Int32.Parse(this.ddlProblema.SelectedValue);
            t.IdTipoServicio = Int32.Parse(this.ddlTipoServicio.SelectedValue);
            
            // Detalles
            t.Observacion = new Observacion(SessionOperador.ID);
            t.Observacion.Descripcion = string.Format(TIPO_TICKET, t.TipoTicket) +  this.txtDetalles.Text.Trim();

            
            return t;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            this.SincronizaSelector();

            if (!this.IsPostBack)
            {
                this.AssignTextToControls();
                this.InicializaControles();
            }
            else
            {
                this.SincrinizaCloseModal();
            }
        }

        private void SincrinizaCloseModal()
        {
            if (this.Request.Form["ClosePopUp"].ToString() != string.Empty)
            {
                this.PopUp = string.Empty;
            }
        }

        private void InicializaComboTipos()
        {
            Classes.Views.AgergarElijaOpcion(this.ddlTipoCaso);
            List<TipoCaso> Tipos = TipoCaso.List();

            foreach (TipoCaso t in Tipos)
            {
                this.ddlTipoCaso.Items.Add(new ListItem(t.Descripcion, t.Descripcion));
            }
        }

        private void InicializaComboTipoAsistencia()
        {
            Classes.Views.AgergarElijaOpcion(this.ddlTipoServicio);
            FiltroTipoServicio f = new FiltroTipoServicio();
            f.OrderBY = " order by descripcion asc";

            List<TipoServicio> TiposServicios = TipoServicio.List(f);

            foreach (TipoServicio t in TiposServicios)
            {
                this.ddlTipoServicio.Items.Add(new ListItem(t.Descripcion, t.ID.ToString()));
            }
        }

        private void InicializaComboEstados()
        {
            // Esto deberia salir de una clase entidad.
            this.ddlEstado.Items.Add(new ListItem("Abierto","1"));
            this.ddlEstado.Items.Add(new ListItem("Cerrado","2"));

            this.ddlEstado.SelectedValue = "1";
        }

        private void AssignTextToControls()
        {

            // Labels
            this.lblIdCaso.Text = Resource.LBL_CASO_ID + Resource.LBL_SEPARADOR;
            this.lblDetalles.Text = Resource.LBL_CASO_DETALLES + Resource.LBL_SEPARADOR;
            this.lblHistorico.Text = Resource.LBL_CASO_HISTORICO + Resource.LBL_SEPARADOR;
            this.lblPresadorPais.Text = Resource.LBL_PRESTADOR_PAIS + Resource.LBL_SEPARADOR;
            this.lblPrestadorProvincia.Text = Resource.LBL_PRESTADOR_PROVINCIA + Resource.LBL_SEPARADOR;
            this.lblPrestadorCiudad.Text = Resource.LBL_PRESTADOR_CIUDAD + Resource.LBL_SEPARADOR;
            this.lblPrestadorNombre.Text = Resource.LBL_PRESTADOR_NOMBRE + Resource.LBL_SEPARADOR;
            this.lblProblemaMecanico.Text = Resource.LBL_TICKET_PROBLEMA + Resource.LBL_SEPARADOR;
            this.lblCantReg.Text = Resource.TXT_RECORD_COUNT + Resource.LBL_SEPARADOR;
            this.lblEstado.Text = Resource.LBL_TICKET_ESTADO + Resource.LBL_SEPARADOR;
            this.lblTelefono.Text = Resource.LBL_TICKET_TELEFONO + Resource.LBL_SEPARADOR;
            this.lblOperador.Text = Resource.LBL_TICKET_OPERADOR + Resource.LBL_SEPARADOR;
            this.lblFecha.Text = Resource.LBL_TICKET_FECHA_HORA + Resource.LBL_SEPARADOR;
            this.lblNonObs.Text = Resource.LBL_TICKET_NON_OBSERVACIONES;
            this.lblNonResult.Text = Resource.TXT_NON_RESULTS;
            this.lblTipoCaso.Text = Resource.LBL_TICKET_TIPO + Resource.LBL_SEPARADOR;
            this.lblTipoAsistencia.Text = Resource.LBL_TICKET_TIPO_ASISTENCIA + Resource.LBL_SEPARADOR;

            // Secciones
            this.lblOrigen.Text = Resource.LBL_SECCION_CASO_ORIGEN;
            this.lblDestino.Text = Resource.LBL_SECCION_CASO_DESTINO;

            // botones
            this.btnAceptarSalir.Text = Resource.BTN_GUARDAR_Y_SALIR;
            this.btnAceptar.Text = Resource.BTN_ACEPTAR;
            this.btnCancelar.Text = Resource.BTN_CANCELAR;
            this.btnBuscarPrestador.Text = Resource.BTN_BUSCAR;
            this.btnLimpiarBusqueda.Text = Resource.BTN_FREE_SEARCH;

            
            this.btnAsignarPrestador.Text = Resource.BTN_ASIGNAR_PRESTADOR;

            // Validadores
            this.cmvProblema.ErrorMessage = string.Format(Resource.ERR_REQUEST_COMBO, Resource.LBL_TICKET_PROBLEMA);
            this.cmvPrestador.ErrorMessage = Resource.ERR_PRESTADOR_OBLIGATORIO;
            this.rfvTelefono.ErrorMessage = string.Format(Resource.ERR_REQUEST_FIELD, Resource.LBL_TICKET_TELEFONO);
            this.cmvTipoCaso.ErrorMessage = string.Format(Resource.ERR_REQUEST_COMBO, Resource.LBL_TICKET_TIPO);
            this.cmvTipoAsisitencia.ErrorMessage = string.Format(Resource.ERR_REQUEST_COMBO, Resource.LBL_TICKET_TIPO_ASISTENCIA);

            // Columnas del listado del Prestadore
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Id].HeaderText = Resource.LBL_PRESTADOR_ID;
            //this.dtgPrestador.Columns[(int)ColumnasPrestador.Nombre].HeaderText = Resource.LBL_PRESTADOR_NOMBRE;
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Pais].HeaderText = Resource.LBL_PRESTADOR_PAIS;
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Provincia].HeaderText = Resource.LBL_PRESTADOR_PROVINCIA;
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Localidad].HeaderText = Resource.LBL_PRESTADOR_LOCALIDAD;
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Domicilio].HeaderText = Resource.LBL_PRESTADOR_DOMICILIO;
            this.dtgPrestador.Columns[(int)ColumnasPrestador.Telefono1].HeaderText = Resource.LBL_PRESTADOR_TELEFONO1;
            ((ButtonColumn)this.dtgPrestador.Columns[(int)ColumnasPrestador.MasInfo]).Text = Resource.BTN_PRESTADOR_INFO;
            ((ButtonColumn)this.dtgPrestador.Columns[(int)ColumnasPrestador.MasInfo]).CommandName = COMMNAD_INFO_PRESTADOR;
            ((ButtonColumn)this.dtgPrestador.Columns[(int)ColumnasPrestador.Asignar]).Text = Resource.BTN_PRESTADOR_ASIGNAR;
            ((ButtonColumn)this.dtgPrestador.Columns[(int)ColumnasPrestador.Asignar]).CommandName = COMMNAD_ASIGNAR_PRESTADOR;

        }

        private void ShowObservaciones(bool value)
        {
            this.divNonObs.Visible = !value;
            this.divObservacinoes.Visible = value;
        }

        private void InicializaControles()
        {
            this.EntityID = Classes.SessionHelper.ID_CASO;
            

            this.ShowAsPrestador();
            this.inicializaControlUbicacionDestino();
            this.InicializaControlUbicacionOrigen();
            this.InicializaCombosPrestador();
            this.InicializaComboTipos();
            
            this.InicializaComboProblema();
            this.InicializaComboEstados();
            this.InicializaComboTipoAsistencia();

            if (!this.IsNew)
            {
                Entities.InterAsisst.Ticket t = Entities.InterAsisst.Ticket.GetById(this.EntityID);
                Classes.SessionHelper.ID_CASO_AFILIADO = t.IdAfiliado;
                this.SetTicketInCotrols(t);
                

            }
            else
            {
                this.InicializaControlAfilado(Classes.SessionHelper.ID_CASO_AFILIADO);
                this.ShowObservaciones(false);
               
            }

            this.InicializaControlAfilado(Classes.SessionHelper.ID_CASO_AFILIADO);

            // Varifica si le tiene que cambiar el rotulo al boton.
            if (this.TienePrestadorAsignado)
            {
                this.btnAsignarPrestador.Text = Resource.BTN_QUITAR_PRESTADOR;
            }

            this.SetValidadores(this.ddlTipoCaso.SelectedValue);

        }

        private void QuitarPrestador()
        {
            this.IdPrestador = DEFAULT_ID;
            this.btnAsignarPrestador.Text = Resource.BTN_ASIGNAR_PRESTADOR;
            this.Prestadorctrl.Reiniciar();
            this.divDatosPrestador.Visible = false;
           
        }

        private void InicializaControlAfilado(int idAfiliado)
        {
            this.ctrlAfiliado.IdAfiliado = idAfiliado;
        }

        private void InicializaCombosPrestador()
        {

            List<Pais> paises = Pais.List();
            Classes.Views.AgragarOpcionBlank(this.ddlPrestadorPais);
            foreach (Pais p in paises)
            {
                this.ddlPrestadorPais.Items.Add(new ListItem(p.Nombre, p.IdPais.ToString()));
            }


            List<Provincia> Provincias = Provincia.ListAll();
            Classes.Views.AgragarOpcionBlank(this.ddlPresadorProvincia);
            foreach (Provincia p in Provincias)
            {
                this.ddlPresadorProvincia.Items.Add(new ListItem(p.Nombre, p.Id.ToString()));
            }

        }

        private void InicializaControlUbicacionOrigen()
        {
            this.UbicacionOrigen.Seccion = Resource.LBL_SECCION_CASO_ORIGEN;

        }

        private void inicializaControlUbicacionDestino()
        {
            this.UbicacionDestino.Seccion = Resource.LBL_SECCION_CASO_DESTINO;
        }

        private void InicializaComboProblema()
        {

            Classes.Views.AgergarElijaOpcion(this.ddlProblema);
            List<Problema> problemas = Problema.ListAll();
            foreach (Problema p in problemas)
            {
                this.ddlProblema.Items.Add(new ListItem(p.Desripcion, p.ID.ToString()));
            }

        }

        private void SincronizaSelector()
        {
            string currentSelect = string.Empty;

            if (this.IsPostBack)
            {
                currentSelect = this.Request.Form["sincSelector"];
            }

            this.litSelector.Text = string.Format(@"<input name=""CurrentSelector"" id=""CurrentSelector"" type=""hidden"" value=""{0}""/>", currentSelect);
        }

        private void SincronizaPopModal()
        {
            this.litPopUp.Text = string.Format(@"<input name=""popModal"" id=""popModal"" type=""hidden"" value=""{0}""/>", this.PopUp);
        }

        public void CargarListado(FiltroPrestador filtro, int pageNumber)
        {
            int totalRegistros;

            filtro.PageSize = PAGE_SIZE;
            filtro.IsPaged = true;
            filtro.StartRow = ((pageNumber - 1) * PAGE_SIZE) + 1;
            filtro.ESTADO = FiltroPrestador.ESTADO_ACTIVO;

            List<Entities.InterAsisst.Prestador> listaAfiliados = Entities.InterAsisst.Prestador.List(filtro, out totalRegistros);

            this.FiltroPrestador.FiltredRowsQtty = totalRegistros;

            this.ShowList(totalRegistros > 0);
            this.lbltxtCantReg.Text = totalRegistros.ToString();

            this.dtgPrestador.CurrentPageIndex = pageNumber - 1;
            this.dtgPrestador.VirtualItemCount = totalRegistros;
            this.dtgPrestador.DataSource = listaAfiliados;
            this.dtgPrestador.DataBind();
        }

        private void AsignarPrestador(string idPrestador)
        {
            this.IdPrestador = Int32.Parse(idPrestador);
            this.Prestadorctrl.CargarPrestador(this.IdPrestador);
            this.btnAsignarPrestador.Text = Resource.BTN_QUITAR_PRESTADOR;
            this.ShowAsPrestador();
        }

        private void MasInformación(string idPrestador)
        {

        }

        private void ShowList(bool value)
        {
            this.divNonResult.Visible = !value;
            this.divGrid.Visible = value;
            this.divCantregistros.Visible = value;
        }

        private void ShowPrestadorInformation(string idPrestador)
        {
             this.PrestadorInfo.CargarPrestador(Int32.Parse(idPrestador));
             this.PopUp = "divPrestadorInfo";
        }

        private void SendSuccMsg(string idTicket, bool Salir)
        {

            string popType;

            if (Salir)
                popType = POP_CREATE_MSG_SALIR;
            else
                popType = POP_CREATE_MSG;

            this.PopUp = popType;
            this.SendInputHidden(this.litSuccMsg, "txtCasoModal", string.Format(Resource.TXT_CASO_SUCCESS, idTicket));
            
        }

        private void SendErrorMsg()
        {
            this.PopUp = POP_ERROR_MSG;
            this.SendInputHidden(this.litSuccMsg, "txtCasoModal", Resource.TXT_CASO_ERROR);
        }

        private void SetValidadores(string tipoCaso)
        {
            this.UbicacionOrigen.Requerido = tipoCaso == TIPO_ASISTENCIA || tipoCaso == TIPO_TRASLADO;
            this.UbicacionDestino.Requerido = tipoCaso == TIPO_TRASLADO;
            
            this.cmvPrestador.Enabled = tipoCaso == TIPO_ASISTENCIA || tipoCaso == TIPO_TRASLADO;

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.GoBackView();
        }

        protected void btnAsignarPrestador_Click(object sender, EventArgs e)
        {
            if (!TienePrestadorAsignado)
            {
                this.ShowAsBuscador();
            }
            else
            {
                this.QuitarPrestador();
            }
            
        }

        protected void btnBuscarPrestador_Click(object sender, EventArgs e)
        {
            this.FiltroPrestador.Reset();

            if (this.ddlPrestadorPais.SelectedValue != Classes.Views.COMBO_ELIJA_OPCION.ToString())
                this.FiltroPrestador.IdPais = Int32.Parse(this.ddlPrestadorPais.SelectedValue);

            if (this.ddlPresadorProvincia.SelectedValue != Classes.Views.COMBO_ELIJA_OPCION.ToString())
                this.FiltroPrestador.IdProvincia = Int32.Parse(this.ddlPresadorProvincia.SelectedValue);

            this.FiltroPrestador.Nombre = this.txtPrestadorNombre.Text.ToString();
            this.FiltroPrestador.Localidad = this.txtPrestadorCiudad.Text.ToString();


            this.CargarListado(this.FiltroPrestador, 1);

        }

        protected void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            this.FiltroPrestador.Reset();
            this.CargarListado(this.FiltroPrestador, 1);
        }

        protected void cmvPrestador_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.IdPrestador != DEFAULT_ID;
        }

        protected void dtgPrestador_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case COMMNAD_ASIGNAR_PRESTADOR:
                    this.AsignarPrestador(e.CommandArgument.ToString());
                    break;
                case COMMNAD_INFO_PRESTADOR:
                    this.ShowPrestadorInformation(e.CommandArgument.ToString());
                    break;

            }
        }

        protected void dtgPrestador_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entities.InterAsisst.Prestador p = (Entities.InterAsisst.Prestador)e.Item.DataItem;

                e.Item.Cells[(int)ColumnasPrestador.Id].Text = p.ID.ToString();
                e.Item.Cells[(int)ColumnasPrestador.Pais].Text = p.NombrePais;
                e.Item.Cells[(int)ColumnasPrestador.Provincia].Text = p.ProvinciaNombre;
                e.Item.Cells[(int)ColumnasPrestador.Localidad].Text = p.LocalidadNombre;
                e.Item.Cells[(int)ColumnasPrestador.Nombre].Text = p.Nombre;
                e.Item.Cells[(int)ColumnasPrestador.Domicilio].Text = p.Domicilio;
                e.Item.Cells[(int)ColumnasPrestador.Telefono1].Text = p.Telefono1;
                ((LinkButton)e.Item.Cells[(int)ColumnasPrestador.MasInfo].Controls[0]).CommandArgument = p.ID.ToString();
                ((LinkButton)e.Item.Cells[(int)ColumnasPrestador.Asignar].Controls[0]).CommandArgument = p.ID.ToString();




            }
        }

        protected void dtgPrestador_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            int a = e.NewPageIndex;
            this.CargarListado(this.FiltroPrestador, a + 1);
        }

        protected void rptObservaciones_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Observacion o = (Observacion)e.Item.DataItem;

            string observaciones = Resource.TXT_OBSERVACIONES_SIN_OBS;

            if (o.Descripcion.ToString() != string.Empty)
                observaciones = o.Descripcion.ToString();


            ((Label)e.Item.FindControl("lblObsOperador")).Text = string.Format(OPERADOR_TEXT, o.IdOperador.ToString(), o.ApellidoOperador, o.NombreOperador);
            ((Label)e.Item.FindControl("lblObsFecha")).Text = o.Fecha.ToString();


            ((Label)e.Item.FindControl("lblObsText")).Text = observaciones;

        }

        private void ReloadEntity(int id)
        {
            this.EntityID = id;
            Ticket t = Ticket.GetById(id);
            this.SetTicketInCotrols(t);
        }

        private void Aceptar(bool salir)
        {
            if (this.IsValid)
            {
                Entities.InterAsisst.Ticket t = this.GetTicketFromControl();
                if (t.Persist())
                {
                    // Success:
                    if (!salir)
                        this.ReloadEntity(t.ID);

                    this.SendSuccMsg(t.ID.ToString(), salir);
                }
                else
                {
                    // Error:
                    this.SendErrorMsg();
                }

            }
        }

        #endregion 

        #region Eventos

        protected void cmvTipoCaso_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.ddlTipoServicio.SelectedValue != Classes.Views.COMBO_ELIJA_OPCION;
        }

        protected void ddlTipoCaso_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetValidadores(this.ddlTipoCaso.SelectedValue);
        }

        #endregion Eventos

 

        #region WebMethods

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

            }
            else
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
                    listResult.Add(new AjaxResponseCiudaes(dr["NOMBRE_COMPLETO"].ToString(), dr["NOMBRE_COMPLETO"].ToString(), Int32.Parse(dr["IDLOCALIDAD"].ToString())));
                }
            }
            catch
            {
            }

            return listResult.ToArray();
        }
        

        #endregion WebMethods

        protected void cmvTipoAsisitencia_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.ddlTipoServicio.SelectedValue != Classes.Views.COMBO_ELIJA_OPCION;
        }

        protected void btnAceptarSalir_Click(object sender, EventArgs e)
        {
            this.Aceptar(true);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Aceptar(false);
        }
    }
}
