<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AfiliadoDetalle.ascx.cs" Inherits="UI.InterAssist.Usercontrols.AfiliadoDetallo" %>
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
                        <table class="style1">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblId" runat="server"></asp:Label>
                                </td>
                                <td align="left" width="100%">
                                    <asp:Label ID="lbltxtId" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td Class="Seccion">
                        <asp:Label ID="lblDatosPersonales" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="style1">
                            <tr>
                                <td align="right" colspan="1">
                                    <asp:Label ID="lblDocumento" runat="server"></asp:Label>
                                </td>
                                <td align="left" colspan="3" width="100%">
                                    <asp:Label ID="lblTxtDocumento" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblNombre" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbltxtNombre" runat="server"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblDireccion" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lbltxtDireccion" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblApellido" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lbltxtApellido" runat="server"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblCodigoPostal" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lbltxtCodigoPostal" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td Class="Seccion">
                        <asp:Label ID="lblDatosPoliza" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="style1">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEmpresa" runat="server"></asp:Label>
                                </td>
                                <td align="left" width="50%">
                                    <asp:Label ID="lbltxtEmpresa" runat="server"></asp:Label>
                                </td>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblFechaDesde" runat="server"></asp:Label>
                                </td>
                                <td align="left" width="50%">
                                    <asp:Label ID="lbltxtFechaDesde" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td abbr="lbltxtFechaDesde" align="right" nowrap="nowrap">
                                    <asp:Label ID="lblPoliza" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lbltxtPoliza" runat="server"></asp:Label>
                                </td>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblFechaHasta" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lbltxtFechaHasta" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td abbr="lbltxtFechaDesde" align="right" nowrap="nowrap">
                                    <asp:Label ID="lblHogar" runat="server"></asp:Label>
                                </td>
                                <td align="left" style="margin-left: 40px">
                                    <asp:Label ID="lblTxtHogar" runat="server"></asp:Label>
                                </td>
                                <td align="right" nowrap="nowrap">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td Class="Seccion">
                        <asp:Label ID="lblDatosVehiculo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="style1">
                            <tr>
                                <td align="right">
                                    &nbsp;</td>
                                <td colspan="3" width="100%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblPatente" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbltxtPatente" runat="server"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblMarca" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lbltxtMarca" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblCategoria" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbltxtCategoria" runat="server"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblModelo" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblTxtModelo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblAño" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbltxtaño" runat="server"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblColor" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lbltxtColor" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

