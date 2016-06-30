<%@ Page Title="" Language="C#" MasterPageFile="~/InterAssist.Master" AutoEventWireup="true" CodeBehind="CasoCrud.aspx.cs" Inherits="UI.InterAssist.Views.CasoCrud" %>
<%@ Register src="../Usercontrols/Ubicacion.ascx" tagname="Ubicacion" tagprefix="uc1" %>
<%@ Register src="../Usercontrols/AfiliadoDetalle.ascx" tagname="AfiliadoDetalle" tagprefix="uc2" %>
<%@ Register src="../Usercontrols/Prestadorctrl.ascx" tagname="Prestadorctrl" tagprefix="uc3" %>
<%@ Register src="../Usercontrols/Operador.ascx" tagname="Operador" tagprefix="uc4" %>
<%@ Register src="../Usercontrols/CasoPrestador.ascx" tagname="CasoPrestador" tagprefix="uc5" %>
<%@ Register src="../Usercontrols/DecimalControl.ascx" tagname="DecimalControl" tagprefix="uc6" %>
<%@ Register Src="~/Usercontrols/Prestadorctrl.ascx" TagPrefix="uc1" TagName="Prestadorctrl" %>
<%@ Register Src="~/Usercontrols/PrestadorView.ascx" TagPrefix="uc1" TagName="PrestadorView" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">

		.style3
		{
			width: 100%;
		}

		.auto-style1 {
			height: 23px;
		}

		.auto-style2 {
			height: 23px;
		}

        .command-grid{
            background-color: white;
        }

        .icon_no_prestadores{
         
            margin-left: 20px;
            margin-top: auto;
         
        }

 
		</style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<script type="text/javascript" language="javascript" src="../Scripts/jquery-1.10.1.min.js"></script>   
	<script type="text/javascript" language="javascript" src="../Scripts/FrontControls.js"></script>
	<script type="text/javascript" language="javascript" src="../Scripts/CasoCrud.js"></script>

    <script type="text/javascript">
        



        var Prestadores = [];

        function getPrestadorFromServer(id) {

            var prestador = null;

            $.ajax({
                type: "POST",
                url: "services.aspx/getPrestadorWM",
                data: "{idPrestador: '" + id + "'}",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",

                success: function (data) {
                    
                    if (data.d != null) {
                        prestador = { Ciudad: "", Comentarios: "", Domicilio: "", Id: data.d.Id, Localidad: "", Nombre: data.d.Nombre, Pais: "", Provincia: "", Telefono: "" };
                    }
                
                },
                failure: function (data) { return null;}
            });

            return prestador;

        }

        

        /*
        function getPrestadorFromServer(id)
        {
            getPrestador(id, function (data) {

                
                var prestador = { Ciudad: "", Comentarios: "", Domicilio: "", Id: data.d.Id, Localidad: "", Nombre: data.d.Nombre, Pais: "", Provincia: "", Telefono: "" };
                
                if (findPrestadores(id) == null) {
                    Prestadores.push(prestador);
                    
                }

                return prestador;

            }, function (value) { });
        }
        */

        function findPrestadores(id)
        {
            var result = null;
            var i = 0;
            var hit = false;

            for (i = 0; i < Prestadores.length; i++)
            {
                if(Prestadores[i].Id == id)
                {
                    result = Prestadores[i];
                    hit = true;
                    break;
                }
            }
            if (!hit)
            {
                result = getPrestadorFromServer(id);
                if(result!=null)
                    Prestadores.push(result);
            }
           
            return result;
        }

        var TipoServicioRender = function (value) {

            var r = ContentPlaceHolder1_StoreComboTipoAsistencia.getById(value)

            if (Ext.isEmpty(r)) {
                return "";
            }

            return r.data.Descripcion;
        }

        var PrestadorRender = function (value)
        {
            if (value.length==0)
            {
                return value;
            }else
            {
                var p = findPrestadores(value)
                if (p != null)
                    return p.Nombre;

            }
            
        }



        var ConfirmDeletePrestador = function () {
            
            if (ContentPlaceHolder1_GridPanel1.getSelectionModel().selections.items.length > 0) {
                var Prestador = findPrestadores(ContentPlaceHolder1_GridPanel1.getSelectionModel().selections.items[0].data.IdPrestador);

                var nombre = "";

                if (Prestador != null) {

                    var nombre = findPrestadores(ContentPlaceHolder1_GridPanel1.getSelectionModel().selections.items[0].data.IdPrestador).Nombre;
                }



                Ext.Msg.confirm("Confirmación", ("Desea quitar el prestador " + nombre), function (btnText) {

                    if (btnText == "yes") {
                        ContentPlaceHolder1_GridPanel1.deleteSelected();
                    }
                }
                );
            } else 
            {
                Ext.Msg.alert("Información","Seleccione un elemento de la lista");
            }

        };
       
        var StorePrestador_BeforeLoad = function (store, records, options) {
            
            var i = 0;
            for(i=0;i<records.length;i++)
            {
                if(findPrestadores(records[i].json.Id)==null)
                {
                    Prestadores.push(records[i].json);
                }
            }

        };


        
        Ext.onReady(function () {
            ContentPlaceHolder1_WinBusquedaPrestador.hide();
        });

        /*
        function Mostrar_WinBusquedaPrestador()
        {
            ContentPlaceHolder1_WinBusquedaPrestador.show();
        }

        */
        function PerstadorAsociado_Busquera(command, source, record)
        {
            if (command == 'BuscaquedaAvanzada')
            {
                InicializaBusquedaAzanzada(record);
            } else if (command == 'InformacionPrestador')
            {
                Ext.net.DirectMethods.GridCommand(command, record.data.IdPrestador)
            }
            
        }
        
        var RecordStoredBusqueda = new function()
        {
            this.record = null;
            this.set = function (r) { this.record = r; };
            this.get = function () { return this.record; };
        }


        function InicializaBusquedaAzanzada(record)
        {
            reset_SrvAdv();
            RecordStoredBusqueda.set(record);
            ContentPlaceHolder1_WinBusquedaPrestador.show();
        }

        var template = '<span style="color:{0};">{1}</span>';

        var change = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value);
        }

        var pctChange = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value + "%");
        }

        var setRaw = function (response, result, expander, type, action, params) {
            expander.bodyContent[params.id] = result.extraParamsResponse.content;

            var row = expander.grid.view.getRow(params.index);
            var body = Ext.DomQuery.selectNode('tr div.x-grid3-row-body', row);
            body.innerHTML = result.extraParamsResponse.content;

            //For example we will cache rows with an even index
            if (isEven(params.index)) {
                expander.grid.store.getById(params.id).cached = true;
            }
        }

        var isEven = function (num) {
            return !(num % 2);
        }


        var buscarOnClick = function () {
            
            if(!ContentPlaceHolder1_FiltroBuscaPrestadores.isVisible())
            {
                BusquedaAvanzada_show();
            }else
            {
                ContentPlaceHolder1_FiltroBuscaPrestadores.setVisible(false);
            }
        }


        var LimpiarFiltroPrestador = function () {
            txtPais.text = "";
        }


        function TestWs() {
            Ext.net.DirectMethod.request({
                url: "views/services.aspx/ListLocalidades",
                cleanRequest: true,
                json: true,
                params: {
                    idPais: 10,
                    idPrivincia: 15,
                    value: "Prueba"

                },
                success: function (result) {
                    Ext.Msg.alert("Xml Message", result);
                }
            });
        }

        function BeforQuery_cmbUbicacionFiltroPrestador() {
            var idPais = "-1";
            var idProvincia = "-1";

            if (ContentPlaceHolder1_cmbPaisFiltroPrestador.value)
                idPais = ContentPlaceHolder1_cmbPaisFiltroPrestador.value;

            if (ContentPlaceHolder1_cmbProvinciaFiltroPrestador.value)
                idProvincia = ContentPlaceHolder1_cmbProvinciaFiltroPrestador.value;


            ContentPlaceHolder1_StoreUbicacionesFiltroPrestador.setBaseParam("paramIdProvincia", idProvincia);

            ContentPlaceHolder1_StoreUbicacionesFiltroPrestador.setBaseParam("paramIdPais", idPais);

        }

        function btnEliminarFiltroPrestador() {
            ContentPlaceHolder1_cmbProvinciaFiltroPrestador.clear();
            ContentPlaceHolder1_cmbUbicacionFiltroPrestador.clear();
            ContentPlaceHolder1_txtNombreFiltroPrestador.clear();

        }




        function Click_btnIniciarBusqueda() {
            ContentPlaceHolder1_grdPrestadorBusquedaAvanzada.loadMask.show();
        }

        function grdPrestadorgrdPrestadorBusquedaAvanzada_BeforeExpand(value) {
            if (!Ext.isEmpty(value)) {
                var expandedPrestador = ContentPlaceHolder1_StorePrestadoresBusquedaAvanzada.getById(value);
                if (expandedPrestador) {
                    setPrestadorInControls(expandedPrestador.data);
                }

            }
        }

        function setPrestadorInControls(Prestador) {

            var strTitulo = Prestador.Nombre;
            //ContentPlaceHolder1_quickPrestador_Titulo.setText(strTitulo);
            ContentPlaceHolder1_QPrest_Detalles_Activo.setValue(Prestador.Activo);
            ContentPlaceHolder1_QPrest_Detalles_Id.setValue(Prestador.Id);
            ContentPlaceHolder1_QPrest_Detalles_iva.setValue(Prestador.Iva);
            ContentPlaceHolder1_QPrest_Detalles_Cuit.setValue(Prestador.Cuit);
            ContentPlaceHolder1_QPrest_Detalles_Pais.setValue(Prestador.Pais);
            ContentPlaceHolder1_QPrest_Detalles_Provincia.setValue(Prestador.Provincia);
            ContentPlaceHolder1_QPrest_Detalles_Localidad.setValue(Prestador.Localidad);
            ContentPlaceHolder1_QPrest_Detalles_Ciudad.setValue(Prestador.Ciudad);
            ContentPlaceHolder1_QPrest_Detalles_Domicilio.setValue(Prestador.Domicilio);
            ContentPlaceHolder1_QPrest_Detalles_Descripcion.setValue(Prestador.Comentarios);
            ContentPlaceHolder1_QPrest_Detalles_Celular.setValue(Prestador.Celular1);
            ContentPlaceHolder1_QPrest_Detalles_Celular2.setValue(Prestador.Celular2);
            ContentPlaceHolder1_QPrest_Detalles_Nextel.setValue(Prestador.Nextel);
            ContentPlaceHolder1_QPrest_Detalles_Telefono.setValue(Prestador.Telefono1);
            ContentPlaceHolder1_QPrest_Detalles_Telefono2.setValue(Prestador.Telefono2);
            ContentPlaceHolder1_QPrest_Detalles_Email.setValue(Prestador.Email);
            // tarifas.
            ContentPlaceHolder1_decLivMovida.setText(Prestador.LIV_MOVIDA);
            ContentPlaceHolder1_decSp1Movida.setText(Prestador.SP1_MOVIDA);
            ContentPlaceHolder1_decSp2Movida.setText(Prestador.SP2_MOVIDA);
            ContentPlaceHolder1_decPs1Movida.setText(Prestador.PS1_MOVIDA);
            ContentPlaceHolder1_decPs2Movida.setText(Prestador.PS2_MOVIDA);
            ContentPlaceHolder1_decLivKm.setText(Prestador.LIV_KM);
            ContentPlaceHolder1_decPs1Km.setText(Prestador.PS1_KM);
            ContentPlaceHolder1_decPs2Km.setText(Prestador.PS2_KM);
            ContentPlaceHolder1_decSp1Km.setText(Prestador.SP1_KM);
            ContentPlaceHolder1_decSp2Km.setText(Prestador.SP2_KM);
        }

        Ext.onReady(function () {
            ContentPlaceHolder1_FiltroBuscaPrestadores.hide();
        });

        
        function BusquedaAvanzada_show()
        {

            ContentPlaceHolder1_FiltroBuscaPrestadores.show();
            ContentPlaceHolder1_cmbPaisFiltroPrestador.show();
            ContentPlaceHolder1_cmbProvinciaFiltroPrestador.show();
            ContentPlaceHolder1_txtNombreFiltroPrestador.show();
            ContentPlaceHolder1_cmbUbicacionFiltroPrestador.show();
        }

        function AgragarPrestadorAsignado(command, selectId)
        {
            if(command=='AgragarPrestador')
            {
                if (RecordStoredBusqueda.get() != null) {
                    var registro = RecordStoredBusqueda.get();
                    registro.set("IdPrestador", selectId);
                    ContentPlaceHolder1_WinBusquedaPrestador.hide();
                    reset_SrvAdv();
                }
            }
        }
    
        function resetFiltro_SrchAdvPrestador()
        {
            btnEliminarFiltroPrestador();
            ContentPlaceHolder1_FiltroBuscaPrestadores.setVisible(false);

        }

        function resetGrid_SrchAdvPrestador()
        {
            ContentPlaceHolder1_grdPrestadorBusquedaAvanzada.clear();
            ContentPlaceHolder1_txtBusquedaSimple.clear();
        }

        function reset_SrvAdv() {
            resetFiltro_SrchAdvPrestador();
            resetGrid_SrchAdvPrestador();
        }


    </script>

        <style type="text/css">
            .search-item {
                font          : normal 11px tahoma, arial, helvetica, sans-serif;
                padding       : 3px 10px 3px 10px;
                border        : 1px solid #fff;
                border-bottom : 1px solid #eeeeee;
                color         : #555;
            }
        
            .search-item h3 {
                display     : block;
                font        : inherit;
                font-weight : bold;
                color       : #222;
            }

            .search-item h3 span {
                float       : right;
                font-weight : normal;
                margin      : 0 0 5px 5px;
                width       : 100px;
                display     : block;
                clear       : none;
            } 
        
            p { width: 650px; }
        
            .ext-ie .x-form-text { position : static !important; }
        </style>
 
	<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="99999999"></asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
	<input type="hidden" id="ClosePopUp" name="ClosePopUp" value="" />
	<asp:Literal ID="litPopUp" runat="server"></asp:Literal>
	<asp:Literal ID="litSuccMsg" runat="server"></asp:Literal>

	<table class="style1">
		<tr>
			<td>
				<table class="style1">
					<tr>
						<td>
							<table class="style1">
								<tr>
									<td nowrap="nowrap" class="DatosTicket">
										<table class="style1">
											<tr>
												<div id="divDatosTicket" runat="server">
													<td align="left" width="100%" colspan="2">
														<table class="style3">
															<tr>
																<td align="right">
																	<asp:Label ID="lblIdCaso" runat="server"></asp:Label>
																</td>
																<td align="left" width="100%">
																	<asp:Label ID="lbltxtCaso" runat="server"></asp:Label>
																</td>
															</tr>
															<tr>
																<td align="right">
																	<asp:Label ID="lblOperador" runat="server"></asp:Label>
																</td>
																<td align="left">
																	<asp:Label ID="lblTextOperador" runat="server"></asp:Label>
																</td>
															</tr>
															<tr>
																<td align="right">
																	<asp:Label ID="lblFecha" runat="server"></asp:Label>
																</td>
																<td align="left">
																	<asp:Label ID="lblTextFecha" runat="server"></asp:Label>
																</td>
															</tr>
														</table>
													</td>
												</div>
											</tr>
											<tr>
												<td align="right" nowrap="nowrap">
													<asp:Label ID="lblEstado" runat="server"></asp:Label>
												</td>
												<td align="left" width="100%">
													<asp:DropDownList ID="ddlEstado" runat="server">
													</asp:DropDownList>
												</td>
											</tr>
											<tr>
												<td align="right" nowrap="nowrap">
													<asp:Label ID="lblTipoCaso" runat="server"></asp:Label>
												</td>
												<td align="left" width="100%">
													<asp:DropDownList ID="ddlTipoCaso" runat="server" AutoPostBack="True" 
														onselectedindexchanged="ddlTipoCaso_SelectedIndexChanged">
													</asp:DropDownList>
													<asp:CustomValidator ID="cmvTipoCaso" runat="server" 
														ClientValidationFunction="validateCombo" ControlToValidate="ddlTipoCaso" 
														CssClass="errorText" onservervalidate="cmvTipoCaso_ServerValidate">*</asp:CustomValidator>
												</td>
											</tr>
											<tr>
												<td align="right" nowrap="nowrap">
													<asp:Label ID="lblTelefono" runat="server"></asp:Label>
												</td>
												<td align="left" width="100%">
													<asp:TextBox ID="txtTelefono" runat="server" Width="250px"></asp:TextBox>
													<asp:RequiredFieldValidator ID="rfvTelefono" runat="server" 
														ControlToValidate="txtTelefono" CssClass="errorText">*</asp:RequiredFieldValidator>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<input name="sincSelector" id="sincSelector" type="hidden" value=""/>
									<asp:Literal ID="litSelector" runat="server"></asp:Literal>
									<td>
									
									<div id="tabs">
											  <ul>
											   
												<li><a href="#tabs-Afiliado">Afiliado</a></li>
												<li><a href="#tabs-Ubicacion">Ubicacion</a></li>
												<li><a href="#tabs-Prestador">Prestadores</a></li>
												<li><a href="#tabs-Detalles">Detalles</a></li>
											  </ul>
											  <div id="tabs-Detalles" class="TicketTab">
																	 <table width="100%">
													<tr>
														<td align="left">
															<table>
																<tr>
																	<td align="right">
																		<asp:Label ID="lblProblemaMecanico" runat="server"></asp:Label>
																	</td>
																	<td align="left" width="100%">
																		<asp:DropDownList ID="ddlProblema" runat="server" Width="450px">
																		</asp:DropDownList>
																		<asp:CustomValidator ID="cmvProblema" runat="server" 
																			ClientValidationFunction="validateCombo" ControlToValidate="ddlProblema" 
																			CssClass="errorText">*</asp:CustomValidator>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td align="left">
															
														</td>
													</tr>
													<tr>
														<td align="left">
															<asp:Label ID="lblDetalles" runat="server"></asp:Label>
														</td>
													</tr>
													<tr>
														<td align="left">
															<asp:TextBox ID="txtDetalles" runat="server" Height="101px" 
																TextMode="MultiLine" Width="600px"></asp:TextBox>
														</td>
													</tr>
													<tr>
														<td align="left">
															<asp:Label ID="lblHistorico" runat="server"></asp:Label>
														</td>
													</tr>
													<tr>
														<td align="left">
															<table class="style3">
															<tr>
																<td>
															<div id="divObservacinoes" runat="server">
															 <div id="accordion">
															  <asp:Repeater ID="rptObservaciones" runat="server" onitemdatabound="rptObservaciones_ItemDataBound">
															   <ItemTemplate>
																 <h3><table width="100%">
																	<tr>
																		<td align="left"><asp:Label ID="lblObsOperador" runat="server"></asp:Label></td>
																		<td align="right"><asp:Label ID="lblObsFecha" runat="server"></asp:Label></td>
																	</tr>
																	</table>
																 </h3>
																	   <div>
																		   <p>
																			<asp:Label ID="lblObsText" runat="server"></asp:Label>
																		   </p>
																	   </div>
																</ItemTemplate>
															  </asp:Repeater>
															 </div>
															</div>
																
															</tr>

																<div id="divNonObs" runat="server">
																	<tr>
																		<td>
																			<asp:Label ID="lblNonObs" runat="server"></asp:Label>
																		</td>
																	</tr>
																</div>
															</table>
														</td>
													</tr>
												</table>
											  </div>
											  <div id="tabs-Afiliado" class="TicketTab">
												  <table class="style3">
													  <tr>
														  <td align="left">
															  <uc2:AfiliadoDetalle ID="ctrlAfiliado" runat="server" />
														  </td>
													  </tr>
												  </table>
											  </div>

											  <div id="tabs-Ubicacion" class="TicketTab">
												  <table align="center" class="style3">
													  <tr>
														  <td align="left" Class="Seccion">
															  <asp:Label ID="lblOrigen" runat="server"></asp:Label>
														  </td>
													  </tr>
													  <tr>
														  <td align="left">
															  <uc1:Ubicacion ID="UbicacionOrigen" runat="server" />
														  </td>
													  </tr>
													  <tr>
														  <td align="left" Class="Seccion">
															  <asp:Label ID="lblDestino" runat="server"></asp:Label>
														  </td>
													  </tr>
													  <tr>
														  <td align="left">
															  <uc1:Ubicacion ID="UbicacionDestino" runat="server" />
														  </td>
													  </tr>
												  </table>
											  </div>

									  
											  <div id="tabs-Prestador" align="left" class="TicketTab">
										 
											  
											  <table width="100%">
																<tr>
																	<td align="right">
																		<asp:Button ID="UpdatePanel_postBack" runat="server" CausesValidation="False" Text="Button" ClientIDMode="Static" style="display:none"/>
																		<asp:CustomValidator ID="cmvPrestador_valid" runat="server" CssClass="errorText" OnServerValidate="cmvPrestador_valid_ServerValidate">*</asp:CustomValidator>
																		<asp:CustomValidator ID="cmvPrestador" runat="server" CssClass="errorText" 
																			onservervalidate="cmvPrestador_ServerValidate">*</asp:CustomValidator>
																	</td>
																</tr>
																<tr>
																	<td align="right">
																		<table class="style3">
																		  
																			<tr>
																				<td>
																				
                                                                              <ext:ResourceManager runat="server" />

                                                                                <ext:Store
                                                                                    ID="StorePrestadorAsignado" 
                                                                                    runat="server" 
                                                                                    AutoSave="true" 
                                                                                    ShowWarningOnFailure="false"
                                                                                    OnBeforeStoreChanged="HandleChanges" 
                                                                                    SkipIdForNewRecords="false"
                                                                                    RefreshAfterSaving="None">
                                                                                    <Reader>
                                                                                       <ext:JsonReader IDProperty="Id">
                                                                                            <Fields>
                                                                                                <ext:RecordField Name="Id" Type="String" AllowBlank="true" />
                                                                                                <ext:RecordField Name="Kilometros" type="Float"/>
                                                                                                <ext:RecordField Name="Costo" type="Float"/>
                                                                                                <ext:RecordField Name="TipoAsistencia" Type = "String" />
                                                                                                <ext:RecordField Name="IdTipoAsistencia" Type="String" />
                                                                                                <ext:RecordField Name="IdPrestador" Type="Int" />
                                                                                                <ext:RecordField Name="Prestador" Type="String" AllowBlank="true"/>
                                                                                                <ext:RecordField Name="InternalID" Type="String " />
                                                                                            </Fields>
                                                                                        </ext:JsonReader>
                                                                                    </Reader>
                                                                                   <Listeners>
                                                                                        <Exception Handler="
                                                                                            Ext.net.Notification.show({
                                                                                                iconCls    : 'icon-exclamation', 
                                                                                                html       : e.message, 
                                                                                                title      : 'EXCEPTION', 
                                                                                                autoScroll : true, 
                                                                                                hideDelay  : 5000, 
                                                                                                width      : 300, 
                                                                                                height     : 200
                                                                                            });" />
                                                                                        <BeforeSave Handler="var valid = true; this.each(function(r){if(r.dirty && !r.isValid()){valid=false;}}); return valid;" />
                                                                                    </Listeners>
                                                                                </ext:Store>


																					<ext:Store runat="server" ID="StoreComboTipoAsistencia">
																						<Reader>
																							 <ext:JsonReader IDProperty="ID">
																								<Fields>
																									<ext:RecordField Name="ID" />
																									<ext:RecordField Name="Descripcion" />
																								</Fields>
																							</ext:JsonReader>
																						</Reader>
																					</ext:Store>

                                                                                

                                                                                <ext:Panel 
                                                                                    ID="PanelPrestadores" 
                                                                                    runat="server" 
                                                                                    Height="250" 
                                                                                    Width="800"
                                                                                    Icon="Table"
                                                                                    Title="Prestadores"
                                                                                    >
                                                                                    <Content>
                                                                                
                                                                                         <ext:Label runat="server" Icon="information" id="lblNoPrestadoresAsignados" CtCls="icon_no_prestadores"/>
                                                                                         <ext:GridPanel
                                                                                            ID="GridPanel1"
                                                                                            runat="server"
                                                                                            Frame="false"
                                                                                            Height="250"
                                                                                            Width="800"
                                                                                            StoreID="StorePrestadorAsignado"
                                                                                            EnableViewState="true">
                                                                                    <ColumnModel>
                                                                                        <Columns>

                                                                                            <ext:Column runat="server" Header="Prestador" DataIndex="IdPrestador" Width="400">
                                                                                                <Commands>
                                                                                                <ext:ImageCommand CommandName="BuscaquedaAvanzada" Icon="Magnifier" Text="Buscar">
                                                                                                   <ToolTip Text="Busqueda Avanzada" />           
                                                                                                </ext:ImageCommand>
                                                                                                <ext:ImageCommand Icon="information" CommandName="InformacionPrestador">
                                                                                                   <ToolTip Text="Ver detalles" />
                                                                                                </ext:ImageCommand>                                                                                                   
                                                                                            </Commands>   
                                                                                             <Renderer Fn="PrestadorRender" />
                                                                                                <Editor>
                                                                                                   <ext:ComboBox
                                                                                                        ID ="ComboBox1"
                                                                                                        runat="server"
                                                                                                        DisplayField="Nombre"
                                                                                                        ValueField="Id"
                                                                                                        LoadingText="Buscando ..."                
                                                                                                        TypeAhead="false"
                                                                                                        PageSize="10"
                                                                                                        HideTrigger="true"
                                                                                                        MinChars="1"              
                                                                                                        ItemSelector="div.search-item">
                                                                                                        <Store>
                                                                                                            <ext:Store runat="server" AutoLoad="false" Id="StorePrestador">
                                                                                                                <Proxy>
                                                                                                                    <ext:HttpProxy Method="POST" Url="~/Prestadores.ashx"/>
                                                                                                                </Proxy>
                                                                                                                <Reader>
                                                                                                                    <ext:JsonReader Root="Prestadores" TotalProperty="total" IDProperty="Id">
                                                                                                                        <Fields>
                                                                                                                            <ext:RecordField Name="Id" />
                                                                                                                            <ext:RecordField Name="Nombre" />
                                                                                                                            <ext:RecordField Name="Pais" />
                                                                                                                            <ext:RecordField Name="Provincia" />
                                                                                                                            <ext:RecordField Name="Ciudad" />
                                                                                                                        </Fields>
                                                                                                                    </ext:JsonReader>
                                                                                                                </Reader>
                                                                                                                <Listeners>
                                                                                                                    <Load Handler="={StorePrestador_BeforeLoad}" />
                                                                                                                </Listeners>
                                                                                                            </ext:Store>
                                                                                                        </Store>
                                                                                                    <Template runat="server">
                                                                                                       <Html>
					                                                                                       <tpl for=".">
                                                                                                            <div class="search-item">
                                                                                                                <h3><span>{Pais}, {Provincia}</span></h3>
                                                                                                                <h3>{Nombre}</h3>
                                                                                                                {Ciudad}
                                                                                                            </div>
					                                                                                       </tpl>
				                                                                                       </Html>
                                                                                                    </Template>
                                                                                                    </ext:ComboBox>
                                                                                                </Editor>
                                                                                            </ext:Column>

                                                                                            <ext:Column runat="server" Header="Kilometros" DataIndex="Kilometros" Align="Right">
                                                                                                <Renderer Fn="Ext.util.Format.numberRenderer('0000.000')" />
                                                                                                <Editor>
                                                                                                    <ext:NumberField runat="server" />
                                                                                                </Editor>
                                                                                            </ext:Column>

                                                                                            <ext:Column runat="server" Header="Costo" DataIndex="Costo" Align="Right">
                                                                                                <Renderer Format="UsMoney" />
                                                                                                <Editor>
                                                                                                    <ext:NumberField runat="server" />
                                                                                                </Editor>
                                                                                            </ext:Column>

                                                                                             <ext:Column runat="server" Header="TipoAsistencia" DataIndex="IdTipoAsistencia" Width="200">
                                                                                                   <Renderer Fn="TipoServicioRender" />
                                                                                                <Editor>
                                                                                                    <ext:ComboBox
                                                                                                        runat="server"
                                                                                                        DisplayField="Descripcion"
                                                                                                        ValueField="ID"
                                                                                                        EmptyText = "Elija una Opcion"
                                                                                                        Width="320"
                                                                                                        LabelWidth="130"
                                                                                                        QueryMode="Local"
                                                                                                        TypeAhead="true"
                                                                                                        StoreID="StoreComboTipoAsistencia">
                                                                                                    </ext:ComboBox>
                                                                                                </Editor>                           
                                                                                             </ext:Column>
                                                                                        </Columns>
                                                                                    </ColumnModel>
                                                                                    <Listeners>
                                                                                        <Command Handler="PerstadorAsociado_Busquera(command, this, record);"></Command>
                                                                                    </Listeners>
                                                                                   <View>
                                                                                        <ext:GridView runat="server" ForceFit="true" />
                                                                                    </View>

         
                                                                                    <SelectionModel>
                                                                                        <ext:RowSelectionModel runat="server" SingleSelect="true">
                                                                                        </ext:RowSelectionModel>
                                                                                    </SelectionModel>
                                                                                </ext:GridPanel>                                                                         
                                                                                    </Content>
                                                                                    <TopBar>
                                                                                        <ext:Toolbar runat="server">
                                                                                            <Items>
                                                                                                <ext:Button runat="server" Text="Agragar" Icon="Add" ToolTip="Agerga un prestador al caso" CausesValidation="false">
                                                                                                    <Listeners>
                                                                                                        <Click Handler="#{GridPanel1}.show();#{GridPanel1}.insertRecord();" />
                                                                                                    </Listeners>
                                                                                                </ext:Button>

                                                                                                <ext:Button runat="server" Text="Quitar" Icon="Exclamation" ToolTip="Seleccione un prestador de la lista para eliminar" ID="btnQuitarPrestador">
                                                                                                    <Listeners>
                                                                                                        <Click Handler="={ConfirmDeletePrestador}" />
                                                                                                    </Listeners>
                                                                                                </ext:Button>

                                                                                                <ext:ToolbarSeparator />

                                                                                            </Items>
                                                                                        </ext:Toolbar>
                                                                                    </TopBar>
                                                                                    
                                                                                </ext:Panel>

                                                                                
																				</td>
																			</tr>
																		</table>
																			
																	</td>
																</tr>
															</table>
											  </div>
									 </div>


	   
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td align="left">
							<asp:ValidationSummary ID="ValidationSummary1" runat="server" 
								CssClass="errorSummaryText" />
						</td>
					</tr>
					<tr>
						<td align="center">
							<table class="style3">
								<tr>
									<td width="33.3%">
										&nbsp;</td>
									<td align="center" width="33.3%">
										&nbsp;<asp:Button ID="btnAceptar" runat="server" onclick="btnAceptar_Click" />
										&nbsp;<asp:Button ID="btnCancelar" runat="server" CausesValidation="False" 
											onclick="btnCancelar_Click" />
									</td>
									<td align="right" width="33.3%">
										<asp:Button ID="btnAceptarSalir" runat="server" 
											onclick="btnAceptarSalir_Click" />
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td align="center" class="auto-style2">
							</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>

 
	
	<input type="hidden" id="UpdatePanel_postBack_Arguments" name="UpdatePanel_postBack_Arguments"/>
	<input type="hidden" name="CasoPrestador_Info_ID" id="CasoPrestador_Info_ID"/>
	<input type="hidden" name="CasoPrestador_Info_TipoAsistencia" id="CasoPrestador_Info_TipoAsistencia"/>
	<input type="hidden" name="CasoPrestador_Info_Descripcion" id="CasoPrestador_Info_Descripcion"/>
	<input type="hidden" name="CasoPrestador_Info_Kilomentros" id="CasoPrestador_Info_Kilomentros" />
	<input type="hidden" name="CasoPrestador_Info_Costo" id="CasoPrestador_Info_Costo" />
	<input type="hidden" id="BuscarPrestador_internalID" name ="BuscarPrestador_internalID" />
	

	</ContentTemplate>
	<Triggers>
		<asp:AsyncPostBackTrigger ControlID="UpdatePanel_postBack" EventName="Click"/>
	</Triggers>
	</asp:UpdatePanel>
	 <link rel="stylesheet" href="../Estilos/jTPS.css" type="text/css" />
	   <div style="visibility: hidden">
		<div id="divPrestadorInfo" title="Información del Prestador">
			<table>
				<tr>
					<td align="center">
					 <uc3:Prestadorctrl ID="PrestadorInfo" runat="server" />
					</td>
				</tr>
			</table>
		</div>
	</div>

  <div style="visibility:hidden">
	<div id="dialog-message_error">
		  <p>
			<span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>
			<p id="pErrMsgTxt"></p>
		  </p>
	</div>
  </div>

  <div style="visibility:hidden"> 
	<div id="DivAsignarPrestador" title="Asignar Prestador">
		 <div style="font-size:12px">
		  <p><uc5:CasoPrestador ID="CasoPrestador1" runat="server" />
		</div>
		  </p>
	</div>
  </div>


<div style="display:none">
	<div id="dialog-message_create">
		  <p>
			<span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>
			<p id="pSuxccMsgTxt"></p>
		  </p>

	</div>
</div>

	 <script type="text/javascript" language="javascript" src="../Scripts/jTPS.js"></script>

  <ext:Window 
            ID="WinBusquedaPrestador" 
            runat="server" 
            Title="Prestador - Busqueda Avanzada"  
            Icon="Magnifier"
            Height="600px" 
            Width="1100px"
            BodyStyle="background-color: #fff;" 
            Padding="5"
            Collapsible="false" 
            Modal="true">


    
            <Content>

       <ext:Store runat="server" ID="Pais_PrestadorBusquedaAvanzada">
            <Reader>
                <ext:JsonReader>
                    <Fields>
                        <ext:RecordField Name="IdPais"/>
                        <ext:RecordField Name="Nombre"/>
                    </Fields>
                </ext:JsonReader>
            </Reader>   
        </ext:Store>

        <ext:Store runat="server" ID="Provincia_PrestadorBusquedaAvanzada">
            <Reader>
                <ext:JsonReader>   
                    <Fields>
                        <ext:RecordField Name="id"/>
                        <ext:RecordField Name="value"/>
                    </Fields>
                </ext:JsonReader>
            </Reader>   
        </ext:Store>
        

        
    
    <ext:FormPanel runat="server" AnchorHorizontal="100%" Title="Busqueda Avanzaa" Padding="5" MonitorResize="true" ID="FiltroBuscaPrestadores">
        <Items>
            <ext:CompositeField runat="server" FieldLabel="Pais" AnchorHorizontal="100%">
                <Items>
                    <ext:ComboBox 
                        ID="cmbPaisFiltroPrestador" 
                        runat="server" 
                        DisplayField="Nombre" 
                        ValueField="IdPais"        
                        width="300"
                        StoreID="Pais_PrestadorBusquedaAvanzada"
                        Mode="Local">
                    </ext:ComboBox>
                </Items>
            </ext:CompositeField>
            <ext:CompositeField runat="server" FieldLabel="Provincia" AnchorHorizontal="100%">
                <Items>
                    <ext:ComboBox 
                        ID="cmbProvinciaFiltroPrestador" 
                        StoreID = "Provincia_PrestadorBusquedaAvanzada"
                        runat="server" 
                        DisplayField="value" 
                        ValueField="id"
                        width="300"
                        Mode="Local">
                    </ext:ComboBox>
                </Items>
            </ext:CompositeField>
            <ext:CompositeField runat="server" FieldLabel="Localidad" AnchorHorizontal="100%">
                <Items>
                    <ext:ComboBox
                        ID ="cmbUbicacionFiltroPrestador"
                        runat="server"
                        DisplayField="Ciudad"
                        ValueField="IDCiudad"
                        Width="300"
                        LoadingText="Buscando ..."                
                        TypeAhead="false"
                        PageSize="10"
                        HideTrigger="true"
                        MinChars="1"                                      
                        ItemSelector="div.search-item">
                        <Listeners>
                            <BeforeQuery Fn="={BeforQuery_cmbUbicacionFiltroPrestador}" />
                        </Listeners>
                        <Store>
                            <ext:Store runat="server" AutoLoad="false" Id="StoreUbicacionesFiltroPrestador">
                                <Proxy>
                                    <ext:HttpProxy Method="POST" Url="~/Ubicaciones.ashx"/>
                                </Proxy>
                                <Reader>
                                    <ext:JsonReader Root="Ubicaciones" TotalProperty="total" IDProperty="IDLocalidad">
                                        <Fields>
                                            <ext:RecordField Name="IDPais" />
                                            <ext:RecordField Name="IDProvincia" />
                                            <ext:RecordField Name="IDCiudad" />
                                            <ext:RecordField Name="IDLocalidad" />
                                            <ext:RecordField Name="Pais" />
                                            <ext:RecordField Name="Provincia" />
                                            <ext:RecordField Name="Ciudad" />
                                            <ext:RecordField Name="Localidad" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                    <Template runat="server">
                        <Html>
					        <tpl for=".">
                            <div class="search-item">
                                <h3><span>{Pais}, {Provincia}</span></h3>
                                <h3>{Localidad}</h3>
                                {Ciudad}
                            </div>
					        </tpl>
				        </Html>
                    </Template>
                    </ext:ComboBox>                   
                </Items>
            </ext:CompositeField>
            <ext:CompositeField runat="server" FieldLabel="Nombre" AnchorHorizontal="100%">
                <Items>
                    <ext:TextField runat="server" Width="300" id="txtNombreFiltroPrestador"/>
                </Items>
            </ext:CompositeField>
         
            <ext:Button runat="server" Text="Inciar Busquedar" Icon="Magnifier" ToolTip="Inicial Busqueda Avanzada" OnDirectClick="IniciarBusqueda_DirectClick" >
            <Listeners>
                <Click Handler="={Click_btnIniciarBusqueda}" />
            </Listeners>
            </ext:Button>

       </Items>
            <TopBar>
                <ext:Toolbar runat="server">
                <Items>
                    <ext:Toolbar runat="server" Cls="form-toolbar" Flat="true">
                        <Items>
                            <ext:Button runat="server" Text="Eliminar Filtros" Icon="BinEmpty" ToolTip="Elimina los parametros del filtro">
                                <Listeners>
                                    <Click Fn="={btnEliminarFiltroPrestador}" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Items>
                </ext:Toolbar>
            </TopBar>
    </ext:FormPanel>
   
 

        <ext:Store ID="StorePrestadoresBusquedaAvanzada" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="Id">
                    <Fields>
                        <ext:RecordField Name="Id" Type="Int"/>
                        <ext:RecordField Name="Nombre" type="String"/>
                        <ext:RecordField Name="Pais" type="String"/>
                        <ext:RecordField Name="Provincia" type="String"/>
                        <ext:RecordField Name="Ciudad" type="String"/>
                        <ext:RecordField Name="Localidad" type="String"/>
                        <ext:RecordField Name="Domicilio" type="String"/>
                        <ext:RecordField Name="Comentarios" type="String"/>
                        <ext:RecordField Name="Iva" type="String"/>
                        <ext:RecordField Name="Email" type="String"/>
                        <ext:RecordField Name="Cuit" type="String"/>
                        <ext:RecordField Name="Activo" type="String"/>
                        <ext:RecordField Name="Telefono1" type="String"/>
                        <ext:RecordField Name="Telefono2" type="String"/>
                        <ext:RecordField Name="Celular1" type="String"/>
                        <ext:RecordField Name="Celular2" type="String"/>
                        <ext:RecordField Name="Nextel" type="String"/>
                        <ext:RecordField Name="LIV_MOVIDA" type="Float"/>
                        <ext:RecordField Name="LIV_KM" type="Float"/>
                        <ext:RecordField Name="SP1_MOVIDA" type="Float"/>
                        <ext:RecordField Name="SP1_KM" type="Float"/>
                        <ext:RecordField Name="SP2_MOVIDA" type="Float"/>
                        <ext:RecordField Name="SP2_KM" type="Float"/>
                        <ext:RecordField Name="PS1_MOVIDA" type="Float"/>
                        <ext:RecordField Name="PS1_KM" type="Float"/>
                        <ext:RecordField Name="PS2_MOVIDA" type="Float"/>
                        <ext:RecordField Name="PS2_KM" type="Float"/>

                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
                <br />
        <ext:GridPanel 
            ID="grdPrestadorBusquedaAvanzada" 
            runat="server" 
            StoreID="StorePrestadoresBusquedaAvanzada" 
            TrackMouseOver="true"
            Title="Prestadores"  
            Icon="Table" 
            Height="500"
            AnchorHorizontal="100%"
            AutoScroll="true">
            <LoadMask ShowMask="true" />
            <ColumnModel runat="server" ID="ctl1486">
                <Columns>
                    <ext:Column Header="ID" DataIndex="Id" Width="60
                        "/>
                    <ext:Column Header="Nombre" DataIndex="Nombre" />
                    <ext:Column Header="Pais" DataIndex="Pais" />
                    <ext:Column Header="Provincia" DataIndex="Provincia" />
                    <ext:Column Header="Localidad" DataIndex="Localidad" />
                    <ext:Column Header="Ciudad" DataIndex="Ciudad" />
                    <ext:CommandColumn Width="15">
                        <Commands>
                            <ext:GridCommand Icon="Add" CommandName="AgragarPrestador" CtCls="command" StandOut="false">
                                <ToolTip Text="Agregar Prestador" />
                            </ext:GridCommand>
                        </Commands>
                    </ext:CommandColumn>
                </Columns>
            </ColumnModel>
            <View>
                <ext:GridView ID="GridView1" runat="server" ForceFit="true" />
            </View>
            <SelectionModel>
            </SelectionModel>
            <Plugins>
                <ext:RowExpander ID="RowExpander1" runat="server">
                    <Component>
                      
                    <ext:TabPanel 
                        ID="TabPanel1" 
                        runat="server" 
                        ActiveTabIndex="0" 
                        AnchorHorizontal="100%"
                        Plain="true"
                        ClientIDMode="Static">
                            <Items>
                                <ext:Panel 
                                    ID="Tab1" 
                                    runat="server" 
                                    Title="Información" 
                                    Padding="6" 
                                    AutoScroll="true" 
                                    LabelAlign="Top">                                 
                                    
                                    <Content>
                                        <table width="100%">
                                            <tr>
                                                <td><ext:TextField 
                                                        ID="QPrest_Detalles_Id" 
                                                        runat="server" 
                                                        Width="300"
                                                        ReadOnly="true"/>
                                               
                                                    <ext:TextField 
                                                        ID="QPrest_Detalles_Activo" 
                                                        runat="server" 
                                                        ReadOnly="true"
                                                        Width="300"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><ext:TextField 
                                                        ID="QPrest_Detalles_Cuit" 
                                                        runat="server" 
                                                        ReadOnly="true"
                                                        Width="500"/>
                                                
                                                    <ext:TextField 
                                                        ID="QPrest_Detalles_iva" 
                                                        runat="server" 
                                                        ReadOnly="true"
                                                        Width="500"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </Content>

                                </ext:Panel>
                            </Items>
                            <Items>
                                <ext:Panel 
                                    ID="Ubicacion" 
                                    runat="server" 
                                    Title="Ubicación" 
                                    Padding="6" 
                                    AutoScroll="true" >

                            
                                     <Content>
                                        <table>
                                            <tr>
                                                <td>
                                                <ext:TextField 
                                                        ID="QPrest_Detalles_Domicilio" 
                                                        runat="server" 
                                                        Width="600"
                                                        ReadOnly="true"/>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td><ext:TextField 
                                                        ID="QPrest_Detalles_Pais" 
                                                        runat="server" 
                                                        Width="600"
                                                        ReadOnly="true"/>
                                               
                                                    <ext:TextField 
                                                        ID="QPrest_Detalles_Provincia" 
                                                        runat="server" 
                                                        ReadOnly="true"
                                                        Width="600"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><ext:TextField 
                                                        ID="QPrest_Detalles_Ciudad" 
                                                        runat="server" 
                                                        ReadOnly="true"
                                                        Width="600"/>
                                                
                                                    <ext:TextField 
                                                        ID="QPrest_Detalles_Localidad" 
                                                        runat="server" 
                                                        ReadOnly="true"
                                                        Width="600"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </Content>      
                                    </ext:Panel>
                            </Items>      
                            <Items>
                                <ext:Panel 
                                    ID="Contactos" 
                                    runat="server" 
                                    Title="Contactos" 
                                    Padding="6" 
                                    AutoScroll="true">
                                    <Content>
                                        <table>
                                            <tr>
                                                <td>
                                                <ext:TextField 
                                                        ID="QPrest_Detalles_Email" 
                                                        runat="server" 
                                                        Width="600"
                                                        ReadOnly="true"/>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td><ext:TextField 
                                                        ID="QPrest_Detalles_Nextel" 
                                                        runat="server" 
                                                        Width="600"
                                                        ReadOnly="true"/>
                                               
                                                    <ext:TextField 
                                                        ID="QPrest_Detalles_Telefono" 
                                                        runat="server" 
                                                        ReadOnly="true"
                                                        Width="600"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><ext:TextField 
                                                        ID="QPrest_Detalles_Telefono2" 
                                                        runat="server" 
                                                        ReadOnly="true"
                                                        Width="600"/>
                                                
                                                    <ext:TextField 
                                                        ID="QPrest_Detalles_Celular" 
                                                        runat="server" 
                                                        ReadOnly="true"
                                                        Width="600"/>

                                                    <ext:TextField 
                                                        ID="QPrest_Detalles_Celular2" 
                                                        runat="server" 
                                                        ReadOnly="true"
                                                        Width="600"/>
                                                </td>
                                            </tr>
                                        </table>                                        
                                    </Content>
                                    </ext:Panel>
                            </Items>
                            <Items>
                                <ext:Panel 
                                    ID="Panel2" 
                                    runat="server" 
                                    Title="Descripción" 
                                    Padding="6" 
                                    AutoScroll="true" 
                                    >
                                    <Content>
                                        <ext:TextArea runat="server" Width="600" Height="100" ID="QPrest_Detalles_Descripcion"/>
                                    </Content>
                                </ext:Panel>
                            </Items>
                            <Items>
                                <ext:Panel 
                                    ID="Panel1" 
                                    runat="server" 
                                    Title="Tarifas" 
                                    Padding="6" 
                                    AutoScroll="true">
                                    <Content>
                                    <table style="border: 1px solid #000000" width="80%">
                                        <tr>
                                            <td align="center">
                                                &nbsp;</td>
                                            <td align="center">
                                                <asp:Label ID="lblLiv" runat="server"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblSp1" runat="server"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblSp2" runat="server"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblps1" runat="server"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lblPs2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" 
                                                style="border-style: 1; border-width: 1px; border-color: #000000;">
                                                <asp:Label ID="lblMovida" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: 1px solid #000000; margin-left: 80px;" align="right" 
                                                nowrap="nowrap">
                                                <ext:Label 
                                                ID="decLivMovida" 
                                                runat="server" 
                                                Width="50"/>
                                            </td>
                                            <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                            <ext:Label 
                                                ID="decSp1Movida" 
                                                runat="server" 
                                                ReadOnly="true"
                                                Width="50"/>
                                            </td>
                                            <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                               <ext:Label 
                                                ID="decSp2Movida" 
                                                runat="server" 
                                                ReadOnly="true"
                                                Width="50"/>
                                            </td>
                                            <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    
                                               <ext:Label 
                                                ID="decPs1Movida" 
                                                runat="server" 
                                                ReadOnly="true"
                                                Width="50"/>
                                            </td>
                                            <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                                <ext:Label 
                                                ID="decPs2Movida" 
                                                runat="server" 
                                                ReadOnly="true"
                                                Width="50"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" 
                                                style="border-style: 1; border-width: 1px; border-color: #000000;">
                                                <asp:Label ID="lblkm" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                              <ext:Label 
                                                ID="decLivKm" 
                                                runat="server" 
                                                ReadOnly="true"
                                                Width="50"/>
                                            </td>
                                            </td>
                                            <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    
                                              <ext:Label 
                                                ID="decSp1Km" 
                                                runat="server" 
                                                ReadOnly="true"
                                                Width="50"/>
                                            </td>
                                            <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    
                                              <ext:Label 
                                                ID="decSp2Km" 
                                                runat="server" 
                                                ReadOnly="true"
                                                Width="50"/>
                                            </td>
                                            <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    
                                              <ext:Label 
                                                ID="decPs1Km" 
                                                runat="server" 
                                                ReadOnly="true"
                                                Width="50"/>
                                            </td>
                                            <td style="border: 1px solid #000000;" align="right" colspan="1" 
                                                nowrap="nowrap">
                                    
                                              <ext:Label 
                                                ID="decPs2Km" 
                                                runat="server" 
                                                ReadOnly="true"
                                                Width="50"/>
                                            </td>
                                        </tr>
                                    </table>
                                    </Content>

                                    </ext:Panel>
                            </Items>
                        </ext:TabPanel>
						</Component>
                    <Listeners>
                        <BeforeExpand Handler="grdPrestadorgrdPrestadorBusquedaAvanzada_BeforeExpand(record.data['Id'])"/>
                    </Listeners>
                </ext:RowExpander>
                
            </Plugins>
            
            <TopBar>
                <ext:Toolbar runat="server" ID="ctl1499">
                <Items>
                    <ext:TextField runat="server" Width="300" Cls="onepx-shift" ID="txtBusquedaSimple" />
                    <ext:Toolbar runat="server" Cls="form-toolbar" Flat="true" ID="ctl1501">
                        <Items>
                            <ext:Button runat="server" Text="Buscar" Icon="Magnifier" ToolTip="Busqueda simplificada" OnDirectClick="BusquedaSimplificada_DirectClick" ID="ctl1502">
                            <Listeners>
                                <Click Handler="={Click_btnIniciarBusqueda}" />
                            </Listeners>
                            </ext:Button>

                            <ext:Button runat="server" Text="Busqueda Avanzada" Icon="keyboard" ToolTip="Filtro para busqueda avanzada de prestadores" ID="btnBusquedaAvanzada">
                                <Listeners>
                                    <Click Handler="={buscarOnClick}" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Items>
                </ext:Toolbar>
            </TopBar>
            <Listeners>
                <Command Handler="AgragarPrestadorAsignado(command, record.data.Id)" />
            </Listeners>
        </ext:GridPanel>

            
            </Content>

        </ext:Window>

        <ext:Window 
        ID="WdoInformacioPrestador" 
        runat="server" 
        Icon="information" 
        Hidden="true" 
        Width="650"
        Modal="true"
        Height="600"
        BodyStyle="background-color: #fff">
        
        <Content>
            <uc1:PrestadorView runat="server" ID="PrestadorView" />
        </Content>


        </ext:Window>
        
        
        

</asp:Content>


  