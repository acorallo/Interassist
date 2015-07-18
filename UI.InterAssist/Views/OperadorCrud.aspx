    <%@ Page Title="" Language="C#" MasterPageFile="~/InterAssist.Master" AutoEventWireup="true" CodeBehind="OperadorCrud.aspx.cs" Inherits="UI.InterAssist.Views.OperadorCrud" %>
<%@ Register src="../Usercontrols/Operador.ascx" tagname="Operador" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="99999999"></asp:ScriptManager>
    <table class="style1">
        <tr>
            <td>
                <uc1:Operador ID="Operador1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
