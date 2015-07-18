<%@ Page Title="" Language="C#" MasterPageFile="~/InterAssist.Master" AutoEventWireup="true" CodeBehind="Operadores.aspx.cs" Inherits="UI.InterAssist.Views.Operadores" %>
<%@ Register src="../Usercontrols/Operador.ascx" tagname="Operador" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="99999999"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <script language="javascript" src="../Scripts/jquery-1.10.1.min.js"></script>   
    <script language="javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript">
        $(
        function () {
            
        }
        );
    </script>
    
    

    </script>
<table width="100%">
    <tr>
        <td>
            
            <table class="style3">
                <tr>
                    <td align="right">
                        <asp:TextBox ID="txtSearch" runat="server" MaxLength="255" Width="250px"></asp:TextBox>
                        &nbsp;<asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" />
                        &nbsp;<asp:Button ID="btnFreeSeacrh" runat="server" onclick="btnFreeSeacrh_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <table class="style1">
                            <tr>
                                <div ID="divCantregistros" runat="server">
                                    <td>
                                        <asp:Label ID="lblCantRegistros" runat="server" 
                                            CssClass="LblRegistrosFiltradas"></asp:Label>
                                    </td>
                                    <td align="left" width="100%">
                                        <asp:Label ID="lbltxtCantidadRegistros" runat="server" 
                                            CssClass="LblCantRegistrosFiltradas"></asp:Label>
                                    </td>
                                </div>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:DataGrid ID="gdwOperadores" runat="server" AllowCustomPaging="True" 
                            AllowPaging="True" AutoGenerateColumns="False" CssClass="RowGrid" 
                            onitemcommand="gdwOperadores_ItemCommand" 
                            onitemdatabound="gdwOperadores_ItemDataBound" 
                            onpageindexchanged="gdwOperadores_PageIndexChanged" 
                            onselectedindexchanged="gdwOperadores_SelectedIndexChanged" PageSize="20" 
                            Width="100%">
                            <Columns>
                                <asp:BoundColumn></asp:BoundColumn>
                                <asp:BoundColumn></asp:BoundColumn>
                                <asp:BoundColumn></asp:BoundColumn>
                                <asp:BoundColumn></asp:BoundColumn>
                                <asp:BoundColumn></asp:BoundColumn>
                                <asp:BoundColumn></asp:BoundColumn>
                                <asp:BoundColumn></asp:BoundColumn>
                                <asp:ButtonColumn></asp:ButtonColumn>
                            </Columns>
                            <HeaderStyle CssClass="HeaderGrid" Font-Bold="True" Font-Italic="False" 
                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                HorizontalAlign="Center" />
                            <ItemStyle CssClass="RowGrid" />
                            <PagerStyle HorizontalAlign="Center" Mode="NumericPages" />
                        </asp:DataGrid>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblNonResults" runat="server" CssClass="SinRegistros"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnCrearNuevo" runat="server" onclick="btnCrearNuevo_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            
        </td>
    </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
