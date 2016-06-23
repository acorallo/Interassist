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
using UI.InterAssist.Modelviews;
using EN = Ext.Net;


namespace UI.InterAssist.Views
{
	public partial class CasoCrud : Classes.Views, ICrmPage
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

		private const string UPDATE_PANEL_KEY = "UpdatePanel_postBack";
		
		private const string ASYNC_AGREGAR_PRESTADOR_METHOD = "AgregarPrestador";
		private const string ASYNC_QUITAR_PRESTADOR_METHOD = "QuitarPrestador";

		private const string VW_LISTA_PRESTADORES_ASIGNADOS = "vw_prestadores_asignados";

		private const string PRESTADOR_DETALLES_COMMAND = "detalles_prestador";
		

		#endregion Constantes

		#region Enumeradores

		private enum ColumnasPrestador
		{
			ID,
			Nombre,
			Kilometros,
			Costo,
			TipoAsistencia,
			Detalles,
			Eliminar
		}
		
		#endregion Enumeradores

		#region Constructores
		#endregion Constructores

		#region Miembros

		#endregion Miembros

		#region Propiedades

		
		private List<Modelviews.PrestadorCasoMV> PrestadoresAsignados
		{
			get
			{
				if (this.Session[VW_LISTA_PRESTADORES_ASIGNADOS] == null)
					this.Session[VW_LISTA_PRESTADORES_ASIGNADOS] = new List<Modelviews.PrestadorCasoMV>();

				return (List<Modelviews.PrestadorCasoMV>)this.Session[VW_LISTA_PRESTADORES_ASIGNADOS];

			}

			set
			{
				this.Session[VW_LISTA_PRESTADORES_ASIGNADOS] = value;
			}
		}

		private List<TipoServicio> _tiposServicios = null;
		/*
		private List<TipoServicio> TiposServicios
		{
			get
			{
				if (_tiposServicios == null)
				{
					Classes.Views.AgergarElijaOpcion(this.ddlTipoServicio);
					FiltroTipoServicio f = new FiltroTipoServicio();
					f.OrderBY = " order by descripcion asc";

					this._tiposServicios = TipoServicio.List(f);
				}

				return this._tiposServicios;
			}
		}
		*/


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

		

		public static Modelviews.PrestadorModelView getPrestador(int idPrestador)
		{
			Modelviews.PrestadorModelView result = null;

			Entities.InterAsisst.Prestador p = Entities.InterAsisst.Prestador.GetById(idPrestador);

			if(p!=null)
			{   
				result = new Modelviews.PrestadorModelView();
				result.Id = p.ID;
				result.Localidad = p.LocalidadNombre;
				result.Nombre = p.Nombre;
				result.Pais = p.NombrePais;
				result.Provincia = p.ProvinciaNombre;
				result.Telefono1 = p.Telefono1;
                result.Telefono2 = p.Telefono2;
                result.Email = p.Email;

			}

			return result;

		}
		
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			this.SincronizaPopModal();
		}

		private void ShowAsPrestador()
		{
			
			/*
			this.divDatosPrestador.Visible = true && this.IdPrestador != -1;
			this.DivBusquedaPrestador.Visible = false;
			*/
		}

		private void ShowAsBuscador()
		{
			/*
			this.divDatosPrestador.Visible = false;
			this.DivBusquedaPrestador.Visible = true;
			this.ShowList(false);
			 */
		
		}

		private void SetTicketInCotrols(Entities.InterAsisst.Ticket t)
		{
			this.ObjectHash = t.UObjectID;
			this.lbltxtCaso.Text = t.ID.ToString();
			this.lblTextOperador.Text = string.Format(OPERADOR_TEXT, t.Operador.ID.ToString(), t.Operador.Apellido, t.Operador.Nombre);
			this.lblTextFecha.Text = t.Fecha.ToString();

			this.ddlEstado.SelectedValue = t.IdEstado.ToString();
			this.ddlTipoCaso.SelectedValue = t.TipoTicket;

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
			/*
			this.IdPrestador = t.IdPrestador;
			this.Prestadorctrl.CargarPrestador(t.IdPrestador);
			*/


			// Prestadores

			/*
			this.dtgPrestadoresAsignados.DataSource = t.PrestadorCaso;
			this.dtgPrestadoresAsignados.DataBind();
			*/

			this.CargarPrestadores(t.PrestadorCaso);

			// Observaciones
			this.ddlProblema.SelectedValue = t.IdProblema.ToString();
			if (t.ObservacionesHistoricas.Count > 0)
			{
				this.ShowObservaciones(true);
				this.rptObservaciones.DataSource = t.ObservacionesHistoricas;
				this.rptObservaciones.DataBind();
			}

		}

		private void CargarPrestadores(List<PrestadorCaso> prestadores)
		{
			this.PrestadoresAsignados.Clear();
			foreach (var p in PrestadorCasoMV.getList(prestadores))
			{
				this.PrestadoresAsignados.Add(p);
			}


			this.CargarPrestadoresViewState();
		}

		/*
		private void CargarPrestadores(List<PrestadorCaso> prestadores)
		{
			this.PrestadoresAsignados.Clear();
            foreach (PrestadorCasoMV p in PrestadorCasoMV.getList(prestadores))
			{
				this.PrestadoresAsignados.Add(p);
			}

			this.CargarPrestadoresViewState();

		}
	    */
        
		public void CargarPrestadoresViewState()
		{
			List<PrestadorCasoMV> listado = PrestadoresActivos();
			this.StorePrestadorAsignado.DataSource = listado;
			this.StorePrestadorAsignado.DataBind();
            this.setPrestadoresAsignadosVisible();
        }
		
		/*
		public void CargarPrestadoresViewState()
		{


			List<PrestadorCasoModelView> listado = PrestadoresActivos();
			
			this.lblSinPrestadores.Visible = listado.Count == 0;
			this.dtgPrestadoresAsignados.Visible = listado.Count > 0;
			
			this.dtgPrestadoresAsignados.DataSource = listado;
			this.dtgPrestadoresAsignados.DataBind();

						
		}
		 */

		/*
		private List<PrestadorCasoModelView> PrestadoresActivos()
		{
			List<PrestadorCasoModelView> resultList = new List<PrestadorCasoModelView>();

			foreach (PrestadorCasoModelView p in this.PrestadoresAsignados)
			{
				if(p.Estado!=Constants.PersistOperationType.Delete)
				{
					resultList.Add(p);
				}
			}

			return resultList;
		}
		*/

		private List<PrestadorCasoMV> PrestadoresActivos()
		{
			List<PrestadorCasoMV> resultList = new List<PrestadorCasoMV>();

			foreach (PrestadorCasoMV p in this.PrestadoresAsignados)
			{
				if (p.Estado != Constants.PersistOperationType.Delete)
				{
					resultList.Add(p);
				}
			}

			return resultList;
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

			
			t.IdProblema = Int32.Parse(this.ddlProblema.SelectedValue);
			/*t.IdTipoServicio = Int32.Parse(this.ddlTipoServicio.SelectedValue);*/
			
			// Detalles
			t.Observacion = new Observacion(SessionOperador.ID);
			t.Observacion.Descripcion = string.Format(TIPO_TICKET, t.TipoTicket) +  this.txtDetalles.Text.Trim();

			// Prestadores


			foreach(var p in this.PrestadoresAsignados)
			{

                PrestadorCaso entPrestador = p.getPrestadorCaso();
                
                if(!entPrestador.IsNew || entPrestador.TipoOperacion!=Constants.PersistOperationType.Delete)
				{
					t.PrestadorCaso.Add(p.getPrestadorCaso());
				}
			}
 
			
			return t;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			base.Page_Load(sender, e);

			this.SincronizaSelector();
			//this.UpdatePanel_PostBack_Eval();
            this.Page_load_Ext_Components(sender, e);
		   
			if (!this.IsPostBack)
			{
				this.AssignTextToControls();
				this.InicializaControles();
			}
			else
			{
				this.SincrinizaCloseModal();
			}


			if (!Ext.Net.X.IsAjaxRequest)
			{
                this.BindPrestadoresAsignados();
                this.InicializaStoreComboTipoAsistencia();
			}
			

		}

		private void BindPrestadoresAsignados()
		{
			this.StorePrestadorAsignado.DataSource = this.PrestadoreAsignadosActivos();
			this.StorePrestadorAsignado.DataBind();
		}

        List<PrestadorCasoMV> PrestadoreAsignadosActivos()
        {

            List<PrestadorCasoMV> result = new List<PrestadorCasoMV>();


            foreach (PrestadorCasoMV p in this.PrestadoresAsignados)
            {
                if (p.Estado != Constants.PersistOperationType.Delete)
                {
                    result.Add(p);
                }
            }

            return result;
        }
		
      
		private void QuitarPrestadorViewState(string pInternalID)
		{
			/*
			foreach (PrestadorCasoMV p in this.PrestadoresAsignados)
			{
				if (p.InternalID == pInternalID)
					p.Estado = Constants.PersistOperationType.Delete;

			}
			*/

			CargarPrestadoresViewState();

			/*
			 *       <ext:RecordField Name="Id" />
					<ext:RecordField Name="Nombre" />
					<ext:RecordField Name="Pais" />
					<ext:RecordField Name="Provincia" />
					<ext:RecordField Name="Ciudad" />
			 * 
			 */
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
		
        /*
		private void AgregarPrestador(int Idprestador, int tipoAsistencia, string detalles, decimal kilometos, decimal costo)
		{


			Entities.InterAsisst.Prestador prestador = Entities.InterAsisst.Prestador.GetById_ReadOnly(Idprestador);
			Entities.InterAsisst.TipoServicio TServicio = Entities.InterAsisst.TipoServicio.GetById(tipoAsistencia);

			Modelviews.PrestadorCasoModelView prestador_vm = new PrestadorCasoModelView(prestador);
			prestador_vm.Detalles = detalles;
			prestador_vm.IdTipoAsistencia = tipoAsistencia;
			prestador_vm.TipoAsistencia = TServicio.Descripcion;
			//prestador_vm.Estado = Constants.PersistOperationType.Create;
			prestador_vm.Costo = costo;
			prestador_vm.Kilometros = kilometos;
			
			//this.PrestadoresAsignados.Add(prestador_vm);
			this.CargarPrestadoresViewState();

		}
        */
		

		private void InicializaComboTipoAsistencia(DropDownList combo, List<TipoServicio> TiposServicios)
		{
			Classes.Views.AgergarElijaOpcion(combo);
			foreach (TipoServicio t in TiposServicios)
			{
				combo.Items.Add(new ListItem(t.Descripcion, t.ID.ToString()));
			}
		}
		/*
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
		*/
		private void InicializaComboEstados()
		{
			// Esto deberia salir de una clase entidad.
			this.ddlEstado.Items.Add(new ListItem("Abierto","1"));
			this.ddlEstado.Items.Add(new ListItem("En curso", "3"));
			this.ddlEstado.Items.Add(new ListItem("Cerrado","2"));
		 

			this.ddlEstado.SelectedValue = "1";
		}

		private void AssignTextToControls()
		{

			// Labels
			this.lblIdCaso.Text = Resource.LBL_CASO_ID + Resource.LBL_SEPARADOR;
			this.lblDetalles.Text = Resource.LBL_CASO_DETALLES + Resource.LBL_SEPARADOR;
			this.lblHistorico.Text = Resource.LBL_CASO_HISTORICO + Resource.LBL_SEPARADOR;
			this.lblProblemaMecanico.Text = Resource.LBL_TICKET_PROBLEMA + Resource.LBL_SEPARADOR;
			//this.lblCantReg.Text = Resource.TXT_RECORD_COUNT + Resource.LBL_SEPARADOR;
			this.lblEstado.Text = Resource.LBL_TICKET_ESTADO + Resource.LBL_SEPARADOR;
			this.lblTelefono.Text = Resource.LBL_TICKET_TELEFONO + Resource.LBL_SEPARADOR;
			this.lblOperador.Text = Resource.LBL_TICKET_OPERADOR + Resource.LBL_SEPARADOR;
			this.lblFecha.Text = Resource.LBL_TICKET_FECHA_HORA + Resource.LBL_SEPARADOR;
			this.lblNonObs.Text = Resource.LBL_TICKET_NON_OBSERVACIONES;
			this.lblTipoCaso.Text = Resource.LBL_TICKET_TIPO + Resource.LBL_SEPARADOR;
			/*this.lblTipoAsistencia.Text = Resource.LBL_TICKET_TIPO_ASISTENCIA + Resource.LBL_SEPARADOR;*/




			// Secciones
			this.lblOrigen.Text = Resource.LBL_SECCION_CASO_ORIGEN;
			this.lblDestino.Text = Resource.LBL_SECCION_CASO_DESTINO;

			// botones
			this.btnAceptarSalir.Text = Resource.BTN_GUARDAR_Y_SALIR;
			this.btnAceptar.Text = Resource.BTN_ACEPTAR;
			this.btnCancelar.Text = Resource.BTN_CANCELAR;
			
			//this.btnBuscarPrestador.Text = Resource.BTN_BUSCAR;
			//this.btnLimpiarBusqueda.Text = Resource.BTN_FREE_SEARCH;

            // Validadores
            this.cmvProblema.ErrorMessage = string.Format(Resource.ERR_REQUEST_COMBO, Resource.LBL_TICKET_PROBLEMA);
            this.cmvPrestador.ErrorMessage = Resource.ERR_PRESTADOR_OBLIGATORIO;
            this.rfvTelefono.ErrorMessage = string.Format(Resource.ERR_REQUEST_FIELD, Resource.LBL_TICKET_TELEFONO);
            this.cmvTipoCaso.ErrorMessage = string.Format(Resource.ERR_REQUEST_COMBO, Resource.LBL_TICKET_TIPO);
            this.cmvPrestador_valid.ErrorMessage = Resource.ERR_CASO_PRESTADOR;


            // Ext Controles
            // Informacion
            this.QPrest_Detalles_Cuit.FieldLabel = Resource.LBL_PRESTADOR_CIUT;
            this.QPrest_Detalles_iva.FieldLabel = Resource.LBL_PRESTADOR_IVA;
            this.QPrest_Detalles_Id.FieldLabel = Resource.LBL_PRESTADOR_ID;
            this.QPrest_Detalles_Activo.FieldLabel = Resource.LBL_PRESTADOR_ESTADO;
            // Ubicación
            this.QPrest_Detalles_Pais.FieldLabel = Resource.LBL_PRESTADOR_PAIS;
            this.QPrest_Detalles_Provincia.FieldLabel = Resource.LBL_PRESTADOR_PROVINCIA;
            this.QPrest_Detalles_Ciudad.FieldLabel = Resource.LBL_PRESTADOR_CIUDAD;
            this.QPrest_Detalles_Localidad.FieldLabel = Resource.LBL_PRESTADOR_LOCALIDAD;
            this.QPrest_Detalles_Domicilio.FieldLabel = Resource.LBL_PRESTADOR_DOMICILIO;
            // Contactos
            this.QPrest_Detalles_Email.FieldLabel = Resource.LBL_PRESTADOR_EMAIL;
            this.QPrest_Detalles_Nextel.FieldLabel = Resource.LBL_PRESTADOR_NEXT_TEX;
            this.QPrest_Detalles_Telefono.FieldLabel = Resource.LBL_PRESTADOR_TELEFONO1;
            this.QPrest_Detalles_Telefono2.FieldLabel = Resource.LBL_PRESTADOR_TELEFONO2;
            this.QPrest_Detalles_Celular.FieldLabel = Resource.LBL_PRESTADOR_CELULAR;
            this.QPrest_Detalles_Celular2.FieldLabel = Resource.LBL_PRESTADOR_CELULAR2;
            // Tarifas
            this.lblMovida.Text = Resource.LBL_PRESTADOR_MOVIDA;
            this.lblkm.Text = Resource.LBL_PRESTADOR_KM;
            this.lblLiv.Text = Resource.LBL_PRESTADOR_LIV;
            this.lblSp1.Text = Resource.LBL_PRESTADOR_SP1;
            this.lblSp2.Text = Resource.LBL_PRESTADOR_SP2;
            this.lblps1.Text = Resource.LBL_PRESTADOR_PS1;
            this.lblPs2.Text = Resource.LBL_PRESTADOR_PS2;

            this.lblNoPrestadoresAsignados.Text = Resource.TXT_CASO_SIN_PRESTADOR;

            this.WdoInformacioPrestador.Title = Resource.TXT_PRESTADORES_INFORMACION;


		}

		private void InicializaStoreComboTipoAsistencia()
		{
	 
			FiltroTipoServicio f = new FiltroTipoServicio();
			f.OrderBY = " order by descripcion asc";

			List<TipoServicio> TiposServicios = TipoServicio.List(f);
			this.StoreComboTipoAsistencia.DataSource = TiposServicios;
			this.StoreComboTipoAsistencia.DataBind();
	 
		}
		
		private void ShowObservaciones(bool value)
		{
			this.divNonObs.Visible = !value;
			this.divObservacinoes.Visible = value;
		}

		private void InicializaControles()
		{
            this.PrestadoresAsignados.Clear();
			this.EntityID = Classes.SessionHelper.ID_CASO;
			

			this.ShowAsPrestador();
			this.inicializaControlUbicacionDestino();
			this.InicializaControlUbicacionOrigen();
			//this.InicializaCombosPrestador();
			this.InicializaComboTipos();
			
			this.InicializaComboProblema();
			this.InicializaComboEstados();
			/*this.InicializaComboTipoAsistencia();*/

			if (!this.IsNew)
			{
				Entities.InterAsisst.Ticket t = Entities.InterAsisst.Ticket.GetById(this.EntityID);
				var a = t.PrestadorCaso;
				Classes.SessionHelper.ID_CASO_AFILIADO = t.IdAfiliado;
				this.SetTicketInCotrols(t);
			}
			else
			{
				this.InicializaControlAfilado(Classes.SessionHelper.ID_CASO_AFILIADO);
				this.ShowObservaciones(false);  
			}

			this.InicializaControlAfilado(Classes.SessionHelper.ID_CASO_AFILIADO);


			this.SetValidadores(this.ddlTipoCaso.SelectedValue);
			this.InicializaStoreComboTipoAsistencia();
			

		}

		private void QuitarPrestador()
		{
			this.IdPrestador = DEFAULT_ID;
			//this.divDatosPrestador.Visible = false;
		   
		}

		private void InicializaControlAfilado(int idAfiliado)
		{
			this.ctrlAfiliado.IdAfiliado = idAfiliado;
		}

		/*
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
		 */

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



		private void AsignarPrestador(string idPrestador)
		{
			this.IdPrestador = Int32.Parse(idPrestador);

			
			this.ShowAsPrestador();
		}

		private void MasInformación(string idPrestador)
		{

		}

		private void ShowPrestadorInformation(string idPrestador)
		{
			 this.PrestadorInfo.CargarPrestador(Int32.Parse(idPrestador));
			 this.PopUp = "divPrestadorInfo";
		}

		private void ShowBuscarPrestador()
		{
			this.PopUp = "DivBusquedaPrestador";
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
			this.ShowBuscarPrestador();            
		}

		/*
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
		 */

		protected void cmvPrestador_ServerValidate(object source, ServerValidateEventArgs args)
		{
			args.IsValid = this.PrestadoresActivos().Count > 0;
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
			args.IsValid = this.ddlTipoCaso.SelectedValue != Classes.Views.COMBO_ELIJA_OPCION;
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

		#region Eventos
		/*
		protected void cmvTipoAsisitencia_ServerValidate(object source, ServerValidateEventArgs args)
		{
			args.IsValid = this.ddlTipoServicio.SelectedValue != Classes.Views.COMBO_ELIJA_OPCION;
		}
		*/
		protected void btnAceptarSalir_Click(object sender, EventArgs e)
		{
			this.Aceptar(true);
		}

		protected void btnAceptar_Click(object sender, EventArgs e)
		{
			this.Aceptar(false);
		}

		protected void dtgPrestadoresAsignados_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void dtgPrestadoresAsignados_SelectedIndexChanged1(object sender, EventArgs e)
		{

		}
        /*
		protected void dtgPrestadoresAsignados_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				PrestadorCasoModelView p = (PrestadorCasoModelView)e.Item.DataItem;

				


				((LinkButton)e.Item.Cells[(int)ColumnasPrestador.Nombre].Controls[0]).Text = p.NombrePrestador;
				((LinkButton)e.Item.Cells[(int)ColumnasPrestador.Nombre].Controls[0]).CommandArgument = p.IdPrestador.ToString();
				((LinkButton)e.Item.Cells[(int)ColumnasPrestador.Nombre].Controls[0]).ToolTip = "Ver Detalles";
				
				e.Item.Cells[(int)ColumnasPrestador.Costo].Text = p.Costo.ToString("C");
				e.Item.Cells[(int)ColumnasPrestador.Costo].HorizontalAlign = HorizontalAlign.Right;
				e.Item.Cells[(int)ColumnasPrestador.Kilometros].Text = p.Kilometros.ToString("0.000");
				e.Item.Cells[(int)ColumnasPrestador.Kilometros].HorizontalAlign = HorizontalAlign.Right;
				e.Item.Cells[(int)ColumnasPrestador.TipoAsistencia].Text = p.TipoAsistencia;
				e.Item.Cells[(int)ColumnasPrestador.Detalles].Text = p.Detalles;
				e.Item.Cells[(int)ColumnasPrestador.Eliminar].Attributes.Add("onClick", "QuitarPrestador('"+p.InternalID+"','"+p.NombrePrestador+"')");
				e.Item.Cells[(int)ColumnasPrestador.Eliminar].ToolTip = "Quitar Prestador";

			}
		}
        */
        
		protected void dtgPrestadoresAsignados_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			if (e.CommandName == PRESTADOR_DETALLES_COMMAND)
			{
				int id = Int32.Parse(e.CommandArgument.ToString());
				//this.PrestadorctrlDetalle.CargarPrestador(id);
				this.PopUp = "divPrestadorDetalle";

			}
		}

		#endregion Eventos

		#region Ext.Net
		
		private UI.InterAssist.Modelviews.PrestadorCasoMV GetPrestadorAsignadoById(string id)
		{
			UI.InterAssist.Modelviews.PrestadorCasoMV r = null;

			foreach(UI.InterAssist.Modelviews.PrestadorCasoMV prestador in this.PrestadoresAsignados)
			{
				if(prestador.Id == id)
				{
					r = prestador;
					break;
				}
			}

			return r;
		}
		
		protected void HandleChanges(object sender, EN.BeforeStoreChangedEventArgs e)
		{
			EN.ChangeRecords<UI.InterAssist.Modelviews.PrestadorCasoMV> Prestadores = e.DataHandler.ObjectData<UI.InterAssist.Modelviews.PrestadorCasoMV>();
			
			foreach (UI.InterAssist.Modelviews.PrestadorCasoMV p in Prestadores.Created)
			{
				//StorePrestadorAsignado.UpdateRecordId(p.Id, Guid.NewGuid().ToString());

				string internalid = Utils.InterAssist.Constants.CONST_NEW_PREFIX + Guid.NewGuid().ToString();
				StorePrestadorAsignado.UpdateRecordId(p.Id, internalid);
				p.Id = internalid;
				p.Estado = Constants.PersistOperationType.Persist;
				this.PrestadoresAsignados.Add(p);
			}

			foreach (UI.InterAssist.Modelviews.PrestadorCasoMV p in Prestadores.Updated)
			{
				UI.InterAssist.Modelviews.PrestadorCasoMV prestador = this.GetPrestadorAsignadoById(p.Id);
				if(prestador!=null)
				{
					prestador.IdPrestador = p.IdPrestador;
					prestador.IdTipoAsistencia = p.IdTipoAsistencia;
					prestador.Kilometros = p.Kilometros;
					prestador.Costo = p.Costo;
					prestador.Estado = Constants.PersistOperationType.Persist;
					
				}
			}

		   foreach (UI.InterAssist.Modelviews.PrestadorCasoMV p in Prestadores.Deleted)
		   {
			   UI.InterAssist.Modelviews.PrestadorCasoMV prestador = this.GetPrestadorAsignadoById(p.Id);
			   if (prestador != null)
			   {
				   prestador.Estado = Constants.PersistOperationType.Delete;
			   }
		   }

           this.setPrestadoresAsignadosVisible();
        }



        public void setPrestadoresAsignadosVisible()
        {
            
            if (this.PrestadoresActivos().Count > 0)
            {
                this.GridPanel1.Show();
                this.btnQuitarPrestador.Show();
                this.lblNoPrestadoresAsignados.Hide();
            }
            else
            {
                this.GridPanel1.Hide();
                this.btnQuitarPrestador.Hide();
                this.lblNoPrestadoresAsignados.Show();
            }
             
        }

        public void Page_load_Ext_Components(object sender, EventArgs e)
        {


            this.setPrestadoresAsignadosVisible();

            if (!EN.X.IsAjaxRequest)
            {
                this.Cargar_CmbPaisFiltroPrestador();
            }
        }


        #region Busqueda Avanzada


        private void Cargar_CmbPaisFiltroPrestador()
        {

            int DefaultPais = 1;

            var dataTablepaises = Pais.List();
            this.Pais_PrestadorBusquedaAvanzada.DataSource = dataTablepaises;
            this.Pais_PrestadorBusquedaAvanzada.DataBind();
            this.cmbPaisFiltroPrestador.SelectedItem.Value = DefaultPais.ToString();
            this.Cargar_cmbProvinciaFiltroPrestador(DefaultPais);
        }

        private void Cargar_cmbProvinciaFiltroPrestador(int id)
        {
            this.Provincia_PrestadorBusquedaAvanzada.DataSource = UI.InterAssist.Views.services.GetProvincias(id);
            this.Provincia_PrestadorBusquedaAvanzada.DataBind();
        }


        protected void BeforeExpand(object sender, EN.DirectEventArgs e)
        {
            e.ExtraParamsResponse["content"] = string.Format("<span class=\"template\">Company: {0}, Row �: {1}, Server Date: {2}</span>", e.ExtraParams["company"], e.ExtraParams["index"], DateTime.Now.ToString());
        }

        protected void IniciarBusqueda_DirectClick(object sender, EN.DirectEventArgs e)
        {
            string value = string.Empty;


            var valPais = this.cmbPaisFiltroPrestador.Value;
            var valProvincia = this.cmbProvinciaFiltroPrestador.Value;
            var valLocalidad = this.cmbUbicacionFiltroPrestador.Value;
            var varNombre = this.txtNombreFiltroPrestador.Text;
            

            
            Utils.InterAssist.FiltroPrestador f = new Utils.InterAssist.FiltroPrestador();

            if (valPais != null)
                f.IdPais = Int32.Parse(valPais.ToString());

            if (valProvincia != null)
                f.IdProvincia = Int32.Parse(valProvincia.ToString());


            if (valLocalidad != null)
                f.IdCiudad = Int32.Parse(valLocalidad.ToString());

            if (varNombre.Trim() != string.Empty)
                f.Nombre = varNombre.ToString();

           

            BuscarPrestador(f);
        }

        protected void BusquedaSimplificada_DirectClick(object sender, EN.DirectEventArgs e)
        {
            string value = txtBusquedaSimple.Text.Trim();


            Utils.InterAssist.FiltroPrestador f = new Utils.InterAssist.FiltroPrestador();
            f.Search = value;

            BuscarPrestador(f);

        }


        private void BuscarPrestador(Utils.InterAssist.FiltroPrestador f)
        {
            List<Modelviews.PrestadorModelView> listaPrestadores = Modelviews.PrestadorModelView.getPrestadorModelView(Entities.InterAsisst.Prestador.List(f));
            StorePrestadoresBusquedaAvanzada.DataSource = listaPrestadores;
            StorePrestadoresBusquedaAvanzada.DataBind();
        }



        [EN.DirectMethod]
        public void GridCommand(string command, string record)
        {
            if (command == "InformacionPrestador")
            {
                if (record.Trim() != string.Empty)
                {
                    int id = Int32.Parse(record);

                    Entities.InterAsisst.Prestador p = Entities.InterAsisst.Prestador.GetById(id);

                    if (p != null)
                    {
                        this.PrestadorView.LoadPrestador(id);
                        this.WdoInformacioPrestador.Show();
                    }
                }
            }
        }



        #endregion Busqueda Avanzada

        protected void cmvPrestador_valid_ServerValidate(object source, ServerValidateEventArgs args)
        {

            bool result = false;
           
            var prestadores = this.PrestadoresActivos();

            if (prestadores.Count > 0)
            {

                foreach (var p in prestadores)
                {
                    result = p.IdPrestador != 0 && p.IdTipoAsistencia.ToString() != string.Empty;
                    if (!result)
                        break;
                }
            }
            else
            {
                result = true;
            }

            args.IsValid = result;
        }

        #endregion Ext.Net

    }
}
