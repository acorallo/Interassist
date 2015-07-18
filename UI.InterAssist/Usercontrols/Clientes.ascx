<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Clientes.ascx.cs" Inherits="UI.InterAssist.Usercontrols.Clientes" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>

<table class="style1">
    <tr>
        <td>
            <table class="style1">
                <tr>
                    <td>
                        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="style1">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblPoliza" runat="server"></asp:Label>
                                </td>
                                <td align="left" width="100%">
                                    <asp:TextBox ID="txtPoliza" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblPatente" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPatente" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblApellido" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblNombre" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" />
                        &nbsp;<asp:Button ID="btnNuevaBusqueda" runat="server" onclick="btnNuevaBusqueda_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grwClientes" runat="server" AutoGenerateColumns="False" 
                            ondatabinding="grwClientes_DataBinding" onrowcommand="grwClientes_RowCommand" 
                            onrowdatabound="grwClientes_RowDataBound">
                            <Columns>
                                <asp:ButtonField Text="Button" />
                                <asp:BoundField />
                                <asp:BoundField />
                                <asp:BoundField />
                                <asp:BoundField />
                                <asp:BoundField />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

