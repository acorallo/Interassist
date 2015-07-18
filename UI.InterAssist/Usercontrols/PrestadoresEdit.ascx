<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestadoresEdit.ascx.cs" Inherits="UI.InterAssist.Usercontrols.PrestadoresEdit" %>
<%@ Register src="DecimalControl.ascx" tagname="DecimalControl" tagprefix="uc1" %>
<%@ Register src="UbicacionPredictivo.ascx" tagname="UbicacionPredictivo" tagprefix="uc2" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        height: 14px;
    }
</style>

<link href="../Estilos/InterAssist.css" rel="stylesheet" type="text/css" />
<script src="../Scripts/InterAssistUI.js" type="text/javascript"></script>
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
                    <td colspan="3">
                        <asp:Label ID="lbltxtId" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblNombre" runat="server"></asp:Label>
                    </td>
                    <td align="left" nowrap="nowrap" colspan="3">
                        <asp:TextBox ID="txtNombre" runat="server" Width="250px" MaxLength="1024"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" 
                            ControlToValidate="txtNombre" CssClass="errorText" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblCuit" runat="server"></asp:Label>
                    </td>
                    <td align="left" nowrap="nowrap">
                        <asp:TextBox ID="txtCuit" runat="server" Width="250px" MaxLength="50"></asp:TextBox>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblIva" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlIva" runat="server" Width="250px">
                        </asp:DropDownList>
                        <asp:CustomValidator ID="cmvIva" runat="server" 
                            ClientValidationFunction="validateCombo" ControlToValidate="ddlIva" 
                            CssClass="errorText" Display="Dynamic">*</asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblPais" runat="server"></asp:Label>
                    </td>
                    <td align="left" nowrap="nowrap">
                        <asp:DropDownList ID="ddlPais" runat="server" Width="250px" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:CustomValidator ID="cmvPais" runat="server" 
                            ClientValidationFunction="validateCombo" ControlToValidate="ddlPais" 
                            CssClass="errorText" Display="Dynamic">*</asp:CustomValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblEstado" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkActivo" runat="server" Checked="True" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style2">
                        <asp:Label ID="lblUbicacion" runat="server"></asp:Label>
                    </td>
                    <td align="left" nowrap="nowrap" colspan="3">
                        <uc2:UbicacionPredictivo ID="UbicacionPredictivo1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style2">
                        <asp:Label ID="lblDomicilio" runat="server"></asp:Label>
                    </td>
                    <td align="left" nowrap="nowrap" colspan="3">
                        <asp:TextBox ID="txtDomicio" runat="server" Width="600px" MaxLength="1024"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </td>
                    <td align="left" nowrap="nowrap">
                        <asp:TextBox ID="txtEmail" runat="server" Width="250px" MaxLength="255"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                            ControlToValidate="txtEmail" CssClass="errorText" Display="Dynamic" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblNextel" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNextel" runat="server" Width="250px" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblTelefono1" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtTelefono1" runat="server" Width="250px" MaxLength="50"></asp:TextBox>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblCelular1" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCelular1" runat="server" Width="250px" MaxLength="60"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblTelefono2" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtTelefono2" runat="server" Width="250px" MaxLength="50"></asp:TextBox>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblCelular2" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCelular2" runat="server" Width="250px" MaxLength="60"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtDescripcion" runat="server" Width="453px" Height="52px" 
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
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
                                <td style="border: 1px solid #000000; margin-left: 80px;" align="right" 
                                    nowrap="nowrap">
                                    <uc1:DecimalControl ID="decLivMovida" runat="server" />
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    <uc1:DecimalControl ID="decSp1Movida" runat="server" />
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    <uc1:DecimalControl ID="decSp2Movida" runat="server" />
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    <uc1:DecimalControl ID="decPs1Movida" runat="server" />
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    <uc1:DecimalControl ID="decPs2Movida" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" 
                                    style="border-style: 1; border-width: 1px; border-color: #000000;">
                                    <asp:Label ID="lblkm" runat="server"></asp:Label>
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    <uc1:DecimalControl ID="decLivKm" runat="server" />
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    <uc1:DecimalControl ID="decSp1Km" runat="server" />
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    <uc1:DecimalControl ID="decSp2Km" runat="server" />
                                </td>
                                <td style="border: 1px solid #000000;" align="right" nowrap="nowrap">
                                    <uc1:DecimalControl ID="decPs1Km" runat="server" />
                                </td>
                                <td style="border: 1px solid #000000;" align="right" colspan="1" 
                                    nowrap="nowrap">
                                    <uc1:DecimalControl ID="decPs2Km" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="left" colspan="3">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                            CssClass="errorSummaryText" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="center" colspan="3">
                        <asp:Button ID="btnAceptar" runat="server" onclick="btnAceptar_Click" />
&nbsp;<asp:Button ID="btnCancelar" runat="server" CausesValidation="False" 
                            onclick="btnCancelar_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

        </td>
    </tr>
</table>

