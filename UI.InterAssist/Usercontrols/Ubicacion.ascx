<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ubicacion.ascx.cs" Inherits="UI.InterAssist.Usercontrols.Ubicacion" %>
<%@ Register src="UbicacionPredictivo.ascx" tagname="UbicacionPredictivo" tagprefix="uc1" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>
<link href="../Estilos/InterAssist.css" rel="stylesheet" type="text/css" />
<script src="../Scripts/InterAssistUI.js" type="text/javascript"></script>
<table class="style1">
    <tr>
        <td>
            <table class="style1">
                <tr>
                    <td align="right" valign="top">
                        <asp:Label ID="lblDireccion" runat="server"></asp:Label>
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtDireccion" runat="server" TextMode="MultiLine" 
                            Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" 
                            ControlToValidate="txtDireccion" CssClass="errorText">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblUbicacion" runat="server"></asp:Label>
                    </td>
                    <td align="left" width="100%">
                        <uc1:UbicacionPredictivo ID="ubicacionPredict" runat="server" 
                            ClientIDMode="Predictable" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:Label ID="lblPais" runat="server"></asp:Label>
                    </td>
                    <td align="left" valign="top">
                        <asp:DropDownList ID="ddlPais" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlPais_SelectedIndexChanged" Width="300px">
                        </asp:DropDownList>
                        <asp:CustomValidator ID="cmvPais" runat="server" ControlToValidate="ddlPais" 
                            ClientValidationFunction="validateCombo" CssClass="errorText">*</asp:CustomValidator>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

