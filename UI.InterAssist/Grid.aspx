<%@ Page Language="C#" CodeBehind="Grid.aspx.cs" Inherits="UI.InterAssist.Grid" AutoEventWireup="true"%>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<%@ Register src="Usercontrols/PrestadorView.ascx" tagname="PrestadorView" tagprefix="uc1" %>
<%@ Register Src="~/Usercontrols/PrestadorView.ascx" TagPrefix="uc2" TagName="PrestadorView" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RowExpander with DirectEvent - Ext.NET Examples</title>
    <ext:ResourcePlaceHolder runat="server" Mode="Script" />
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    
    <style type="text/css">
        .template {
            color: #fff;
            background-color: gray;
        }
    </style>

       <style type="text/css">
            .search-item {
                font          : normal 11px tahoma, arial, helvetica, sans-serif;
                padding       : 3px 10px 3px 10px;
                border        : 1px solid #fff;
                border-bottom : 1px solid #eeeeee;
                white-space   : normal;
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

    <script type="text/javascript">



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


        var buscarOnClick = function ()
        {
            FiltroBuscaPrestadores.setVisible(!FiltroBuscaPrestadores.isVisible());
        }


        var LimpiarFiltroPrestador = function ()
        {
            txtPais.text = "";
        }


        function TestWs()
        {
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

        function BeforQuery_cmbUbicacionFiltroPrestador()
        {
            var idPais = "-1";
            var idProvincia = "-1";

            if (cmbPaisFiltroPrestador.value)
                idPais = cmbPaisFiltroPrestador.value;

            if (cmbProvinciaFiltroPrestador.value)
                idProvincia = cmbProvinciaFiltroPrestador.value;

            StoreUbicacionesFiltroPrestador.setBaseParam("paramIdProvincia", idProvincia);
            StoreUbicacionesFiltroPrestador.setBaseParam("paramIdPais", idPais);

        }

        function btnEliminarFiltroPrestador()
        {
            cmbProvinciaFiltroPrestador.clear();
            cmbUbicacionFiltroPrestador.clear();
            txtNombreFiltroPrestador.clear();

        }

        function Click_btnIniciarBusqueda()
        {
            grdPrestadorBusquedaAvanzada.loadMask.show();
        }

        function grdPrestadorgrdPrestadorBusquedaAvanzada_BeforeExpand(value)
        {
            if (!Ext.isEmpty(value))
            {
                var expandedPrestador = StorePrestadoresBusquedaAvanzada.getById(value);
                if(expandedPrestador)
                {
                    setPrestadorInControls(expandedPrestador.data);
                }
                
            }
        }

    function setPrestadorInControls(Prestador)
    {

        var strTitulo = Prestador.Nombre;
        quickPrestador_Titulo.setText(strTitulo);
        QPrest_Detalles_Activo.setValue(Prestador.Activo);
        QPrest_Detalles_Id.setValue(Prestador.Id);
        QPrest_Detalles_iva.setValue(Prestador.Iva);
        QPrest_Detalles_Cuit.setValue(Prestador.Cuit);
    }


        
    Ext.onReady(function() {
        FiltroBuscaPrestadores.hide();
    });
        

  </script>        
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />

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
        

        
        
    <ext:FormPanel runat="server" Width="1200" Title="Busqueda Avanzada" Padding="5" MonitorResize="true" ID="FiltroBuscaPrestadores">
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
   
        </br>

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

        <ext:GridPanel 
            ID="grdPrestadorBusquedaAvanzada" 
            runat="server" 
            StoreID="StorePrestadoresBusquedaAvanzada" 
            TrackMouseOver="true"
            Title="Prestadores"  
            Icon="Table" 
            Width="1200" 
            Height="300">
            <LoadMask ShowMask="true" />
            <ColumnModel runat="server" ID="ctl1486">
                <Columns>
                    <ext:Column Header="ID" DataIndex="Id" />
                    <ext:Column Header="Nombre" DataIndex="Nombre" />
                    <ext:Column Header="Pais" DataIndex="Pais" />
                    <ext:Column Header="Provincia" DataIndex="Provincia" />
                    <ext:Column Header="Localidad" DataIndex="Localidad" />
                    <ext:Column Header="Ciudad" DataIndex="Ciudad" />
                    <ext:CommandColumn Width="11">
                        <Commands>
                            <ext:GridCommand Icon="Add" CommandName="Delete" StandOut="true">
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
                        Width="800" 
                        Height="150" 
                        Plain="true"
                        ClientIDMode="Static">
                            <Items>
                                <ext:Panel 
                                    ID="Tab1" 
                                    runat="server" 
                                    Title="Información" 
                                    Padding="6" 
                                    AutoScroll="true" 
                                    LabelAlign="Top"
                                    >
                                    
                                    <Content>
                                        <table>
                                            <tr>
                                                <td><h2>
                                                    <ext:Label runat="server" Text="Hello World" id="quickPrestador_Titulo"/>
                                                    </h2>
                                                </td>
                                            </tr>
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
                                                        Width="300"/>
                                                
                                                    <ext:TextField 
                                                        ID="QPrest_Detalles_iva" 
                                                        runat="server" 
                                                        ReadOnly="true"
                                                        Width="300"/>

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
                                    Html="My content was added with the Html Property."
                                    Padding="6" 
                                    AutoScroll="true" 
                                    />
                            </Items>
            
                            <Items>
                                <ext:Panel 
                                    ID="Contactos" 
                                    runat="server" 
                                    Title="Contactos" 
                                    Html="My content was added with the Html Property."
                                    Padding="6" 
                                    AutoScroll="true" 
                                    />
                            </Items>
                            <Items>
                                <ext:Panel 
                                    ID="Panel2" 
                                    runat="server" 
                                    Title="Descripción" 
                                    Html="My content was added with the Html Property."
                                    Padding="6" 
                                    AutoScroll="true" 
                                    />
                            </Items>
                            <Items>
                                <ext:Panel 
                                    ID="Panel1" 
                                    runat="server" 
                                    Title="Tarifas" 
                                    Html="My content was added with the Html Property."
                                    Padding="6" 
                                    AutoScroll="true" 
                                    />
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
        </ext:GridPanel>

        <br />
        <br />
        




    </form>
</body>
</html>