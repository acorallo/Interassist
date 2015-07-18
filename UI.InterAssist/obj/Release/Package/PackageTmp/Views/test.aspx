<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="UI.InterAssist.Views.test" %>

<%@ Register src="../Usercontrols/UbicacionPredictivo.ascx" tagname="UbicacionPredictivo" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="99999999"></asp:ScriptManager>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
            <asp:ListItem>Valor 1</asp:ListItem>
            <asp:ListItem>Valor 2</asp:ListItem>
            <asp:ListItem>Valor 3</asp:ListItem>
            <asp:ListItem>Valor 4</asp:ListItem>
        </asp:DropDownList>
        <uc1:UbicacionPredictivo ID="UbicacionPredictivo1" runat="server" />
        <uc1:UbicacionPredictivo ID="UbicacionPredictivo2" runat="server" />
        <br />
    </div>
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    </form>
</body>
</html>
