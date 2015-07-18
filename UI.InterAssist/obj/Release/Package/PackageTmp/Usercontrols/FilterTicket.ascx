<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterTicket.ascx.cs" Inherits="UI.InterAssist.Usercontrols.FilterTicket" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 0%;
    }
</style>

<table class="style1">
    <tr>
        <td class="style2" style="text-align: right" align="right">
            <asp:Label ID="lblTicket" runat="server"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtTicket" runat="server" MaxLength="50" Width="265px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2" align="right">
            <asp:Label ID="lblOperador" runat="server"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlOperador" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style2" align="right">
            <asp:Label ID="lblCliente" runat="server"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2" align="right">
            <asp:Label ID="lblEmpresa" runat="server"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2" align="right">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2" align="right">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>

