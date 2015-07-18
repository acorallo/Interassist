<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Prestadorctrl.ascx.cs" Inherits="UI.InterAssist.Usercontrols.Prestadorctrl" %>
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
                    <td align="right">
                        <asp:Label ID="lblId" runat="server"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lbltxtId" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblNombre" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="LbTxtlNombre" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblCuit" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lbltxtCuit" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lbltxtDescripcion" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblEstado" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTxtEstador" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblPais" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTxtPais" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblProvincia" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lbltxtProvincia" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblCiudad" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTxtCiudad" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblLocalidad" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lbltxtLocalidad" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblDomicilio" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lbltxtDomicilio" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTxtEmail" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblNextel" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTxtNextel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblTelefono1" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lbltxtTelefono1" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblCelular1" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTxtCeluar1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblTelefono2" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lbltxtTelefono2" runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblCelular2" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblTxtCeluar2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:Label ID="lblTarifas" runat="server"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
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
                                <td style="border: 1px solid #000000;" align="right">
                                    <asp:Label ID="lblLivMovida" runat="server"></asp:Label>
                                </td>
                                <td style="border: 1px solid #000000;" align="right">
                                    <asp:Label ID="lblSp1Movida" runat="server"></asp:Label>
                                </td>
                                <td style="border: 1px solid #000000;" align="right">
                                    <asp:Label ID="lblSp2Movida" runat="server"></asp:Label>
                                </td>
                                <td style="border: 1px solid #000000;" align="right">
                                    <asp:Label ID="lblPs1Movida" runat="server"></asp:Label>
                                </td>
                                <td style="border: 1px solid #000000;" align="right">
                                    <asp:Label ID="lblps2Movida" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" 
                                    style="border-style: 1; border-width: 1px; border-color: #000000;">
                                    <asp:Label ID="lblkm" runat="server"></asp:Label>
                                </td>
                                <td style="border: 1px solid #000000;" align="right">
                                    <asp:Label ID="lblLivkm" runat="server"></asp:Label>
                                </td>
                                <td style="border: 1px solid #000000;" align="right">
                                    <asp:Label ID="lblSp1Km" runat="server"></asp:Label>
                                </td>
                                <td style="border: 1px solid #000000;" align="right">
                                    <asp:Label ID="lblSp2Km" runat="server"></asp:Label>
                                </td>
                                <td style="border: 1px solid #000000;" align="right">
                                    <asp:Label ID="lblPs1km" runat="server"></asp:Label>
                                </td>
                                <td style="border: 1px solid #000000;" align="right">
                                    <asp:Label ID="lblps2Km" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
</table>

