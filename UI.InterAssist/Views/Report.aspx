<%@ Page Title="" Language="C#" MasterPageFile="~/InterAssist.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="UI.InterAssist.Views.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript" src="../Scripts/jquery-1.10.1.min.js"></script> 
<script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
<script src="../Scripts/InterAssistUI.js" type="text/javascript"></script>
<link href="../Estilos/InterAssist.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="../jquery-ui-1.11.1/jquery-ui.css">


<script type="text/javascript">

    $(document).ready(on_loadPage);
    function on_loadPage() {

        InicializaControles();



    }

    function InicializaControles() {
        $(function () {
            $("#txtFechaDesde").datepicker({ dateFormat: "dd/mm/yy" });
        });


        $(function () {
            $("#txtFechaHasta").datepicker({ dateFormat: "dd/mm/yy" });
        });
    }



</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td nowrap="nowrap">
                            <asp:Label ID="lblFechaDesde" runat="server"></asp:Label>
                        </td>
                        <td align="left" width="100%">
                            <asp:TextBox ID="txtFechaDesde" runat="server" ClientIDMode="Static"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFechaDesde" runat="server" ControlToValidate="txtFechaDesde" CssClass="errorText">*</asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cmvFechaDesde" runat="server" ControlToValidate="txtFechaDesde" CssClass="errorText" OnServerValidate="cmvFechaDesde_ServerValidate">*</asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" nowrap="nowrap">
                            <asp:Label ID="lblFechaHasta" runat="server"></asp:Label>
                        </td>
                        <td align="left" class="auto-style1">
                            <asp:TextBox ID="txtFechaHasta" runat="server" ClientIDMode="Static"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFechaHasta" runat="server" ControlToValidate="txtFechaHasta" CssClass="errorText">*</asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cmvFechaHasta" runat="server" ControlToValidate="txtFechaHasta" CssClass="errorText" OnServerValidate="cmvFechaHasta_ServerValidate">*</asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap">&nbsp;</td>
                        <td align="left">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="errorText" />
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap">&nbsp;</td>
                        <td>
                            <asp:Button ID="btnGenerarReporte" runat="server" OnClick="btnGenerarReporte_Click" />
                            <asp:CustomValidator ID="cmvRerport" runat="server" CssClass="errorText">*</asp:CustomValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
