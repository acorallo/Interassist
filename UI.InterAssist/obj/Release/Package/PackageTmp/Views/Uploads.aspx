<%@ Page Title="" Language="C#" MasterPageFile="~/InterAssist.Master" AutoEventWireup="true" CodeBehind="Uploads.aspx.cs" Inherits="UI.InterAssist.Views.Uploads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="99999999"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table class="style1">
        <tr>
            <td class="style3" align="left">
                        <asp:HyperLink ID="lnkHuerfanos" runat="server">[lnkHuerfanos]</asp:HyperLink>
                    </td>
        </tr>
        <tr>
            <td align="right" class="style3">
                <asp:TextBox ID="txtSearch" runat="server" MaxLength="255" Width="250px"></asp:TextBox>
                &nbsp;<asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" />
                &nbsp;<asp:Button ID="btnFreeSeacrh" runat="server" onclick="btnFreeSeacrh_Click" />
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
                <asp:DataGrid ID="dtgUploads" runat="server" AllowCustomPaging="True" 
                    AllowPaging="True" AutoGenerateColumns="False" 
                    onitemdatabound="dtgUploads_ItemDataBound" 
                    onpageindexchanged="dtgUploads_PageIndexChanged" 
                    onselectedindexchanged="dtgUploads_SelectedIndexChanged" PageSize="20" 
                    Width="100%" CssClass="RowGrid" OnItemCommand="dtgUploads_ItemCommand">
                    <Columns>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:ButtonColumn></asp:ButtonColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
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
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
