<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AfiliadoCtrl.ascx.cs" Inherits="UI.InterAssist.Usercontrols.AfiliadoCtrl" %>

<script language="javascript" src="../Scripts/jquery-1.10.1.min.js"></script>   
<script language="javascript" src="../Scripts/jquery-ui.js"></script>
<script src="../Scripts/InterAssistUI.js" type="text/javascript"></script>
<script src="../Scripts/AfiliadoCtrl.js" type="text/javascript"></script>
<link href="../Estilos/InterAssist.css" rel="stylesheet" type="text/css" />
<asp:Literal ID="ltrIdFechaDesde" runat="server"></asp:Literal>
<asp:Literal ID="ltrIdFechaHasta" runat="server"></asp:Literal>

<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        height: 23px;
    }
</style>

<table class="style1">
    <tr>
        <td>
            <table class="style1">
                <tr>
                    <td>
                        <table class="style1" runat="server" id="tableId">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblID" runat="server"></asp:Label>
                                </td>
                                <td width="100%" align="left">
                                    <asp:Label ID="lbltxtID" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <table class="style1">
                            <tr>
                                <td align="left" colspan="2" nowrap="nowrap" Class="Seccion">
                                    <asp:Label ID="lblSeccionPersonal" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblDocumento" runat="server"></asp:Label>
                                </td>
                                <td width="100%" align="left">
                                    <asp:TextBox ID="txtDocumento" runat="server" Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblNombre" runat="server"></asp:Label>
                                </td>
                                <td width="100%" align="left">
                                    <asp:TextBox ID="txtNombre" runat="server" Width="250px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" 
                                        ControlToValidate="txtNombre" ValidationGroup="vgAfiliadoCtrl" 
                                        CssClass="errorText">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblApellido" runat="server"></asp:Label>
                                </td>
                                <td width="100%" align="left">
                                    <asp:TextBox ID="txtApellido" runat="server" Width="250px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" 
                                        ValidationGroup="vgAfiliadoCtrl" ControlToValidate="txtApellido" 
                                        CssClass="errorText">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblDireccion" runat="server"></asp:Label>
                                </td>
                                <td width="100%" align="left">
                                    <asp:TextBox ID="txtDireccion" runat="server" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblCodigoPostal" runat="server"></asp:Label>
                                </td>
                                <td width="100%" align="left">
                                    <asp:TextBox ID="txtCodigoPostal" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" nowrap="nowrap" Class="Seccion">
                                    <asp:Label ID="lblSeccionPoliza" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblEmpresa" runat="server"></asp:Label>
                                </td>
                                <td width="100%" align="left">
                                    <asp:DropDownList ID="ddlEmpresa" runat="server" Width="250px">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cmvEmpresa" runat="server" 
                                        ControlToValidate="ddlEmpresa" ValidationGroup="vgAfiliadoCtrl" 
                                        CssClass="errorText" onservervalidate="cmvEmpresa_ServerValidate" 
                                        ClientValidationFunction="validateCombo">*</asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblPoliza" runat="server"></asp:Label>
                                </td>
                                <td width="100%" align="left">
                                    <asp:TextBox ID="txtPoliza" runat="server"></asp:TextBox>
                                    <asp:CustomValidator ID="cmvPolizaExiste" runat="server" ControlToValidate="txtPoliza" CssClass="errorText" OnServerValidate="cmvPolizaExiste_ServerValidate" ValidationGroup="vgAfiliadoCtrl">*</asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblFechaDesde" runat="server"></asp:Label>
                                </td>
                                <td width="100%" align="left">
                                    <asp:TextBox ID="txtFechaDesde" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblFechaaHasta" runat="server"></asp:Label>
                                </td>
                                <td width="100%" align="left">
                                    <asp:TextBox ID="txtFechaHasta" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                                </td>
                                <td width="100%" align="left">
                                    <asp:CheckBox ID="chkEstado" runat="server" Checked="True" Text="Activo" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    &nbsp;</td>
                                <td width="100%" align="left">
                                    <asp:CheckBox ID="chkHogar" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" Class="Seccion">
                                    <asp:Label ID="lblSeccionVehiculo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblCategoria" runat="server"></asp:Label>
                                </td>
                                <td width="100%" align="left">
                                    <asp:DropDownList ID="ddlCategoria" runat="server" Width="250px">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cmvCategorias" runat="server" 
                                        ClientValidationFunction="validateCombo" ControlToValidate="ddlCategoria" 
                                        CssClass="errorText" ErrorMessage="CustomValidator" 
                                        onservervalidate="cmvCategorias_ServerValidate" 
                                        ValidationGroup="vgAfiliadoCtrl">*</asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblPatente" runat="server"></asp:Label>
                                </td>
                                <td width="100%" align="left">
                                    <asp:TextBox ID="txtPatente" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPatente" runat="server" 
                                        ControlToValidate="txtPatente" CssClass="errorText" 
                                        ValidationGroup="vgAfiliadoCtrl">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblMarca" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMarca" runat="server" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblModelo" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtModelo" runat="server" MaxLength="254" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" nowrap="nowrap">
                                    <asp:Label ID="lblAño" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtAno" runat="server" MaxLength="4"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revAño" runat="server" 
                                        ControlToValidate="txtAno" ValidationGroup="vgAfiliadoCtrl" 
                                        CssClass="errorText" ValidationExpression="\d{4}">*</asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2" align="right" nowrap="nowrap">
                                    <asp:Label ID="lblColor" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                </td>
                </tr>
                <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td align="left">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                    ValidationGroup="vgAfiliadoCtrl" CssClass="errorSummaryText" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnAceptar" runat="server" onclick="btnAceptar_Click" 
                                    ValidationGroup="vgAfiliadoCtrl" />
&nbsp;<asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </td>
                </tr>

            </table>
        </td>
    </tr>
</table>

