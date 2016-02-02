<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DecimalControl.ascx.cs" Inherits="UI.InterAssist.Usercontrols.DecimalControl" %>

<link href="../Estilos/InterAssist.css" rel="stylesheet" type="text/css" />
<script src="../Scripts/InterAssistUI.js" type="text/javascript"></script>
<table>
    <tr>
        <td>
            <asp:TextBox ID="txtInteger" runat="server" Width="40px" CssClass="floatEntero" ClientIDMode="Predictable"></asp:TextBox>
            <asp:Label ID="lblDecimaSeparator" runat="server"></asp:Label>
            <asp:TextBox ID="txtDecimal" runat="server" Width="20px" CssClass="floatDecima" ClientIDMode="Predictable"></asp:TextBox>
        </td>
    </tr>
</table>

