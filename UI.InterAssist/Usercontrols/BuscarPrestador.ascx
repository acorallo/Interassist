<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BuscarPrestador.ascx.cs" Inherits="UI.InterAssist.Usercontrols.BuscarPrestador" %>
<script type="text/javascript" src="../Scripts/BuscarPrestador.js"></script>
<link rel="stylesheet" href="../fonts/style.css" />
<style type="text/css">

    .auto-style1 {
        width: 100%;
    }

    .search-icon
    {  
        font-size: 20px;
        margin-left: 10px;
        cursor: pointer;
    }


</style>


<input type="hidden" id="BuscarPrestador_idPrestador" name ="BuscarPrestador_idPrestador" value=""/>
<table class="auto-style1">
    <tr>
        <td>
            <asp:TextBox ID="txtNombrePrestadorCaso" runat="server" ReadOnly="True" Width="400px" ClientIDMode="Static"></asp:TextBox>
            <span onclick="javascript:showPopBuscarPrestador();" class="icon-magnifying-glass search-icon"></span>
        </td>
    </tr>
</table>

    <div style="display:none">
         <div id="DivBusquedaPrestador" title="Buscar Prestador">
              <div style="font-size:12px">
            <table>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblPresadorPais" runat="server"></asp:Label>
                    </td>
                    <td width="100%" align="left">
                        <select id="ddlPrestadorPais" name="D1" style="width: 300px">
                            <option></option>
                        </select></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblPrestadorProvincia" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <select id="ddlPrestadorProvincia" name="D2" style="width: 300px">
                            <option></option>
                        </select></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblPrestadorCiudad" runat="server"></asp:Label>
                    </td>
                    <td align="left" class="auto-style1">
                        <input id="txtPrestadorCiudad" type="text" style="width: 300px" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblPrestadorNombre" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <input id="txtPrestadorNombre" style="width: 300px" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">

             
                        &nbsp;&nbsp;<input id="btnBuscarPrestador" type="button" value="Buscar" />
                        <input id="btnLimpiarBusqueda" type="button" value="Limpiar" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">

                        <table width="100%">
                            <tr id="trListadoPrestadores" style="visibility:hidden">

                                <td>
                                     <table id="demoTable" style="border: 1px solid #ccc;" cellspacing="0" width="100%">
                                                <thead>
                                                        <tr>
                                                                <th sort="id" class="auto-style2">Id</th>
                                                                <th sort="nombre" class="auto-style2">Nombre</th>
                                                                <th sort="pais" class="auto-style2">Pais</th>
                                                                <th sort="provincia" class="auto-style2">Provincia</th>
                                                                <th sort="localidad" class="auto-style2">Localidad</th>
                                                                <th sort="domicilio" class="auto-style2">Domicilio</th>
                                                                <th sort="telefono" class="auto-style2">Telefono</th>
                                                                <th class="auto-style2">Detalles</th>
                                                               

                                                        </tr>
                                                </thead>
                                                <tbody>


                                                </tbody>
                                                <tfoot class="nav">
                                                        <tr>
                                                                <td colspan=8>
                                                                        <div class="pagination"></div>
                                                                        <div class="paginationTitle">Page</div>
                                                                        <div class="selectPerPage"></div>
                                                                        <div class="status"></div>
                                                                </td>
                                                        </tr>
                                                </tfoot>
                                        </table>



                                </td>
                            
                            </tr>

                           
                                <tr id="trLabelPrestador"><td align="left" class="auto-style1">
                                        <asp:Label ID="lblNonResult" runat="server"></asp:Label>
                                        </td>
                                </tr>
                        
                            </table>

                     

                     </td>
               </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                </table>
             </div>
         </div>

        </div>
      