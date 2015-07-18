<%@ Page Title="" Language="C#" MasterPageFile="~/InterAssist.Master" AutoEventWireup="true" CodeBehind="Afiliados.aspx.cs" Inherits="UI.InterAssist.Views.Afiliados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            height: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="99999999"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table class="style1">
        <tr>
            <td class="style3" align="right">
                        <asp:TextBox ID="txtSearch" runat="server" MaxLength="255" 
                    Width="250px"></asp:TextBox>
                        &nbsp;<asp:Button ID="btnBuscar" runat="server" 
                    onclick="btnBuscar_Click" />
                        &nbsp;<asp:Button ID="btnFreeSeacrh" runat="server" 
                            onclick="btnFreeSeacrh_Click" />
                    </td>
        </tr>
        <tr>
            <td align="left">
                <table class="style1">
                    <tr>
                        <div id="divCantregistros" runat="server">
                        <td>
                            <asp:Label ID="lblCantRegistros" runat="server" 
                                CssClass="LblRegistrosFiltradas"></asp:Label>
                        </td>
                        <td width="100%">
                            <asp:Label ID="lbltxtCantidadRegistros" runat="server" 
                                CssClass="LblCantRegistrosFiltradas"></asp:Label>
                        </td>
                        </div>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <div id="divGrid" runat="server">
            <td>
                <asp:DataGrid ID="dtgAfiliados" runat="server" AllowCustomPaging="True" 
                    AllowPaging="True" AutoGenerateColumns="False" 
                    onitemcommand="dtgAfiliados_ItemCommand" 
                    onitemdatabound="dtgAfiliados_ItemDataBound" 
                    onpageindexchanged="dtgAfiliados_PageIndexChanged" 
                    onselectedindexchanged="dtgAfiliados_SelectedIndexChanged" PageSize="20" 
                    Width="100%" CssClass="RowGrid">
                    <Columns>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:ButtonColumn></asp:ButtonColumn>
                        <asp:ButtonColumn></asp:ButtonColumn>
                    </Columns>
                    <HeaderStyle CssClass="HeaderGrid" Font-Bold="True" Font-Italic="False" 
                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                        HorizontalAlign="Center" />
                    <ItemStyle CssClass="RowGrid" />
                    <PagerStyle HorizontalAlign="Center" Mode="NumericPages" />
                </asp:DataGrid>
            </td>
            </div>
        </tr>
        <tr><div id="divNonResult" runat="server" visible="false">
            <td align="left">
                <asp:Label ID="lblNonResults" runat="server" Class="SinRegistros"></asp:Label>
            </td></div>
        </tr>
        <tr>
            <td>&nbsp; &nbsp;</td></tr>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnCrearNUevo" runat="server" onclick="btnCrearNUevo_Click" />
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
